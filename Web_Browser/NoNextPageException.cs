using System;

namespace Web_Browser
{
    public class NoNextPageException : Exception
    {
        public NoNextPageException()
        {
        }

        public NoNextPageException(string message)
            : base(message)
        {
        }

        public NoNextPageException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
