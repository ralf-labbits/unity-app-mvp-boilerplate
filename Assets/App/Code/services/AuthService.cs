using Newtonsoft.Json;
using RxRest;
using System;
using UniRx;
public class AuthService
{
    static readonly string ApiPath = "http://3.19.238.19:1337";

    public static IObservable<string> Login(User user)
    {
        var jsonUser = JsonConvert.SerializeObject(user);
        return RestClient.Post($"{ApiPath}/api/login",jsonUser);
    }
}
