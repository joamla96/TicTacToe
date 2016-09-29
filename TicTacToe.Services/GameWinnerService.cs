using System;

namespace TicTacToe.Services {

	public class GameWinnerService : IGameWinnerService {


		private const char SYMBOL_FOR_NO_WINNER = ' ';
		private const char SYMBOL_P1 = 'X';
		private const char SYMBOL_P2 = 'O';
		private int X_DIM = 3;
		private int Y_DIM = 3;
		private int WIN_COND = 3;

		public GameWinnerService(int X, int Y, int W) {
			this.X_DIM = X;
			this.Y_DIM = Y;
			this.WIN_COND = W;
		}

		public GameWinnerService() {  }

		public char Validate(char[,] gameBoard) {

			var currentWinningSymbol = CheckForThreeInARowInHorizontalRow(gameBoard);
			if (currentWinningSymbol != SYMBOL_FOR_NO_WINNER) {
				return currentWinningSymbol;
			}
			currentWinningSymbol = CheckForThreeInARowInVerticalColumn(gameBoard);
			if (currentWinningSymbol != SYMBOL_FOR_NO_WINNER) {
				return currentWinningSymbol;
			}
			currentWinningSymbol = CheckForThreeInARowDiagonally(gameBoard);
			return currentWinningSymbol;
		}

		private char CheckForThreeInARowInHorizontalRow(char[,] gameBoard) {
			char CheckChar;
			int Counter;

			for (int i = 0; i < this.X_DIM; i++) { // for each horizontal (X) row
				Counter = 0;
				CheckChar = gameBoard[i, 0];
				for(int j = 0; j < this.Y_DIM; j++) { // for each colum in row (Y)
					if (gameBoard[i, j] == CheckChar) Counter++;
				}

				if(Counter == this.WIN_COND && CheckChar != SYMBOL_FOR_NO_WINNER) { return CheckChar; }
			}
			return SYMBOL_FOR_NO_WINNER;
		}

		private char CheckForThreeInARowInVerticalColumn(char[,] gameBoard) {
			char CheckChar;
			int Counter;

			for (int i = 0; i < this.Y_DIM; i++) { // for each vertial row (Y)
				Counter = 0;
				CheckChar = gameBoard[0, i];
				for (int j = 0; j < this.X_DIM; j++) { // for each colum in row (X)
					if (gameBoard[j, i] == CheckChar) Counter++;
				}

				if (Counter == this.WIN_COND && CheckChar != SYMBOL_FOR_NO_WINNER) { return CheckChar; }
			}
			return SYMBOL_FOR_NO_WINNER;
		}
		
		//TODO: REFACTOR FOR ARBRITARY SIZE
		private char CheckForThreeInARowDiagonally(char[,] gameBoard) {
			var cellTwoChar = gameBoard[1, 1];
			int a = 0;

			for (int i = 0; i < 2; i++) {
				var cellOneChar = gameBoard[0, a];
				if (i == 0) {
					a += 2;
				} else {
					a -= 2;
				}
				var cellThreeChar = gameBoard[2, a];
				if (cellOneChar == cellTwoChar && cellTwoChar == cellThreeChar) {
					return cellOneChar;
				}
			}
			return SYMBOL_FOR_NO_WINNER;
		}

		public char[,] GetGameBoard() {
			char[,] gameBoard = new char[this.X_DIM, this.Y_DIM];
			for(int i = 0; i < this.X_DIM; i++) {
				for(int j = 0; j < this.Y_DIM; j++) {
					gameBoard[i, j] = ' '; 
				}
			}

			return gameBoard;
		}
	}
}