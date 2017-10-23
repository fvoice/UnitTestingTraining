using System.Collections;
using System.Collections.Generic;
using GameOfLife.Artifacts;

namespace GameOfLife.Logic
{
	class CellEnumeratorFromTopAndLeft : IEnumerable<Citizen>
	{
		private readonly Universe _universe;

		public CellEnumeratorFromTopAndLeft(Universe universe)
		{
			_universe = universe;
		}

		public IEnumerator<Citizen> GetEnumerator()
		{
			for (int y = 0; y < _universe.Dimension; y++) //up->bottom
			{
				for (int x = 0; x < _universe.Dimension; x++) //left->right
				{
					yield return _universe[x, y];
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
