namespace GameOfLife.Artifacts
{
	public class Citizen
	{
		public bool IsAlive { private set; get; }
        public int X { get; set; }
        public int Y { get; set; }

        public Citizen(int x, int y)
		{
            X = x;
            Y = y;
		}

		public void SetAlive()
		{
			IsAlive = true;
		}

		public void Die()
		{
			IsAlive = false;
		}
	}
}
