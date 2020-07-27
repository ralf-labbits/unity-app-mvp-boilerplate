using Newtonsoft.Json;
using UniRx;

public class LoginPresenter : LoginContract.IPresenter
{
    private CompositeDisposable subscriptions;
    private LoginContract.IView view;

    public void Attach(LoginContract.IView view)
    {
        this.view = view;
    }

    public void Detach()
    {
        this.view = null;
    }

    public void Login(string email, string password)
    {
        view.Progress(true);

        User user = new User()
        {
            email = email,
            password = password
        };

        var subscribe = AuthService.Login(user)
            .Subscribe(data =>
            {
                view.Progress(false);

                Auth auth = JsonConvert.DeserializeObject<Auth>(data);
                UserSession.StoreUserAccess(auth.user);
                TokenSession.StoreAuthToken(auth.token);
                view.ConfirmAPIResponse(auth);
            }, error => {
                view.Progress(false);
                view.ShowMessage(error.ToString());
            });

        subscriptions.Add(subscribe);
    }

    public void SubsCribe()
    {
        subscriptions = new CompositeDisposable();
    }

    public void Unsubscribe()
    {
        subscriptions.Clear();
    }
}
