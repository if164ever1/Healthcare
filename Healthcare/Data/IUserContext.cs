using Healthcare.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Healthcare.Data
{
    public interface IUserContext
    {
        public DbSet<IUserModel> Users { get; set; }
        Task SaveChangesAsync();

    }
}
