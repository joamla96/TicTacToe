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
			//this.X_DIM = X;
			//this.Y_DIM = Y;
			//this.WIN_COND = W;
		}

		public GameWinnerService() {  }

		public char Validate(char[,] gameBoard) {

			var currentWinningSymbol = CheckXRow(gameBoard);
			if (currentWinningSymbol != SYMBOL_FOR_NO_WINNER) {
				return currentWinningSymbol;
			}
			currentWinningSymbol = CheckYRow(gameBoard);
			if (currentWinningSymbol != SYMBOL_FOR_NO_WINNER) {
				return currentWinningSymbol;
			}
			currentWinningSymbol = CheckDiagonally(gameBoard);
			return currentWinningSymbol;
		}

		private char CheckXRow(char[,] gameBoard) {
			char lastChar;
			char thisChar;
			int Counter;

			for (int i = 0; i < this.X_DIM; i++) { // for each horizontal (X) row
				Counter = 0;
				lastChar = thisChar = gameBoard[i, 0];
				
				for(int j = 0; j < this.Y_DIM; j++) { // for each colum in row (Y)
					thisChar = gameBoard[i, j];

					if(thisChar == lastChar && thisChar != SYMBOL_FOR_NO_WINNER) {
						Counter++;
						if (Counter == WIN_COND) return thisChar;
					}

					lastChar = thisChar;
				}
			}
			return SYMBOL_FOR_NO_WINNER;
		}

		private char CheckYRow(char[,] gameBoard) {
			char lastChar;
			char thisChar;
			int Counter;

			for (int j = 0; j < this.Y_DIM; j++) { // for each horizontal (Y) row
				Counter = 0;
				lastChar = thisChar = gameBoard[0, j];

				for (int i = 0; i < this.X_DIM; i++) { // for each colum in row (X)
					thisChar = gameBoard[i, j];

					if (thisChar == lastChar && thisChar != SYMBOL_FOR_NO_WINNER) {
						Counter++;
						if (Counter == WIN_COND) return thisChar;
					}

					lastChar = thisChar;
				}
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

		private char CheckDiagonally(char[,] gameBoard) {
			int CurX = 0;
			int CurY = 0;

			char lastChar = ' ';
			int Count = 0;

			for(int i = 0; i < X_DIM; i++) {
				char thisChar = gameBoard[i, CurY];
				if (thisChar == lastChar) {
					if(thisChar != SYMBOL_FOR_NO_WINNER) Count++;
					if (Count == WIN_COND) return thisChar;
				} else Count = 0;

				CurY++;
				lastChar = thisChar;

				if (CurY > Y_DIM) break;
			}

			for (int j = 1; j < X_DIM; j++) {
				char thisChar = gameBoard[CurX, j];
				if (thisChar == lastChar) {
					if (thisChar != SYMBOL_FOR_NO_WINNER) Count++;
					if (Count == WIN_COND) return thisChar;
				} else Count = 0;

				CurX++;
				lastChar = thisChar;

				if (CurX > X_DIM) break;
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