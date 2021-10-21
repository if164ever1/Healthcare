using Healthcare.Models;
using Microsoft.EntityFrameworkCore;


namespace Healthcare.Data
{
    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions<UserContext> options): base(options)
        { }

        public DbSet<UserModel> Users { get; set; }

    }
}
