using NUnit.Framework;

namespace GameOfLife.Tests
{
    public class Tests
    {
		private const int DEFAULT_DIMENSION = 10;

		[SetUp]
		public void SetUp()
	    {
		    
	    }

		[Test]
	    public void Init_should_create_world_with_given_state()
		{
			//Arrange
			Universe universe = new Universe(DEFAULT_DIMENSION);

			//Act
		    universe[1, 1].SetAlive();

		    //Assert
			Assert.IsTrue(universe[1, 1].IsAlive, "Cell 1:1 should be alive");
			Assert.IsFalse(universe[0, 0].IsAlive, "Cell 0:0 should be died");
			Assert.AreEqual(universe[DEFAULT_DIMENSION, 6], null, "Cell over the dimension should be null");
	    }

	    [Test]
	    public void LiveDay_should_kill_single_alive_cell()
	    {
		    // Arrange
			Universe universe = new Universe(DEFAULT_DIMENSION);

		    // Act
			universe[1, 1].SetAlive();
		    universe.LiveDay();

		    // Assert
			Assert.IsFalse(universe[1, 1].IsAlive, "Cell 1:1 should be died");
	    }
    }
}