using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetP2
{
    internal class Sortie
    {
        private Banque _banque;


        public Sortie(Banque banque)
        {
            this._banque = banque;
        }

        public void AffichageSortie(string cheminFichierSortieTransactions,string cheminFichierSortieOperations)
        {
            using (FileStream fsRetour = new FileStream(cheminFichierSortieTransactions, FileMode.OpenOrCreate)) 
            using (StreamWriter writer = new StreamWriter(fsRetour))
            {
                foreach (StatutTransaction statut in this._banque.StatutTransactions)
                {
                    //StatutTransaction statut = this._banque.StatutTransactions.Where(s => s.Id == transaction.Id).First();
                    writer.WriteLine($"{statut.Id};{statut.Statut}");
                }
            }
            using (FileStream fsRetour = new FileStream(cheminFichierSortieOperations, FileMode.OpenOrCreate))
            using (StreamWriter writer = new StreamWriter(fsRetour))
            {
                foreach (StatutOperation statutOpe in this._banque.StatutOperations)
                {
                    writer.WriteLine($"{statutOpe.Id};{statutOpe.Statut}");
                }
            }

            _banque.Statistique.Display();

            Console.WriteLine("Frais de gestion");
            foreach (KeyValuePair<Gestionnaire,decimal> kvp in _banque.FraisDeGestion)
            {
                Console.WriteLine($"{kvp.Key.Id} : {kvp.Value}");
            }

            Console.ReadKey();

        }
    }
}
