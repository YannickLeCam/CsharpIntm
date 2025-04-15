using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetS2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Compte compte = new Compte(1, 1000);
            Compte compte1 = new Compte(2);
            Compte compte2 = new Compte(3, 500);

            Transaction tran = new Transaction(1, 200, 1, 2);
            Transaction tran1 = new Transaction(2, 500, 0, 2);

        }
    }
    
}
