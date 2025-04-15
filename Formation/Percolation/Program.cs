using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //3.b Cette méthode devrat parcourir toute les case du si la grille est est totallement vide apres la destruction de la case bloqué
            //3.c Pour un cas vrai il serrait plus judicieux de dire _size * _size - _size-1, car la "surface" est sensé etre couverte d'eau sauf a un endroit 
            PercolationSimulation simulation = new PercolationSimulation();
            PclData data = simulation.MeanPercolationValue(10,100);
            Console.WriteLine($" La moyenne est : {data.Mean.ToString()} et l'écart-type est : {data.StandardDeviation.ToString()}");
            Console.ReadLine();
        }
    }
}
