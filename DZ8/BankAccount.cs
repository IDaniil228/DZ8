using System;
using System.Collections.Generic;
using System.IO;

namespace DZ8
{
    public enum Account { Текущий, Сберегательный }
    public class BankAccount
    {
        private static int numbOfAccount;
        private double balance;
        private Account accountType;
        private Queue<BankTransaction> typeOfBankTransaction = new Queue<BankTransaction>();

        public BankAccount(double balance)
        {
            numbOfAccount = SetNumbOfAccount();
            this.balance = balance;
        }
        public BankAccount(Account type)
        {
            numbOfAccount = SetNumbOfAccount();
            accountType = type;
        }
        public BankAccount(double balance, Account type)
        {
            numbOfAccount = SetNumbOfAccount();
            accountType = type;
            this.balance = balance;
        }
        public double Balance
        {
            get
            {
                return balance;
            }
        }
        /// <summary>
        /// Генерирует номер счета
        /// </summary>
        /// <returns></returns>
        public int SetNumbOfAccount()
        {
            return numbOfAccount++;
        }
        /// <summary>
        /// возвращает номер счета 
        /// </summary>
        /// <returns></returns>
        public int GetNumber()
        {
            return numbOfAccount;
        }
        /// <summary>
        /// возвращает тип счета
        /// </summary>
        /// <returns></returns>
        public string GetAccountType()
        {
            return accountType.ToString();
        }
        /// <summary>
        /// Положить деньги на баланс
        /// </summary>
        /// <param name="balance"></param>
        /// <returns></returns>
        public double AddBalince(double balance)
        {
            BankTransaction transaction = new BankTransaction(balance);
            typeOfBankTransaction.Enqueue(transaction);
            this.balance += balance;
            return balance;
        }
        /// <summary>
        /// Снять средства с баланса
        /// </summary>
        /// <param name="balance"></param>
        /// <returns></returns>
        public double WithdrawFromBalance(double balance)
        {
            if (balance <= this.balance)
            {
                BankTransaction transaction = new BankTransaction(balance);
                typeOfBankTransaction.Enqueue(transaction);
                this.balance -= balance;
                return this.balance;
            }
            Console.WriteLine("Невозможно снять такую сумму");
            return this.balance;
        }
        public void Transfer(BankAccount account, double amount)
        {
            if (account != null && account.Balance > 0 && amount <= account.Balance)
            {
                account.balance -= amount;
                balance += amount;
            }
            else
            {
                Console.WriteLine("Невозможно снять деньги с этого счета");
            }
        }
        /// <summary>
        /// данные о проводках из очереди запишет в файл
        /// </summary>
        public void Dispose()
        {
            foreach (BankTransaction bt in typeOfBankTransaction)
            {
                string date = bt.Date.ToString();
                string amount = bt.Amount.ToString();
                using (var writer = new StreamWriter("Переводы.txt", true))
                {
                    writer.Write(amount + ' ');
                    writer.Write(date);
                    writer.WriteLine();
                }
                GC.SuppressFinalize(bt);
            }

        }
    }
}
