using System.Collections.Generic;
using System.Linq;

namespace CQRS.Commands
{
    public sealed class CommandResult<TResult> : CommandResult
    {
        public TResult Result { get; private set; }

        public CommandResult(TResult result, IEnumerable<string> errors = null)
            : base(errors)
        {
            Result = result;
        }
    }

    public class CommandResult
    {
        public CommandResult(IEnumerable<string> errors = null)
        {
            Errors = errors == null ? new List<string>() : errors.ToList();
            IsSuccess = !Errors.Any();
        }

        public bool IsSuccess { get; private set; }

        public IEnumerable<string> Errors { get; private set; }

        public string ErrorsAsString { get {
            return string.Join("", Errors);
        } }
    }
}
