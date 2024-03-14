using FutureProjects.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace FutureProjects.Infrastructure.Persistance
{

    public class FutureProjectsDbContext : DbContext
    {
        public FutureProjectsDbContext(DbContextOptions<FutureProjectsDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }



        public virtual DbSet<User> Users { get; set; }
    }


    //public class MyDbContextFactory : IDesignTimeDbContextFactory<FutureProjectsDbContext>
    //{
    //    private readonly IConfiguration _conf;

    //    public MyDbContextFactory(IConfiguration conf)
    //    {
    //        _conf = conf;
    //    }

    //    public FutureProjectsDbContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<FutureProjectsDbContext>();
    //        optionsBuilder.UseNpgsql(_conf.GetConnectionString("FutureProjectsConnectionString"));
    //        throw new System.NotImplementedException();
    //    }
    //}
}
