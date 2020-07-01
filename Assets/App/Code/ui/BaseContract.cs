using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseContract
{
    public interface IPresenter<in T>
    {
        void SubsCribe();
        void Unsubscribe();
        void Attach(T view);
        void Detach();
    }

    public interface IView
    {
        void Progress(bool isActive);

        void ShowMessage(string message);
    }
}
