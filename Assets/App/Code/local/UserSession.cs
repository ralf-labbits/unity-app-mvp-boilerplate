using Newtonsoft.Json;
using Prefs = UnityEngine.PlayerPrefs;
public class UserSession
{
    static readonly string USER_LOGGED = "logged";

    static readonly string USER_PROFILE = "profile";

    public static bool IsUserLogged()
    {
        if(Prefs.HasKey(USER_LOGGED))
        {
            return Prefs.GetInt(USER_LOGGED) == 1;
        }
        return false;
    }

    public static User GetUser()
    {
        if(Prefs.HasKey(USER_PROFILE))
        {
            return JsonConvert.DeserializeObject<User>(Prefs.GetString(USER_PROFILE));
        }
        return null;
    }

    public static void StoreUserAccess(User user)
    {
        SetUserAccess(true);
        Prefs.SetString(USER_PROFILE, JsonConvert.SerializeObject(user));
        Prefs.Save();
    }

    public static void ResetUserAccess()
    {
        Prefs.SetInt(USER_LOGGED, 0);
        Prefs.SetString(USER_PROFILE, "");
        Prefs.Save();
    }

    private static void SetUserAccess(bool logged)
    {
        int loggedIn = logged ? 1 : 0;
        Prefs.SetInt(USER_LOGGED, loggedIn);
        Prefs.Save();
    }
}
