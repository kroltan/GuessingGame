using System.Threading.Tasks;
using GuessingGame.Core.Gameplay;

namespace GuessingGame.Core.Tests {
    class DummyUserInterface : IUserInterface {
        public Task<bool> Confirmation(string message) {
            return Task.FromResult(true);
        }

        public Task<string> Input(string question) {
			return Task.FromResult("");
		}
    }
}
