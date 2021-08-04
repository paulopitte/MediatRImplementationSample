using System.Collections.Generic;

namespace MediatRImplementationSample.Domain
{
    public class Result
    {
        public static Result Ok = new();

        public bool HasValidation => _validations.Count > 0;
        private List<string> _validations = new();
        public IList<string> Validations => _validations;
        public Result() { }

        public void AddValidation(string validation) => _validations.Add(validation);
    }

    public class Result<TResponse> : Result
    {
        public TResponse Data { get; private set; }
        public Result() { }

        public Result(TResponse data) => Data = data;

    }
}
