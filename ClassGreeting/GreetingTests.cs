using FluentAssertions;
using NUnit.Framework;

namespace ClassGreeting
{
	public class DoormanFixture
	{
		private Doorman _doorman;

		[SetUp]
		public void Setup()
		{
			_doorman = new Doorman();
		}

		[Test]
		public void Greet_should_say_hello_for_given_name() //1
		{
			string greeting = _doorman.Greet("Bob");

			greeting.Should().Be("Hello, Bob.");
		}

		[Test]
		public void Greet_should_say_my_friend_for_null_name() //2
		{
			string greeting = _doorman.Greet(null);

			greeting.Should().Be("Hello, my friend.");
		}

		[Test]
		public void Greet_should_shout_for_shouted_name() //3
		{
			string greeting = _doorman.Greet("JERRY");

			greeting.Should().Be("HELLO, JERRY!");
		}

		[Test]
		public void Greet_should_say_hello_for_two_names() //4
		{
			string greeting = _doorman.Greet("Jerry", "Bob");

			greeting.Should().Be("Hello, Jerry and Bob.");
		}

		[Test]
		public void Greet_should_say_hello_for_array_of_names() //5
		{
			string greeting = _doorman.Greet("Jerry", "Bob", "Mike");

			greeting.Should().Be("Hello, Jerry, Bob and Mike.");
		}

		[Test]
		public void Greet_should_say_hello_for_array_of_names_and_in_UPPER_case_for_UPPER_names() //6
		{
			string greeting = _doorman.Greet("Jerry", "BOB", "Mike");

			greeting.Should().Be("Hello, Jerry and Mike. AND HELLO, BOB!");
		}

		[Test]
		public void Greet_should_say_hello_for_array_of_names_with_string_arrays() //7
		{
			string greeting = _doorman.Greet("Jerry", "Bob, Mike");

			greeting.Should().Be("Hello, Jerry, Bob and Mike.");
		}

		[Test]
		public void Greet_should_say_hello_for_array_of_names_with_string_arrays_and_allow_escaping() //8
		{
			string greeting = _doorman.Greet("Jerry", "*Bob, Mike*");

			greeting.Should().Be("Hello, Jerry and Bob, Mike.");
		}
	}
}
