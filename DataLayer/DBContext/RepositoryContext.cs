using BusinessModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DBContext
{
    public class RepositoryContext : DbContext
    {
        public virtual DbSet<Employee> Employee { get; set; }
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

    }
}
