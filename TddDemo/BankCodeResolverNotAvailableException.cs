namespace TddDemo
{

    [System.Serializable]
    public class BankCodeResolverNotAvailableException : System.Exception
    {
        public BankCodeResolverNotAvailableException() { }
        public BankCodeResolverNotAvailableException(string message) : base(message) { }
        public BankCodeResolverNotAvailableException(string message, System.Exception inner) : base(message, inner) { }
        protected BankCodeResolverNotAvailableException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}