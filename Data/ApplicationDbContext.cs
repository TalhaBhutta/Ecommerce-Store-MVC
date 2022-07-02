﻿
using Microsoft.EntityFrameworkCore;
using NetCuisine.Models;

namespace NetCuisine.DataBase
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<SignUpModel> signUp { get; set; }
    }
}
