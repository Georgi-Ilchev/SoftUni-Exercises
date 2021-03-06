using System.Collections.Generic;

namespace Pr._08.CollectionHierarchy.Interfaces
{
    public interface IMyList<T> : IAddRemoveCollection<T>
    {
        public IReadOnlyCollection<T> Used { get; }
    }
}
