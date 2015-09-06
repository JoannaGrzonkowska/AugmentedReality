using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class CommandResult
    {
        public CommandResult(IEnumerable<string> errors = null)
        {
            Errors = errors == null ? new List<string>() : errors.ToList();
            IsSuccess = !Errors.Any();
        }

        public bool IsSuccess { get; private set; }

        public IEnumerable<string> Errors { get; private set; }

        public string ErrorsToString
        {
            get
            {
                return string.Join(",", Errors);
            }
        }
    }
}
