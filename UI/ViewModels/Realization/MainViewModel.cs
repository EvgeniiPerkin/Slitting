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
            _Knifes = new ObservableCollection<Knife>();
        }
        #region fields
        private readonly IDialogServices dialogServices;
        private ObservableCollection<Strip> _Strips;
        private ObservableCollection<Knife> _Knifes;
        private Knife _SelectedKnife;
        private double _RollWidth;
        private double _Thickness;
        private int _CuttingMachine;
        private double _Progress;
        private string _Notify;
        private string _Msg;
        #endregion

        #region properties
        /// <summary>list strips</summary>
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
        /// <summary>list knifes</summary>
        public ObservableCollection<Knife> Knifes
        {
            get => _Knifes;
            set
            {
                if (_Knifes == value)
                {
                    return;
                }
                _Knifes = value;
                OnPropertyChanged();
            }
        }
        /// <summary>selected knife</summary>
        public Knife SelectedKnife
        {
            get => _SelectedKnife;
            set
            {
                if (_SelectedKnife == value)
                {
                    return;
                }
                _SelectedKnife = value;
                OnPropertyChanged();
            }
        }
        /// <summary>Roll width</summary>
        public double RollWidth
        {
            get => _RollWidth;
            set
            {
                if (_RollWidth == value)
                {
                    return;
                }
                _RollWidth = value;
                OnPropertyChanged();
            }
        }
        /// <summary>Thickness metal</summary>
        public double Thickness
        {
            get => _Thickness;
            set
            {
                if (_Thickness == value)
                {
                    return;
                }
                _Thickness = value;
                OnPropertyChanged();
            }
        }
        /// <summary>unoccupied сutting machine</summary>
        public int CuttingMachine
        {
            get => _CuttingMachine;
            set
            {
                if (_CuttingMachine == value)
                {
                    return;
                }
                _CuttingMachine = value;
                OnPropertyChanged();
            }
        }
        /// <summary>process execution scale</summary>
        public double Progress
        {
            get => _Progress;
            set
            {
                if (_Progress == value)
                {
                    return;
                }
                _Progress = value;
                OnPropertyChanged();
            }
        }
        /// <summary>message about the scale of execution</summary>
        public string Notify
        {
            get => _Notify;
            set
            {
                if (string.Compare(_Notify, value) == 0)
                {
                    return;
                }
                _Notify = value;
                OnPropertyChanged();
            }
        }
        /// <summary>help message about the current change</summary>
        public string Msg
        {
            get => _Msg;
            set
            {
                if (string.Compare(_Msg, value) == 0)
                {
                    return;
                }
                _Msg = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region commands
        private RelayCommand _Command;
        /// <summary>команда</summary>
        public RelayCommand Command => _Command ??
                    (_Command = new RelayCommand(obj =>
                    {
                        string result = "";
                        foreach (Strip strip in Strips)
                        {
                            result += strip.Size + "==" + strip.Count + "\n";
                        }
                        dialogServices.ShowMsg(result);
                    }));

        #endregion
    }
}
