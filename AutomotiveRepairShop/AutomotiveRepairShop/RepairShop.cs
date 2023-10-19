using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
       private List<Vehicle> vehicles;
        private int capacity;
        public RepairShop(int capacity)
        {
            this.Capacity= capacity;
            this.Vehicles = new List<Vehicle>();
        }
        public int Capacity { get; private set; }
        public List<Vehicle> Vehicles { get; private set; }

        public void AddVehicle(Vehicle vehicle) 
        {
            if (Vehicles.Count < Capacity)
            {
                Vehicles.Add(vehicle);
            }
        }
        public bool RemoveVehicle(string vin) => Vehicles.Remove(Vehicles.FirstOrDefault(v => v.VIN == vin));   

        public int GetCount() => Vehicles.Count;

        public Vehicle GetLowestMileage() => Vehicles.MinBy(x => x.Mileage);

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vehicles in the preparatory:");
            foreach (Vehicle v in Vehicles)
            {
                sb.AppendLine(v.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
