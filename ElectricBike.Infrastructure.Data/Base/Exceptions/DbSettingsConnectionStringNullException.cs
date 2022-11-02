using System.Runtime.Serialization;

namespace ElectricBike.Infrastructure.Data.Base.Exceptions
{
    [Serializable]
    public class DbSettingsConnectionStringNullException : Exception
    {
        public DbSettingsConnectionStringNullException()
        {
        }

        public DbSettingsConnectionStringNullException(string message) : base(message)
        {
        }

        public DbSettingsConnectionStringNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DbSettingsConnectionStringNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}