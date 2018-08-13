using System.Threading.Tasks;
using System.Windows;
using GuessingGame.Core;
using GuessingGame.Core.Gameplay;

namespace GuessingGame.Interface {
	public partial class MainWindow : Window, IUserInterface {
		public MainWindow() {
			InitializeComponent();

			var solver = new SolverWorld();
			var shark = new Subject("shark");
			shark.Traits.Add(new Trait("lives in water"));
			var monkey = new Subject("monkey");
			solver.Insert(shark);
			solver.Insert(monkey);

			var game = new Game(solver, this);
			RunGamesUntilExit(game);
		}

		public Task<bool> Confirmation(string message) {
			var source = new TaskCompletionSource<bool>();

			var confirmation = new ConfirmationPage {
				Message = message
			};
			confirmation.OnYes += () => {
				source.SetResult(true);
				Frame.Navigate(null);
			};
			confirmation.OnNo += () => {
				source.SetResult(false);
				Frame.Navigate(null);
			};
			Frame.Navigate(confirmation);

			return source.Task;
		}

		public Task<string> Input(string question) {
			var source = new TaskCompletionSource<string>();

			var prompt = new PromptPage {
				Label = question
			};
			prompt.OnSubmit += answer => {
				source.SetResult(answer);
				Frame.Navigate(null);
			};
			Frame.Navigate(prompt);

			return source.Task;
		}

		private async void RunGamesUntilExit(Game game) {
			try {
				while (true) {
					await game.Run();
				}
			} catch (TaskCanceledException) {
				Close();
			}
		}
	}
}
