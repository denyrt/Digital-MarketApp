using static System.Environment;

namespace DigitalMarket.Domain.Constants
{
    public static class EnvironmentConstants
    {
        private const System.EnvironmentVariableTarget Machine = System.EnvironmentVariableTarget.Machine;

        public static string DbConnectionString => GetEnvironmentVariable("DIGITAL_DATABASE", Machine);

        public static string SendGridEmail => GetEnvironmentVariable("SEND_GRID_EMAIL", Machine);

        public static string SendGridUser => GetEnvironmentVariable("SEND_GRID_USER", Machine);

        public static string SendGridKey => GetEnvironmentVariable("SEND_GRID_KEY", Machine);

        public static string BackendHost => GetEnvironmentVariable("DIGITAL_BACKEND_HOST", Machine);
    }
}