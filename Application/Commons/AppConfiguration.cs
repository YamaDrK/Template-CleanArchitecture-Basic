namespace Application.Commons
{
    public class AppConfiguration
    {
        public DatabaseConfig DatabaseConfig { get; set; } = null!;
        public JwtConfig JwtConfig { get; set; } = null!;
    }

    public class DatabaseConfig
    {
        public string ConnectionString { get; set; } = string.Empty;
        public bool IsMemoryDB { get; set; } = false;
    }

    public class JwtConfig
    {
        public string SecretKey { get; set; } = string.Empty;
        public int ExpireTimeInDays { get; set; } = 30;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
    }

    public class EmailConfig
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
