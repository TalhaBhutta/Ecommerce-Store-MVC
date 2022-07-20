using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCuisine.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
