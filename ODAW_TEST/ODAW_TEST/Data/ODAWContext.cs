using ODAW_TEST.Models;
using Microsoft.EntityFrameworkCore;

namespace ODAW_TEST.Data
{
    public class ODAWContext: DbContext
    {
        public DbSet<Test> tests { get; set; }

        public ODAWContext(DbContextOptions<ODAWContext> options) : base(options) { }
    }
}
