using System;
using System.Collections.Generic;

namespace exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new Tab();

            x.Add(5);
            x.Add(11);
            x.Add(-4);
            x.Add(23);

            Console.WriteLine("Sum: "+x.Sum());
            Console.WriteLine("Min: "+x.Min());
            Console.WriteLine("Max: "+x.Max());
            Console.WriteLine("Index of 5: "+x.IndexOf(5));
            Console.WriteLine(x.Print());
        }
    }
    class Tab
    {
        // Pole klasy
        private List<int> _lista = new List<int>();

        // Konstruktor bezparametrowy
        public Tab() { }
        public void Add(int number)
        {
            _lista.Add(number);
        }

        public void Clear() 
        {
            _lista.Clear();
        }

        public bool Contains(int number)
        {
            return _lista.Contains(number);
        }

        public int IndexOf(int number)
        {
            return _lista.IndexOf(number);
        }

        public int Sum()
        {
            return (_lista.Sum());
        }

        public int Min()
        {
            return (int)_lista.Min();
        }

        public int Max()
        {
            return (int)_lista.Max();
        }

        public String Print()
        {
            String output = "";
            foreach(var item in _lista)
            {
                output += item.ToString()+", ";
            }
            return output;
        }

    }
}
