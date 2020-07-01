using Prefs = UnityEngine.PlayerPrefs;
public class TokenSession
{
    const string AUTHENTICATION_TOKEN = "authentication";

    public static string GetToken()
    {
        string token = "";
        if (Prefs.HasKey(AUTHENTICATION_TOKEN))
        {
            token = Prefs.GetString(AUTHENTICATION_TOKEN);
        }
        return token;
    }

    public static void StoreAuthToken(string authToken)
    {
        Prefs.SetString(AUTHENTICATION_TOKEN, authToken);
        Prefs.Save();
    }
}
