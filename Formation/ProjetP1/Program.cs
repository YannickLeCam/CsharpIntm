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

            LectureDonnee datas = new LectureDonnee("C:\\Users\\Formation\\Desktop\\Comptes.txt", "C:\\Users\\Formation\\Desktop\\Transaction.txt");

            Banque banque = datas.Banque;
            banque.faireTransactions();
            Sortie sortie = new Sortie(banque);
            sortie.AffichageSortie("C:\\Users\\Formation\\Desktop\\Sortie.txt");

            


            /*compte compte = new compte(1, 1000);
            compte compte1 = new compte(2);
            compte compte2 = new compte(3, 500);
            
            

            transaction tran = new transaction(1, 200, 1, 2);
            transaction tran1 = new transaction(2, 500, 0, 2);
            transaction tran2 = new transaction(3 ,1000,1,2);
            transaction tran3 = new transaction(4, 300, 3, 1);
            transaction tran4 = new transaction(5, 200, 0, 2);
            transaction tran5 = new transaction(6, 100, 1, 0);*/
            /*banque.comptes.Add(compte);
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
            bool test = compte.VerifyTransaction(500);*/
            Console.ReadLine();
        }
    }
}
