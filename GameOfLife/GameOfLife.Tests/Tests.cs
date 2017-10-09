using NUnit.Framework;

namespace GameOfLife.Tests
{
    public class Tests
    {
		[Test]
	    public void Init_should_create_world_with_given_state()
	    {
			//Arrange
		    Universe universe = new Universe(10);

			//Act
		    universe[1, 1].SetAlive();
		    universe[0, 6].SetAlive();

		    //Assert
			Assert.IsTrue(universe[1, 1].IsAlive, "Cell 1:1 should be alive");
			Assert.IsFalse(universe[0, 0].IsAlive, "Cell 0:0 should be died");
			Assert.AreEqual(universe[10, 6], null);
	    }
    }

	public class Cell
	{
		public bool IsAlive { get; set; }

		public void SetAlive()
		{
			IsAlive = true;
		}
	}

	public class Universe
	{
		private readonly Cell[,] _cells;
		private readonly int _dimension;

		public Universe(int i)
		{
			_dimension = i;
			_cells = new Cell[i,i];
		}

		public Cell this[int i, int j]
		{
			get
			{
				//if (i >= _dimension || j >= _dimension) return null;
				return _cells[i, j] ?? (_cells[i, j] = new Cell());
			}
		}
	}
}