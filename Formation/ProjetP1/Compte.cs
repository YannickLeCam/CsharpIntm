using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetP1
{
    public class Compte
    {
        private int _id;
        private decimal _solde;
        private List<Transaction> _historique = new List<Transaction>();

        public decimal Solde
        {
            get
            {
                return this._solde;
            }
            set
            {
                this._solde = value;
            }
        }

        public List<Transaction> Historique
        {
            get
            {
                return this._historique;
            }
        }

        public void ajoutTransactionHistorique(Transaction transaction)
        {
            _historique.Add(transaction);
        }

        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }


        public Compte()
        {
            this._id=0;
            this._solde = 0;
        }
        public Compte(int id, decimal solde = 0)
        {
            this._id = id;
            this._solde = solde;
            this._historique = new List<Transaction>();
        }

        public bool VerifyTransaction(decimal montant)
        {
            decimal sumMontant = this._historique.Where(histo => histo.Expediteur == this._id).Take(10).Sum(histo => histo.Montant);
            sumMontant += montant;
            if (montant > this.Solde || sumMontant > 1000) 
            {
                return false;
            }
            return true;
        }

        public bool Withdraw(decimal montant)
        {
            //On fait une verification tout de meme 
            if (this.VerifyTransaction(montant))
            {
                this.Solde -= montant;
                return true;
            }
            return false;
        }

        public void Deposit(decimal montant)
        {
            this._solde += montant;
        }

        


    }
}
