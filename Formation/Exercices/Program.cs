using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exercices
{
    internal class Program
    {
        enum Genre
        {
            Male,
            Female,
            AC130DeCombat,
            Autre
        }
        struct Person
        {
            public string prenom;
            public string nom;
            public int age;
            public Genre genre;

            public Person(string prenom, string nom , int age , char genre)
            {
                this.prenom = prenom;
                this.nom = nom;
                this.age = age;
                switch (genre)
                {
                    case 'M':
                        this.genre = Genre.Male;
                        break;
                    case 'F':
                        this.genre = Genre.Female;
                        break;
                    case 'C':
                        this.genre = Genre.AC130DeCombat;
                        break;
                    case 'A':
                    default:
                        this.genre = Genre.Autre;
                        break;
                }
            }



            public string toString()
            {
                return $"{this.nom} {this.prenom}";
            }
        }


        struct Voiture
        {
            public string modele;
            public string marque;
            public float puissance;
            public string couleur;
            public double kilometrage;
            public int anneeAchat;
            public Person proprietaire;

            public Voiture (string modele , string marque , float puissance, string couleur, double kilometrage, int anneeAchat , Person proprietaire)
            {
                this.modele = modele;
                this.marque = marque;
                this.puissance = puissance;
                this.couleur = couleur;
                this.kilometrage = kilometrage;
                this.anneeAchat = anneeAchat;
                this.proprietaire = proprietaire;
            }

            public string toString()
            {
                return $" La voiture est une {this.modele} de la marque {this.marque}, elle a une puissance de {this.puissance}, la couleur est {this.couleur} et a parcourue {this.kilometrage} km alors quelle a été acheter en {this.anneeAchat} et appartient a {this.proprietaire.toString()}"; 
            }
            
        }

        static void Main(string[] args)
        {
            CultureInfo culture = CultureInfo.InvariantCulture;
            CultureInfo us = new CultureInfo("fr-FR");
            Console.OutputEncoding = Encoding.UTF8;

            int x = 12 * 30;
            Console.WriteLine("La valeur de 'X' est égal a : " + x.ToString("C2",us));

            int y = 10;
            Console.WriteLine("La valeur de 'Y' est égale a : " + y);
            int z = x + y;
            Console.WriteLine("La valeur de 'X + Y' est égale a : " + z);
            Console.Write("Entre ton prénom : ");
            string entree = Console.ReadLine();
            Console.WriteLine($"Bonjour {entree} ! ♥ ");


            int a = 0;
            while(a < 10)
            {
                a += 1;
                Console.WriteLine("Je suis dans la boucle while et a = " + a);
            }

            string[] tabJoursSemaine = { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche" };




            for (int i = 0; i < tabJoursSemaine.Length; i++)
            {
                Console.WriteLine(tabJoursSemaine[i]);
            }
            
            //TEST EXERCICE 1
            BasicOperation(2, 2, '+');
            BasicOperation(2, 2, 'J');
            BasicOperation(4, 4,'/');
            BasicOperation(1, 0, '/');
            BasicOperation(1, 0, '-');
            BasicOperation(1, 2, '*');

            IntegerDivision(4, 4);
            IntegerDivision(19, 4);
            IntegerDivision(6, 0);

            Pow(10, 3);
            Pow(2,3);
            Pow(1000, 0);
            Pow(4, -5);
            //TEST EXERCICE 2
            Console.WriteLine("Test de l'horloge avec 12 : " + GoodDay(12));
            Console.WriteLine("Test de l'horloge avec 0 : " + GoodDay(0));
            Console.WriteLine("Test de l'horloge avec -5 : " + GoodDay(-5));
            Console.WriteLine("Test de l'horloge avec 19 : " + GoodDay(19));
            Console.WriteLine("Test de l'horloge avec 11 : " + GoodDay(11));
            //TEST EXERCICE 3
            PyramidConstruction(50);

            //TEST exercice 4 
            Console.WriteLine("Factorial Itérative de 10 : " + Factorial(10));
            Console.WriteLine("Factorial Recursive de 10 : " + FactorialRec(10));
            

            //TEST exercice 5
            Console.WriteLine("Test de isPrime 13 : " + isPrime(13));
            Console.WriteLine("Test de isPrime 10 : " + isPrime(10));
            Console.WriteLine("Test de isPrime 150 : " + isPrime(150));
            for (int i = 1; i < 100; i++) 
            {
                if (isPrime(i))
                {
                    Console.WriteLine(i);
                }
            
            }
            //TEST EXERCICE 6
            Console.WriteLine("Test PGCD 165 100 : " + gcd(165,100));
            Console.WriteLine("Test PGCD 132 99 : " + gcd(132, 99));




            Person george = new Person("Geoge", "DelaJungle", 18, 'C');
            
            


            Voiture BatMobile = new Voiture("Polo", "Volkwagen", (float)7.5, "Vert Bouteille", 300000, 1999, george);
            Console.WriteLine(BatMobile.toString());

            int[] tab = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            Console.WriteLine(maFonction(tab));



            List<string> listMots = new List<string>() { "Chaussure", "Canapé", "Pédoncule", "Pistil", "Chaussettes" };

            int[] tab1 = { 1, -5, -4, 9, -11, 6, 3, 0 };
            int[] tab2 = { };
            Console.WriteLine("Le tableau est : " + tab1);   
            Console.WriteLine("LinearSearch on cherche -112 " + LinearSearch(tab1, -112));
            Console.WriteLine("LinearSearch on cherche 6 " + LinearSearch(tab1, 6));
            Console.WriteLine("LinearSearch on cherche 6 dans un tab vide " + LinearSearch(tab2, 6));

            Console.ReadKey();
        }



        static int LinearSearch(int[] tableau , int valeur)
        {
            if (tableau.Length == 0)
            {
                return -1;
            }
            for (int i = 0; i < tableau.Length; i++)
            {
                if (tableau[i] == valeur)
                {
                    return i;
                }
            }
            return -1;
        }

        static int maFonction(params int[] tab)
        {  

            for (int i = 1; i < tab.Length; i++)
            {
                tab[0] += tab[i];
            }
            return tab[0];
        }


        /// <summary>
        /// Cette methode permet de faire les calcules basics et en faire un affichage avec vérification de ce qu'il y a en entrée.
        /// <example>
        /// For example:
        /// <code>
        /// BasicOperation(2, 2, '+');
        /// BasicOperation(2, 2, 'J');
        /// </code>
        /// 2 + 2 = 4
        /// 2 J 2 = Opération Ivalide.
        /// </example>
        /// </summary>
        static void BasicOperation(int a, int b, char operateur)
        {
            Console.Write($"{a} {operateur} {b} = ");
            switch (operateur)
            {

                case '*':

                    Console.Write(a*b);
                    break;
                case '+':
                    Console.Write(a+b);
                    break;
                case '-':
                    Console.Write(a-b);
                    break;
                case '/':
                    if (b == 0)
                    {
                        Console.Write("Opération Invalide .");
                    }
                    else
                    {
                        Console.WriteLine(a / b);
                    }
                    break;
                default:
                    Console.Write("Opération Invalide .");
                    break;

            }
            Console.Write('\n');
        }

        static void IntegerDivision(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine($"{a} : {b} = Opération Invalide .");
            }
            else
            {
                int q = (int)a / b;
                int r = a % b;
                if (r == 0)
                {
                    Console.WriteLine($"{a} = {q} * {b}");
                }
                else
                {
                    Console.WriteLine($"{a} = {q} * {b} + {r}");
                }
            }
        }
       
        static void Pow(int a, int b) 
        {
            Console.Write($"{a} ^ {b} = ");
            if (b > 0)
            {
                int temp = a;
                for (int i = 0; i < b; i++)
                {
                    a = a * temp;
                }
                Console.Write(a);

            } else if (b == 0)
            {
                Console.Write('1');
            }
            else {
                Console.Write("Opération Invalide");
            }
            Console.Write('\n');
        }

        static string GoodDay(int heure)
        {
            if (heure > 24 || heure < 0)
            {
                return "L'heure n'est pas valide";
            }
            switch (heure)
            {
                case int h when h < 6:
                    return "Merveilleuse Nuit !";
                case int h when h >= 6 && h < 12:
                    return "Bonne matinée !";
                case int h when h == 12:
                    return "Bon app ! ♥";
                case int h when h >= 13 && h < 18:
                    return "Profitez de votre après-midi ! ";
                case int h when h >= 18:
                    return "Passez une bonne soirée !";
                default:
                    return "Bug de l'horloge parlante ! :X";
            }
        }

        static void ConstructionNivPyr(int etage,int etage_max,char bloc = '*') 
        {
            string affi = $"{bloc}";
            int longueurMaxPyr = etage_max - 1;
            int longueurEtage = etage - 1;
            for (int i = 0; i < longueurEtage; i++)
            {
                affi = $"{bloc}" + affi + $"{bloc}";
            }
            for (int i = 0; i < longueurMaxPyr-longueurEtage; i++)
            {
                affi = " " + affi + " ";
            } 
            Console.WriteLine(affi);
        }

        static void PyramidConstruction(int etage) 
        {
            char bloc = '*';
            for (int i = 1; i <= etage; i++)
            {
                if (i % 2 == 0)
                {
                    bloc = '-';
                }
                else 
                {
                    bloc = '+';
                }
                ConstructionNivPyr (i, etage,bloc);
            }
        }

        static int Factorial(int n)
        {
            int retour = 1;
            for (int i = 1; i <= n; i++)
            {
                retour = retour * i;
            }
            return retour;
        }
        static int FactorialRec(int n)
        {
            if (n == 0) return 1;
            else return n * FactorialRec(n-1);
        }
        //La methode la plus efficace est la facon recursive ! 
        //Car pas de valeur intermediaire ^^

        static bool isPrime(int n) 
        {
            for (int i = 2; i < n ; i++) 
            {
                if (n % i == 0) return false;
            }
            return true;
        
        }

        static int gcd(int a, int b) 
        {
            if (a % b == 0)
            {
                return b;
            }
            else
            { 
                return gcd(b , a%b);
            }
        }
    }
}
