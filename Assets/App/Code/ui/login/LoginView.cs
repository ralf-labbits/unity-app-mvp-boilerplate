using UnityEngine;

public class LoginView : LoginContract.IView
{
    public LoginScreen binding;
    public LoginContract.IPresenter presenter;

    public LoginView()
    {
        presenter = new LoginPresenter();
        presenter.SubsCribe();
        presenter.Attach(this);
        binding = LoginScreen.Instance;
        Init();
    }

    void Init()
    {
        binding.btnLogin.onClick.AddListener(()=> {

            string email = binding.inputEmail.text;
            string password = binding.inputPassword.text;

            RequestLogin(email, password);
        });
    }

    public void ConfirmAPIResponse(Auth auth)
    {
        if (auth.user != null)
        {
            binding.OpenMainScreen();
        }
    }

    public void Progress(bool isActive)
    {
        if(isActive)
        {
            binding.loading.SetActive(true);
        } else
        {
            binding.loading.SetActive(false);
        }
    }

    public void RequestLogin(string email, string password)
    {
        presenter.Login(email, password);
    }

    public void ShowMessage(string message)
    {
        Debug.LogError(message);
    }

    public void Destroy()
    {
        presenter.Unsubscribe();
        presenter.Detach();
        presenter = null;
    }
}
