using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class Subscriber
    {
        public string Key { get; }
        public string Name { get; }
        public string Address { get; }

        public Subscriber(string name, string phone, string address)
        {
            Name = name;
            Key = phone;
            Address = address;
        }
        public override int GetHashCode()
        {
            if (int.TryParse(Key, out int key))
                return key % 256;
            else
                return 0;
        }
    }
}
