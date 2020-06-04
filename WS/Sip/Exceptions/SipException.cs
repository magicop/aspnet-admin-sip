using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sip.Exceptions
{
    [Serializable]
    public class SipException:BaseException
    {

        public SipException(string message, params object[] args) : base(message, args) { }
        public SipException(Exception innerException, string message, params object[] args) : base(message, innerException) { }

    }
}