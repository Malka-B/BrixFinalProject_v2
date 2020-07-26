﻿using Account.Data;
using Account.NSB.Data;
using Account.NSB.Service;
using Account.NSB.Service.Interfaces;
using Account.WebApi.Profiles;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NServiceBus;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

namespace Account.NSB
{
    class Program
    {
        static async Task Main()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            Console.Title = GetQueue("queueName");
            var endpointConfiguration = new EndpointConfiguration(GetQueue("queueName"));

            var containerSettings = endpointConfiguration.UseContainer(new DefaultServiceProviderFactory());            
            containerSettings.ServiceCollection.AddScoped<IAccountNSBService, AccountNSBService>();
            containerSettings.ServiceCollection.AddScoped<IAccountNSBRepository, AccountNSBRepository>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AccountProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            containerSettings.ServiceCollection.AddSingleton(mapper);

            containerSettings.ServiceCollection.AddDbContext<AccountContext>(
                  options => options.UseSqlServer(configuration.GetConnectionString("FinalProject_Account")));

            endpointConfiguration.EnableOutbox();
            endpointConfiguration.EnableInstallers();

            var connection = configuration.GetConnectionString("AccountOutBox");

            var persistence = endpointConfiguration.UsePersistence<SqlPersistence>();

            persistence.SqlDialect<SqlDialect.MsSqlServer>();
            persistence.ConnectionBuilder(
                connectionBuilder: () =>
                {
                    return new SqlConnection(connection);
                });

            var subscription = persistence.SubscriptionSettings();
            subscription.CacheFor(TimeSpan.FromMinutes(1));

            var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
            transport.UseConventionalRoutingTopology();
            transport.ConnectionString(configuration.GetConnectionString("RabbitMQ"));
            
            var recoverability = endpointConfiguration.Recoverability();           
            recoverability.Immediate(
                immediate =>
                {
                    immediate.NumberOfRetries(3);
                });
            recoverability.Delayed(
                delayed =>
                {
                    var retries = delayed.NumberOfRetries(3);
                    retries.TimeIncrease(TimeSpan.FromSeconds(2));
                });

            endpointConfiguration.SendFailedMessagesTo(GetQueue("errorQueue"));
            endpointConfiguration.AuditProcessedMessagesTo(GetQueue("auditQueue"));           

            var conventions = endpointConfiguration.Conventions();
            conventions.DefiningCommandsAs(type => type.Namespace == "Messages.Commands");
            conventions.DefiningEventsAs(type => type.Namespace == "Messages.Events");


            var endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();

            await endpointInstance.Stop()
                .ConfigureAwait(false);

            string GetQueue(string queueName)
            {
                return configuration.GetSection("Queues").GetSection(queueName).Value;
            }           
        }
    }
}
