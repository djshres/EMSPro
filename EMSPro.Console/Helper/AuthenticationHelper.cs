namespace EMSPro.App.Helper
{
    public static class AuthenticationHelper
    {
        public static Dictionary<string, string> users = new Dictionary<string, string>
        {
            { "admin", "password" }
        };

        public static Dictionary<string, string[]> userRoles = new Dictionary<string, string[]>
        {
            { "admin", new [] { "admin" } }
        };
    }
}
