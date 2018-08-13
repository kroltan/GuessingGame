using System.Threading.Tasks;

namespace GuessingGame.Core.Gameplay {
	public interface IGameState {
		Task<IGameState> Run(Game game);
	}
}