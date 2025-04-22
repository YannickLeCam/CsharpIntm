using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetP2
{
    public class Compte
    {
        private int _id;
        private decimal _solde;
        private List<Transaction> _historique = new List<Transaction>();
        private Gestionnaire _gestionnaire;
        private DateTime _dateOuverture;
        private DateTime _dateFermeture;

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

        public Gestionnaire Gestionnaire
        {
            get { return this._gestionnaire; }
            set { this._gestionnaire = value; }
        }

        public DateTime DateOuverture
        {
            get { return _dateOuverture; }
            set { this.DateOuverture = value; } 
        }

        public DateTime DateFermeture
        {
            get
            {
                return this._dateFermeture;
            }
            set
            {
                this._dateFermeture = value;
            }
        }



        public Compte()
        {
            this._id=0;
            this._solde = 0;
        }

        public Compte(int id,Gestionnaire gestionnaire,DateTime dateOuverture, decimal solde = 0)
        {
            this._id = id;
            this._solde = solde;
            this._gestionnaire = gestionnaire;
            this._historique = new List<Transaction>();
        }

        public bool VerifyTransaction(decimal montant, DateTime dateTransaction)
        {
            List<Transaction> listTransaction = this._historique.Where(histo => histo.Expediteur == this._id && histo.DateTransaction.AddDays(7) >= dateTransaction).ToList();

            decimal sumMontant = listTransaction.Sum(histo => histo.Montant);
            sumMontant += montant;
            if (montant > this.Solde || sumMontant > 2000 || listTransaction.Count()+1 > this._gestionnaire.NbTransactions) 
            {
                return false;
            }
            return true;
        }

        public bool Withdraw(decimal montant , DateTime dateTransaction)
        { 
            if(VerifyTransaction(montant, dateTransaction))
            {
                this.Solde -= montant;
                return true;
            }
            return false;
            
        }

        public bool IsActif(DateTime date)
        { 
            if(this._dateFermeture == null || date < this._dateFermeture)
            {
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
