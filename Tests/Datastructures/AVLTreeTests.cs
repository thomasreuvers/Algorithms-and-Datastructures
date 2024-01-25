using DataStructures;

namespace Tests.Datastructures;

[TestFixture]
public class AVLTreeTests
{
	[Test]
	public void Insert_ShouldAddElementToTree()
	{
		AVLTree<int> tree = new AVLTree<int>();
		tree.Insert(5);
		tree.Insert(3);
		tree.Insert(7);

		AVLNode<int> root = tree.Find(5);
		AVLNode<int> left = tree.Find(3);
		AVLNode<int> right = tree.Find(7);

		Assert.AreEqual(5, root.Value);
		Assert.AreEqual(3, left.Value);
		Assert.AreEqual(7, right.Value);
	}

	[Test]
	public void Remove_ShouldRemoveElementFromTree()
	{
		AVLTree<int> tree = new AVLTree<int>();
		tree.Insert(5);
		tree.Insert(3);
		tree.Insert(7);

		tree.Remove(3);

		AVLNode<int> root = tree.Find(5);
		AVLNode<int> left = tree.Find(3);
		AVLNode<int> right = tree.Find(7);

		Assert.AreEqual(5, root.Value);
		Assert.IsNull(left);
		Assert.AreEqual(7, right.Value);
	}

	[Test]
	public void FindMin_ShouldReturnMinimumValue()
	{
		AVLTree<int> tree = new AVLTree<int>();
		tree.Insert(5);
		tree.Insert(3);
		tree.Insert(7);

		AVLNode<int> min = tree.FindMin();

		Assert.AreEqual(3, min.Value);
	}

	[Test]
	public void FindMax_ShouldReturnMaximumValue()
	{
		AVLTree<int> tree = new AVLTree<int>();
		tree.Insert(5);
		tree.Insert(3);
		tree.Insert(7);

		AVLNode<int> max = tree.FindMax();

		Assert.AreEqual(7, max.Value);
	}

	[Test]
	public void Find_ShouldReturnCorrectNode()
	{
		AVLTree<int> tree = new AVLTree<int>();
		tree.Insert(5);
		tree.Insert(3);
		tree.Insert(7);

		AVLNode<int> found = tree.Find(3);

		Assert.AreEqual(3, found.Value);
	}
}