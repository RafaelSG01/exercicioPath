using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace ExercicioPath
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dados dos produtos:");
            Console.Write("Quantidade de produtos: ");
            int n = int.Parse(Console.ReadLine());

            List<Product> products = new List<Product>();

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Produto #{i}");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Preço: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantidade: ");
                int quantity = int.Parse(Console.ReadLine());
                products.Add(new Product(name, price, quantity));
            }

            double totalPrice = 0.0;
            Console.WriteLine();
            foreach (Product product in products)
            {
                totalPrice = product.TotalPrice();
                Console.WriteLine(product.ToString());
            }

            string path = @"C:\Users\rafas\source\repos\ExercicioPath\ExercicioPath\out";
            
            try
            {
                Directory.CreateDirectory(path);
                using(StreamWriter sw = File.AppendText(path + @"\summary.csv"))
                {
                    foreach(Product product in products)
                    {
                        sw.WriteLine(product.Name + ", " + product.TotalPrice().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um erro:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
