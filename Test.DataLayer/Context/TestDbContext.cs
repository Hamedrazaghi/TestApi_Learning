using Microsoft.EntityFrameworkCore;
using Test.DataLayer.Entitis.Accont;
using Test.DataLayer.Entitis.product;


namespace Test.DataLayer.Context
{
    public class TestDbContext:DbContext
    {
        #region Constructor
        public TestDbContext(DbContextOptions<TestDbContext> options):base(options) { }
        #endregion


        #region DbSet

        public DbSet<User>Users { get; set; }
        public DbSet<Book>Books { get; set; }
        
        #endregion
    }
}
