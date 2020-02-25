using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.MocksSpecs
{
  public class LruCacheSpecs
  {
    /*
     * Design and implement a data structure for Least Recently Used (LRU) cache. It should support the following operations: get and put.

      get(key) - Get the value (will always be positive) of the key if the key exists in the cache, otherwise return -1.
      put(key, value) - Set or insert the value if the key is not already present. When the cache reached its capacity, it should invalidate the least recently used item before inserting a new item.

      The cache is initialized with a positive capacity.

      Follow up:
      Could you do both operations in O(1) time complexity?

      Example:

      LRUCache cache = new LRUCache( 2);

      cache.put(1, 1);
      cache.put(2, 2);
      cache.get(1);       // returns 1
      cache.put(3, 3);    // evicts key 2
      cache.get(2);       // returns -1 (not found)
      cache.put(4, 4);    // evicts key 1
      cache.get(1);       // returns -1 (not found)
      cache.get(3);       // returns 3
      cache.get(4);       // returns 4
     */

    public class LRUCache
    {
      public class ListNode
      {
        public int key;
        public int val;
        public ListNode higher;
        public ListNode lower;

        public ListNode(int key, int val)
        {
          this.key = key;
          this.val = val;
          higher = null;
          lower = null;
        }
      }

      private readonly int Capacity;
      private Dictionary<int, ListNode> _dictionary;
      private ListNode _high;
      private ListNode _low;

      public LRUCache(int capacity)
      {
        this.Capacity = capacity;
        this._dictionary = new Dictionary<int, ListNode>();
        this._high = new ListNode(-1, -1);
        this._low = new ListNode(-1, -1);
        this._high.lower = this._low;
        this._low.higher = this._high;
      }

      public int Get(int key)
      {
        if (this._dictionary.ContainsKey(key))
        {
          //bump priority of key
          BumpPriority(key);
          return this._dictionary[key].val;
        }
        else return -1;
      }

      public void Put(int key, int value)
      {
        if (this._dictionary.Count == this.Capacity && !this._dictionary.ContainsKey(key))
        {
          // remove list used
          RemoveLeastUsed();
        }
        if (this._dictionary.ContainsKey(key))
        {
          this._dictionary[key].val = value;
        }
        else
        {
          ListNode node = new ListNode(key, value);
          this._dictionary[key] = node;
        }
        //bump priority of key
        BumpPriority(key);
      }

      // O(1)
      private void BumpPriority(int key)
      {
        ListNode nodeToBump = this._dictionary[key];
        ListNode tempHigher, tempLower, temp;

        tempHigher = nodeToBump.higher;

        tempLower = nodeToBump.lower;

        if (tempLower != null)
        {
          tempHigher.lower = tempLower;
        }
        if (nodeToBump.lower != null)
        {
          tempLower.higher = tempHigher;
        }
        //move nodeToBump all the way up to the head
        temp = this._high.lower;
        this._high.lower = nodeToBump;
        nodeToBump.lower = temp;
        temp.higher = nodeToBump;
        nodeToBump.higher = this._high;
      }

      // O(1)
      private void RemoveLeastUsed()
      {
        ListNode leastUsed = this._low.higher;
        // remove from dictionary
        this._dictionary.Remove(leastUsed.key);
        // remove from linkedlist
        ListNode higherNode = leastUsed.higher;
        higherNode.lower = leastUsed.lower;
        this._low.higher = higherNode;
      }
    }

    [Fact]
    public void CanVerifyLruCache()
    {
      LRUCache cache = new LRUCache(2 /* capacity */ );

      cache.Put(1, 1);
      cache.Put(2, 2);
      Assert.Equal(1, cache.Get(1));       // returns 1
      cache.Put(3, 3);    // evicts key 2
      Assert.Equal(-1, cache.Get(2));       // returns -1 (not found)
      cache.Put(4, 4);    // evicts key 1
      Assert.Equal(-1, cache.Get(1));       // returns -1 (not found)
      Assert.Equal(3, cache.Get(3));       // returns 3
      Assert.Equal(4, cache.Get(4));       // returns 4
    }
  }
}
