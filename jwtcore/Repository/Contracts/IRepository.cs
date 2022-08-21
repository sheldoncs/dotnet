using System;
using System.Threading;
using System.Threading.Tasks;

namespace jwtcore.Repository.Contracts {

    public interface IRepository<TEntity> : IDisposable {

        Task<TEntity> WithTransactionAsync(Func<CancellationToken, Task<TEntity>> execution, CancellationToken cancellationToken = default);

        Task RollbackAsync (CancellationToken cancellationToken = default);

        Task commitAsync(CancellationToken cancellationToken = default);
        
    }

}