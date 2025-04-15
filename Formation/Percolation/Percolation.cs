using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public class Percolation
    {
        private readonly bool[,] _open;
        private readonly bool[,] _full;
        private readonly int _size;
        private bool _percolate;

        public Percolation(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size, "Taille de la grille négative ou nulle.");
            }

            _open = new bool[size, size];
            _full = new bool[size, size];
            _size = size;
        }

        public bool IsOpen(int i, int j)
        {

            return _open[i,j];
        }

        private bool IsFull(int i, int j)
        {
            return _full[i,j];
        }

        public bool Percolate()
        {
            for (int i = 0; i < _size; i++)
            {
                if (IsFull(_size-1,i))
                {
                    _percolate = true;
                    return true;
                }
            }
            return false;
        }

        private List<KeyValuePair<int, int>> CloseNeighbors(int i, int j)
        {
            List<KeyValuePair<int,int>> neighbors = new List<KeyValuePair<int,int>>();
            if(i == _size - 1 && j == _size-1)
            {
                neighbors.Add(new KeyValuePair<int, int>(i,j-1));
                neighbors.Add(new KeyValuePair<int, int>(i-1,j));
            }
            else if(i == 0 && j == 0)
            {
                neighbors.Add(new KeyValuePair<int, int>(i+1,j));
                neighbors.Add(new KeyValuePair<int, int>(i , j+1));
            }
            else if (i == _size - 1 && j == 0)
            {
                neighbors.Add(new KeyValuePair<int, int>(i - 1, j));
                neighbors.Add(new KeyValuePair<int, int>(i,j+1));
            }
            else if (i == 0 && j == _size - 1)
            {
                neighbors.Add(new KeyValuePair<int, int>(i +1 , j));
                neighbors.Add(new KeyValuePair<int, int> (i,j-1));
            }
            else if (i== 0)
            {
                neighbors.Add(new KeyValuePair<int, int>(i+1, j));
                neighbors.Add (new KeyValuePair<int, int> (i, j+1));
                neighbors.Add(new KeyValuePair<int, int> (i , j-1));
            }
            else if (i == _size - 1)
            {
                neighbors.Add(new KeyValuePair<int, int>(i - 1, j));
                neighbors.Add(new KeyValuePair<int, int>(i, j + 1));
                neighbors.Add(new KeyValuePair<int, int>(i, j - 1));
            }
            else if (j == 0)
            {
                neighbors.Add(new KeyValuePair<int, int>(i, j+1));
                neighbors.Add(new KeyValuePair<int, int> (i+1,j));
                neighbors.Add(new KeyValuePair<int, int>(i-1, j));
            }
            else if (j == _size - 1)
            {
                neighbors.Add(new KeyValuePair<int, int>(i,j-1));
                neighbors.Add(new KeyValuePair<int, int> (i+1, j));
                neighbors.Add(new KeyValuePair<int, int>(i-1,j));
            }
            else
            {
                neighbors.Add(new KeyValuePair<int, int>(i, j - 1));
                neighbors.Add(new KeyValuePair<int, int>(i, j + 1));
                neighbors.Add(new KeyValuePair<int, int>(i + 1, j));
                neighbors.Add(new KeyValuePair<int, int>(i - 1, j));
            }

            return neighbors;
        }

        public void DisplayGrille()
        {
            Console.WriteLine("================FULL=============");
            for (int ii = 0; ii < _size; ii++)
            {
                for (int jj = 0; jj < _size; jj++)
                {
                    if(_full[ii, jj])
                    {
                        Console.Write("1 ");
                    }
                    else
                    {
                        Console.Write("0 ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("==============OPEN===============");
            for (int ii = 0; ii < _size; ii++)
            {
                for (int jj = 0; jj < _size; jj++)
                {
                    if (_open[ii, jj])
                    {
                        Console.Write("1 ");
                    }
                    else
                    {
                        Console.Write("0 ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("=================================");
        }

        public void Open(int i, int j)
        {
            _open[i,j] = true;
            bool isFull = false;
            //Si le open se situe au top de la roche alors la case devient innondée
            if (i == 0)
            {
                isFull = true;
            }
            else
            {
                //On verifie les voisin si il n'y en pas une innondé
                List<KeyValuePair<int, int>> neighbors = CloseNeighbors(i, j);
                foreach (KeyValuePair<int, int> kvp in neighbors)
                {
                    if (IsFull(kvp.Key, kvp.Value))
                    {
                        isFull = true;
                    }
                }
            }
            if (isFull)
            {
                //la case doit etre innondé alors on verifie les voisins si cela ne répercute pas sur eux
                _full[i, j] = true;
                
                if (Percolate())
                {
                    return;
                }
                List<KeyValuePair<int, int>> neighbors = CloseNeighbors(i, j);
                Stack<KeyValuePair<int, int>> stackNeighborOpen = new Stack<KeyValuePair<int, int>>();
                foreach (KeyValuePair<int, int> kvp in neighbors)
                {
                    if (IsOpen(kvp.Key, kvp.Value) && !IsFull(kvp.Key, kvp.Value))
                    {
                        stackNeighborOpen.Push(new KeyValuePair<int, int>(kvp.Key, kvp.Value));
                    }
                }

                while (stackNeighborOpen.Count > 0)
                {
                    List<KeyValuePair<int, int>> neighborsTmp = CloseNeighbors(stackNeighborOpen.Peek().Key, stackNeighborOpen.Peek().Value);
                    _full[stackNeighborOpen.Peek().Key, stackNeighborOpen.Peek().Value] = true;
                    stackNeighborOpen.Pop();
                    foreach (KeyValuePair<int, int> kvp in neighborsTmp)
                    {
                        if (IsOpen(kvp.Key, kvp.Value) && !IsFull(kvp.Key, kvp.Value))
                        {
                            stackNeighborOpen.Push(new KeyValuePair<int, int>(kvp.Key, kvp.Value));
                        }
                    }
                    if (Percolate())
                    {
                        return;
                    }
                }
            }
        }
    }
}
