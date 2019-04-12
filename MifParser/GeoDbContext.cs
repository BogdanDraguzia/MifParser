using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace MifParser
{
    public class GeoDbInitializer : DropCreateDatabaseAlways<GeoDbContext>
    {
        public override void InitializeDatabase(GeoDbContext context)
        {
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
                , $"ALTER DATABASE IF EXISTS [{context.Database.Connection.Database}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
            base.InitializeDatabase(context);
        }
    }

    public class GeoDbContext : DbContext
    {
         public static string connectionString =
            @"data source=DRAGONPC;initial catalog=GeoDbContext;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework; Pooling=false;"; 
        static GeoDbContext()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<GeoDbContext>());
            SqlConnection.ClearAllPools();
        }

        //public GeoDbContext()
        //    : base("name=GeoDbContext")
        //{ }
        public GeoDbContext() : base(connectionString)
        {}

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Point> Points { get; set; }
    }
}