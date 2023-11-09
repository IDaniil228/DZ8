using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Song song_1 = new Song("In the end", "Linkin park");
            Song song_2 = new Song("Without me", "Eminem", song_1);
            BankAccount account = new BankAccount(1500);
            account.WithdrawFromBalance(1000);
            account.Dispose();
        }
    }
}
