using AloKaza.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AloKaza.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<AppLog> AppLogs { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Damage> Damages { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<Slider> Sliders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // OnConfiguring Metodu EntityFrameworkCore ile gelir, veritabanı bağlantılarını (Host) yapmamızı sağlar.

            optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB; Database = AloKaza; Trusted_Connection = True ");

            //optionsBuilder.UseSqlServer(@"Server=CanlıServerAdı; Database=CanlıdakiDatabase; Username=CanlıVeritabanıKullanıcıAdı; Password=CanlıVeritabanıŞifre");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // FluentApı ile veritabanı tablolarımız oluşurken veri tiplerini db kurallarını burada da tanımlayabiliriz.


            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = 1,
                Email = "info@AloKaza.com",
                Password = "123",
                UserGuid = Guid.NewGuid(),
                FullName = "Admin",
                IsActive = true,
                IsAdmin = true,
                IsCorporate = false,
                Phone = "5448504624"
                
            }
                );

            modelBuilder.Entity<Setting>().HasData(new Setting
            {
                Address = "Adres",
                Id = 1,
                Port = 587,
                Email = "yazilim@AloKaza.com",
                Title = "AloKazaCase"
               
            }

                );

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // Uygulamadaki tüm Configurations class'larını burada çalıştır.


            // Katmanlı mimaride MvcWebUI katmanından direk data katmanına erişilmesi istenmez, arada bir iş katmanının tüm db süreçlerini yönetmesi istenir. Bu yüzden solutiona service katmanı ekleyip Mvc katmanından service katmanına erişim vermemiz gerekir. Service katmanı da data katmanına erişir. Data katmanı da core katmanına erişir, böylece MVCUI > Service > Data > Core ile en üstten en alt katmana kadar ulaşılabilmiş olunur.

            base.OnModelCreating(modelBuilder);
        }

    }

    
}
