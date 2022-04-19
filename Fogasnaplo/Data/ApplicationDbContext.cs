using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Fogasnaplo.Models;

namespace Fogasnaplo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Fogasnaplo.Models.Fogas> Fogas { get; set; }
        public DbSet<Fogasnaplo.Models.Users> User { get; set; }
    }
}
