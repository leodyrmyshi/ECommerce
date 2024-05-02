using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dyrmyshi.leo._5h.ECommerce.Models;

    public class dbContext : DbContext
    {
        public dbContext (DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public DbSet<Piade> Piade { get; set; } = default!;
        private readonly DbContextOptions? _options;
        public dbContext(){}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite("Data Source=dbContext-6d8ab487-cd8d-462b-8817-ab48b55d6b26.db");

                public DbSet<Utente> Utenti{get;set;}
    }
