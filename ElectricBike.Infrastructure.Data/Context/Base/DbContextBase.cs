using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Microsoft.Extensions.Configuration;

namespace ElectricBike.Infrastructure.Data.Context.Base
{
    public class DbContextBase : DbContext
    {
        private readonly DbContextOptions _options;
        private readonly IConfiguration _config;
        private string _connectionString;
        
        public DbContextBase(IConfiguration config) : base()
        {
            _config = config;
            SetStringConnection();
        }

        public DbContextBase(DbContextOptions options) => _options = options;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_options != null)
            {
                try
                {
                    var extension = _options.FindExtension<SqlServerOptionsExtension>();
                    if (extension != null)
                    {
                        optionsBuilder.UseSqlServer(extension.ConnectionString);
                    }
                    
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            
            SetStringConnection();
            optionsBuilder.UseSqlServer(_connectionString);
        }

        private void SetStringConnection() => _connectionString = _config.GetConnectionString("DefaultConnection");

        public new DbSet<TGenericEntity> Set<TGenericEntity>() where TGenericEntity : class => base.Set<TGenericEntity>();

        public void AttachEntity<TGenericEntity>(TGenericEntity item) where TGenericEntity : class
        {
            if (Entry(item).State == EntityState.Detached)
                base.Set<TGenericEntity>().Attach(item);
        }

        public void SetModified<TGenericEntity>(TGenericEntity item) where TGenericEntity : class => Entry(item).State = EntityState.Modified;

        public int Commit() => base.SaveChanges();

        public void UndoChanges()
        {
            base.ChangeTracker.Entries()
            .Where(e => e.Entity != null).ToList()
            .ForEach(e => e.State = EntityState.Detached);
        }
    }
}
