using exam.Models.Drivers.Contracts;

namespace exam.Models.Races.Contracts
{
    using System.Collections.Generic;

    public interface IRace
    {
        string Name { get; }

        int Laps { get; }

        IReadOnlyCollection<IDriver> Drivers { get; }

        void AddDriver(IDriver driver);
    }
}