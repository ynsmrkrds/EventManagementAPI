namespace EventManagement.Domain.Constants
{
    public static class ExceptionConstants
    {
        public const string ServerSideException = "An error has occurred with the server!";
        public const string TokenError = "Please login, then try again!";
        public const string NoAuthority = "You are not authorized to access here!";
        public const string NotFoundUser = "No such user is registered in the system!";
        public const string NotFoundCategory = "No such category is in the system!";
        public const string NotFoundLocation = "No such location is in the system!";
        public const string NotFoundEvent = "No such event is in the system!";
    }
}
