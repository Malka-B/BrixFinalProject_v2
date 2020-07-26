using System;
using System.Collections.Generic;
using System.Text;

namespace Transaction.Data.Entities
{
    public enum eStatus { proccessing, success, fail};
    public class TransactionEntity
    {
        public Guid Id { get; set; }
        public Guid FromAccountId { get; set; }
        public Guid ToAccountId { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public eStatus Status { get; set; }
        public string FailureReason { get; set; }
    }
}
