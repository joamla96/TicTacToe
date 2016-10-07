using System;

namespace TicTacToe.Services {

	public class GameWinnerService : IGameWinnerService {
		
		private const char SYMBOL_FOR_NO_WINNER = ' ';
		private const char SYMBOL_P1 = 'X';
		private const char SYMBOL_P2 = 'O';
		private int X_DIM = 3;
		private int Y_DIM = 3;
		private int WIN_COND = 3;

		public GameWinnerService(int SizeX, int SizeY, int WinCond) {
			this.X_DIM = SizeX;
			this.Y_DIM = SizeY;
			this.WIN_COND = WinCond;
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
			currentWinningSymbol = CheckDiagonallyTopDown(gameBoard);
			if(currentWinningSymbol != SYMBOL_FOR_NO_WINNER) {
				return currentWinningSymbol;
			}

			currentWinningSymbol = CheckDiagonallyDownTop(gameBoard);

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

		private char CheckDiagonallyTopDown(char[,] gameBoard) {
			int CurX;
			int CurY;

			char thisChar;
			char lastChar = ' ';
			int Count = 0;

			bool runX;
			bool runY;

			for(int i = 0; i < X_DIM; i++) {
				CurX = i;
				CurY = 0;
				lastChar = gameBoard[CurX, CurY];
				runX = true;
				while (runX) {
					thisChar = gameBoard[CurX, CurY];

					if (thisChar == lastChar && thisChar != SYMBOL_FOR_NO_WINNER) {
						Count++;
						if (Count == WIN_COND) return thisChar;
					} else Count = 0;

					lastChar = thisChar;

					CurX++;
					CurY++;
					if (CurX >= X_DIM || CurY >= Y_DIM) {
						runX = false;
					}
				}
			}

			for (int j = 1; j < Y_DIM; j++) {
				CurX = 0;
				CurY = j;
				lastChar = gameBoard[CurX, CurY];
				runY = true;
				while (runY) {
					thisChar = gameBoard[CurX, CurY];

					if (thisChar == lastChar && thisChar != SYMBOL_FOR_NO_WINNER) {
						Count++;
						if (Count == WIN_COND) return thisChar;
					} else Count = 0;

					lastChar = thisChar;

					CurX++;
					CurY++;
					if (CurX >= X_DIM || CurY >= Y_DIM) {
						runY = false;
					}
				}
			}

			return SYMBOL_FOR_NO_WINNER;
		}

		private char CheckDiagonallyDownTop(char[,] gameBoard) {
			int CurX;
			int CurY;

			char thisChar;
			char lastChar = ' ';
			int Count = 0;

			bool runX;
			bool runY;

			for (int i = 0; i < X_DIM; i++) {
				CurX = i;
				CurY = Y_DIM-1;
				lastChar = gameBoard[CurX, CurY];

				runX = true;
				while (runX) {
					thisChar = gameBoard[CurX, CurY];

					if (thisChar == lastChar && thisChar != SYMBOL_FOR_NO_WINNER) {
						Count++;
						if (Count == WIN_COND) return thisChar;
					} else Count = 0;

					lastChar = thisChar;

					CurX++;
					CurY--;
					if (CurX >= X_DIM || CurY < 0) {
						runX = false;
					}
				}
			}

			for (int j = Y_DIM - 2; j >= 0; j--) {
				CurX = 0;
				CurY = j;
				lastChar = gameBoard[CurX, CurY];

				runY = true;
				while (runY) {
					thisChar = gameBoard[CurX, CurY];

					if (thisChar == lastChar && thisChar != SYMBOL_FOR_NO_WINNER) {
						Count++;
						if (Count == WIN_COND) return thisChar;
					} else Count = 0;

					lastChar = thisChar;

					CurX++;
					CurY--;
					if (CurX >= X_DIM || CurY < 0) {
						runY = false;
					}
				}
			}

			return SYMBOL_FOR_NO_WINNER;
		}

		public char[,] GetGameBoard() {
			char[,] gameBoard = new char[this.X_DIM, this.Y_DIM];
			for (int i = 0; i < this.X_DIM; i++) {
				for (int j = 0; j < this.Y_DIM; j++) {
					gameBoard[i, j] = ' ';
				}
			}

			return gameBoard;
		}
	}
}