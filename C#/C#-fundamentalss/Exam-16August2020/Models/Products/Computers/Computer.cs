using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components =>
            (IReadOnlyCollection<IComponent>)this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals =>
            (IReadOnlyCollection<IPeripheral>)this.peripherals;

        public void AddComponent(IComponent component)
        {
            if (this.Components.Any(x => x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }
            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.Peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }
            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
            //if (!this.Components.Any() || !this.Components.Any(c => c.GetType().Name == componentType))
            if (this.Components.Count == 0 || component == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }
            this.components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var periperal = this.Peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            //if (!this.Peripherals.Any() || !this.Peripherals.Any(p => p.GetType().Name == peripheralType))
            if (this.peripherals.Count == 0 || periperal == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }
            this.peripherals.Remove(periperal);
            return periperal;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($" Components ({this.components.Count}):");
            foreach (var component in this.Components)
            {
                sb.AppendLine($"  {component.ToString()}");
            }

            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({this.CalculateOverallPerformance():F2}):");
            foreach (var peripheral in this.Peripherals)
            {
                sb.AppendLine($"  {peripheral.ToString()}");
            }

            return base.ToString() + Environment.NewLine + sb.ToString().TrimEnd();
        }

        public override double OverallPerformance => this.components.Count == 0 ? base.OverallPerformance
                          : base.OverallPerformance + this.components.Average(x => x.OverallPerformance);

        public override decimal Price => this.peripherals.Sum(x => x.Price) +
                                         this.components.Sum(x => x.Price);
                                          // + base.Price;
        
        //this.CalculatePrice();

        private decimal CalculatePrice()
        {
            var result = base.Price;

            if (this.Components.Any())
            {
                result += this.components
                    .Sum(x => x.Price);
            }

            if (this.Peripherals.Any())
            {
                result += this.peripherals
                    .Sum(x => x.Price);
            }

            return result;
        }

        private double CalculateOverallPerformance() => this.peripherals.Count == 0 ? 0
            : this.peripherals.Average(x => x.OverallPerformance);
    }
}
