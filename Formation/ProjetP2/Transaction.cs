using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetP2
{
    public class Transaction
    {
        private int _id;
        private decimal _montant;
        private int _expediteur;
        private int _destinataire;
        private DateTime _dateTransaction;


        public Transaction(int id, decimal montant, int expediteur, int destinataire, DateTime dateTransaction)
        {
            this._id = id;
            this._montant = montant;
            this._expediteur = expediteur;
            this._destinataire = destinataire;
            this._dateTransaction = dateTransaction;
        }

        public int Id { get { return _id; } }

        public decimal Montant {get { return _montant; } }
        public int Expediteur {get { return _expediteur; } }
        public int Destinataire {get { return _destinataire; } }
        public DateTime DateTransaction { get { return _dateTransaction; } }
        
    }
}
