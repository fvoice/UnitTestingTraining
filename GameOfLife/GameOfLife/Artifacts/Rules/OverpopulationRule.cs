using System.Linq;
using GameOfLife.Logic;

namespace GameOfLife.Artifacts.Rules
{
	public class OverpopulationRule : Rule
    {
        public override void Check(Universe universe)
        {
	        var enumerator = new CellEnumeratorFromTopAndLeft(universe);
			foreach (var citizenForCheck in enumerator.Where(x => x.IsAlive))
	        {
		        var neighborEnumerator = new NeighborEnumeratorClockwise(universe, citizenForCheck);
				if (neighborEnumerator.Count(x => x.IsAlive) > 3)
		        {
			        citizenForCheck.Die();
		        }
	        }
        }
    }
}
