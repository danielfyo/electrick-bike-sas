using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Microsoft.Extensions.Configuration;

namespace ElectricBike.Infrastructure.Data.Context.Base
{
    public class DbContextBase : DbContext
    {
        private readonly DbContextOptions _options = null!;
        private readonly IConfiguration _config = null!;
        private string _connectionString = null!;
        
        public DbContextBase(IConfiguration config, DbContextOptions options, string connectionString)
        {
            _config = config;
            _options = options;
            _connectionString = connectionString;
            SetStringConnection();
        }
        
        public DbContextBase(IConfiguration config)
        {
            _config = config;
            SetStringConnection();
        }
        
        public DbContextBase(DbContextOptions options) => _options = options;

        public DbContextBase(DbContextOptions options, string connectionString)
        {
            _options = options;
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
#pragma warning disable EF1001
                var extension = _options.FindExtension<SqlServerOptionsExtension>();
#pragma warning restore EF1001
                if (extension is {ConnectionString: { }}) optionsBuilder.UseSqlServer(extension.ConnectionString);

                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
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
            base.ChangeTracker.Entries().ToList()
            .ForEach(e => e.State = EntityState.Detached);
        }
    }
}
