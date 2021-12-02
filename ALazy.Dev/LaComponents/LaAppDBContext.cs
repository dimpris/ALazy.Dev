using ALazy.Dev.Models;
using ALazy.Dev.Models.LaData;
using Microsoft.EntityFrameworkCore;

namespace ALazy.Dev.LaComponents
{
    public class LaAppDBContext : DbContext
    {
        public DbSet<LaApp> Apps { get; set; }
        public DbSet<LaContext> Contexts { get; set; }
        public DbSet<LaEntity> Entities { get; set; }
        public DbSet<LaMethod> Methods { get; set; }
        public DbSet<LaProperty> Properties { get; set; }

        public LaAppDBContext(DbContextOptions<LaAppDBContext> options) : base(options)
        {
        }
    }
}
