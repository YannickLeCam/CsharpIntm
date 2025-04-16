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
        public List<Transaction> transactions = new List<Transaction>();
        public List<Compte> comptes = new List<Compte>();
        private static readonly List<StatutTransaction> statutTransactions = new List<StatutTransaction>();


        public void faireTouteTransaction()
        {
            Console.WriteLine(" Sorties | Solde Compte 1 | Solde Compte 2 | Solde Compte 3");
            Console.WriteLine($"         | {this.comptes[0].Solde} | {this.comptes[1].Solde} | {this.comptes[2].Solde}");
            foreach (Transaction transaction in this.transactions)
            {
                if (faireTransaction(transaction))
                {
                    Console.WriteLine($"{transaction.Id} OK| {this.comptes[0].Solde} | {this.comptes[1].Solde} | {this.comptes[2].Solde}");

                }
                else
                {
                    Console.WriteLine($"{transaction.Id} KO| {this.comptes[0].Solde} | {this.comptes[1].Solde} | {this.comptes[2].Solde}");

                }

            }
        }


        public bool faireTransaction(Transaction transaction)
        {
            Compte expe = new Compte();
            Compte desti = new Compte();
            foreach (Compte compte in comptes)
            {
                if (compte.Id == transaction.Expediteur)
                {
                    expe = compte;
                }
                if(compte.Id == transaction.Destinataire)
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
                    statutTransactions.Add(new StatutTransaction(transaction.Id, false));
                    return false;
                }
                else
                {
                    if (expe.Withdraw(transaction.Montant))
                    {
                        statutTransactions.Add(new StatutTransaction(transaction.Id, true));
                        return true;
                    }
                    else
                    {
                        statutTransactions.Add(new StatutTransaction(transaction.Id, false));
                        return false;
                    }

                }
            }
            //Cas ou l'utilisateur dépose de l'argent sur un guichet
            else if (transaction.Expediteur == 0)
            {
                desti.Deposit(transaction.Montant);
                statutTransactions.Add(new StatutTransaction(transaction.Id, true));
                return true;
            }
            else
            {
                if (expe.Withdraw(transaction.Montant))
                {
                    desti.Deposit(transaction.Montant);
                    statutTransactions.Add(new StatutTransaction(transaction.Id, true));
                    return true;
                }
                else
                {
                    statutTransactions.Add(new StatutTransaction(transaction.Id, false));
                    return false;
                }
            }
        }
    }
}
