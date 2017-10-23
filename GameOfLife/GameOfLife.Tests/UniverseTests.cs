using System;
using NUnit.Framework;
using GameOfLife.Artifacts;
using GameOfLife.Artifacts.Rules;

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
			Universe universe = new Universe(DEFAULT_DIMENSION, new Rule[] { new UnderpopulationRule() });

			//Act
		    universe[1, 1].SetAlive();

		    //Assert
			Assert.IsTrue(universe[1, 1].IsAlive, "Cell 1:1 should be alive");
			Assert.IsFalse(universe[0, 0].IsAlive, "Cell 0:0 should be died");
			Assert.AreEqual(universe[DEFAULT_DIMENSION, 6], null, "Cell over the dimension should be null");
	    }
        
        [Test]
        public void Init_should_fault_witout_rules()
        {
            // Assert
			Assert.Throws<ArgumentException>(() => new Universe(DEFAULT_DIMENSION, null));
			Assert.Throws<ArgumentException>(() => new Universe(DEFAULT_DIMENSION, new Rule[] { }));
        }

	    [Test]
		public void UnderpopulationRule_should_kill_single_alive_citizen()
	    {
            // Arrange
            Universe universe = new Universe(DEFAULT_DIMENSION, new[] { new UnderpopulationRule() });

            // Act
            universe[1, 1].SetAlive();
		    universe.LiveDay();

		    // Assert
			Assert.IsFalse(universe[1, 1].IsAlive, "Cell 1:1 should be died");
	    }

	    [Test]
		public void OverpopulationRule_should_kill_citizen_with_more_then_three_neighbors()
	    {
		    // Arrange
		    Universe universe = new Universe(DEFAULT_DIMENSION, new Rule[] { new OverpopulationRule() });

		    // Act
		    universe[1, 1].SetAlive();
		    universe[2, 1].SetAlive();
		    universe[2, 2].SetAlive();
		    universe[1, 2].SetAlive();
		    universe[0, 2].SetAlive();
		    universe.LiveDay();

		    // Assert
		    Assert.IsFalse(universe[1, 1].IsAlive, "Cell 1:1 should be died");
	    }
    }
}