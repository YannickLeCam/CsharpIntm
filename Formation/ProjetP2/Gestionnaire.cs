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

        //Un gestionnaire ne peut avoir l'id 0
        public Gestionnaire()
        {

        }

        public Gestionnaire(int id, string type, int nbTransactions)
        {
            //Test de validation d'un gestionnaire
            if (id <= 0) 
            {
                throw new ArgumentException("Id est invalid");
            }
            if (type != "Particulier" || type != "Entreprise")
            {
                throw new ArgumentException("Le type du gestionnaire ne semble pas etre juste");
            }
            if (nbTransactions < 0)
            {
                throw new ArgumentException("Le nombre de transaction semble etre invalide ...");
            }

            _id = id;
            _type = type;
            _nbTransactions = nbTransactions;
        }

    }
}
