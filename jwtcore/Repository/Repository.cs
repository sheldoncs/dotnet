using jwtcore.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace jwtcore.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
    {
        public Task commitAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> WithTransactionAsync(Func<CancellationToken, Task<TEntity>> execution, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
