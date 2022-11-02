using ElectricBike.Infrastructure.Data.Base.Exceptions;

namespace ElectricBike.Infrastructure.Data.Base.Configuration
{
    public class DbSettings
    {
        public string ConnectionString { get; set; }

        public void CopyFrom(DbSettings options)
        {
            if (options is null or null)
                throw new DbSettingsNullException($"Parameter: {nameof(options)} required");
            ConnectionString = options.ConnectionString ?? throw new DbSettingsConnectionStringNullException($"Parameter: {nameof(options.ConnectionString)} required");
        }
    }
}