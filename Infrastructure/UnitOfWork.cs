using Domain.IReposiotories;

namespace Infrastructure
{
    internal class UnitOfWork : IUnitOfWork
    {
        public Task<int> SaveChangesAsync(CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }
    }
}
    