using System.Collections.Generic;

namespace GuessingGame.Core {
    public interface IQueryOperation {
        IEnumerable<Subject> Apply(IEnumerable<Subject> subjects);
    }
}
