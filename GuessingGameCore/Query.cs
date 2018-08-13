using System;
using System.Collections.Generic;
using System.Linq;

namespace GuessingGame.Core {
    public class Query {
        private List<IQueryOperation> _operations = new List<IQueryOperation>();

        public IReadOnlyList<IQueryOperation> Operations => _operations.AsReadOnly();

        public IReadOnlyCollection<Subject> Results { get; }

        public Query(IReadOnlyCollection<Subject> dataset) {
            Results = dataset ?? throw new ArgumentNullException(nameof(dataset));
        }

        public Query Bind(IQueryOperation operation) {
            var newOperationSet = new List<IQueryOperation>(_operations) {
                operation
            };

            var newResults = operation
                .Apply(Results)
                .ToArray();

            return new Query(newResults) {
                _operations = newOperationSet
            };
        }
    }
}
