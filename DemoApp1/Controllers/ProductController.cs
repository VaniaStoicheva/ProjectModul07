using DemoApp1.Data;
using DemoApp1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoApp1.Controllers
{
   public class ProductController
    {
        private ShopingProductsContext context;
        
        public ProductController()
        {
            
        }
        public List<Product> GetAll()
        {
            using(context=new ShopingProductsContext())
            {
                return context.Products.ToList();
            }
            
        }
        public Product Get(int id)
        {
            using(context=new ShopingProductsContext())
            {
                return context.Products.FirstOrDefault(x=>x.Id==id);
            }
           
        }
        public void Add(Product product)
        {
            using (context = new ShopingProductsContext())
            {
                this.context.Add(product);
                this.context.SaveChanges();
            }
              
        }
        public void Update(Product product)
        {
            using (context = new ShopingProductsContext())
            {
                var prod = this.context.Products.Find(product.Id);
               
                    context.Entry(prod).CurrentValues.SetValues(product);
                    context.SaveChanges();
                
                
            }
                

        }
        public void Delete(int id)
        {
           using(context=new ShopingProductsContext())
            {
                var product = context.Products.Find(id);
                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
            }
            
        }
    }
}
