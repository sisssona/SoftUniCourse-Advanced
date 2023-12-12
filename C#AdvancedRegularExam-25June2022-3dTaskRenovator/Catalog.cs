using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Renovators
{
    public class Catalog
    {
        private string name;
        private int neededRenovators;
        private string project;
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            renovators = new List<Renovator>();
        }

        public string Name { get; private set; }
        public int NeededRenovators { get; private set; }
        public string Project { get; private set; }
        public IReadOnlyCollection<Renovator> Renovators => this.renovators;
        public int Count => Renovators.Count;
        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            if (Count == NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }
        public bool RemoveRenovator(string name)
        {
            var renovatorToRemove = Renovators.FirstOrDefault(r => r.Name == name);
            if (renovatorToRemove == null)
            {
                return false;
            }
            renovators.Remove(renovatorToRemove);
            return true;
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            int count = 0;
            while (Renovators.FirstOrDefault(r => r.Type == type) != null)
            {
                var renovatorToRemove = Renovators.FirstOrDefault(r => r.Type == type);
                renovators.Remove(renovatorToRemove);
                count++;
            }
            return count;
        }

        public Renovator HireRenovator(string name)
        {
            var hired = Renovators.FirstOrDefault(r => r.Name == name);
            if (hired == null)
            {
                return null;
            }
            Renovators.FirstOrDefault(r => r.Name == name).Hired = true;
            return hired;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> paidRenovatorsList = new List<Renovator>();
            foreach (var renovator in Renovators.Where(r => r.Days >= days))
            {
                paidRenovatorsList.Add(renovator);
            }
            return paidRenovatorsList;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {this.Project}:");
            foreach (var item in this.Renovators.Where(x => x.Hired == false))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }


    }
}
