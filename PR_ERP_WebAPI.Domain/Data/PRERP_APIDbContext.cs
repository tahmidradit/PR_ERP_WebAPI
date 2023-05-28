using Microsoft.EntityFrameworkCore;
using PR_ERP_WebAPI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_ERP_WebAPI.Domain.Data
{
    public class PRERP_APIDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public PRERP_APIDbContext(DbContextOptions<PRERP_APIDbContext> options) : base(options) { }
    }
}
