using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
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
            _ = Startup();
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

        public async Task Startup()
        {
            ParametsViewModel param = await serializer.DeSerialize().ConfigureAwait(false);

            SelectedKnife = param.SelectedKnife;
            Strips = param.Strips;
            CuttingMachine = param.CuttingMachine;
            Msg = param.Msg;
            RollWidth = param.RollWidth;
            Thickness = param.Thickness;
            _Knifes = new ObservableCollection<Knife>();
        }

        #region commands
        private RelayCommand _AddNewStripCommand;
        /// <summary>create new item strip</summary>
        public RelayCommand AddNewStripCommand => _AddNewStripCommand ??
                    (_AddNewStripCommand = new RelayCommand(obj =>
                    {
                        Strips.Add(new Strip { Count = 0, Size = 0f });
                    }));

        private RelayCommand _RemoveStripCommand;
        /// <summary>команда</summary>
        public ICommand RemoveStripCommand
        {
            get
            {
                if (_RemoveStripCommand == null)
                {
                    _RemoveStripCommand = new RelayCommand(ExecuteRemoveStrip, CanExecuteRemoveStrip);
                }
                return _RemoveStripCommand;
            }
        }
        /// <summary>выполненеие команды</summary>
        /// <param name="parameter"></param>
        public void ExecuteRemoveStrip(object parameter)
        {
            Strip strip = (Strip)parameter;
            Strips.Remove(strip);
        }
        /// <summary>до выполнения команды проверяет на null параметр</summary>
        /// <param name="parameter">параметр команды</param>
        /// <returns></returns>
        public bool CanExecuteRemoveStrip(object parameter)
        {
            return parameter != null;
        }


        private RelayCommand _CalculateCommand;
        /// <summary>команда</summary>
        public ICommand CalculateCommand
        {
            get
            {
                if (_CalculateCommand == null)
                {
                    _CalculateCommand = new RelayCommand(ExecuteCalculate, CanExecuteCalculate);
                }
                return _CalculateCommand;
            }
        }
        /// <summary>выполненеие команды</summary>
        /// <param name="parameter"></param>
        public void ExecuteCalculate(object parameter)
        {
            //TO DO
        }
        /// <summary>до выполнения команды проверяет на null параметр</summary>
        /// <param name="parameter">параметр команды</param>
        /// <returns></returns>
        public bool CanExecuteCalculate(object parameter)
        {
            return this.IsValid();
        }

        private RelayCommand _Command;
        /// <summary>команда</summary>
        public RelayCommand Command => _Command ??
                    (_Command = new RelayCommand(async obj =>
                    {
                        await serializer.Serialize(new ParametsViewModel
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
