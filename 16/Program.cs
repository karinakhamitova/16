using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Net.Http;

namespace _16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n = 1;
            Product[] products = new Product[n];
            try
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Введите код товара");
                    int code = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите название товара");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите стоимость товара:");
                    double sol = Convert.ToInt32(Console.ReadLine());
                    products[i] = new Product() { Name = name, Code = code, Price = sol };
                }
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                string jsonString = JsonSerializer.Serialize(products, options);
                using (StreamWriter sw = new StreamWriter("../../../Products.json"))
                {
                    sw.WriteLine(jsonString);
                }
            }
            catch (Exception ex)    
            {
                Console.WriteLine(ex.Message);
            }
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

