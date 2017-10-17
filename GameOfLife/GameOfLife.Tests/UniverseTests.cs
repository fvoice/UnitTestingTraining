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
            bool exceptionOccured = false;
            try
            {
                // Arrange
                // Act
                new Universe(DEFAULT_DIMENSION, null);
            }
            catch (Exception)
            {
                exceptionOccured = true;
            }
            
            // Assert
            Assert.AreEqual(true, exceptionOccured, "Universe initialized without rules");

            try
            {
                // Arrange
                // Act
                new Universe(DEFAULT_DIMENSION, new Rule[] { });
            }
            catch (Exception)
            {
                exceptionOccured = true;
            }

            // Assert
            Assert.AreEqual(true, exceptionOccured, "Universe initialized without rules");
        }

	    [Test]
	    public void LiveDay_should_kill_single_alive_cell()
	    {
            // Arrange
            Universe universe = new Universe(DEFAULT_DIMENSION, new[] { new UnderpopulationRule() });

            // Act
            universe[1, 1].SetAlive();
		    universe.LiveDay();

		    // Assert
			Assert.IsFalse(universe[1, 1].IsAlive, "Cell 1:1 should be died");
	    }
    }
}