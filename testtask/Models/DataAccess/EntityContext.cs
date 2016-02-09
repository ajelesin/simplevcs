using System.Data.Entity;
using testtask.Models.Logic;

namespace testtask.Models.DataAccess
{
    public class EntityContext : DbContext
    {
        public EntityContext() : base("DefaultConnection")
        {
            // nothing to do here
        }

        public DbSet<AssemblyItem> AssemblyItems { get; set; }
        public DbSet<AssemblyHistoryItem> AssemblyHistoryItems { get; set; }
    }
}