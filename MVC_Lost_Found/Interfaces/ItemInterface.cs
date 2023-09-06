using MVC_Lost_Found.Models;

namespace MVC_Lost_Found.Interfaces
{
    public interface ItemInterface
    {
        Item AddLostItem(Item item);
       
        Item AddFoundItem(Item item);

        List<Item> SearchItemByFloor(Item item);
    }
}
