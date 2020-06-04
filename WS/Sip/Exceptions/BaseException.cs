using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace Sip.Exceptions
{
    [Serializable]
    public abstract class BaseException : Exception
    {
        private string _uniqueId = Guid.NewGuid().ToString();
        private const short _category = 1;
        private string _message;
        private string _innerExceptionMessages = string.Empty;
        private int _eventId = 0;
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region Constructores
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Mensaje de la excepción</param>
        public BaseException(string message, params object[] args)
            : base(String.Format(message, args))
        {
            _message = String.Format(message, args);

            LogException();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Mensaje de la excepción</param>
        /// <param name="innerException">Excepción interna</param>
        public BaseException(Exception innerException, string message, params object[] args)
            : base(String.Format(message, args), innerException)
        {
            _message = String.Format(message, args);

            SetInnerExceptionsMessages(innerException);
            LogException();
        }

        /// <summary>
        /// Constructor para serialización
        /// </summary>
        /// <param name="info">Información de serialización</param>
        /// <param name="context">Parámetro de contexto</param>
        //public CampanaBaseException(int eventId, SerializationInfo info, StreamingContext context)
        //    : base(info, context)
        //{
        //    _eventId = eventId;
        //    _message = context.ToString();

        //    LogException();
        //}

        #endregion

        #region Métodos privado
        private void LogException()
        {
            ConfigureLog();
            object[] args = new object[] { _message, this.StackTrace, _innerExceptionMessages };

            _message = string.Format("Ocurrió una excepción: {0} {1} {2} ", args[0], args[1], args[2]);
            Log.Error(_message);
        }

        private void SetInnerExceptionsMessages(Exception innerException)
        {
            _innerExceptionMessages = "InnerExceptions->";

            StringBuilder sb = new StringBuilder();

            while (innerException != null)
            {
                sb.Append(innerException.GetType().ToString());
                sb.Append(":");
                sb.Append(innerException.Message);
                sb.Append("Stack Trace:");
                sb.Append(innerException.StackTrace);
                sb.Append("|");

                innerException = innerException.InnerException;
            }

            _innerExceptionMessages += sb.ToString();

        }

        private void ConfigureLog()
        {
            XmlConfigurator.Configure();

        }

        #endregion

    }
}