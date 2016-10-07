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
			int X;
			int Y;
			int W;

			Console.WriteLine("Enter X Dimension (Max 9):");
			X = int.Parse(Console.ReadLine());

			Console.WriteLine("Enter Y Dimension (Max 9):");
			Y = int.Parse(Console.ReadLine());
			
			Console.WriteLine("Win Conditions Max(9)");
			W = int.Parse(Console.ReadLine());

			if (X > 9) X = 9;
			if (Y > 9) Y = 9;
			if (W > 9) W = 9;

			Game = new GameWinnerService(X,Y,W);
			gameBoard = Game.GetGameBoard();
			this.gameIsReady =  true;
		}

		void PlayGame() {
			printBoard(gameBoard);
			Console.WriteLine("\nPlease type where you wish to place your mark, eg. A1, B5, D3: ");
			string Input = Console.ReadLine();

			char x = Input[1];
			char y = Input[0];

			int X = (int)x-1;
			int Y = ConvertCharToNumber(y) -1;

			Console.WriteLine("gameBoard["+ X +", "+ Y +"]");
			gameBoard[X, Y] = 'X';

			Console.WriteLine(Game.Validate(gameBoard));
			Console.ReadKey();
		}

		static void printBoard(char[,] board) {
			int DimX = board.GetLength(0);
			int DimY = board.GetLength(1);

			Console.Write("  ");
			for(int i = 0; i < DimX; i++) {
				int Num = i + 1;
				Console.Write("  " + Num + " ");
			}

			for(int j = 0; j < DimY; j++) {
				char NumY = ConvertNumToChar(j + 1);
				Console.Write("\n");
				Console.Write(" " + NumY + "| ");
				for(int i = 0; i < DimX; i++) {
					Console.Write(board[i,j]);
					if(i != DimX-1) Console.Write(" | ");
				}

				if (j != (DimY - 1)) {
					Console.Write("\n--+");
					for (int i = 0; i < DimX; i++) {
						if (i != DimX - 1) Console.Write("---+");
					}
					Console.Write("---");
				}
			}
			Console.Write("\n");
		}

		private static char ConvertNumToChar(int Number) {
			char Return;
			switch (Number) {
				default: Return = '#'; break;
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

		private static int ConvertCharToNumber(char Letter) {
			int Return;
			switch (Letter) {
				default: Return = 0; break;
				case 'A': Return = 1; break;
				case 'B': Return = 2; break;
				case 'C': Return = 3; break;
				case 'D': Return = 4; break;
				case 'E': Return = 5; break;
				case 'F': Return = 6; break;
				case 'G': Return = 7; break;
				case 'H': Return = 8; break;
				case 'I': Return = 9; break;
				case 'J': Return = 10; break;
				case 'K': Return = 11; break;
				case 'L': Return = 12; break;
				case 'M': Return = 13; break;
				case 'N': Return = 14; break;
				case 'O': Return = 15; break;
				case 'P': Return = 16; break;
				case 'Q': Return = 17; break;
				case 'R': Return = 18; break;
				case 'S': Return = 19; break;
				case 'T': Return = 20; break;
				case 'U': Return = 21; break;
				case 'V': Return = 22; break;
				case 'W': Return = 23; break;
				case 'X': Return = 24; break;
				case 'Y': Return = 25; break;
				case 'Z': Return = 26; break;
			}

			return Return;
		}
	}
}
