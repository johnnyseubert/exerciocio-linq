using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using LINQ_LAMBDA_EXERCICIO.Entities;

namespace LINQ_LAMBDA_EXERCICIO
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Product> list = new List<Product>();
            string path = @"C:\temp\in.txt";

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    double price = double.Parse(fields[1], CultureInfo.InvariantCulture);

                    list.Add(new Product(name, price));
                }
            }

            double avg = list.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine($"Average Price: {avg.ToString("F2", CultureInfo.InvariantCulture)}");

            IEnumerable<string> names = list.Where(p => p.Price < avg).OrderByDescending(p => p.Name).Select(p => p.Name);
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }

        }
    }
}