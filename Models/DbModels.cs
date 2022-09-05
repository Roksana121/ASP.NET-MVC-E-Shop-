using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_Shop.Models
{
    public class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }
        [Key]
        public int CategoryId { get; set; }
        [Required, StringLength(50), Display(Name = "Category")]
        public string CategoryName { get; set; }
        
        //nev
        public virtual ICollection<Product> Products { get; set; }
    }
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required, StringLength(50), Display(Name = "ProductName")]
        public string ProductName { get; set; }

        [Required, Column(TypeName = "money"), DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }
       
        [Required(ErrorMessage = "Cannot Be Blank")]
        public int Quantity { get; set; }

       
        public bool isAvailable { get; set; }

        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SalesDate { get; set; }

        [Display(Name = "ProductPhoto")]
        public string ProductPhoto { get; set; }
        //fk
        [Required, ForeignKey("Category")]
        public int CategoryId { get; set; }
        
        //nev
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required, StringLength(40), Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "The Email is required!!!")]
        [DataType(DataType.EmailAddress), EmailAddress]
        [Display(Name = "E-mail Address")]
        public string Email { get; set; }
       
        [Required(ErrorMessage = "Cannot Be Blank")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Cannot Be Blank")]
        public string PhoneNo { get; set; }

        //nev
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
    public class OrderDetail
    {
        [Key]
        public int OrderId { get; set; }

        [Required, Column(TypeName = "money"), DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Cannot Be Blank")]
        public int Quantity { get; set; }

        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }       
        
       
        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        
        [ForeignKey("Products")]
        public int ProductId { get; set; }

        //nev
        public virtual Product Products { get; set; }
        public virtual Customer Customers { get; set; }
    }

    public class E_ShopDbContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}