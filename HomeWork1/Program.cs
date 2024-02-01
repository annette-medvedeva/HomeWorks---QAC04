using HomeWork1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static HomeWork1.ProductEnum;

namespace HomeWorks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            //func7_0();
            //func7_1();
            //func7_3();
            func7_4();
        }
        //1.1 У вас есть следующая коллекция:
        //ArrayList list = new ArrayList();
        //И в вашей программе вызвается следующий код:
        //object s = list[18];
        //Необходимо перехватить ошибку и вывести на экран с указанием типа этой ошибки.

        public static void func7_0()
        {
            ArrayList list = new ArrayList();
            try
            {
                object s = list[18];
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.GetType().Name}");
            }
            //1.2 Необходимо создать коллекцию Dictionary, в которой будет находиться 10
             //различных пар объектов.Необходимо вывести содержимое коллекции на экран.
            Dictionary<object, object> dictionary = new Dictionary<object, object>();
            for (int i = 1; i<=10; i++) 
            {
                dictionary.Add($"Key {i}", $"Value {i}");
            }
            Console.WriteLine("Dictionary: ");
            foreach (var pair in dictionary)
            {
                Console.WriteLine($"{pair.Key}: { pair.Value}");
            }
            //1.3 Пользователь вводит набор чисел в виде одной строки "1, 2, 3, 4, 4, 5".
            //Избавиться от повторяющихся элементов в строке и вывести результат на экран.
            Console.WriteLine("Введите набор чисел в виде одной строки:" );
            string input = Console.ReadLine();
            string[] inputNumbers = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            HashSet<string> uniqueNumbers = new HashSet<string>();
            foreach (string number in inputNumbers)
            {
                uniqueNumbers.Add(number);
            }
            Console.WriteLine("Результат после удаления повторяющихся элементов:");
            Console.WriteLine(string.Join(", ", uniqueNumbers));
            Console.ReadLine();
        }
        //а) Создать динамический массив, содержащий объекты класса Product
        //б) Распечатать его содержимое используя for each.
        //в) Изменить цену одного продукта на 100
        //г) Удалить последний продукт.
        //е) Получить массив содержащий продукты из коллекции тремя способами и вывести на консоль.
        //ж) Удалить все продукты.
        public static void func7_1()
        {
            List<Product> products = new List<Product>
        {
            new Product(ProductsEnum.Apple, 50.0, 10),
            new Product(ProductsEnum.PineApple, 30.0, 5),
            new Product(ProductsEnum.Cherry, 20.0, 8)
        };

            Console.WriteLine("Содержимое массива до изменений:");
            foreach (Product product in products)
            {
                Console.WriteLine("{0}: {1}, {2}", product.Name, product.Price,product.Quantity);
            }
            products[0].Price = 100;
            Console.WriteLine("Содержимое массива после изменения цены: ");
            foreach (Product product in products)
            {
                Console.WriteLine("{0}: {1}, {2}", product.Name, product.Price, product.Quantity);
            }
            Console.WriteLine("Удалить последний продукт: "+(products.Count));
            products.RemoveAt(products.Count - 1);
            Product[] productsArray1 = products.ToArray();
            Console.WriteLine("\n 1)Массив:");
            foreach (Product product in productsArray1)
            {
                Console.WriteLine("{0}: {1}, {2}", product.Name, product.Price, product.Quantity);
            }

            Console.WriteLine("\n 2)Метод GetEnumerator:");
            double[] productsArray2 = new double[products.Count];
            int i = 0;
            foreach (Product product in products)
            {
                Console.WriteLine( productsArray2[i++] = product.Price);
            }

            Console.WriteLine("Содержимое SortedSet:");
            SortedSet<Product> sortedSet = new SortedSet<Product>
        {
            new Product(ProductsEnum.Apple, 50.0, 10),
            new Product(ProductsEnum.PineApple, 30.0, 5),
            new Product(ProductsEnum.Cherry, 20.0, 8)
        };
            foreach (Product product in sortedSet)
            {
                Console.WriteLine("{0}: {1}, {2}", product.Name, product.Price, product.Quantity);
            }

            products.Clear();
            if (products.Count == 0)
            {
                Console.WriteLine("Коллекция пуста");
            }
            Console.ReadLine();

            
        }
        //Задание 3:
        //Создать коллекцию, содержащую объекты Product.Написать метод, который перебирает
        //элементы коллекции и проверяет цену продуктов. Если цена продукта больше 300
        //рублей, продукт перемещается в другую коллекцию.
        //Необходимо вывести минимальное значение продукта из полученной коллекции.
        public static void func7_3()
        {
            List<Product> expensiveProducts = new List<Product>();
            List<Product> products = new List<Product>
        {
            new Product(ProductsEnum.Apple, 50.0, 10),
            new Product(ProductsEnum.PineApple, 30.0, 5),
            new Product(ProductsEnum.Cherry, 299.0, 8),
            new Product(ProductsEnum.Meat, 620.0, 8),
            new Product(ProductsEnum.Milk, 150.0, 12),
            new Product(ProductsEnum.Cookies, 400.0, 7)
        };
            MoveExpensiveProducts(products, expensiveProducts);
            Console.WriteLine("All Products:");
            foreach (var product in products)
            {
                Console.WriteLine(product.Name + " - " + product.Price + " rubles");
            }

            Console.WriteLine("\nExpensive Products:");
            foreach (var product in expensiveProducts)
            {
                Console.WriteLine(product.Name + " - " + product.Price + " rubles");
            }
            if (expensiveProducts.Count > 0)
            {
                Product minExpensiveProduct = expensiveProducts.Min();
                Console.WriteLine($"\nMinimum Price Product: {minExpensiveProduct.Name} - {minExpensiveProduct.Price} rubles");
            }
            else
            {
                Console.WriteLine("\nNo expensive products in the collection.");
            }

            Console.ReadLine();
        }

        static void MoveExpensiveProducts(List<Product> source, List<Product> destination)
        {
            foreach (var product in source.ToList())
            {
                if (product.Price > 300)
                {
                    destination.Add(product);
                    source.Remove(product);
                }
            }
        }

        //4.Создайте Dictionary, содержащий пары значений - имя продукта и количестов единиц
        //продукта(класс Product).
        //Перебрать и распечатать пары значений в формате "Name = abc, Price = 15, Count = 5"
        //Перебрать и распечатать набор из имен продуктов
        //Перебрать и распечатать значения количества единиц продуктов.
        //Для каждого перебора создать свой метод.
        //Создайте и в List
        public static void func7_4() 
        {
            Dictionary<string, Product> productDictionary = new Dictionary<string, Product>
        {
                { "Apple", new Product(ProductsEnum.Apple, 50.0, 10) },
                { "PineApple",new Product(ProductsEnum.PineApple, 30.0, 5) },
                { "Cherry", new Product(ProductsEnum.Cherry, 299.0, 8) },
                {"Meat", new Product(ProductsEnum.Meat, 620.0, 8) },
                { "Milk", new Product(ProductsEnum.Milk, 150.0, 12) },
                {"Cookies", new Product(ProductsEnum.Cookies, 400.0, 7) }
        };
            Product.PrintProductPairs(productDictionary);
            Product.PrintProductNames(productDictionary);
            Product.PrintProductCounts(productDictionary);

            List<Product> products = new List<Product>
        {
            new Product(ProductsEnum.Apple, 50.0, 10),
            new Product(ProductsEnum.PineApple, 30.0, 5),
            new Product(ProductsEnum.Cherry, 299.0, 8),
            new Product(ProductsEnum.Meat, 620.0, 8),
            new Product(ProductsEnum.Milk, 150.0, 12),
            new Product(ProductsEnum.Cookies, 400.0, 7)
        };
            Product.PrintProductPairs(products);
            Product.PrintProductNames(products);
            Product.PrintProductCounts(products);

            Console.ReadLine();
        }

    }
}

