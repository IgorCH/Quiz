using System;
using BaseClasses;

public interface IWindowManager : IDisposable
{
    void Show(string windowName, BaseWindowModel model = null);
}