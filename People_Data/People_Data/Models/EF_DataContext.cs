using Microsoft.EntityFrameworkCore;

namespace People_Data.Models
{
    public class EF_DataContext :DbContext
    {

       
        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options) { }

        public DbSet<People> peoples { get; set; }

    }
}
