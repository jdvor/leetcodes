namespace LeetCodes;

/// <summary>
/// https://leetcode.com/problems/lru-cache/
/// </summary>
// ReSharper disable once InconsistentNaming
public sealed class LRUCache
{
    private readonly int capacity;
    private const int MaxCapacity = 3000;
    private readonly Dictionary<int, int> data;
    private readonly LinkedList<int> insertion;
    private readonly object writeLock = new ();

    public LRUCache(int capacity)
    {
        if (capacity is < 1 or > MaxCapacity)
        {
            throw new ArgumentException($"capacity outside of valid range <1, {MaxCapacity}>", nameof(capacity));
        }

        this.capacity = capacity;

        data = new Dictionary<int, int>(capacity);
        insertion = new LinkedList<int>();
    }

    public int Get(int key)
    {
        if (data.TryGetValue(key, out var v))
        {
            return v;
        }

        return -1;
    }

    public void Put(int key, int value)
    {
        lock (writeLock)
        {
            if (data.ContainsKey(key))
            {
                data[key] = value;
                return;
            }

            if (insertion.Count >= capacity)
            {
                var newestKey = insertion.Last!.Value;
                data.Remove(newestKey);
                insertion.RemoveLast();
            }

            data[key] = value;
            insertion.AddLast(key);
        }
    }
}
