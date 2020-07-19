using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.WebApi.DTO
{
    public class AccountDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime OpenDate { get; set; }
        public float Balance { get; set; }
    }
}
