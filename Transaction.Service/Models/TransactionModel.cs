using System;
using System.Collections.Generic;
using System.Text;

namespace Transaction.Service.Models
{
    public class TransactionModel
    {
        public Guid Id { get; set; }
        public Guid FromAccountId { get; set; }
        public Guid ToAccountId { get; set; }
        public int Amount { get; set; }
        public string FailureReason { get; set; }
    }
}
