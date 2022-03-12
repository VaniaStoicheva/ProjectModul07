using DemoApp1.Controllers;
using DemoApp1.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp1.Views
{
    public class Display
    {
      ProductController productControler=new ProductController();

       public Display()
        {
            Input();
        }
        
        public void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1.List all entries");
            Console.WriteLine("2.Add new entries");
            Console.WriteLine("3.Update entries");
            Console.WriteLine("4.Fetch entrie by ID");
            Console.WriteLine("5.Delete entrie by ID");
            Console.WriteLine("6.Exit");
        }
        private void Input()
        {
            int closeOperationId = 6;
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1: ListAll();break;
                    case 2: Add();break;
                    case 3: Update(); break;
                    case 4: Fetch();break;
                    case 5: Delete();break;
                default :break;
                }

            } while (operation != closeOperationId);
        }

        private void Delete()
        {
            Console.WriteLine("Enter ID to delete:");
            int id = int.Parse(Console.ReadLine());
            
            productControler.Delete(id);
            Console.WriteLine("Done.");
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch:");
            int id = int.Parse(Console.ReadLine());
            Product product = productControler.Get(id);
            
            if (product != null)
            {
                Console.WriteLine("ID {0}",product.Id);
                Console.WriteLine("Name {0}",product.Name);
                Console.WriteLine("Price {0}",product.Price);
                Console.WriteLine("Stock {0}",product.Stock);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }

        private void Update()
        {
            Console.WriteLine("Enter id");
            var id = int.Parse(Console.ReadLine());
            Product product = productControler.Get(id);

            if (product != null)
            {
                
                Console.WriteLine("Enter name product");
                product.Name = Console.ReadLine();
                Console.WriteLine("Enter price product");
                product.Price = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter stock");
                product.Stock = int.Parse(Console.ReadLine());

                

                productControler.Update(product);
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }

        private void Add()
        {
            Product product = new Product();
            Console.WriteLine("Enter name product");
            string name = Console.ReadLine();
            Console.WriteLine("Enter price product");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter stock");
            int stock = int.Parse(Console.ReadLine());

            product.Name = name;
            product.Price = price;
            product.Stock = stock;

            productControler.Add(product);

        }

        private void ListAll()
        {
            Console.WriteLine(new string(' ', 18) + "ALL PRODUCTS" + new string(' ', 18));
            Console.WriteLine();
            var productsAll = productControler.GetAll();
            foreach (var product in productsAll)
            {
                Console.WriteLine("{0} {1} {2} {3}",product.Id,product.Name,product.Price,product.Stock);
            }
        }
    }
    
}
