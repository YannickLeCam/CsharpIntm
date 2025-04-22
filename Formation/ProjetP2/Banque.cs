using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProjetP2
{
    public class Banque
    {
        private List<Transaction> _transactions = new List<Transaction>();
        private List<Operation> _operations = new List<Operation>();
        private List<Compte> _comptes = new List<Compte>();
        private List<StatutTransaction> _statutTransactions = new List<StatutTransaction>();
        private List<StatutOperation> _statutOperations = new List<StatutOperation>();
        private List<Gestionnaire> _gestionnaireList = new List<Gestionnaire>();
        private Dictionary<Gestionnaire, decimal> _fraisDeGestion = new Dictionary<Gestionnaire, decimal>();

        //Pour pouvoir générer une banque par défault
        public Banque() { }

        //Pour pouvoir générer une banque avec des listes par défault
        //A oublier pour la partie 2 mais peut servir si on veut avoir une base
        public Banque(List<Compte> comptes, List<Transaction> transactions)
        {
            this._transactions = transactions;
            this._comptes = comptes;
            this.Transactions.Sort();
            this.Operations.Sort();
        }

        public List<Operation> Operations { get { return _operations; } }
        public List<Compte> Comptes { get { return _comptes; } }
        public List<Transaction> Transactions { get { return _transactions; } }
        public List<StatutTransaction> StatutTransactions { get { return _statutTransactions; } }
        public List<StatutOperation> StatutOperations {  get { return _statutOperations; } }

        public void ActiverBanque()
        {
            int compteurOpe = 0;
            int compteurTrans = 0;
            while (compteurOpe != -1 && compteurTrans != -1)
            { 
                //Il n'y a plus de transaction
                if(compteurTrans == -1)
                {
                    faireOperation(this._operations[compteurOpe]);
                    compteurOpe += 1;
                    if(compteurOpe == _operations.Count())
                    {
                        compteurOpe = -1;
                    }
                    continue;
                }
                //Il n'y pas d'opé
                if(compteurOpe == -1)
                {
                    faireTransaction(this._transactions[compteurTrans]);
                    compteurTrans += 1;
                    if(compteurTrans == _transactions.Count())
                    {
                        compteurTrans = -1;
                    }
                }
                //On va traiter les demandes par ordre chronologique
                //Dans le cas ou doit faire une Opération
                if (this._operations[compteurOpe].Date < this._transactions[compteurTrans].DateTransaction)
                {
                    faireOperation(this._operations[compteurOpe]);
                    compteurOpe += 1;
                    if (compteurOpe == _operations.Count())
                    {
                        compteurOpe = -1;
                    }
                    continue;
                }
                //dans le cas ou l'on doit faire une transaction
                else
                {
                    faireTransaction(this._transactions[compteurTrans]);
                    compteurTrans += 1;
                    if (compteurTrans == _transactions.Count())
                    {
                        compteurTrans = -1;
                    }
                }
            }
        }

        //Pouvoir ajouter un compte en créer un
        public bool CreationAjoutCompte(int id,int idGestionnaire,DateTime dateCreation , decimal solde = 0)
        {
            if (IsAccountExist(id))
            {
                //Pour eviter qu'il soit bloquant    
                //throw new Exception("Le compte existe deja . . .");
                
                return false;
            }
            if (solde < 0)
            {
                //Pour eviter qu'il soit bloquant 
                //throw new ArgumentException("Le solde ne semble ne pas etre correct");
                return false;
            }
            Gestionnaire gestionnaire = new Gestionnaire();
            foreach (Gestionnaire gest in _gestionnaireList)
            {
                if(idGestionnaire == gest.Id)
                {
                    gestionnaire = gest;
                }
            }
            if(gestionnaire.Id == 0)
            {
                //throw new ArgumentException("Le gestionnaire ne semble pas exister"); 
                return false;
            }


            this._comptes.Add(new Compte(id ,gestionnaire,dateCreation,solde ));
            return true;
        }

        public void CreationAjoutOperation(int id, DateTime dateOperation , decimal solde , int entree , int sortie)
        {
            if(id == 0 || IsOperationExist(id))
            {
                return;
            }
            if (solde < 0)
            {
                return;
            }

            //detection création de compte 
            if(sortie == 0)
            {
                this._operations.Add(new Operation (id,dateOperation,entree,solde));
            }
            //Cas ou c'est un changement de gestionnaire
            else if( solde == 0 && entree > 0 && sortie > 0)
            {
                this._operations.Add(new Operation(id,dateOperation,entree,sortie)); 
            }
            //Cas ou c'est une resiliation de compte
            else if (sortie > 0)
            {
                this._operations.Add(new Operation(id,dateOperation,sortie));   
            }
            
        }

        public bool CessionCompte(int idCompte , DateTime date , int idGestionnaireEntrant , int idGestionnaireSortant)
        {
            if (!IsAccountExist(idCompte))
            {
                return false;
            }
            Compte compte = new Compte();
            foreach (Compte cpt in this._comptes)
            { 
                if(cpt.Id == idCompte)
                {
                    compte = cpt;
                }
            }


            if (idGestionnaireSortant != compte.Gestionnaire.Id)
            {
                return false;
            }

            if ( !compte.IsActif(date))
            {
                return false ;
            }
            Gestionnaire newGestionnaire = new Gestionnaire();
            if (this.IsGestionnaireExist(idGestionnaireEntrant))
            {
                foreach(Gestionnaire gest in this._gestionnaireList)
                {
                    if(gest.Id == idGestionnaireEntrant)
                    {
                        newGestionnaire = gest;
                    }
                }
            }
            else { return false; }

            compte.Gestionnaire = newGestionnaire;
            return true;

        }

        public bool CloturerCompte(int idCompte, DateTime date, int idGestionnaire)
        {
            Compte compte = new Compte();
            if (IsAccountExist(idCompte))
            {
                foreach (Compte cpt in this.Comptes)
                {
                    if (cpt.Id == idCompte)
                    {
                        compte = cpt;
                    }
                }
            }
            else
            {
                return false;
            }
            if (!compte.IsActif(date)) { return false; }

            if(compte.Gestionnaire.Id != idGestionnaire)
            {
                return false ;
            }



            return true;
        }

        //Pourvoir ajouter une transaction et en créer une
        public void CreationAjoutTransaction(int id, decimal montant, int expediteur, int destinataire, DateTime dateTransaction)
        {
            this._transactions.Add(new Transaction(id, montant, expediteur, destinataire,dateTransaction));
        }

        public void CreationAjoutGestionnaire(int id, string type, int nbTransactions)
        {
            if (IsGestionnaireExist(id))
            {
                return;
            }
            _gestionnaireList.Add(new Gestionnaire(id, type, nbTransactions));
        }

        public bool IsAccountExist(int id)
        {
            foreach (Compte compte in _comptes)
            {
                if (compte.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsGestionnaireExist(int id)
        {
            foreach(Gestionnaire gestionnaire in _gestionnaireList)
            {
                if(gestionnaire.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsOperationExist (int id)
        {
            foreach (Operation ope in this._operations)
            {
                if(ope.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public void faireOperation(Operation ope)
        {

            switch (ope.TypeOperation)
            {
                //Partie Création de compte
                case 0:
                    if (CreationAjoutCompte(ope.Id, ope.Entree, ope.Date, ope.Solde))
                    {
                        this._statutOperations.Add(new StatutOperation(ope.Id,true));
                    }
                    else
                    {
                        this._statutOperations.Add(new StatutOperation(ope.Id, false));
                    }
                    break;
                           
                //Partie Cession de compte
                case 1:
                    if (CessionCompte(ope.Id,ope.Date,ope.Entree,ope.Sortie))
                    {
                        this._statutOperations.Add(new StatutOperation(ope.Id, true));
                    }
                    else
                    {
                        this._statutOperations.Add(new StatutOperation(ope.Id, false));
                    }
                    break;
                //Partie Suppression de Compte
                case 2:
                    if (CloturerCompte(ope.Id, ope.Date, ope.Sortie))
                    {
                        this._statutOperations.Add(new StatutOperation(ope.Id, true));
                    }
                    else
                    {
                        this._statutOperations.Add(new StatutOperation(ope.Id, false));

                    }
                    break;
                default:
                    break;
            }


            //Partie création de compte

        }

        public void faireTransaction(Transaction transaction)
        {

            //On doit vérifier les date du compte avec celle de la transaction
            //SI l'expediteur n'existe pas 
            if (!IsAccountExist(transaction.Expediteur) && transaction.Expediteur != 0)
            {
                _statutTransactions.Add(new StatutTransaction(transaction.Id, false));
                return;
            }
            //Si le destinataire n'existe pas 
            if (!IsAccountExist(transaction.Destinataire) && transaction.Destinataire != 0)
            {
                _statutTransactions.Add(new StatutTransaction(transaction.Id, false));
                return;
            }
            //Le montant n'est pas une valeur absolue alors transaction eroné ou égal a 0
            if (transaction.Montant <= 0)
            {
                _statutTransactions.Add(new StatutTransaction(transaction.Id, false));
                return;
            }
            Compte expe = new Compte();
            Compte desti = new Compte();
            foreach (Compte compte in _comptes)
            {
                if (compte.Id == transaction.Expediteur)
                {
                    expe = compte;
                }
                if (compte.Id == transaction.Destinataire)
                {
                    desti = compte;
                }
            }
            if (!expe.IsActif(transaction.DateTransaction) || !desti.IsActif(transaction.DateTransaction))
            {
                _statutTransactions.Add(new StatutTransaction(transaction.Id, false));
                return;
            }
            //Par la creation de Compte par défaut les comptes serront vu comme des guichet avec l'Id 0
            //Cas si l'utilisateur retire de l'argent dans un guichet
            if (transaction.Destinataire == 0)
            {

                if (expe.Id == 0)
                {
                    _statutTransactions.Add(new StatutTransaction(transaction.Id, false));
                }
                else
                {
                    if (expe.Withdraw(transaction.Montant,transaction.DateTransaction))
                    {
                        _statutTransactions.Add(new StatutTransaction(transaction.Id, true));
                    }
                    else
                    {
                        _statutTransactions.Add(new StatutTransaction(transaction.Id, false));
                    }

                }
            }
            //Cas ou l'utilisateur dépose de l'argent sur un guichet
            else if (transaction.Expediteur == 0)
            {
                desti.Deposit(transaction.Montant);
                _statutTransactions.Add(new StatutTransaction(transaction.Id, true));
            }
            else
            {
                if (expe.Withdraw(transaction.Montant, transaction.DateTransaction))
                {
                    
                    _statutTransactions.Add(new StatutTransaction(transaction.Id, true));
                    if (expe.Gestionnaire != desti.Gestionnaire) 
                    {
                        if (expe.Gestionnaire.Type == "Entreprise")
                        {
                            desti.Deposit(transaction.Montant - 10);
                            this._fraisDeGestion[expe.Gestionnaire] += 10; 
                        }
                        else
                        {
                            desti.Deposit(transaction.Montant - (transaction.Montant *(decimal)0.01));
                            this._fraisDeGestion[expe.Gestionnaire] += (transaction.Montant * (decimal)0.01);
                        }
                    }
                    else
                    {
                        desti.Deposit(transaction.Montant);
                    }
                }
                else
                {
                    _statutTransactions.Add(new StatutTransaction(transaction.Id, false));
                }
            }
            
        }
    }
}