using System.Threading.Tasks;
using GuessingGame.Core.Gameplay;

namespace GuessingGame.Core.Tests {
    class TestUserInterface : IUserInterface {
        public bool Confirmed;
        public string Response;

        public Task<bool> Confirmation(string message) {
            return Task.FromResult(Confirmed);
        }

        public Task<string> Input(string question) {
			return Task.FromResult(Response);
		}
    }
}
