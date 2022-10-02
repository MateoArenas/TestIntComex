using Microsoft.EntityFrameworkCore;
using TestIntComex.Core.Entities;

namespace TestIntComex.Infrastructure.Data
{
    public class IntComexContext : DbContext
    {
        public IntComexContext(DbContextOptions<IntComexContext> options):base(options)
        {
        }

        public DbSet<TbContact> TbContact { get; set; }
        public DbSet<TbContactType> TbContactType { get; set; }


    }
}
