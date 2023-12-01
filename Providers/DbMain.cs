using Microsoft.EntityFrameworkCore;
using TradeSoftTask.Configs;
using TradeSoftTask.MVVM.Model;
using TradeSoftTask.Utilities;

namespace TradeSoftTask.Providers;

class DbMain : DbContext
{
    public DbSet<ProductModel> Products { get; set; }

    public DbMain()
    {
        TryEnsureCreated();
    }

    private void TryEnsureCreated()
    {
        try
        {
            Database.EnsureCreated();
        }
        catch (Exception ex)
        {
            Logger.ShowMessage(ex.Message);
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(DbConnectionString.ConnectionString);
    }
}