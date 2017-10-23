using System.Collections;
using System.Collections.Generic;
using GameOfLife.Artifacts;

namespace GameOfLife.Logic
{
	class NeighborEnumeratorClockwise : IEnumerable<Citizen>
	{
		private readonly Universe _universe;
		private readonly Citizen _citizen;

		public NeighborEnumeratorClockwise(Universe universe, Citizen citizen)
		{
			_universe = universe;
			_citizen = citizen;
		}

		public IEnumerator<Citizen> GetEnumerator()
		{
			var neighbor = _universe[_citizen.X + 1, _citizen.Y - 1];
			if (neighbor != null) 
				yield return neighbor;

			neighbor = _universe[_citizen.X + 1, _citizen.Y];
			if (neighbor != null) 
				yield return neighbor;

			neighbor = _universe[_citizen.X + 1, _citizen.Y + 1];
			if (neighbor != null) 
				yield return neighbor;

			neighbor = _universe[_citizen.X, _citizen.Y + 1];
			if (neighbor != null) 
				yield return neighbor;

			neighbor = _universe[_citizen.X - 1, _citizen.Y + 1];
			if (neighbor != null) 
				yield return neighbor;

			neighbor = _universe[_citizen.X - 1, _citizen.Y];
			if (neighbor != null) 
				yield return neighbor;

			neighbor = _universe[_citizen.X - 1, _citizen.Y - 1];
			if (neighbor != null) 
				yield return neighbor;

			neighbor = _universe[_citizen.X, _citizen.Y - 1];
			if (neighbor != null) 
				yield return neighbor;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
