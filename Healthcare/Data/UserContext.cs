using Healthcare.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public DbSet<UserModel> Users { get; set; }
        
        public Task SaveChangesAsync() => base.SaveChangesAsync();

    }
}
