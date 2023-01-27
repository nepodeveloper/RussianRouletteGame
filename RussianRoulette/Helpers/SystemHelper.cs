using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianRoulette.Helpers
{
    /// <summary>
    /// The system helper class.
    /// </summary>
    public class SystemHelper
    {
        /// <summary>
        /// Gets all exception messages.
        /// </summary>
        /// <param name="exception">
        /// The exception.
        /// </param>
        /// <returns>A single string with all exception messages.</returns>
        public static string GetAllExceptionMessages(Exception exception)
        {
            var currentException = exception;
            StringBuilder result = new StringBuilder();
            while (currentException != null)
            {
                result.Append(currentException.Message ?? string.Empty + " ");
                currentException = currentException.InnerException;
            }

            return result.ToString().Trim();
        }
    }
}
