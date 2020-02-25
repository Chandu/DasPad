using Xunit;

namespace DasPad.Specs.MocksSpecs
{
  public class TrieNodeSpecs
  {
    public class TrieNode
    {
      public TrieNode() : this('^')
      {
      }

      public TrieNode(char c)
      {
        CurChar = c;
      }

      public char CurChar { get; }
      public readonly TrieNode[] Children = new TrieNode[26];
      public bool HasEnd { get; set; }
      private const int AIndex = 'a';

      public TrieNode GetNode(char c)
      {
        var index = c - AIndex;
        return Children[index];
      }

      private TrieNode EnsureAndGetNode(char c)
      {
        var index = c - AIndex;
        if (Children[index] == null)
        {
          Children[index] = new TrieNode(c);
        }
        return Children[index];
      }

      public void Insert(string s)
      {
        if (s != null && s.Length > 0)
        {
          var curChar = s[0];
          var node = EnsureAndGetNode(curChar);
          node.Insert(s.Substring(1));

          if (s.Length == 1)
          {
            node.HasEnd = true;
          }
        }
      }

      public override string ToString()
      {
        return CurChar.ToString();
      }
    }

    public class Trie
    {
      /** Initialize your data structure here. */

      public Trie()
      {
      }

      private readonly TrieNode root = new TrieNode();
      /** Inserts a word into the trie. */

      public void Insert(string word)
      {
        root.Insert(word);
      }

      /** Returns if the word is in the trie. */

      public bool Search(string word)
      {
        if (word == null || word.Length < 1)
        {
          return false;
        }
        var index = 0;
        TrieNode node = root;

        while (index < word.Length)
        {
          node = node.GetNode(word[index]);
          if (node == null)
          {
            return false;
          }
          index++;
        }
        return (node != null) && node.HasEnd;
      }

      /** Returns if there is any word in the trie that starts with the given prefix. */

      public bool StartsWith(string word)
      {
        if (word == null || word.Length < 1)
        {
          return false;
        }
        var index = 0;
        TrieNode node = root;// root.GetNode(word[index]);

        while (index < word.Length)
        {
          node = node.GetNode(word[index]);
          if (node == null)
          {
            return false;
          }
          index++;
        }
        return (node != null);
      }
    }

    [Fact]
    public void CanBuildTrieNode()
    {
      Trie trie = new Trie();

      trie.Insert("apple");
      Assert.True(trie.Search("apple"));   // returns true
      Assert.False(trie.Search("app"));     // returns false
      Assert.True(trie.StartsWith("app")); // returns true
      trie.Insert("app");
      Assert.True(trie.Search("app"));     //
    }
  }
}
