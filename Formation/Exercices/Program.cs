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

            /*            string[] tabJoursSemaine = ["Lundi","Mardi","Mercredi","Jeudi","Vendredi","Samedi","Dimanche"];




                        for (int i = 0; i < tabJoursSemaine.Length; i++)
                        {
                            Console.WriteLine(tabJoursSemaine[i]);
                        }*/
            
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
            Console.ReadKey();
        }


        
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
    }
}
