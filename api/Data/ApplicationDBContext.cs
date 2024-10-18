using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    // This class represents the database context
    // It's used to interact with the database using Entity Framework Core
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }
        // DbSet represents the customers table in the database
        public DbSet<CusInfo> cusInfos {get; set;}
        
    }
}