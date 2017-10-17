using System.Linq;

namespace GameOfLife.Artifacts.Rules
{
    public class UnderpopulationRule : Rule
    {
        public override void Check(Universe universe)
        {
            for (int x = 0; x < universe.Dimension; x++) //left->right
            {
                for (int y = universe.Dimension-1; y > 0 ; y--)//up->bottom
                {
                    var cellForCheck = universe[x, y];
                    var neighbors = FindNeighbors(universe, cellForCheck);
                    if (neighbors.Length <= 2)
                    {
                        cellForCheck.Die();
                    }
                }
            }
        }

        private Citizen[] FindNeighbors(Universe universe, Citizen c)
        {
            return new[] {
                universe[c.X+1, c.Y+1], //go clockwise
                universe[c.X+1, c.Y],
                universe[c.X+1, c.Y-1],
                universe[c.X, c.Y-1],
                universe[c.X-1, c.Y-1],
                universe[c.X-1, c.Y],
                universe[c.X-1, c.Y-1],
                universe[c.X, c.Y+1],
            }.Where(x => x != null && x.IsAlive).ToArray();
        }
    }
}
