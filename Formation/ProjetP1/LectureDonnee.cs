using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetP1
{
    internal class LectureDonnee
    {
        private Banque banque = new Banque();

        public Banque Banque { get { return banque; } }

        public LectureDonnee(string cheminFichierCompte, string cheminFichierTransaction)
        {
            using (FileStream fsRetour = new FileStream(cheminFichierCompte, FileMode.Open))
            using (StreamReader reader = new StreamReader(fsRetour))
            {
                while (!reader.EndOfStream)
                {

                    string line = reader.ReadLine();
                    string purifiedLine = line.TrimEnd(';');
                    string[] elemLine = purifiedLine.Split(';');
                    try
                    {

                        if (elemLine.Length == 2 )
                        {
                            this.banque.CreationAjoutCompte(Int32.Parse(elemLine[0]), Decimal.Parse(elemLine[1]));
                        }
                        else if (elemLine.Length == 1)
                        {
                            this.banque.CreationAjoutCompte(Int32.Parse(elemLine[0]));
                        }
                        else
                        {
                            throw new Exception("Le fichier d'entrée de compte ne semble ne pas etre correctement alimenté.");
                        }
                    }
                    catch (Exception)
                    {

                        throw new Exception("Probleme lors de la lecture des compte.");
                    }
                }
            }
            using (FileStream fsRetour = new FileStream(cheminFichierTransaction, FileMode.Open))
            using (StreamReader reader = new StreamReader(fsRetour))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] elemLine = line.Split(';');
                    try
                    {
                        if (elemLine.Length < 4)
                        {
                            throw new DataException("Les données ne semble pas etre possible a traiter");
                        }

                        this.banque.CreationAjoutTransaction(Int32.Parse(elemLine[0]), Decimal.Parse(elemLine[1]), Int32.Parse(elemLine[2]), Int32.Parse(elemLine[3]));
                    }
                    catch (Exception)
                    {

                        throw new Exception("Probleme lors de la lecture des transactions.");
                    }
                }
            }
        }
    }
}
