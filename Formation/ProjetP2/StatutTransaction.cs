using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetP2
{
    public class StatutTransaction
    {
        private int _id;
        private bool _statut;

        public int Id { get { return _id; } }
        public string Statut { get {
                if (_statut) { return "OK"; }
                else { return "KO"; }
            } }

        public StatutTransaction(int id , bool statut) 
        {
            this._id = id;
            this._statut = statut;
        }
    }
}
