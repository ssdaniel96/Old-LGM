// ReSharper disable UnusedAutoPropertyAccessor.Local

using LGM.Domain.Entities.Groups;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LGM.Repository.Context
{
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<Group> Groups { get; private set; }

#pragma warning disable CS8618 
        public ApplicationDbContext(DbContextOptions options) : base(options)
#pragma warning restore CS8618 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}