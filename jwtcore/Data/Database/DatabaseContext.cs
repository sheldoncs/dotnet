using jwtcore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace jwtcore.Data.Database
{
    public partial class DatabaseContext : DbContext, IAdvisorDbContext
    {
         
        
        
        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt)
        {

        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
             CancellationToken cancellationToken = new CancellationToken())
        {
           
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {

            return await base.SaveChangesAsync(cancellationToken);
        }
      
        public IExecutionStrategy CreateExecutionStrategy()
        {
            return Database.CreateExecutionStrategy();
        }

        partial void BuildAdvisorTransaction(ModelBuilder modelBuilder);

    }
}
