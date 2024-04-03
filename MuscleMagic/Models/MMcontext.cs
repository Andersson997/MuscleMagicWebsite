using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MuscleMagic.Models;

namespace MuscleMagic.Models
{
    public class MMcontext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Exerciseschedule> Programs { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        

        public MMcontext()
        {
            Database.EnsureCreated();
           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("DataSource = MM_DB.db");
            
        }
            
     
    }
}

