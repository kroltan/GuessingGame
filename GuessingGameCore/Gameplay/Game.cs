using System;
using System.Threading.Tasks;
using GuessingGame.Core.Gameplay.States;

namespace GuessingGame.Core.Gameplay {
    public class Game {
        private bool _running;
        private bool _stopRequested;

        public SolverWorld Solver { get; }
        public IUserInterface Ui { get; }

        public Game(SolverWorld solver, IUserInterface ui) {
            Solver = solver ?? throw new ArgumentNullException(nameof(solver));
            Ui = ui ?? throw new ArgumentNullException(nameof(ui));
        }

        public async Task Run() {
            if (_running) {
                throw new InvalidOperationException();
            }

            _running = true;
            IGameState state = new Starting();

            try {
                while (state != null) {
                    if (_stopRequested) {
                        _stopRequested = false;
                        throw new TaskCanceledException();
                    }

                    state = await state.Run(this);
                }
            } finally {
                _running = false;
            }
        }

        public void Stop() {
            _stopRequested = true;
        }
    }
}
