namespace Client.Static;

internal static class ApiEndpoints
{
#if DEBUG
    internal const string ServerBaseUrl = "https://localhost:7025";
#else
    internal const string ServerBaseUrl = "https://localhost:7025"; //change when published
#endif

    internal readonly static string s_categories =$"{ServerBaseUrl}";


}
