﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace WebApplication1.Models
{
    public class ToDoListContext : DbContext
    {
        public virtual DbSet<Item> Items { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<itemcategories> itemcategories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ToDoList;integrated security = true");
        }

    }
}
