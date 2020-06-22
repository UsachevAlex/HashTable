using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HashTable
{
    public class HashTableGraphics<T> : HashTable<T>
    {
        public void Draw(Panel panel)
        {
            SolidBrush brush = new SolidBrush(Color.Red);
            Graphics graphics = panel.CreateGraphics();
            double k = GetK(panel.Width);
            for (int i = 0; i < table.Length; i++)
            {
                graphics.FillRectangle(brush, 0, i * 2, (int)(table[i].Count * k) - 20, 2);
            }
        }
        private double GetK(int size)
        {
            int max = table[0].Count;
            foreach (var item in table)
                if (item.Count > max)
                    max = item.Count;
            return size / max;
        }
    }
}
