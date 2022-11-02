using Microsoft.EntityFrameworkCore;

namespace ElectricBike.Domain.Core.Aggregates
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        
        void UndoChanges();
        
        DbSet<TGenericEntity> Set<TGenericEntity>() where TGenericEntity : class;
        
        void AttachEntity<TGenericEntity>(TGenericEntity item) where TGenericEntity : class;
        
        void SetModified<TGenericEntity>(TGenericEntity item) where TGenericEntity : class;
    }
}

