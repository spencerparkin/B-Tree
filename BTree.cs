// BTree.cs

using System.Collections;
using System.Collections.Generic;

namespace BTree
{
    public class BTree
    {
        public BTree(int maxKeys = 5)
        {
            this.maxKeys = maxKeys;
            this.root = new Node(null);
        }

        public void Insert(string key, object value)
        {
            var keyValuePair = FindKeyValuePair(key);
            if(keyValuePair != null)
                keyValuePair.value = value;
            else
            {
                keyValuePair = new KeyValuePair(key, value);
                
                Node node = root;
                int i;

                while(node.keyList.Count > 0)
                {
                    i = node.FindBranch(key);
                    node = node.childList[i];
                }

                if(node.parent != null)
                    node = node.parent;

                i = node.FindBranch(key);
                if(i == -1)
                {
                    node.keyList.Add(keyValuePair);
                    node.childList.Add(new Node(node));
                    node.childList.Add(new Node(node));
                }
                else
                {
                    node.keyList.Insert(i, keyValuePair);
                    node.childList.Insert(i + 1, new Node(node));

                    while(node.keyList.Count > maxKeys)
                    {
                        i = node.keyList.Count / 2;

                        Node leftNode = new Node(node.parent);
                        Node rightNode = new Node(node.parent);

                        for(int j = 0; j < node.childList.Count; j++)
                        {
                            Node childNode = node.childList[j];
                            if(j <= i)
                                leftNode.childList.Add(childNode);
                            else
                                rightNode.childList.Add(childNode);
                        }

                        for(int j = 0; j < node.keyList.Count; j++)
                        {
                            keyValuePair = node.keyList[j];
                            if(j < i)
                                leftNode.keyList.Add(keyValuePair);
                            else if(j > i)
                                rightNode.keyList.Add(keyValuePair);
                        }

                        keyValuePair = node.keyList[i];

                        Node parentNode = node.parent;
                        if(parentNode != null)
                        {
                            i = parentNode.FindBranch(keyValuePair.key);
                            parentNode.childList[i] = rightNode;
                            parentNode.childList.Insert(i, leftNode);
                            parentNode.keyList.Insert(i, keyValuePair);

                            node = node.parent;
                        }
                        else
                        {
                            root = new Node(null);
                            root.keyList.Add(keyValuePair);
                            root.childList.Add(leftNode);
                            root.childList.Add(rightNode);
                            leftNode.parent = root;
                            rightNode.parent = root;

                            break;
                        }
                    }
                }
            }
        }

        public bool Remove(string key)
        {
            return false;
        }

        public object Find(string key)
        {
            var keyValuePair = FindKeyValuePair(key);
            return keyValuePair != null ? keyValuePair.value : null;
        }

        private KeyValuePair FindKeyValuePair(string key)
        {
            Node node = root;
            
            while(true)
            {
                KeyValuePair keyValuePair = node.FindKeyValuePair(key);
                if(keyValuePair != null)
                    return keyValuePair;

                int i = node.FindBranch(key);
                if(i == -1)
                    break;

                node = node.childList[i];
            }

            return null;
        }

        private class Node
        {
            public Node(Node parent)
            {
                this.parent = parent;
                keyList = new List<KeyValuePair>();
                childList = new List<Node>();
            }

            public int FindBranch(string key)
            {
                if(keyList.Count == 0)
                    return -1;

                for(int i = 0; i < keyList.Count; i++)
                {
                    int result = string.Compare(key, keyList[i].key);
                    if(result == -1)
                        return i;
                }

                return keyList.Count;
            }

            public KeyValuePair FindKeyValuePair(string key)
            {
                for(int i = 0; i < keyList.Count; i++)
                    if(keyList[i].key == key)
                        return keyList[i];

                return null;
            }

            public List<KeyValuePair> keyList;
            public List<Node> childList;
            public Node parent;
        }

        private class KeyValuePair
        {
            public KeyValuePair(string key, object value)
            {
                this.key = key;
                this.value = value;
            }

            public string key;
            public object value;
        }

        private Node root;
        private int maxKeys;
    }
}