using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTerm
{
    public class Inventory
    {
        private Dictionary<string, int> items = new Dictionary<string, int>();

        public void AddItem(string item)
        {
            if (items.ContainsKey(item))
            {
                items[item]++;
            }
            else
            {
                items.Add(item, 1);
            }
            Console.WriteLine($"You acquired a {item}.");
        }

        public bool HasItem(string item)
        {
            return items.ContainsKey(item) && items[item] > 0;
        }
    }
}
