namespace UniqueryPlus
{
    public class RecursiveReturn<T> : RecursiveReturn<byte[], T>;

    /// <summary>
    /// Think of a better name :)
    /// </summary>
    public class RecursiveReturn<K, T>
    {
        public K? LastKey { get; set; }
        public required IEnumerable<T> Items { get; set; }
    }
}
