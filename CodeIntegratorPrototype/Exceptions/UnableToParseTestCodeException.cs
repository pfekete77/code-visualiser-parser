using Microsoft.CodeAnalysis;
using System.Runtime.Serialization;

namespace CodeIntegratorPrototype.Exceptions
{
    [Serializable]
    internal class UnableToParseTestCodeException : Exception
    {
        private SyntaxNode line;

        public UnableToParseTestCodeException()
        {
        }

        public UnableToParseTestCodeException(SyntaxNode line, string message)
        {
            Console.WriteLine("EXCEPTION AT LINE=" + line.ToString());
            this.line = line;
        }

        public UnableToParseTestCodeException(string? message) : base(message)
        {
        }

        public UnableToParseTestCodeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UnableToParseTestCodeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}