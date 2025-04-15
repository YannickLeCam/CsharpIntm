using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetS2
{
    internal class StatutTransaction
    {
        public int id;
        public bool statut;

        public StatutTransaction(int id, bool statut)
        {
            this.id = id;
            this.statut = statut;
        }
    }
}
