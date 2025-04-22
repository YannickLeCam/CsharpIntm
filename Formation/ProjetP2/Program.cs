using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetP2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LectureDonnee datas = new LectureDonnee("C:\\Users\\Formation\\Desktop\\Comptes.txt", "C:\\Users\\Formation\\Desktop\\Transactions.txt", "C:\\Users\\Formation\\Desktop\\Gestionnaires.txt");
            Banque banque = datas.Banque;
            banque.ActiverBanque();
            Sortie sortie = new Sortie(banque);
            sortie.AffichageSortie("C:\\Users\\Formation\\Desktop\\SortieTransactions.txt", "C:\\Users\\Formation\\Desktop\\SortieOperations.txt");
        }
    }
}
