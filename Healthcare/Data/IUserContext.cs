using Healthcare.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

namespace Healthcare.Data
{
    public interface IUserContext
    {
        public DbSet<UserModel> Users { get; set; }
        Task SaveChangesAsync();

    }
}
