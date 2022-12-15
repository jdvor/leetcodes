namespace LeetCodes.Tests;

using Xunit;

public class Leet146Tests
{
    [Fact]
    public void Test()
    {
        const int capacity = 2;
        var lru = new LRUCache(capacity);

        lru.Put(1, 1);
        lru.Put(2, 2);
        var v = lru.Get(1);
        Assert.Equal(1, v);

        lru.Put(3, 3);
        v = lru.Get(2);
        Assert.Equal(-1, v);

        lru.Put(4, 4);
        v = lru.Get(1);
        Assert.Equal(-1, v);

        v = lru.Get(3);
        Assert.Equal(3, v);

        v = lru.Get(4);
        Assert.Equal(4, v);
    }
}
