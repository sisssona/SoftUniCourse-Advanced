using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace ClothesMagazine
{
    public class Magazine
    {
        public Magazine(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Clothes = new List<Cloth>();
        }

        public string Type { get; private set; }
        public int Capacity { get; private set; }
        public List<Cloth> Clothes { get; private set; }

        public void AddCloth(Cloth cloth)
        {
            if (Clothes.Count < Capacity)
            {
                Clothes.Add(cloth);
            }
        }
        public bool RemoveCloth(string color) => Clothes.Remove(Clothes.FirstOrDefault(x => x.Color == color));
        public Cloth GetSmallestCloth() => Clothes.MinBy(x => x.Size);
        public Cloth GetCloth(string color) => Clothes.FirstOrDefault(x => x.Color == color);
        public int GetClothCount() => Clothes.Count;
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Type} magazine contains:");
            foreach (var cloth in Clothes.OrderBy(x => x.Size))
            {

                sb.AppendLine(cloth.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
