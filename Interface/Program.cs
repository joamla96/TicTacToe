using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Services;

namespace Interface {
	class Program {
		bool gameIsReady = false;

		static void Main(string[] args) {
			Program program = new Program();
			program.Run();
		}

		void Run() {
			bool running = true;
	
			do {
				if (!this.gameIsReady) PrepareGame();
				else PlayGame();
			} while (running) ;
		}

		void PrepareGame() {
			throw new NotImplementedException();
		}

		void PlayGame() {
			throw new NotImplementedException();
		}
	}
}
