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

        public DbSet<Text> Texts { get; set; }
    }
}
