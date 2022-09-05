using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_Shop.Models.ViewModels
{
    public class ProductVM
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
        [StringLength(500)]
        public string ProductPhoto { get; set; }
        //fk
        [Required, ForeignKey("Category")]
        public int CategoryId { get; set; }
         
        //nev
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public HttpPostedFileBase Picture { get; set; }

    }
}
