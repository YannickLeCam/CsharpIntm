using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetP2
{
    public class StatutOperation
    {
        private int _id;
        private bool _statut;

        public int Id { get { return _id; } }
        //sert de toString car la seule on a pas besoin de voir son retour pour l'instant
        public string Statut
        {
            get
            {
                if (_statut) { return "OK"; }
                else { return "KO"; }
            }
        }
    

        public StatutOperation (int id, bool statut)
        {
            _id = id;
            _statut = statut;
        }


    }
}
