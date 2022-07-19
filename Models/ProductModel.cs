using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCuisine.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProductCategory")]
        public int ProductCategoryID { get; set; }
        public virtual ProductCategoryModel ProductCategory { get; set; }
        //[ForeignKey("ProductCategory")]
        //public string ProductCategoryID { get; set; }
        //public virtual ProductCategoryModel ProductCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
    }
}
