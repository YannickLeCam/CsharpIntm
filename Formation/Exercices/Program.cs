using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

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
            Console.WriteLine("La valeur de 'X' est égal a : " + x.ToString("C2", us));

            int y = 10;
            Console.WriteLine("La valeur de 'Y' est égale a : " + y);
            int z = x + y;
            Console.WriteLine("La valeur de 'X + Y' est égale a : " + z);
            Console.Write("Entre ton prénom : ");
            string entree = Console.ReadLine();
            Console.WriteLine($"Bonjour {entree} ! ♥ ");


            int a = 0;
            while (a < 10)
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
            BasicOperation(4, 4, '/');
            BasicOperation(1, 0, '/');
            BasicOperation(1, 0, '-');
            BasicOperation(1, 2, '*');

            IntegerDivision(4, 4);
            IntegerDivision(19, 4);
            IntegerDivision(6, 0);

            Pow(10, 3);
            Pow(2, 3);
            Pow(1000, 0);
            Pow(4, -5);
            //TEST EXERCICE 2
            Console.WriteLine("Test de l'horloge avec 12 : " + GoodDay(12));
            Console.WriteLine("Test de l'horloge avec 0 : " + GoodDay(0));
            Console.WriteLine("Test de l'horloge avec -5 : " + GoodDay(-5));
            Console.WriteLine("Test de l'horloge avec 19 : " + GoodDay(19));
            Console.WriteLine("Test de l'horloge avec 11 : " + GoodDay(11));
            //TEST EXERCICE 3
            // le nombre de blocks pour un étage est  (NumEtage * 2 - 1)
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
            Console.WriteLine("Test PGCD 165 100 : " + gcd(165, 100));
            Console.WriteLine("Test PGCD 132 99 : " + gcd(132, 99));




            Person george = new Person("Geoge", "DelaJungle", 18, 'C');




            Voiture BatMobile = new Voiture("Polo", "Volkwagen", (float)7.5, "Vert Bouteille", 300000, 1999, george);
            Console.WriteLine(BatMobile.toString());

            int[] tab = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            Console.WriteLine(maFonction(tab));



            List<string> listMots = new List<string>() { "Chaussure", "Canapé", "Pédoncule", "Pistil", "Chaussettes" };

            int[] tab1 = { -11, -5, -4, 0, 4, 6, 19, 123 };
            int[] tab2 = { };
            Console.WriteLine("Le tableau est : " + tab1);
            Console.WriteLine("LinearSearch on cherche -112 " + LinearSearch(tab1, -112));
            Console.WriteLine("LinearSearch on cherche 6 " + LinearSearch(tab1, 6));
            Console.WriteLine("LinearSearch on cherche 6 dans un tab vide " + LinearSearch(tab2, 6));

            Console.WriteLine("dichoSearch on cherche -112 " + DichoSerch(tab1, -112));
            Console.WriteLine("dichoSearch on cherche 6 " + DichoSerch(tab1, 6));
            Console.WriteLine("DichoSearch on cherche 6 dans un tab vide " + DichoSerch(tab2, 6));

            int[] matriceA = { 1, 2, 3 };
            int[] matriceB = { -1, -4, 0 };

            BuildingMatrix(matriceA, matriceB);

            int[][] matriceC = new int[3][];
            matriceC[0] = new int[]{ 1, 2 };
            matriceC[1] = new int[] { 4, 6 };
            matriceC[2] = new int[] { -1, 8 };
            int[][] matriceD = new int[3][];
            matriceD[0]= new int[] { -1, 5 };               
            matriceD[1] = new int[] { -4, 0 };              
            matriceD[2] = new int[] { 0, 2 };               
                                                            
            addMatrix(matriceC, matriceD);                  
                                                            
            int[][] matriceE = new int[2][];                
            matriceE[0] = new int[] { -1, 5 , 5};
            matriceE[1] = new int[] { -4, 0 , 6};

            mulMatrix(matriceC, matriceE);

            int[] primeTab = EratosthenesSieve(100);
            for (int i = 0; i < primeTab.Length; i++)
            {
                Console.Write($"{primeTab[i]} ");
            }
            Console.WriteLine();
            StringBuilder str = strBuilder(100);
            Console.WriteLine(str);

            //====================================================================
            //Manipulation de fichier
            //====================================================================

            /*
            FileStream fs = new FileStream("C:\\Users\\Formation\\Desktop\\Chaussure.txt", FileMode.Open);
            StreamReader reader = new StreamReader(fs);
            string buffer;
            Console.WriteLine("AFFICHAGE DU FICHIER AVANT ECRITURE ");
            while (!reader.EndOfStream)
            {

                buffer = reader.ReadLine();
                Console.WriteLine(buffer);
            }

            
            
            StreamWriter writer = new StreamWriter(fs);
            string input = "ldsjfqlsfqsd";
            while(input != "")
            {
                Console.WriteLine("Entre une marque de chaussure");
                input = Console.ReadLine();
                writer.WriteLine(input);
            }
            writer.Close();
            fs.Close();
            fs = new FileStream("C:\\Users\\Formation\\Desktop\\Chaussure.txt", FileMode.Open);
            reader = new StreamReader(fs);
            Console.WriteLine("AFFICHAGE DU FICHIER APRES ECRITURE ");
            while (!reader.EndOfStream)
            {
                buffer = reader.ReadLine();
                Console.WriteLine(buffer);
            }
            reader.Close();
            */
            

            consDeClass();

            Console.ReadKey();
        }


        struct Eleve
        {
            public string nom;
            public string matiere;
            public double note;


            public Eleve(string nom, string matiere,double note)
            {
                if (note<0 || note > 20)
                {
                    //Throw execption
                }
                this.nom = nom;
                this.matiere = matiere;
                this.note = note;
            }
        }

        struct MoyMatiere
        {
            public string matiere;
            public int nbEleve;
            public double somme;

            public MoyMatiere(string matiere , int nbEleve , double somme)
            {
                this.matiere = matiere;
                this.nbEleve = nbEleve;
                this.somme = somme;
            }
        }

        static void consDeClass()
        {
            CultureInfo culture = CultureInfo.InvariantCulture;
            CultureInfo us = new CultureInfo("en-US");

            List<Eleve> classe = new List<Eleve>();
            Eleve eleveTmp;
            List<MoyMatiere> moyMat = new List<MoyMatiere>();

            Dictionary<string, double> matMoy;

            string[] splitBuffer = new string[3];

            FileStream fs = new FileStream("C:\\Users\\Formation\\Desktop\\classe.txt", FileMode.Open);
            StreamReader reader = new StreamReader(fs);

            string buffer;
            double temp;

            while (!reader.EndOfStream)
            {
                buffer = reader.ReadLine();
                splitBuffer = buffer.Split(';');

                temp = Double.Parse(splitBuffer[2],culture);
                eleveTmp = new Eleve(splitBuffer[0], splitBuffer[1], temp);
                classe.Add(eleveTmp);

                
               
                if (!(matMoy.ContainsKey(splitBuffer[1])))
                {
                    matMoy.Add(splitBuffer[1], 0);
                }
                
                Console.WriteLine($"{splitBuffer[0]} {splitBuffer[1]} {splitBuffer[2]}");
            }

            string[] listMatiere = classe.GroupBy(eleve => eleve.matiere).Select(g => g.Key).ToArray();

            for (int i = 0; i < listMatiere.Length; i++)
            {
                moyMat.Add(new MoyMatiere(listMatiere[i], 0, 0));
            }
            /*
            for (int i = 0; i < classe.Count; i++)
            {
                for (int j = 0; j < moyMat.Count; j++)
                {
                    if (moyMat[j].matiere == classe[i].matiere)
                    {
                        moyMat[j].nbEleve += 1; 
                        //moyMat[j].somme += classe[i].note;
                    }
                }
                /*foreach (MoyMatiere mat in moyMat)
                {
                    if(mat.matiere == classe[i].matiere)
                    {
                        mat.somme += classe[i].note; 
                    }
                }
            }*/

            

            return;
        }

        struct QCM
        {
            public string question;
            public List<string> answer;
            public string solution;
            public int weight;


            public QCM(string question, List<string> answer , string solution , int weight)
            {
                if (weight < 0)
                {
                    //Throw execption ! 
                }

                this.question = question;
                this.answer = answer;
                this.solution = solution;
                this.weight = weight;
            }


            public bool affiQuestion()
            {
                Console.WriteLine(this.question);
                for (int i = 0; i < this.answer.Count; i++)
                {
                    Console.Write($" {i + 1} - {this.answer[i]} \n");
                }
                string reponse = Console.ReadLine();
                bool reponseValide = false;
                while (reponseValide)
                {
                    try
                    {
                        int result = Int32.Parse(reponse);
                        reponseValide = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("La reponse n'est pas valide retaper la réponse");
                        reponse = Console.ReadLine();
                    }
                }
                return false;
            }

        }

        static StringBuilder strBuilder(int n)
        {
            StringBuilder str = new StringBuilder("0");
            for (int i = 1; i <= n; i++)
            {
                str.Append($" - {i}");
            }
            return str;
        }

        static int[] EratosthenesSieve(int n)
        {
            int[] retour = new int[n];
            int cpt = 0;
            for (int i = 2; i < n; i++)
            {
                if (isPrime(i))
                {
                    retour[cpt] = i;
                    cpt += 1;
                }
            }
            return retour;
        }

        static int[][] mulMatrix(int[][] leftMatrix, int[][] rightMatrix)
        {
            int[][] retour = new int[leftMatrix.Length][];
            if (leftMatrix.Length != rightMatrix[0].Length || leftMatrix[0].Length != rightMatrix.Length)
            {
                return retour;
            }
            int sum = 0;
            for (int i = 0; i < leftMatrix.Length; i++)
            {
                retour[i] = new int[leftMatrix.Length];
                for (int j = 0; j < leftMatrix.Length; j++)
                {
                    sum = 0;
                    for (int k = 0; k < leftMatrix[i].Length; k++)
                    {
                        sum += leftMatrix[i][k] * rightMatrix[k][j];
                    }
                    retour[i][j] = sum;
                    Console.Write(retour[i][j] + " ");
                }
                Console.Write('\n');
            }
            return retour;
        }

        static int[][] addMatrix(int[][] leftMatrix , int[][] rightMatrix)
        {
            int[][] retour = new int[leftMatrix.Length][];
            if(leftMatrix.Length != rightMatrix.Length || leftMatrix[0].Length != rightMatrix[0].Length)
            {
                return retour;
            }

            for (int i = 0; i < leftMatrix.Length; i++)
            {
                retour[i] = new int[leftMatrix[i].Length];
                for (int j = 0; j < leftMatrix[i].Length; j++)
                {
                    retour[i][j] = leftMatrix[i][j] + rightMatrix[i][j];
                    Console.Write(retour[i][j] + " ");
                }
                Console.Write('\n');
            }
            return retour;
        }


        static int[][] BuildingMatrix(int[] leftVector , int[] rightVector)
        {
            int[][] retour = new int[leftVector.Length][];
            if (leftVector.Length != rightVector.Length)
            {
                return retour;
            }
            

            for (int i = 0; i < leftVector.Length; i++)
            {
                retour[i] = new int[rightVector.Length];
                for (int j = 0; j < rightVector.Length; j++)
                {
                    retour[i][j] = leftVector[i] * rightVector[j];
                    Console.Write(retour[i][j] + " ");
                }
                Console.Write('\n');
            }
            return retour;
        }







        static int DichoSerch(int[] tableau , int valeur)
        {
            if (tableau.Length == 0)
            {
                return -1;
            }
            int i = tableau.Length / 2;
            int iBorneMin = 0;
            int iBorneMax = tableau.Length;
         
            while (iBorneMax != iBorneMin)
            {
                Console.WriteLine(tableau[i]);
                if (tableau[i] == valeur)
                {
                    return i;
                }
                else if (valeur > tableau[i]){
                    iBorneMin = i;
                    i = (i + iBorneMax) / 2;
                }
                else
                {
                    iBorneMax = i;
                    i = (i + iBorneMin) / 2;
                }
            }

            return -1;
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
