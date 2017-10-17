using GameOfLife.Artifacts.Rules;
using System;
using System.Linq;

namespace GameOfLife.Artifacts
{
    public class Universe
	{
		private readonly Citizen[,] _cells;
        private readonly Rule[] _rules;
		private readonly int _dimension;

		public Universe(int i, Rule[] rules)
		{
            if (rules == null || !rules.Any())
            {
                throw new ArgumentException("Universe can't exist without rules", nameof(rules));
            }

            _dimension = i;
			_cells = new Citizen[i, i];
            _rules = rules;
		}

        public int Dimension => _dimension;

	    public Citizen this[int x, int y]
		{
			get
			{
				if (x >= _dimension || y >= _dimension || x < 0 || y < 0) return null;
				return _cells[x, y] ?? (_cells[x, y] = new Citizen(x, y));
			}
		}

		public void LiveDay()
		{
			foreach (var rule in _rules)
			{
                rule.Check(this);
			}
		}
	}
}
