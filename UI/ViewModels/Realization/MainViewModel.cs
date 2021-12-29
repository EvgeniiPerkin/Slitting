using MathCore.ViewModels;
using System.Collections.ObjectModel;
using UI.Base;
using UI.Commands;
using UI.Services;
using UI.ViewModels.Interfaces;

namespace UI.ViewModels.Realization
{
    public class MainViewModel : ViewModel, IMainViewModel
    {
        public MainViewModel(IDialogServices dialogServices)
        {
            this.dialogServices = dialogServices;
            _Strips = new ObservableCollection<Strip>();
        }
        private readonly IDialogServices dialogServices;
        private ObservableCollection<Strip> _Strips;
        /// <summary></summary>
        public ObservableCollection<Strip> Strips
        {
            get => _Strips;
            set
            {
                if (_Strips == value)
                {
                    return;
                }
                _Strips = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<string> MyList { get; set; } = new ObservableCollection<string>
        {
            "asdf",
            "asdfasdff",
            "123rwqerf"
        };
        private int _Id = 90;
        public int Id
        {
            get => _Id;
            set
            {
                if (_Id == value)
                    return;
                _Id = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _Command;
        /// <summary>команда</summary>
        public RelayCommand Command
        {
            get
            {
                return _Command ??
                    (_Command = new RelayCommand(obj =>
                    {
                        string result = "";
                        foreach(Strip strip in Strips)
                        {
                            result += strip.Size + "==" + strip.Count + "\n";
                        }
                        dialogServices.ShowMsg(result);
                    }));
            }
        }
    }
}
