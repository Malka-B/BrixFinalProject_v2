﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Messages.Events
{
    public class AccountsUpdated
    {
        public Guid TransactionId { get; set; }
        public bool isAccountsUpdateSuccess { get; set; }
    }
}
