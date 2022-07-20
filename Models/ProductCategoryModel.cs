using System.ComponentModel.DataAnnotations;

namespace NetCuisine.Models
{
    public class ProductCategoryModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        
    }
}
