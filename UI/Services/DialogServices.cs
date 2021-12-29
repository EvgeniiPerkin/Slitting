using Microsoft.Win32;
using System.Windows;

namespace UI.Services
{
    public class DialogServices : IDialogServices
    {
        public void ShowMsg(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}
