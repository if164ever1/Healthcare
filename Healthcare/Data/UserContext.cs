using Healthcare.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Healthcare.Data
{
    public class UserContext: DbContext, IUserContext
    {
        public UserContext()
        {
        }
        public UserContext(DbContextOptions<UserContext> options): base(options)
        { }

        public DbSet<IUserModel> Users { get; set; }

        public DbSet<TokenModel> Tokens { get; set; }

        public Task SaveChangesAsync() => base.SaveChangesAsync();
    }
}
