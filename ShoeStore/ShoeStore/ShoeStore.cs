using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeStore
{
    public class ShoeStore
    {
        public ShoeStore(string name, int storageCapacity)
        {
            this.Name = name;
            this.StorageCapacity = storageCapacity;
            Shoes = new List<Shoe>();
        }

        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        public List<Shoe> Shoes { get; set; }

        public int GetterCount() { return Shoes.Count; }
        public string AddShoe(Shoe shoe)
        {
            if (Shoes.Count == StorageCapacity)
            {
                return "No more space in the storage room.";
            }
            Shoes.Add(shoe);
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";

        }
        public int RemoveShoes(string material) => Shoes.RemoveAll(sh => sh.Material == material);

        public List<Shoe> GetShoesByType(string type)
        {
            List<Shoe> typeShoes = new List<Shoe>();
            foreach (var shoe in Shoes)
            {
                if (shoe.Type == type.ToLower())
                {
                    typeShoes.Add(shoe);
                }
            }
            return typeShoes;
        }
        public Shoe GetShoeBySize(double size) => Shoes.FirstOrDefault(sh => sh.Size == size);

        public string StockList(double size, string type)
        {
            List<Shoe> stockList = this.Shoes.Where(sh => sh.Size == size && sh.Type == type).ToList();
            StringBuilder sb = new StringBuilder();
            if (stockList.Count > 0)
            {
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");
                foreach (var shoe in stockList)
                {
                    sb.AppendLine(shoe.ToString());
                }
            }
            else
            {
                return "No matches found!";
            }

            return sb.ToString().TrimEnd();
        }
    }
}
