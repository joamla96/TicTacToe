using System;
using NUnit.Framework;
using TicTacToe.Services;

namespace TicTacToe.UnitTests
{
	[TestFixture]
	public class GameWinnerServiceTests {
		IGameWinnerService gameWinnerService;
		private char[,] gameBoard;

		[SetUp]
		public void SetupUnitTests() {
			gameWinnerService = new GameWinnerService();
			gameBoard = new char[3, 3] {
					{' ', ' ', ' '},
					{' ', ' ', ' '},
					{' ', ' ', ' '}
			};
		}

		[Test]
		public void NeitherPlayerHasThreeInARow() {
			const char expected = ' ';
			var gameBoard = new char[3, 3] { {' ', ' ', ' '},
											{' ', ' ', ' '},
											{' ', ' ', ' '}};
			var actual = gameWinnerService.Validate(gameBoard);
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void PlayerWithAllSpacesInTopRowIsWinner() {
			gameWinnerService = new GameWinnerService();
			const char expected = 'X';
			var gameBoard = new char[3, 3] {
				{expected, expected, expected},
				{' ', ' ', ' '},
				{' ', ' ', ' '}
			};
			var actual = gameWinnerService.Validate(gameBoard);
			Assert.AreEqual(expected.ToString(),
			actual.ToString());
		}
	}
}
