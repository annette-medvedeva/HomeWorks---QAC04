using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HomeWork1
{
    public class Product : IComparable<Product>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Product(ProductEnum.ProductsEnum productName, double price, int quantity)
        {
            this.Name = productName.ToString();
            this.Price = price;
            this.Quantity = quantity;
        }

        public int CompareTo(Product other)
        {
            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }

        public static void PrintProductPairs(Dictionary<string, Product> dictionary)
        {
            Console.WriteLine("Перебор и распечатка пар значений:");
            foreach (var pair in dictionary)
            {
                Console.WriteLine($"Name = {pair.Value.Name}, Price = {pair.Value.Price}, Quantity = {pair.Value.Quantity}");
            }
            Console.WriteLine();
        }
        public static void PrintProductNames(Dictionary<string, Product> dictionary)
        {
            Console.WriteLine("Перебор и распечатка имен продуктов:");
            foreach (var pair in dictionary)
            {
                Console.WriteLine($"Name: {pair.Value.Name}");
            }
            Console.WriteLine();
        }

        public static void PrintProductCounts(Dictionary<string, Product> dictionary)
        {
            Console.WriteLine("Перебор и распечатка значений количества единиц продуктов:");
            foreach (var pair in dictionary)
            {
                Console.WriteLine($"Quantity: {pair.Value.Quantity}");
            }
            Console.WriteLine();
        }

        //List
        public static void PrintProductPairs(List<Product> productList)
        {
            Console.WriteLine("Перебор и распечатка пар значений by List:");
            foreach (var product in productList)
            {
                Console.WriteLine($"Name = {product.Name}, Price = {product.Price}, Quantity = {product.Quantity}");
            }
            Console.WriteLine();
        }

        public static void PrintProductNames(List< Product> productList)
        {
            Console.WriteLine("Перебор и распечатка имен продуктов by List:");
            foreach (var product in productList)
            {
                Console.WriteLine($"Name: {product.Name}");
            }
            Console.WriteLine();
        }
        public static void PrintProductCounts(List<Product> productList)
        {
            Console.WriteLine("Перебор и распечатка значений количества единиц продуктов by List:");
            foreach (var product in productList)
            {
                Console.WriteLine($"Quantity: {product.Quantity}");
            }
            Console.WriteLine();
        }

    }
}
