namespace Assignment3;

public class MyHashTable<K, V> {
    private class HashNode<K, V>
    {
        private K key;
        private V value;
        private HashNode<K, V> next;

        public HashNode(K key, V value)
        {
            this.key = key;
            this.value = value;
        }

        public String toString()
        {
            return "{" + key + " " + value + "}";
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

    private int hash(K key)
    {
        int hashCode = key.GetHashCode();
        return hashCode % M;
    }
    public void put(K key, V value) {…}
    public V get(K key) {…}
    public V remove(K key) {…}
    public bool contains(V value) {…}
    public K getKey(V value) {…}