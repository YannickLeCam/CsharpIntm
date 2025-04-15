using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public struct PclData
    {
        /// <summary>
        /// Moyenne 
        /// </summary>
        public double Mean { get; set; }
        /// <summary>
        /// Ecart-type
        /// </summary>
        public double StandardDeviation { get; set; }
        /// <summary>
        /// Fraction
        /// </summary>
        public double Fraction { get; set; }
    }

    public class PercolationSimulation
    {
        public PclData MeanPercolationValue(int size, int t)
        {
            PclData pclData = new PclData();
            double sum = 0;
            List<double> values = new List<double>();


            for (int i = 0; i < t; i++)
            {
                //Console.WriteLine("Debut de la perco " + i);
                double retour = PercolationValue(size);
                values.Add(retour);
                sum += retour;
                //Console.WriteLine("Fin de la perco " + i);
            }
            //Moyenne
            pclData.Mean = (double)sum/t;

            //Ecart-Type
            double sumEcartMoy = 0;
            foreach (double ret in values)
            {
                sumEcartMoy += Math.Pow(ret,2);
            }
            pclData.StandardDeviation= Math.Sqrt(sumEcartMoy/t - Math.Pow(pclData.Mean,2));
            return pclData;
        }

        public double PercolationValue(int size)
        {
            Percolation perco = new Percolation(size);
            Random rnd = new Random();
            int cpt = 0;
            while (!perco.Percolate())
            {
                int i = rnd.Next(0,size);
                int j = rnd.Next(0,size);
                if(!perco.IsOpen(i,j))
                {
                    perco.Open(i,j);
                    cpt+=1;
                  //  perco.DisplayGrille();
                }
                
            }
            double retour = (double)cpt / (size * size);
            return retour;
        }
    }
}
