using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetP2
{
    public class Gestionnaire
    {
        private int _id;
        private string _type;
        private int _nbTransactions;

        public int Id { get { return _id; } }
        public string Type { get { return _type; } }
        public int NbTransactions { get { return _nbTransactions; } }

        public Gestionnaire(int id, string type, int nbTransactions)
        {
            _id = id;
            if (type != "Particulier" || type != "Entreprise")
            {
                throw new ArgumentException("Le type du gestionnaire ne semble pas etre juste");
            }
            
            _type = type;
            if (nbTransactions < 0)
            {
                throw new ArgumentException("Le nombre de transaction semble etre invalide ...");
            }
            _nbTransactions = nbTransactions;
        }
    }
}
