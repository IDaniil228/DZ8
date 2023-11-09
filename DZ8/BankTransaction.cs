using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ8
{
    internal class BankTransaction
    {
        private readonly DateTime date;
        private readonly double amount;
        public BankTransaction(double amount)
        {
            this.amount = amount;
            date = DateTime.Now;
        }
        public DateTime Date
        {
            get { return date; }
        }
        public double Amount
        {
            get { return amount; }
        }
    }
}
