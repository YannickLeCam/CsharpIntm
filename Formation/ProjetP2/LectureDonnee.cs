using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetP2
{
    internal class LectureDonnee
    {
        private Banque banque = new Banque();

        public Banque Banque { get { return banque; } }

        public LectureDonnee(string cheminFichierOperation, string cheminFichierTransaction , string cheminFichierGestionnaire)
        {
            //IL FAUT VERIFIER SI LE FICHIER EXISTE !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            using (FileStream fsRetour = new FileStream(cheminFichierGestionnaire, FileMode.Open))
            using (StreamReader reader = new StreamReader(fsRetour)) 
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string purifiedLine = line.TrimEnd(';');
                    string[] elemLine = purifiedLine.Split(';');

                    try
                    {
                        bool verif;

                        //id
                        //Ne peut pas etre null
                        int id;
                        verif = Int32.TryParse(elemLine[0], out id);
                        if (!verif) { throw new ArgumentException("l'id est incorect . . ."); }


                        //entrée
                        //Ne peut pas etre null
                        string type = elemLine[1];

                        //sortie
                        //Ne peut pas etre null
                        int nbTransactions;

                        verif = Int32.TryParse(elemLine[2], out nbTransactions);
                        if (!verif) { throw new ArgumentException("le nombre de transactions est incorrect . . . "); }

                        banque.CreationAjoutGestionnaire(id, type, nbTransactions);
                    }
                    catch(Exception)
                    {

                    }
                }
            
            }

            //verifier si le fichier exist 
            using (FileStream fsRetour = new FileStream(cheminFichierOperation, FileMode.Open))
            using (StreamReader reader = new StreamReader(fsRetour))
            {
                while (!reader.EndOfStream)
                {

                    string line = reader.ReadLine();
                    string[] elemLine = line.Split(';');

                   


                    try
                    {
                        bool verif;

                        //id
                        //Ne peut pas etre null
                        int id;
                        verif = Int32.TryParse(elemLine[0],out id);
                        if (!verif) { throw new ArgumentException("l'id est incorect . . ."); }

                        //date
                        //Ne peut pas etre null
                        DateTime date;
                        verif = DateTime.TryParse(elemLine[1],out date);
                        if (!verif) { throw new ArgumentException("la date est incorect . . ."); }

                        //solde
                        decimal solde;
                        if (elemLine[2] == "") { solde = 0; }
                        else 
                        {
                            verif = Decimal.TryParse(elemLine[2],out solde);
                            if (!verif) { throw new ArgumentException("le solde est incorect . . ."); }
                        }

                        //entrée
                        int entree;
                        if (elemLine[3] == "") {  entree = 0; }
                        else
                        {
                            verif = Int32.TryParse(elemLine[3],out entree);
                            if (!verif) { throw new ArgumentException("l'entrée est incorect . . ."); }
                        }

                        //sortie
                        int sortie;
                        if (elemLine[4] == "") {  sortie = 0; }
                        else
                        {
                            verif = Int32.TryParse(elemLine[4],out sortie);
                            if (!verif) { throw new ArgumentException("la sortie est incorrect . . . "); }
                        }

                        banque.CreationAjoutOperation(id,date,solde,entree,sortie);
                        
                    }
                    catch (Exception)
                    {

                        //throw new Exception("Probleme lors de la lecture des compte.");
                    }
                }
            }
            using (FileStream fsRetour = new FileStream(cheminFichierTransaction, FileMode.Open))
            using (StreamReader reader = new StreamReader(fsRetour))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string purifiedLine = line.TrimEnd(';');
                    string[] elemLine = purifiedLine.Split(';');
                    try
                    {
                        bool verif;
                        //id
                        //Ne peut pas etre null
                        int id;
                        verif = Int32.TryParse(elemLine[0], out id);
                        if (!verif) { throw new ArgumentException("l'id est incorect . . ."); }

                        //date
                        //Ne peut pas etre null
                        DateTime date;
                        verif = DateTime.TryParse(elemLine[1], out date);
                        if (!verif) { throw new ArgumentException("la date est incorect . . ."); }

                        //montant
                        //Ne peut pas etre null
                        decimal montant;

                        verif = Decimal.TryParse(elemLine[2], out montant);
                        if (!verif) { throw new ArgumentException("le montant est incorect . . ."); }
                        

                        //expéditeur
                        //Ne peut pas etre null
                        int expe;
                        
                        verif = Int32.TryParse(elemLine[3], out expe);
                        if (!verif) { throw new ArgumentException("l'expediteur est incorect . . ."); }
                        

                        //destinataire
                        //Ne peut pas etre null
                        int desti;
                        
                        verif = Int32.TryParse(elemLine[4], out desti);
                        if (!verif) { throw new ArgumentException("la sortie est incorrect . . . "); }
                        

                        this.banque.CreationAjoutTransaction(id,montant,expe,desti,date);
                    }
                    catch (Exception)
                    {

                        //throw new Exception("Probleme lors de la lecture des transactions.");
                    }
                }
            }
        }
    }
}
