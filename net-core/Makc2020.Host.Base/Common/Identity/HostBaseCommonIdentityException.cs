//Author Maxim Kuzmin//makc//

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makc2020.Host.Base.Common.Identity
{
    /// <summary>
    /// Хост. Основа. Общее. Идентичность. Исключение.
    /// </summary>
    public class HostBaseCommonIdentityException : Exception
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="errors">Ошибки.</param>
        public HostBaseCommonIdentityException(IEnumerable<IdentityError> errors)
            : base(CreateErrorMessage(errors))
        {
        }

        #endregion Constructors

        #region Private methods

        private static string CreateErrorMessage(IEnumerable<IdentityError> errors)
        {
            var sb = new StringBuilder();

            string separator1 = null;

            foreach (var error in errors)
            {
                if (separator1 != null)
                {
                    sb.Append(separator1);
                }

                string separator2 = null;

                if (!string.IsNullOrWhiteSpace(error.Code))
                {
                    sb.Append(error.Code);

                    separator2 = ": ";
                }

                if (!string.IsNullOrWhiteSpace(error.Description))
                {
                    if (separator2 != null)
                    {
                        sb.Append(separator2);
                    }

                    sb.Append(error.Description);
                }

                separator1 = ". ";
            }

            return sb.ToString();
        }

        #endregion Private methods
    }
}
