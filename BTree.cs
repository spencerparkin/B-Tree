// BTree.cs

using System.Collections;
using System.Collections.Generic;
using System.Drawing;

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

                        Node leftNode = new Node(null);
                        Node rightNode = new Node(null);

                        for(int j = 0; j < node.childList.Count; j++)
                        {
                            Node childNode = node.childList[j];
                            if(j <= i)
                            {
                                leftNode.childList.Add(childNode);
                                childNode.parent = leftNode;
                            }
                            else
                            {
                                rightNode.childList.Add(childNode);
                                childNode.parent = rightNode;
                            }
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
                            leftNode.parent = parentNode;
                            rightNode.parent = parentNode;

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
            // Removing from a leaf is a trivial case.
            // From an internal node, I can see bringing the predecessor or successor up to replace the removed key.
            // Which we choose may be based on the size of the nodes in question.
            // When does the height of the tree shrink?

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

        protected class Node
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

            public bool IsLeaf()
            {
                for(int i = 0; i < childList.Count; i++)
                    if(childList[i].keyList.Count > 0)
                        return false;

                return true;
            }

            public List<KeyValuePair> keyList;
            public List<Node> childList;
            public Node parent;
        }

        protected class KeyValuePair
        {
            public KeyValuePair(string key, object value)
            {
                this.key = key;
                this.value = value;
            }

            public string key;
            public object value;
        }

        protected Node root;
        private int maxKeys;
    }

    public class BTreeDebug : BTree
    {
        public float levelMargin;
        public float levelPadding;

        public BTreeDebug(int maxKeys = 5) : base(maxKeys)
        {
            levelMargin = 30.0f;
            levelPadding = 5.0f;
        }

        public void Render(Bitmap bitmap)
        {
            Graphics graphics = Graphics.FromImage(bitmap);

            Rectangle imageRect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            graphics.FillRectangle(new SolidBrush(Color.White), imageRect);

            Font font = new Font("Arial", 12);

            List<RenderBox> renderBoxList = new List<RenderBox>();
            GenerateRenderBoxesForSubtree(root, graphics, font, renderBoxList);

            RectangleF boundingRectangle = CalcBoundingRectangle(renderBoxList);
            PointF offset = new PointF(-boundingRectangle.X, -boundingRectangle.Y);

            foreach(RenderBox renderBox in renderBoxList)
            {
                renderBox.Translate(offset);
                renderBox.Render(graphics, font);
            }
        }

        private class RenderBox
        {
            public RectangleF rectangle;
            public string label;

            public RenderBox()
            {
                rectangle = new RectangleF();
            }

            public void Render(Graphics graphics, Font font)
            {
                Rectangle backgroundRect = Rectangle.Round(rectangle);
                
                graphics.FillRectangle(new SolidBrush(Color.Gray), backgroundRect);
                graphics.DrawRectangle(new Pen(Color.Black), backgroundRect);

                PointF point = new PointF(rectangle.X, rectangle.Y);
                graphics.DrawString(label, font, new SolidBrush(Color.White), point);

                // TODO: Draw lines to children.
            }

            public void Translate(PointF offset)
            {
                rectangle.X += offset.X;
                rectangle.Y += offset.Y;

                // TODO: Translate lines to children.
            }
        }

        private void GenerateRenderBoxesForSubtree(Node node, Graphics graphics, Font font, List<RenderBox> renderBoxList)
        {
            RenderBox nodeRenderBox = GenerateRenderBoxForNode(node, graphics, font);
            renderBoxList.Add(nodeRenderBox);

            if(!node.IsLeaf())
            {
                float totalWidth = 0.0f;
                float maxHeight = 0.0f;

                List<List<RenderBox>> listOfSubRenderBoxLists = new List<List<RenderBox>>();
                List<RectangleF> boundingRectangleList = new List<RectangleF>();

                for(int i = 0; i < node.childList.Count; i++)
                {
                    List<RenderBox> subRenderBoxList = new List<RenderBox>();
                    GenerateRenderBoxesForSubtree(node.childList[i], graphics, font, subRenderBoxList);

                    listOfSubRenderBoxLists.Add(subRenderBoxList);

                    RectangleF boundingRectangle = CalcBoundingRectangle(subRenderBoxList);
                    boundingRectangleList.Add(boundingRectangle);

                    totalWidth += boundingRectangle.Width;
                    if(maxHeight < boundingRectangle.Height)
                        maxHeight = boundingRectangle.Height;
                }
                
                totalWidth += levelPadding * (listOfSubRenderBoxLists.Count - 1);
                float left = -totalWidth / 2.0f + nodeRenderBox.rectangle.Width / 2.0f;
                float top = nodeRenderBox.rectangle.Bottom + levelMargin;
                for(int i = 0; i < listOfSubRenderBoxLists.Count; i++)
                {
                    // TODO: Add lines to be drawn by nodeRenderBox to each renderBox we translate here.

                    List<RenderBox> subRenderBoxList = listOfSubRenderBoxLists[i];
                    RectangleF boundingRectangle = boundingRectangleList[i];

                    PointF offset = new PointF(left, top);
                    for(int j = 0; j < subRenderBoxList.Count; j++)
                    { 
                        RenderBox renderBox = subRenderBoxList[j];
                        renderBox.Translate(offset);
                        renderBoxList.Add(renderBox);
                    }

                    left += boundingRectangle.Width + levelPadding;
                }
            }
        }

        private RenderBox GenerateRenderBoxForNode(Node node, Graphics graphics, Font font)
        {
            string label = "";

            if(node.keyList.Count == 0)
                label = "Empty";
            else
            {
                for(int i = 0; i < node.keyList.Count; i++)
                {
                    if(i > 0)
                        label += ", ";

                    label += node.keyList[i].key;
                }
            }

            SizeF size = graphics.MeasureString(label, font);
            RenderBox renderBox = new RenderBox();
            renderBox.rectangle = new RectangleF(0.0f, 0.0f, size.Width, size.Height);
            renderBox.label = label;
            return renderBox;
        }

        private RectangleF CalcBoundingRectangle(List<RenderBox> renderBoxList)
        {
            RectangleF boundingRectangle = new RectangleF(renderBoxList[0].rectangle.Location, renderBoxList[0].rectangle.Size);
            
            for(int i = 1; i < renderBoxList.Count; i++)
                boundingRectangle = RectangleF.Union(boundingRectangle, renderBoxList[i].rectangle);

            return boundingRectangle;
        }
    }
}