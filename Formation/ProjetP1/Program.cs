using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetP1
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
            Transaction tran2 = new Transaction(3 ,1000,1,2);
            Transaction tran3 = new Transaction(4, 300, 3, 1);
            Transaction tran4 = new Transaction(5, 200, 0, 2);
            Transaction tran5 = new Transaction(6, 100, 1, 0);
            Banque banque = new Banque();
            banque.comptes.Add(compte);
            banque.comptes.Add(compte1);
            banque.comptes.Add(compte2);
            banque.transactions.Add(tran);
            banque.transactions.Add(tran1);
            banque.transactions.Add(tran2);
            banque.transactions.Add(tran3);
            banque.transactions.Add(tran4);
            banque.transactions.Add(tran5);


            banque.faireTouteTransaction();

            

            compte.ajoutTransactionHistorique(tran);
            compte.ajoutTransactionHistorique(tran5);
            compte.ajoutTransactionHistorique(tran3);
            bool test = compte.VerifyTransaction(500);
            Console.ReadLine();
        }
    }
}
