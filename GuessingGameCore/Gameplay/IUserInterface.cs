using System.Threading.Tasks;

namespace GuessingGame.Core.Gameplay {
    public interface IUserInterface {
        Task<bool> Confirmation(string message);

        Task<string> Input(string question);
    }
}
