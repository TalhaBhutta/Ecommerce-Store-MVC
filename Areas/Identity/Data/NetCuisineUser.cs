using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace NetCuisine.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the NetCuisineUser class
    public class NetCuisineUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName="nvarchar(200)")]
        public string Phone { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Role { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }
    }
}
