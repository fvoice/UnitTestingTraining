namespace GameOfLife
{
	public class Citizen
	{
		private Universe _universe;

		public bool IsAlive { private set; get; }

		public Citizen(Universe universe)
		{
			_universe = universe;
		}

		public void SetAlive()
		{
			IsAlive = true;
		}

		public void Die()
		{
			IsAlive = false;
		}

		public void LiveDay()
		{
			
		}
	}
}
