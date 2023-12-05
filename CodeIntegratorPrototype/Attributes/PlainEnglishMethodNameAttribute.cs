using System.Diagnostics.Contracts;

namespace CodeIntegratorPrototype.Attributes
{
    internal class PlainEnglishMethodNameAttribute : Attribute
    {
        public string PlainEnglishMethodName { get; set; }
        public PlainEnglishMethodNameAttribute(string plainEnglishMethodName)
        {
            Contract.Requires(plainEnglishMethodName != null);
            this.PlainEnglishMethodName = plainEnglishMethodName;
            Contract.Requires(this.PlainEnglishMethodName != null);
        }
    }
}