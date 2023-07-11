namespace MegaApiTest.Helpers
{
    using System;
    using Xunit.Sdk;

    public class CustomEqualException : XunitException
    {
        public CustomEqualException(Object expected, Object actual, String userMessage) : base(userMessage)
        {
            var message = $"Assert.Equal() Failure: ";
            var expectedTypeText = expected != null && actual != null && expected != actual ? $", type {expected}" : "";
            var actualTypeText = expected != null && actual != null && expected != actual ? $", type {actual}" : "";
            message += $"{Environment.NewLine}Expected: {expectedTypeText}{Environment.NewLine}Actual:   {actualTypeText}{Environment.NewLine} message: {userMessage}";
            
            UserMessage = message;
        }

        public override String Message => UserMessage;

        private String UserMessage { get; }
    }
}
