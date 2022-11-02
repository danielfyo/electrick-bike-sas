using System.Runtime.Serialization;

namespace ElectricBike.Infrastructure.Data.Base.Exceptions
{
    [Serializable]
    public class DbSettingsNullException : Exception
    {
        public DbSettingsNullException()
        {
        }

        public DbSettingsNullException(string message) : base(message)
        {
        }

        public DbSettingsNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DbSettingsNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}