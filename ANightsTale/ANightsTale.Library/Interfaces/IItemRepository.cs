using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library.Interfaces
{
    public interface IItemRepository
    {
        void CreateItem(Item item);
        void DeleteItem(int id);

        IEnumerable<Item> GetAllItems();
        Item GetItemById(int id);
        Item GetItemByName(string name);

        void UpdateItem(Item item);

        void CreateIventory(Inventory inventory);
        void DeleteInventory(int id);

        IEnumerable<Inventory> GetAllInvetories();

        void UpdateInventory(Inventory inventory);

        void Save();
    }
}
