using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetP1
{
    internal class Sortie
    {
        private Banque _banque;


        public Sortie(Banque banque)
        {
            this._banque = banque;
        }

        public void AffichageSortie(string cheminFichierSortie)
        {
            using (FileStream fsRetour = new FileStream(cheminFichierSortie, FileMode.OpenOrCreate)) 
            using (StreamWriter writer = new StreamWriter(fsRetour))
            {
                //En-tete
                Console.WriteLine("Etat des comptes final");
                Console.Write("Sorties;");
                foreach (Compte compte in this._banque.Comptes)
                {
                    Console.Write($"Solde Compte {compte.Id};");
                }
                Console.WriteLine();
                Console.Write($"    |");
                foreach (Compte compte in this._banque.Comptes)
                {
                    Console.Write($"{compte.Solde} |");
                }
                Console.WriteLine();

                foreach (Transaction transaction in this._banque.Transactions)
                {
                    StatutTransaction statut = this._banque.StatutTransactions.Where(s => s.Id == transaction.Id).First();
                    writer.WriteLine($"{statut.Id};{statut.Statut}");
                }
            }

           
        }
    }
}
