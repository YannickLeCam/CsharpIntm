using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetP2
{
    public class Statistique
    {
        private int _nbCompte;
        private int _nbTrans;
        private int _nbTransRéussite;
        private int _nbTransEchouee;
        private decimal _totalMontant;

        public int NbCompte { get { return _nbCompte; } set { _nbCompte = value; } }
        public int NbTrans { get { return _nbTrans; } set { _nbTrans = value; } }    
        public int NbTransReussite { get { return _nbTransRéussite; } set { _nbTransRéussite = value; } }
        public int NbTransEchouee {  get { return _nbTransEchouee;} set { _nbTransEchouee = value; } }
        public decimal TotalMontant { get { return _totalMontant; } set { _totalMontant = value; } }


        public void Display()
        {
            Console.WriteLine($"Le nombre de comptes créé(s) : {_nbCompte}");
            Console.WriteLine($"Le nombre de transactions traitée(s) : {_nbTrans}");
            Console.WriteLine($"Le nombre de transactions réussite(s) : {_nbTransRéussite}");
            Console.WriteLine($"Le nombre de transactions échouée(s) : {_nbTransEchouee}");
            Console.WriteLine($"Le total des montants traitée : {_totalMontant}");
        }
    }
}
