public class LoginContract
{
    public interface IView: BaseContract.IView
    {
        void RequestLogin(string email, string password);

        void ConfirmAPIResponse(Auth auth);
    }

    public interface IPresenter: BaseContract.IPresenter<IView>
    {
        void Login(string email, string password);
    }
}
