using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class HashTable<T>
    {
        protected List<Subscriber>[] table = new List<Subscriber>[256];
        public bool IsHashParam { get; set; } = false;
        public int[] Params { get; } = { 1, 1, 1 };

        public HashTable()
        {
            for (int i = 0; i < table.Length; i++)
                table[i] = new List<Subscriber>();
                
        }
        public void Add(Subscriber value)
        {
            if (IsHashParam)
                table[HashParam(value.Key)].Add(value);
            else
                table[Hash(value.Key)].Add(value);
        }
        public Subscriber Find(string key)
        {
            List<Subscriber> ls = null;
            if (IsHashParam)
                ls = table[HashParam(key)];
            else
                ls = table[Hash(key)];
            foreach (var item in ls)
                if (item.Key == key)
                    return item;
            return null;
        }
        private byte Hash(string s)
        {
            if (int.TryParse(s, out int key))
                return (byte)(key % 256);
            else
                return 0;
        }
        private byte HashParam(string s)
        {
            if (int.TryParse(s, out int key))
                return (byte)(key * Params[0] * Params[1] * Params[2] % 256);
            else
                return 0;
        }
    }
}
