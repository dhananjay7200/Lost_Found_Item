using MVC_Lost_Found.Interfaces;
using MVC_Lost_Found.Models;

namespace MVC_Lost_Found.Repository
{
    public class ItemRepo : ItemInterface
    {
        private readonly LostandFoundContext _context;

        public ItemRepo(LostandFoundContext context)
        {
            _context = context;
        }
        public Item AddFoundItem(Item item)
        {
           _context.Items.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Item AddLostItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return item;
        }

        public List<Item> SearchItemByFloor(Item item)
        {
            return _context.Items.Where(x => x.FloorDetails.Equals(item.FloorDetails) && x.IsFound==1 && x.IsDeleted==0 ).ToList();
        }
    }
}
