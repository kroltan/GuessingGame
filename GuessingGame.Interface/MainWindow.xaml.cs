using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using GuessingGame.Core;
using GuessingGame.Core.Gameplay;

namespace GuessingGame.Interface {
	public partial class MainWindow : Window, IUserInterface {
		private const string StoredSolverWorldDataFilename = "Solver.xml";

		public MainWindow() {
			InitializeComponent();
			InitializeGame();
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

		private async void InitializeGame() {
			var solver = await LoadStoredWorld();
			var game = new Game(solver, this);

			await RunGamesUntilExit(game);
		}

		private async Task RunGamesUntilExit(Game game) {
			try {
				while (true) {
					await game.Run();
				}
			} catch (TaskCanceledException) {
				Close();
			}
		}

		private Task<SolverWorld> LoadStoredWorld() {
			var directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

			if (directory == null) {
				throw new DirectoryNotFoundException("The application's directory could not be located");
			}

			var path = Path.Combine(directory, StoredSolverWorldDataFilename);

			return Task.Run(() => {
				var serializer = new XmlSerializer(typeof(SolverWorld));
				var settings = new XmlReaderSettings {
				};

				using (var reader = File.OpenRead(path)) {
					using (var xml = XmlReader.Create(reader, settings)) {
						return (SolverWorld) serializer.Deserialize(xml);
					}
				}
			});
		}
	}
}
