namespace MegaApiTest.Helpers
{
    using System;
    public static class CustomEqual
    {
        public static void Validate<TAction>(TAction expected, TAction actual, String userMessage)
        {
            Boolean areEqual;

            if (expected == null || actual == null)
            {
                // If either null, equal only if both null
                areEqual = (expected == null && actual == null);
            }
            else
            {
                // expected is not null - so safe to call .Equals()
                areEqual = expected.Equals(actual);
            }

            if (!areEqual)
            {
                throw new CustomEqualException(expected, actual, userMessage);
            }
        }
    }
}
