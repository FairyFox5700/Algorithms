namespace APIsAndElementaryImplementations.HashTables
{
    public interface IHashTable<TKey, TValue>
    {
        public TValue Get(TKey key);
        public void Put(TKey key, TValue value);

    }
}