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
            set
            {
                this._historique.Add(value);
            }
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

        public Compte(int id, decimal solde = 0)
        {
            this._id = id;
            this._solde = solde;
            this._historique = new List<Transaction>();
        }



    }
}
