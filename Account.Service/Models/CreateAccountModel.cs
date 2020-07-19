using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Service.Models
{
    public class CreateAccountModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Passowrd { get; set; }
    }
}
