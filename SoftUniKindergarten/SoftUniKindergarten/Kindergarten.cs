using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();           
        }
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public List<Child> Registry { get; private set; }

        public bool AddChild(Child child)
        {
            if (this.ChildrenCount < this.Capacity)
            {
                Registry.Add(child);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveChild(string childFullName) => Registry.Remove(Registry.FirstOrDefault(ch => ch.FirstName + " " + ch.LastName == childFullName));
       public int ChildrenCount => Registry.Count;
        public Child GetChild(string childFullName) => Registry.FirstOrDefault(ch => ch.FirstName + " " + ch.LastName == childFullName);

        public string RegistryReport()
        {
            List<Child> list = Registry.OrderByDescending(ch => ch.Age).ThenBy(ch => ch.LastName).ThenBy(ch => ch.FirstName).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Registered children in {Name}:");
            foreach (Child child in list)
            {
            sb.AppendLine(child.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}