using System;

namespace GameOfLife
{
	public class Universe
	{
		private readonly Citizen[,] _cells;
		private readonly int _dimension;

		public Universe(int i)
		{
			_dimension = i;
			_cells = new Citizen[i, i];
		}

		public Citizen this[int i, int j]
		{
			get
			{
				if (i >= _dimension || j >= _dimension) return null;
				return _cells[i, j] ?? (_cells[i, j] = new Citizen(this));
			}
		}

		public void LiveDay()
		{
			foreach (var cell in _cells)
			{
				cell.LiveDay();
			}
		}
	}
}
