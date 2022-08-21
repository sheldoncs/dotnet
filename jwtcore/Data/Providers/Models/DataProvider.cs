using jwtcore.Data.Database;
using jwtcore.Data.Providers.Contracts;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace jwtcore.Data.Providers.Models
{
    public class DataProvider : IDataProvider
    {
        protected ILogger<DataProvider> Logger { get; }
        protected IAdvisorDbContext Context { get; }
        protected DataProvider(
            ILogger<DataProvider> logger, IAdvisorDbContext context)
        {
            Logger = logger;
            Context = context;
        }
        public IDbContextTransaction Transaction => throw new NotImplementedException();

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IExecutionStrategy CreateExecutionStrategy()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IDataProvider WithTransaction(IDbContextTransaction transaction)
        {
            throw new NotImplementedException();
        }
       

    }
}
