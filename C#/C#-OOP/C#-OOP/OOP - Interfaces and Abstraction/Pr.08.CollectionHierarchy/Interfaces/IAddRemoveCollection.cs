namespace Pr._08.CollectionHierarchy.Interfaces
{
    public interface IAddRemoveCollection<T> : IAddCollection<T>
    {
        public T Remove();
    }
}
