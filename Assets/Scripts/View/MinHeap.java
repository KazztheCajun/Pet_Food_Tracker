import java.util.*;



public class MinHeap<T> extends BinaryTree<T>
{

	public MinHeap()
	{
		super();
	}

	public void insert(T item)
	{
		BinaryNode<T> n = new BinaryNode<T>(item);

		// base case
		if (this.root == null)
		{
			root = n;
		}
		else // 
		{
			insertInChild(root);
		}
	}

	private void insertInChild(BinaryNode<T> root, BinaryNode<T> node)
	{
		int test = root.compareTo(node)

		if (int < 1) // if node is greater than root
		{
			if (root.getRightNode() == null)
			{
				root.getRightNode() = node;
			}
			else
			{
				insertInChild(root.getRightNode(), node);
			}
		}

		if (int > -1) // if node is less than root
		{
			if (root.getLeftNode() == null)
			{
				root.getLeftNode() = node;
			}
			else
			{
				insertInChild(root.getLeftNode(), node);
			}
		}

		// if they are equal?

		orderTree();
	}

	public void remove(T item)
	{

	}

	private void orderTree()
	{

	}

	public boolean isEmpty()
	{

	}

	public boolean isFull()
	{

	}

	public String toString()
	{

	}
}