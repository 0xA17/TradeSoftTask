namespace TradeSoftTask.Configs;

static class DbConnectionString
{
    private const String Server = "localhost";

    private const String Port = "5432";

    private const String UserId = "postgres";

    private const String Password = "123";

    private const String Database = "TradeSoftTask";

    public const String ConnectionString = $"Server={Server};Port={Port};User Id={UserId};Password={Password};Database={Database}";
}