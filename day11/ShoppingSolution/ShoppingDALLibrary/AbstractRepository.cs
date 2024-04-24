using ShoppingModelLibrary.Exceptions;
namespace ShoppingDALLibrary
{
    public abstract class AbstractRepository<K, T> : IRepository<K, T>
    {
        protected IList<T> items = new List<T>();
        public T? Add(T item)
        {
            if(items.Contains(item))
            {
                throw new ItemPresentException();
            }
            items.Add(item);
            return item;
        }
        public ICollection<T> GetAll()
        {
            return items.ToList<T>();
        }

        public abstract T Delete(K key);



        public abstract T GetByKey(K key);

        public abstract T Update(T item);

    }
}
