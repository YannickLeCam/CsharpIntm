using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
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

    }
}
