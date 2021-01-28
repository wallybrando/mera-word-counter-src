using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mera.WordCounter.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mera.WordCounter.Server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Text>().HasData(
                    new Text() { Id = 1, Content = "One morning, . ,  when Gregor Samsa woke" },
                    new Text() { Id = 2, Content = "from   troubled dreams, he found himself" },
                    new Text() { Id = 3, Content = "transformed in his bed into a    horrible vermin." },
                    new Text() { Id = 4, Content = "He lay on his" },
                    new Text() { Id = 5, Content = "armour-like back, and if he lifted his head a little he could see" },
                    new Text() { Id = 6, Content = "his brown, .  belly, slightly domed and ,,,, divided by" },
                    new Text() { Id = 7, Content = "arches into stiff sections." },
                    new Text() { Id = 8, Content = "The bedding .. was hardly    able to cover" },
                    new Text() { Id = 9, Content = "it and seemed" },
                    new Text() { Id = 10, Content = " ready to slide off any moment." }
                );
        }

        public DbSet<Text> Texts { get; set; }
    }
}
