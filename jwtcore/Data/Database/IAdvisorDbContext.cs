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
    public interface IAdvisorDbContext : IDisposable
    {
        public DbSet<Authentication> Authentications { get; set; }
        public DbSet<Advisor> Advisors { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Level> Levels { get; set; }

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Creates an instance of the configured <see cref="IExecutionStrategy" />.
        /// </summary>
        /// <returns>An <see cref="IExecutionStrategy" /> instance.</returns>
        IExecutionStrategy CreateExecutionStrategy();
    }
}
