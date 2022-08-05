using BaseClasses;
using Managers;

namespace Scripts.MVC
{
    public interface IWindow
    {
        WindowTypes Type { get; }
        string WindowName { get; }
        string Resource { get; }
        void SetModel(BaseWindowModel model);
        void Show();
        void Hide();
    }
}