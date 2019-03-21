using ANightsTale.Library;
using ANightsTale.Library.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANightsTale.DataAccess.Repos
{
    public class ItemRepository : IItemRepository
    {
        private readonly ANightsTaleContext _db;

        public ItemRepository(ANightsTaleContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void CreateItem(Library.Item item)
        {
            _db.Add(Mapper.Map(item));
        }

        public void CreateIventory(Library.Inventory inventory)
        {
            _db.Add(Mapper.Map(inventory));
        }

        public void DeleteInventory(int id)
        {
            _db.Remove(_db.Inventory.Find(id));
        }

        public void DeleteItem(int id)
        {
            _db.Remove(_db.Item.Find(id));
        }

        public IEnumerable<Library.Inventory> GetAllInvetories()
        {
            return Mapper.Map(_db.Inventory);
        }

        public IEnumerable<Library.Item> GetAllItems()
        {
            return Mapper.Map(_db.Item);
        }

        public Library.Item GetItemById(int id)
        {
            return Mapper.Map(_db.Item.AsNoTracking().First(r => r.ItemId == id));
        }

        public Library.Item GetItemByName(string name)
        {
            return Mapper.Map(_db.Item.AsNoTracking().First(r => r.Name == name));
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void UpdateInventory(Library.Inventory inventory)
        {
            _db.Entry(_db.Inventory.Find(inventory.ItemID, inventory.CharacterID)).CurrentValues.SetValues(Mapper.Map(inventory));
        }

        public void UpdateItem(Library.Item item)
        {
            _db.Entry(_db.Item.Find(item.ItemID)).CurrentValues.SetValues(Mapper.Map(item));
        }
    }
}
