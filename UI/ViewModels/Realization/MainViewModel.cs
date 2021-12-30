using System.Collections.ObjectModel;
using UI.Base;
using UI.Commands;
using UI.Services;
using UI.ViewModels.Interfaces;

namespace UI.ViewModels.Realization
{
    public class MainViewModel : ParametsViewModel, IMainViewModel
    {
        public MainViewModel(IDialogServices dialogServices, ISerializer serializer)
        {
            this.dialogServices = dialogServices;
            this.serializer = serializer;
            ParametsViewModel param = serializer.DeSerialize();

            SelectedKnife = param.SelectedKnife;
            Strips = param.Strips;
            CuttingMachine = param.CuttingMachine;
            Msg = param.Msg;
            RollWidth = param.RollWidth;
            Thickness = param.Thickness;
            _Knifes = new ObservableCollection<Knife>();
        }
        #region fields
        private readonly ISerializer serializer;
        private readonly IDialogServices dialogServices;
        private ObservableCollection<Knife> _Knifes;
        private double _Progress;
        private string _Notify;
        #endregion

        #region properties
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
        #endregion

        #region commands
        private RelayCommand _Command;
        /// <summary>команда</summary>
        public RelayCommand Command => _Command ??
                    (_Command = new RelayCommand(obj =>
                    {
                        serializer.Serialize(new ParametsViewModel
                        {
                            SelectedKnife = SelectedKnife,
                            Strips = Strips,
                            CuttingMachine = CuttingMachine,
                            Msg = Msg,
                            RollWidth = RollWidth,
                            Thickness = Thickness
                        });
                        dialogServices.ShowMsg("ok");
                    }));

        #endregion
    }
}
