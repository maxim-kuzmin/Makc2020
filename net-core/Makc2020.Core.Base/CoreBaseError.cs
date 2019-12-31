//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using System;
using System.Net;
using System.Net.Http;

namespace Makc2020.Core.Base
{
    /// <summary>
    /// Ядро. Основа. Ошибка.
    /// </summary>
    public class CoreBaseError
    {
        #region Properties

        /// <summary>
        /// Шаблон для формирования сообщения с URL.
        /// </summary>
        private string MessagePartWithUrlTmpl { get; set; }

        /// <summary>
        /// Шаблон для формирования сообщения с кодом.
        /// </summary>
        private string MessageWithCodeTmpl { get; set; }

        /// <summary>
        /// Сообщение об ошибке.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Признак того, что сообщение об ошибке должно быть занесено в журнал.
        /// </summary>
        public bool ShouldBeLogged { get; set; }

        /// <summary>
        /// Исключение, приведшее к возникновению ошибки.
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Код ошибки.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Код HTTP-статуса.
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// URL.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Признак того, что нужно спрятать код и URL.
        /// </summary>
        public bool HideCodeAndUrl { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор информации об ошибке. 
        /// Если исключение равно нулю, признак того, что сообщение об ошибке должно быть занесено в журнал,
        /// устанавливается в false, иначе - в true.
        /// Если исключение равно нулю, признак того, что нужно спрятать код и URL, устанавливается в true, иначе - в false. 
        /// </summary>
        /// <param name="exception">Исключение.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public CoreBaseError(Exception exception, CoreBaseResourceErrors coreBaseResourceErrors)
        {
            Exception = exception;
            ShouldBeLogged = exception != null;
            HideCodeAndUrl = exception == null;
            MessagePartWithUrlTmpl = coreBaseResourceErrors.GetStringFormatMessagePartWithUrl();
            MessageWithCodeTmpl = coreBaseResourceErrors.GetStringFormatMessageWithCode();
            Message = coreBaseResourceErrors.GetStringUnknownError();
            Code = Guid.NewGuid().ToString("N").ToUpper();
            HttpStatusCode = HttpStatusCode.InternalServerError;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получение сообщения для HTTP-отклика.
        /// </summary>
        /// <returns>Сообщение для HTTP-отклика.</returns>
        public HttpResponseMessage GetHttpResponseMessage()
        {
            return new HttpResponseMessage(HttpStatusCode)
            {
                Content = new StringContent(CreateMessageWithCode()),
                ReasonPhrase = Message
            };
        }

        /// <summary>
        /// Создание сообщения с кодом ошибки.
        /// </summary>
        /// <returns>Сообщение с кодом ошибки.</returns>
        public string CreateMessageWithCode()
        {
            string result = string.Empty;

            if (HideCodeAndUrl)
            {
                result = Message;
            }
            else
            {
                result = string.IsNullOrWhiteSpace(Code)
                    ?
                    Message
                    :
                    (
                        string.IsNullOrWhiteSpace(Url)
                        ?
                        string.Format(MessageWithCodeTmpl, Message, Code)
                        :
                        string.Format(MessageWithCodeTmpl + MessagePartWithUrlTmpl, Message, Code, Url)
                    );

                result = result.Replace("!.", "!").Replace("?.", "?");
            }

            return result;
        }

        #endregion Public methods
    }
}
