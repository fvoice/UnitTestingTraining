
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassGreeting
{
	public class Doorman
	{
		private const string HELLO_FORMAT_STRING = "Hello, {0}.";
		private const string UPPER_HELLO_FORMAT_STRING = "HELLO, {0}!";
		private const string DEFAULT_HELLO_FORMAT_STRING = "Hello, my friend.";

		public string Greet(params string[] names)
		{
			if (names == null) return DEFAULT_HELLO_FORMAT_STRING;

			var upperCaseNames = names.Where(x => x.All(Char.IsUpper)).ToArray();
			var usualNames = names.Except(upperCaseNames).ToArray();

			var usualNamesString = ProduceSequenceOfNames(usualNames);
			var upperCaseNamesString = ProduceSequenceOfNames(upperCaseNames);

			StringBuilder result = new StringBuilder();
			if (usualNamesString.Length > 0) result.AppendFormat(HELLO_FORMAT_STRING, usualNamesString);
			if (upperCaseNamesString.Length > 0)
			{
				var upperNamesGreetingString = string.Format(UPPER_HELLO_FORMAT_STRING, upperCaseNamesString.ToUpper());
				var appendFormatString = result.Length > 0 ? " AND {0}" : "{0}";
				result.AppendFormat(appendFormatString, upperNamesGreetingString);
			}

			return result.ToString();
		}

		private string ProduceSequenceOfNames(string[] names)
		{
			if (!names.Any()) return string.Empty;

			var expandedNames = ExpandComplexNames(names);

			return FormatNames(expandedNames);
		}

		private string FormatNames(string[] names)
		{
			int lastCommaIndex = -1;
			StringBuilder sb = new StringBuilder();
			for (int index = 0; index < names.Length; index++) //go through the array of names, can't use string.Join with a special delimiter as name can contain the same symbol
			{
				var isLast = index == names.Length - 1;
				if (isLast)
				{
					lastCommaIndex = sb.Length - 2;
				}
				var name = names[index];
				var format = isLast ? "{0}" : "{0}, ";
				sb.AppendFormat(format, name);
			}

			var namesString = sb.ToString();

			if (lastCommaIndex > 0)
			{
				namesString = namesString.Remove(lastCommaIndex, 2);
				namesString = namesString.Insert(lastCommaIndex, " and ");
			}
			return namesString;
		}

		private string[] ExpandComplexNames(string[] names)
		{
			var expandedNames = new List<string>();
			foreach (var name in names)
			{
				if (name.StartsWith("*") && name.EndsWith("*"))
				{
					expandedNames.Add(name.Trim('*'));
				}
				else
				{
					expandedNames.AddRange(name.Split(',').Select(x => x.Trim()));
				}
			}
			return expandedNames.ToArray();
		}
	}
}
