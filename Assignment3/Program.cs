public class MyHashTable<K, V>
{
    private class HashNode<K, V>
    {
        public K key;
        public V value;
        public HashNode<K, V> next;

        public HashNode(K key, V value)
        {
            this.key = key;
            this.value = value;
        }

        public override string ToString()
        {
            return "{" + key.ToString() + " " + value.ToString() + "}";
        }
    }

    private HashNode<K, V>[] chainArray;
    private int M = 11;
    private int size;

    public MyHashTable()
    {
        chainArray = new HashNode<K, V>[M];
        size = 0;
    }

    public MyHashTable(int M)
    {
        this.M = M;
        chainArray = new HashNode<K, V>[M];
        size = 0;
    }

    private int Hash(K key)
    {
        return (key.GetHashCode() & 0x7fffffff) % M;
    }

    public void Put(K key, V value)
    {
        int hash = Hash(key);
        HashNode<K, V> node = chainArray[hash];
        while (node != null)
        {
            if (node.key.Equals(key))
            {
                node.value = value;
                return;
            }

            node = node.next;
        }

        HashNode<K, V> newNode = new HashNode<K, V>(key, value);
        newNode.next = chainArray[hash];
        chainArray[hash] = newNode;
        size++;
    }

    public V Get(K key)
    {
        int hash = Hash(key);
        HashNode<K, V> node = chainArray[hash];
        while (node != null)
        {
            if (node.key.Equals(key))
            {
                return node.value;
            }

            node = node.next;
        }

        throw new ArgumentException("Key not found");
    }

    public V remove(K key)
    {
        int hash = Hash(key);
        HashNode<K, V> node = chainArray[hash];
        HashNode<K, V> prev = null;
        while (node != null)
        {
            if (node.key.Equals(key))
            {
                if (prev == null)
                {
                    chainArray[hash] = node.next;
                }
                else
                {
                    prev.next = node.next;
                }
                size--;
                return node.value;
            }
            prev = node;
            node = node.next;
        }
        throw new ArgumentException("Key not found");
    }

    public bool contains(V value)
    {
        for (int i = 0; i < chainArray.Length; i++)
        {
            HashNode<K, V> node = chainArray[i];
            while (node != null)
            {
                if (node.value.Equals(value))
                {
                    return true;
                }
                node = node.next;
            }
        }
        return false;
    }

    public K getKey(V value)
    {
        for (int i = 0; i < chainArray.Length; i++)
        {
            HashNode<K, V> node = chainArray[i];
            while (node != null)
            {
                if (node.value.Equals(value))
                {
                    return node.key;
                }
                node = node.next;
            }
        }
        return default(K);
    }
}