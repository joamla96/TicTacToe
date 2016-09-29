using System;
using NUnit.Framework;

namespace TicTacToe.UnitTests
{
	[TestFixture]
	public class GameWinnerServiceTests {
		[Test]
		public void NeitherPlayerHasThreeInARow() {
			const char expected = ' ';
			var gameBoard = new char[3, 3] { {' ', ' ', ' '},
											{' ', ' ', ' '},
											{' ', ' ', ' '}};
			var actual = gameWinnerService.Validate(gameBoard);
			Assert.AreEqual(expected, actual);
		}
	}

}
