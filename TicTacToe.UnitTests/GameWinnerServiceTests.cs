using System;
using NUnit.Framework;
using TicTacToe.Services;

namespace TicTacToeTests {
	[TestFixture]
	public class GameWinnerServiceTests {

		IGameWinnerService _gameWinnerService;
		private char[,] _gameBoard;

		[SetUp]
		public void SetupUnitTests() {
			_gameWinnerService = new GameWinnerService(3,3,3);
			_gameBoard = new char[3, 3] {
				{' ', ' ', ' '},
				{' ', ' ', ' '},
				{' ', ' ', ' '}
			};
		}
		[Test]
		public void CheckGameBoard() {
			Assert.AreEqual(_gameBoard, _gameWinnerService.GetGameBoard());
		}


		[Test]
		public void NeitherPlayerHasThreeInARow() {
			const char expected = ' ';
			var actual = _gameWinnerService.Validate(_gameBoard);
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void PlayerWithAllSpacesInTopRowIsWinner() {
			char expected = 'X';
			_gameBoard = new char[3, 3] {
				{'X', 'X', 'X'},
				{' ', 'O', 'O'},
				{'O', ' ', 'O'}
			};
			var actual = _gameWinnerService.Validate(_gameBoard);
			Assert.AreEqual(expected.ToString(), actual.ToString());

			char expected2 = 'O';
			_gameBoard = new char[3, 3] {
				{'O', 'O', 'O'},
				{' ', ' ', ' '},
				{' ', ' ', ' '}
			};
			var actual2 = _gameWinnerService.Validate(_gameBoard);
			Assert.AreEqual(expected2.ToString(), actual2.ToString());
		}

		[Test]
		public void PlayerWithAllSpacesInBottomRowIsWinner() {
			char expected = 'X';
			_gameBoard = new char[3, 3] {
				{' ', ' ', ' '},
				{' ', ' ', ' '},
				{'X', 'X', 'X'}
			};
			var actual = _gameWinnerService.Validate(_gameBoard);
			Assert.AreEqual(expected.ToString(), actual.ToString());

			char expected2 = 'O';
			_gameBoard = new char[3, 3] {
				{' ', ' ', ' '},
				{' ', ' ', ' '},
				{'O', 'O', 'O'}
			};
			var actual2 = _gameWinnerService.Validate(_gameBoard);
			Assert.AreEqual(expected2.ToString(), actual2.ToString());
		}

		[Test]
		public void PlayerWithAllSpacesInMiddleRowIsWinner() {
			char expected = 'X';
			_gameBoard = new char[3, 3] {
				{' ', ' ', ' '},
				{'X', 'X', 'X'},
				{' ', ' ', ' '}
			};
			var actual = _gameWinnerService.Validate(_gameBoard);
			Assert.AreEqual(expected.ToString(), actual.ToString());
		}

		[Test]
		public void PlayerWithAllSpacesInFirstColumnIsWinner() {
			char expected = 'X';
			_gameBoard = new char[3, 3] {
				{'X', ' ', ' '},
				{'X', ' ', ' '},
				{'X', ' ', ' '}
			};
			var actual = _gameWinnerService.Validate(_gameBoard);
			Assert.AreEqual(expected.ToString(), actual.ToString());
		}

		[Test]
		public void PlayerWithAllSpacesInThirdColumnIsWinner() {
			char expected = 'X';
			_gameBoard = new char[3, 3] {
				{' ', ' ', 'X'},
				{' ', ' ', 'X'},
				{' ', ' ', 'X'}
			};
			var actual = _gameWinnerService.Validate(_gameBoard);
			Assert.AreEqual(expected.ToString(), actual.ToString());
		}

		[Test]
		public void PlayerWithAllSpacesInSecondColumnIsWinner() {
			char expected = 'X';
			_gameBoard = new char[3, 3] {
				{' ', 'X', ' '},
				{' ', 'X', ' '},
				{' ', 'X', ' '}
			};
			var actual = _gameWinnerService.Validate(_gameBoard);
			Assert.AreEqual(expected.ToString(), actual.ToString());
		}

		[Test]
		public void PlayerWithThreeInARowDiagonallyDownAndToRightIsWinner() {
			char expected = 'X';
			_gameBoard = new char[3, 3] {
				{' ', ' ', 'X'},
				{' ', 'X', ' '},
				{'X', ' ', ' '}
			};
			var actual = _gameWinnerService.Validate(_gameBoard);
			Assert.AreEqual(expected.ToString(), actual.ToString());

			char expected2 = 'O';
			_gameBoard = new char[3, 3] {
				{' ', ' ', 'O'},
				{' ', 'O', ' '},
				{'O', ' ', ' '}
			};
			var actual2 = _gameWinnerService.Validate(_gameBoard);
			Assert.AreEqual(expected2.ToString(), actual2.ToString());
		}

		[Test]
		public void PlayerWithThreeInARowDiagonallyTopAndToLeftIsWinner() {
			char expected = 'X';
			_gameBoard = new char[3, 3] {
				{'X', ' ', ' '},
				{' ', 'X', ' '},
				{' ', ' ', 'X'}
			};
			var actual = _gameWinnerService.Validate(_gameBoard);
			Assert.AreEqual(expected.ToString(), actual.ToString());

			char expected2 = 'O';
			_gameBoard = new char[3, 3] {
				{'O', ' ', ' '},
				{' ', 'O', ' '},
				{' ', ' ', 'O'}
			};
			var actual2 = _gameWinnerService.Validate(_gameBoard);
			Assert.AreEqual(expected2.ToString(), actual2.ToString());
		}
	}
}