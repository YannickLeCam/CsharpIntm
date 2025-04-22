using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetP2
{
    public class Operation
    {
        private int _id;
        private DateTime _date;
        private decimal _solde;
        private int _entree;
        private int _sortie;
        //0 = creation de compte
        //1 = changement de gestionnaire
        //2 = resilliation de compte
        private int _typeOperation;

        public int Id
        {
            get { return _id; }
        }
        public DateTime Date
        {
            get { return this._date; }
        }
        public decimal Solde
        {
            get { return (decimal)this._solde; }
        }
        public int Entree
        {
            get { return this._entree; }
        }
        public int Sortie
        {
            get { return _sortie; }
        }
        public int TypeOperation
        {
            get { return this._typeOperation; }
        }

        //Operation crétion de compte
        public Operation(int id, DateTime date, int entree, decimal solde = 0 )
        {
            this._id = id;
            this._date = date;
            this._solde = solde;
            this._entree = entree;
            this._typeOperation = 0; 
        }
        //Operation modification de gestionnaire
        public Operation(int id, DateTime date, int entree, int sortie)
        {
            this._id=id;
            this._date = date; 
            this._entree=entree;
            this._sortie=sortie;
            this._typeOperation=1;
        }
        //Opération de supression de compte
        public Operation(int id, DateTime date , int sortie)
        {
            this._id = id;
            this._date = date;
            this._sortie = sortie;
            this._typeOperation=2;
        } 
        
        
            
        


    }
}
