#nullable disable

namespace DataStructures;

public class AVLNode<T>(T value)
	where T : IComparable<T>
{
	public T Value { get; set; } = value;
	public AVLNode<T> Left { get; set; }
	public AVLNode<T> Right { get; set; }
	public int Height { get; set; } = 1;
}
public class AVLTree <T> where T : IComparable<T>
{
	private AVLNode<T> _root;
	
	private	int Height(AVLNode<T> node)
	{
		return node?.Height ?? 0;
	}
	
	private int BalanceFactor(AVLNode<T> node)
	{
		return node == null ? 0 : Height(node.Left) - Height(node.Right);
	}
	
	private void UpdateHeight(AVLNode<T> node)
	{
		node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
	}

	private AVLNode<T> RotateRight(AVLNode<T> y)
	{
		var x = y.Left;
		var t2 = x.Right;

		x.Right = y;
		y.Left = t2;

		UpdateHeight(y);
		UpdateHeight(x);

		return x;
	}
	
	private AVLNode<T> RotateLeft(AVLNode<T> x)
	{
		var y = x.Right;
		var t2 = y.Left;

		y.Left = x;
		x.Right = t2;

		UpdateHeight(x);
		UpdateHeight(y);

		return y;
	}
	
	public AVLNode<T> Find(int value)
	{
		return Find(_root, value);
	}

	private AVLNode<T> Find(AVLNode<T> node, int value)
	{
		if (node == null || value.CompareTo(node.Value) == 0)
			return node;

		return Find(value.CompareTo(node.Value) < 0 ? node.Left : node.Right, value); // Using recursion here could use a while loop instead, may by faster in some cases?
	}

	public AVLNode<T> FindMin()
	{
		return FindMin(_root);
	}

	private AVLNode<T> FindMin(AVLNode<T> node)
	{
		while (node.Left != null)
			node = node.Left;

		return node;
	}

	public AVLNode<T> FindMax()
	{
		return FindMax(_root);
	}

	private AVLNode<T> FindMax(AVLNode<T> node)
	{
		while (node.Right != null)
			node = node.Right;

		return node;
	}
	
	public void Insert(T value)
    {
        _root = Insert(_root, value);
    }

    private AVLNode<T> Insert(AVLNode<T> node, T value)
    {
        if (node == null)
            return new AVLNode<T>(value);

        if (value.CompareTo(node.Value) < 0)
            node.Left = Insert(node.Left, value);
        else if (value.CompareTo(node.Value) > 0)
            node.Right = Insert(node.Right, value);
        else
            return node; // Duplicate values are not allowed

        UpdateHeight(node);

        var balance = BalanceFactor(node);
        
        if (balance > 1 && value.CompareTo(node.Left.Value) < 0)
            return RotateRight(node);
        
        if (balance < -1 && value.CompareTo(node.Right.Value) > 0)
            return RotateLeft(node);
        
        if (balance > 1 && value.CompareTo(node.Left.Value) > 0)
        {
            node.Left = RotateLeft(node.Left);
            return RotateRight(node);
        }
        
        if (balance < -1 && value.CompareTo(node.Right.Value) < 0)
        {
            node.Right = RotateRight(node.Right);
            return RotateLeft(node);
        }

        return node;
    }

    public void Remove(T value)
    {
        _root = Remove(_root, value);
    }

    private AVLNode<T> Remove(AVLNode<T> node, T value)
    {
        if (node == null)
            return node;

        if (value.CompareTo(node.Value) < 0)
            node.Left = Remove(node.Left, value);
        else if (value.CompareTo(node.Value) > 0)
            node.Right = Remove(node.Right, value);
        else
        {
            if (node.Left == null || node.Right == null)
            {
                AVLNode<T> temp = (node.Left != null) ? node.Left : node.Right;

                if (temp == null)
                {
                    temp = node;
                    node = null;
                }
                else
                    node = temp;

                temp = null;
            }
            else
            {
                var temp = FindMin(node.Right);
                node.Value = temp.Value;
                node.Right = Remove(node.Right, temp.Value);
            }
        }

        if (node == null)
            return node;

        UpdateHeight(node);

        var balance = BalanceFactor(node);
        
        if (balance > 1 && BalanceFactor(node.Left) >= 0)
            return RotateRight(node);
        
        if (balance > 1 && BalanceFactor(node.Left) < 0)
        {
            node.Left = RotateLeft(node.Left);
            return RotateRight(node);
        }
        
        if (balance < -1 && BalanceFactor(node.Right) <= 0)
            return RotateLeft(node);
        
        if (balance < -1 && BalanceFactor(node.Right) > 0)
        {
            node.Right = RotateRight(node.Right);
            return RotateLeft(node);
        }

        return node;
    }
}