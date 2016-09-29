namespace TicTacToe.Services {
	public interface IGameWinnerService {
		object Validate(char[,] gameBoard);
	}
}
