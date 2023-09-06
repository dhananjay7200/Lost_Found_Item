using MVC_Lost_Found.Models;

namespace MVC_Lost_Found.Interfaces
{
    public interface IUserdetails
    {

        Userdetail UserLogin(Userdetail user);
        Userdetail UserReagister(Userdetail Udata);

        IEnumerable<Item> UserProfile(String name);
    }
}
