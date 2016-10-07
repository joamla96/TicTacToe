using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Services;

namespace Interface {
	class Program {
		bool gameIsReady = false;
		GameWinnerService Game;
		char[,] gameBoard;

		static void Main(string[] args) {
			Program program = new Program();
			program.Run();
		}

		void Run() {
			bool running = true;
	
			do {
				Console.Clear();
				if (!this.gameIsReady) PrepareGame();
				else PlayGame();
			} while (running) ;
		}

		void PrepareGame() {
			Game = new GameWinnerService(3,4,3);
			gameBoard = Game.GetGameBoard();
			this.gameIsReady =  true;
		}

		void PlayGame() {
			printBoard(gameBoard);
			Console.ReadKey();
		}

		static void printBoard(char[,] board) {
			int DimX = board.GetLength(0);
			int DimY = board.GetLength(1);

			Console.Write(" ");
			for(int i = 0; i < DimX; i++) {
				int Num = i + 1;
				Console.Write("  " + Num + " ");
			}

			for(int j = 0; j < DimY; j++) {
				char NumY = ConvertNumToChar(j + 1);
				Console.Write("\n");
				Console.Write(NumY + "| ");
				for(int i = 0; i < DimX; i++) {
					Console.Write(board[i,j]);
					if(i != DimX-1) Console.Write(" | ");
				}

				if (j != (DimY - 1)) {
					Console.Write("\n-+");
					for (int i = 0; i < DimX; i++) {
						if (i != DimX - 1) Console.Write("---+");
					}
					Console.Write("---");
				}
			}
			Console.Write("\n");
		}

		private static char ConvertNumToChar(int Number) {
			char Return = '#';
			switch (Number) {
				case 1: Return = 'A'; break;
				case 2: Return = 'B'; break;
				case 3: Return = 'C'; break;
				case 4: Return = 'D'; break;
				case 5: Return = 'E'; break;
				case 6: Return = 'F'; break;
				case 7: Return = 'G'; break;
				case 8: Return = 'H'; break;
				case 9: Return = 'I'; break;
				case 10: Return = 'J'; break;
				case 11: Return = 'K'; break;
				case 12: Return = 'L'; break;
				case 13: Return = 'M'; break;
				case 14: Return = 'N'; break;
				case 15: Return = 'O'; break;
				case 16: Return = 'P'; break;
				case 17: Return = 'Q'; break;
				case 18: Return = 'R'; break;
				case 19: Return = 'S'; break;
				case 20: Return = 'T'; break;
				case 21: Return = 'U'; break;
				case 22: Return = 'V'; break;
				case 23: Return = 'W'; break;
				case 24: Return = 'X'; break;
				case 25: Return = 'Y'; break;
				case 26: Return = 'Z'; break;
			}

			return Return;
		}
	}
}
