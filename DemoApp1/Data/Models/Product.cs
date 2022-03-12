using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoApp1.Data.Models
{
   public class Product
    {
        public Product()
        {

        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}
