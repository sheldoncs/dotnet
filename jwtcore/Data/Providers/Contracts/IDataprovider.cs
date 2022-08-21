using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace jwtcore.Data.Providers.Contracts
{
    public interface IDataProvider : IDisposable
    {
        public IDbContextTransaction Transaction { get; }

        IExecutionStrategy CreateExecutionStrategy();

        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

        /// <summary>
        ///     Stores in memory a transaction
        /// </summary>
        /// <param name="transaction">The transaction to store</param>
        /// <returns>This instance.</returns>
        IDataProvider WithTransaction(IDbContextTransaction transaction);
    }
}
