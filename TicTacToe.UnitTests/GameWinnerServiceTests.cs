using System;
using NUnit.Framework;
using TicTacToe.Services;


namespace TicTacToe.UnitTests
{
	[TestFixture]
	public class GameWinnerServiceTests {
		[Test]
		public void NeitherPlayerHasThreeInARow() {
			IGameWinnerService gameWinnerService = new GameWinnerService();
			const char expected = ' ';
			var gameBoard = new char[3, 3] { {' ', ' ', ' '},
											{' ', ' ', ' '},
											{' ', ' ', ' '}};
			var actual = gameWinnerService.Validate(gameBoard);
			Assert.AreEqual(expected, actual);
		}
	}

}
