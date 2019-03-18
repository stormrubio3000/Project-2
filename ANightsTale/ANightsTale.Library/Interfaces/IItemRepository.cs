using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library.Interfaces
{
    public interface IItemRepository
    {
        void CreateItem();
        void DeleteItem();
        IEnumerable<Character> GetAllItems();
        Character GetItemById(int id);
        Character GetItemByName(string name);
        void SetNumberDice();
        void SetNumberSides();
        void SetMods();
        void SetEffects();
    }
}
