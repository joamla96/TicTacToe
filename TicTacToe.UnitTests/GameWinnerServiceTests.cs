
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
			_gameWinnerService = new GameWinnerService();
			_gameBoard = new char[3, 3]{ {' ', ' ', ' '},
										 {' ', ' ', ' '},
										 {' ', ' ', ' '}};
		}

		[Test]
		public void NeitherPlayerHasThreeInARow() {
			const char expected = ' ';
			var actual = _gameWinnerService.Validate(_gameBoard);
			Assert.AreEqual(expected, actual);
		}
		[Test]
		public void PlayerWithAllSpacesInTopRowIsWinner() {
			const char expected = 'X';
			for (int i = 0; i < 3; i++) {
				_gameBoard[0, i] = expected;
			}
			var actual = _gameWinnerService.Validate(_gameBoard);
			Assert.AreEqual(expected.ToString(), actual.ToString());
		}
		[Test]
		public void PlayerWithAllSpacesInBottomRowIsWinner() {
			const char expected = 'X';
			for (int i = 0; i < 3; i++) {
				_gameBoard[2, i] = expected;
			}
			var actual = _gameWinnerService.Validate(_gameBoard);
			Assert.AreEqual(expected.ToString(), actual.ToString());
		}
		[Test]
		public void PlayerWithAllSpacesInMiddleRowIsWinner() {
			const char expected = 'X';
			for (int i = 0; i < 3; i++) {
				_gameBoard[1, i] = expected;
			}
			var actual = _gameWinnerService.Validate(_gameBoard);
			Assert.AreEqual(expected.ToString(), actual.ToString());
		}
		[Test]
		public void PlayerWithAllSpacesInFirstColumnIsWinner() {
			const char expected = 'X';
			for (var columnIndex = 0; columnIndex < 3; columnIndex++) {
				_gameBoard[columnIndex, 0] = expected;
			}
			var actual = _gameWinnerService.Validate(_gameBoard);
			Assert.AreEqual(expected.ToString(), actual.ToString());
		}
		[Test]
		public void PlayerWithAllSpacesInThirdColumnIsWinner() {
			const char expected = 'X';
			for (var columnIndex = 0; columnIndex < 3; columnIndex++) {
				_gameBoard[columnIndex, 2] = expected;
			}
			var actual = _gameWinnerService.Validate(_gameBoard);
			Assert.AreEqual(expected.ToString(), actual.ToString());
		}
		[Test]
		public void PlayerWithAllSpacesInSecondColumnIsWinner() {
			const char expected = 'X';
			for (var columnIndex = 0; columnIndex < 3; columnIndex++) {
				_gameBoard[columnIndex, 1] = expected;
			}
			var actual = _gameWinnerService.Validate(_gameBoard);
			Assert.AreEqual(expected.ToString(), actual.ToString());
		}
		[Test]
		public void PlayerWithThreeInARowDiagonallyDownAndToRightIsWinner() {
			const char expected = 'X';
			for (var cellIndex = 0; cellIndex < 3; cellIndex++) {
				_gameBoard[cellIndex, cellIndex] = expected;
			}
			var actual = _gameWinnerService.Validate(_gameBoard);
			Assert.AreEqual(expected.ToString(), actual.ToString());
		}
		[Test]
		public void PlayerWithThreeInARowDiagonallyTopAndToLeftIsWinner() {
			const char expected = 'X';
			for (var cellIndex = 0; cellIndex < 3; cellIndex++) {
				_gameBoard[cellIndex, (2 - cellIndex)] = expected;
			}
			var actual = _gameWinnerService.Validate(_gameBoard);
			Assert.AreEqual(expected.ToString(), actual.ToString());
		}
	}
}