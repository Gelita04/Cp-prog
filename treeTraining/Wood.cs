



namespace Equisde
{
    public class Tree<T>
    {
        public List<Tree<T>> children;
        public T value;

        public Tree(T value)
        {
            this.value = value;
            children = new List<Tree<T>>();
        }
        public Tree(T value, List<Tree<T>> childreen)
        {
            this.value = value;
            this.children = childreen;
        }

        public int WidthTree()
        {
            int result = children.Count;
            foreach (var item in children)
            {
                result = Math.Max(item.WidthTree(), children.Count);
            }
            return result;
        }
    }

    public class BinaryTree<T> where T : IComparable
    {
        public T value;
        public BinaryTree<T>? left;
        public BinaryTree<T>? right;

        public BinaryTree(T value)
        {
            this.value = value;
        }
        public BinaryTree(T value, List<BinaryTree<T>> children)
        {
            this.value = value;
            left = children[0];
            right = children[1];
        }

        public void InsertTreeWithValue(T entry)
        {
            if (entry.CompareTo(value) == 0)
                return;
            if (entry.CompareTo(value) == -1)
            {
                if (left == null)
                    left = new BinaryTree<T>(entry);
                else
                    left.InsertTreeWithValue(entry);
            }
            else if (entry.CompareTo(value) == 1)
            {
                if (right == null)
                    right = new BinaryTree<T>(entry);
                else
                    right.InsertTreeWithValue(entry);
            }
        }

        public int High()
        {
            int resultA = 0;
            int resultB = 0;
            if (left != null)
                resultA += 1 + left.High();
            if (right != null)
                resultB += 1 + right.High();
            return Math.Max(resultA, resultB);
        }

        public int Diameter()
        {
            int rootDiameter = 0;
            int leftHigh = 0;
            int rightHigh = 0;

            if (left != null)
                leftHigh = left.High() + 1;

            if (right != null)
                rightHigh = right.High() + 1;

            rootDiameter = leftHigh + rightHigh;

            return Math.Max(rootDiameter, Math.Max(left == null ? 0 : left.Diameter(), right == null ? 0 : right.Diameter()));
        }

        public int DistanceFromTargetNodetoRoot(T nodeID, int steps = 0)
        {
            int result = 0;
            if (value.CompareTo(nodeID) == 0)
                return steps;
            if (left != null)
            {
                result = left.DistanceFromTargetNodetoRoot(nodeID, steps + 1);
                if (result != 0) return result;
            }
            if (right != null)
            {
                result = right.DistanceFromTargetNodetoRoot(nodeID, steps + 1);
                if (result != 0) return result;
            }

            return result;
        }

        bool IsAnyNodeOn(T ANodeID, T BNodeID)
        {
            if (value.CompareTo(ANodeID) == 0 || value.CompareTo(BNodeID) == 0)
                return true;
            if (left != null)
            {
                if (left.IsAnyNodeOn(ANodeID, BNodeID))
                    return true;
            }
            if (right != null)
            {
                if (right.IsAnyNodeOn(ANodeID, BNodeID))
                    return true;
            }
            return false;
        }
        public int DistanceFromANodeToBNode(T valueA, T valueB)
        {
            int result = 0;
            if (left != null && right != null && left.IsAnyNodeOn(valueA, valueB) && right.IsAnyNodeOn(valueA, valueB))
            {
                return DistanceFromTargetNodetoRoot(valueA) + DistanceFromTargetNodetoRoot(valueB);
            }
            if (left != null)
            {
                result = left.DistanceFromANodeToBNode(valueA, valueB);
                if (result != 0) return result;
            }
            if (right != null)
            {
                result = right.DistanceFromANodeToBNode(valueA, valueB);
                if (result != 0) return result;
            }
            return result;
        }

        public int Inversions()
        {
            List<T> listOfOrderValues = new List<T>();
            MakeArrInOrder(listOfOrderValues);
            T[] arrValues = listOfOrderValues.ToArray();
            return 0;
        }
        public void MakeArrInOrder(List<T> list)
        {
            if (left != null)
            { left.MakeArrInOrder(list); list.Add(value); }
            else if (left == null)
                list.Add(value);

            if (right != null)
                right.MakeArrInOrder(list);
            else if (right == null)
                return;
        }
    }

}




