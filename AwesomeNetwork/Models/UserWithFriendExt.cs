using AwesomeNetwork.DAL.Models;

namespace AwesomeNetwork.Models
{
    public class UserWithFriendExt : User
    {
        public bool IsFriendWithCurrent { get; set; }
    }
}
