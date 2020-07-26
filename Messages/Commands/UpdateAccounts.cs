using System;
using System.Collections.Generic;
using System.Text;

namespace Messages.Commands
{
    public class UpdateAccounts
    {
        public Guid TransactionId { get; set; }
        public Guid FromAccountId { get; set; }
        public Guid ToAccountId { get; set; }
        public int Amount { get; set; }
    }
}
