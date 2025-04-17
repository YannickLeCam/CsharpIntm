using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProjetP1
{
    public class Banque
    {
        private List<Transaction> _transactions = new List<Transaction>();
        private List<Compte> _comptes = new List<Compte>();
        private List<StatutTransaction> _statutTransactions = new List<StatutTransaction>();

        //Pour pouvoir générer une banque par défault
        public Banque(){}

        //Pour pouvoir générer une banque avec des listes par défault
        public Banque(List<Compte> comptes, List<Transaction> transactions) 
        {
            this._transactions = transactions;
            this._comptes = comptes;
        }

        public List<Compte> Comptes { get { return _comptes; } }
        public List<Transaction> Transactions { get { return _transactions; } }
        public List<StatutTransaction> StatutTransactions { get { return _statutTransactions; } }

        //Pouvoir ajouter un compte en créer un
        public void CreationAjoutCompte(int id, decimal solde=0)
        {
            if (IsAccountExist(id))
            {
                //Pour eviter qu'il soit bloquant    
                //throw new Exception("Le compte existe deja . . .");
                return;
            }
            if (solde < 0)
            {
                //Pour eviter qu'il soit bloquant 
                //throw new ArgumentException("Le solde ne semble ne pas etre correct");
                return;
            }
            this._comptes.Add(new Compte(id, solde));
        }
        //Pourvoir ajouter une transaction et en créer une
        public void CreationAjoutTransaction(int id, decimal montant, int expediteur, int destinataire)
        {
            this._transactions.Add(new Transaction(id,montant,expediteur,destinataire));
        }

        public bool IsAccountExist(int id)
        {
            foreach (Compte compte in _comptes)
            { 
                if(compte.Id == id)
                {
                    return true;
                }
            }
            return false;
        }


        public void faireTransactions()
        {
            foreach (Transaction transaction in this._transactions)
            {
                //SI l'expediteur n'existe pas 
                if(!IsAccountExist(transaction.Expediteur) && transaction.Expediteur!= 0)
                {
                    _statutTransactions.Add(new StatutTransaction(transaction.Id, false));
                    continue;
                }
                //Si le destinataire n'existe pas 
                if(!IsAccountExist(transaction.Destinataire) && transaction.Destinataire!= 0)
                {
                    _statutTransactions.Add(new StatutTransaction(transaction.Id, false));
                    continue;
                }
                //Le montant n'est pas une valeur absolue alors transaction eroné ou égal a 0
                if(transaction.Montant <= 0)
                {
                    _statutTransactions.Add(new StatutTransaction(transaction.Id, false));
                    continue;
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
                        if (expe.Withdraw(transaction.Montant))
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
                    if (expe.Withdraw(transaction.Montant))
                    {
                        desti.Deposit(transaction.Montant);
                        _statutTransactions.Add(new StatutTransaction(transaction.Id, true));
                    }
                    else
                    {
                        _statutTransactions.Add(new StatutTransaction(transaction.Id, false));
                    }
                }

            }
        }
    }
}
