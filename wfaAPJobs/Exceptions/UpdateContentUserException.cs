using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfaAPJobs.Exceptions
{
    public class UpdateContentUserException : Exception
    {
        public UpdateContentUserException(string message) : base(message) { }
    }
}
