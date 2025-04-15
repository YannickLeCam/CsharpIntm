using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetP1
{
    public class Transaction
    {
        public int id;
        public decimal montant;
        public int expediteur;
        public int destinataire;


        public Transaction(int id, decimal montant, int expediteur, int destinataire)
        {
            this.id = id;
            this.montant = montant;
            this.expediteur = expediteur;
            this.destinataire = destinataire;
        }
    }
}
