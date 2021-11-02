using AutoMapper;
using Healthcare.Data;
using Healthcare.Models;
using System.Linq;

namespace Healthcare.DTO
{
    public class TransferUserData
    {
        private readonly UserContext userContext;
        public TransferUserData()
        {
            userContext = new UserContext();
        }
        public UserDTO GetById(int id)
        {
            var config = new MapperConfiguration(conf =>
            {
                conf.CreateMap<UserModel, UserDTO>();
            });
            var mapper = new Mapper(config);
            var user = userContext.Users.SingleOrDefault(x => x.Id == id);
            return mapper.Map<UserDTO>(user);
        }
    }
}
