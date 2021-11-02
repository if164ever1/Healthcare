using Healthcare.Models;
using System.Runtime.Serialization;

namespace Healthcare.DTO
{
    [DataContract]
    public  class UserDTO: IUserModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}