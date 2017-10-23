using GameOfLife.Artifacts.Rules;
using System;
using System.Linq;

namespace GameOfLife.Artifacts
{
    public class Universe
	{
		private readonly Citizen[,] _citizens;
        private readonly Rule[] _rules;

		public Universe(int i, Rule[] rules)
		{
            if (rules == null || !rules.Any())
            {
                throw new ArgumentException("Universe can't exist without rules", "rules");
            }

            Dimension = i;
			_citizens = new Citizen[i, i];
            _rules = rules;
		}

        public int Dimension { get; private set; }

		public Citizen this[int x, int y]
		{
			get
			{
				if (x >= Dimension || y >= Dimension || x < 0 || y < 0) return null;
				return _citizens[x, y] ?? (_citizens[x, y] = new Citizen(x, y));
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
