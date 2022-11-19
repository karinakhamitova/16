using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace _16_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string json = String.Empty;
            using (StreamReader sr = new StreamReader("../../../Products.json"))
            {
                json = sr.ReadToEnd();
            }
            Product[] products = JsonSerializer.Deserialize<Product[]>(json);
            Product max = products[0];
            foreach (Product product in products)
            {
                if (product.Price> max.Price)
                {
                    max = product;
                }
            }
            Console.WriteLine($"{max.Code} {max.Name}, {max.Price}");
            Console.ReadKey();
        }
    }
    class Product
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

    }
}
