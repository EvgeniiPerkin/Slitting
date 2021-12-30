using MathCore.ViewModels;
using System;
using System.Collections.ObjectModel;
using UI.Base;

namespace UI.ViewModels.Realization
{
    [Serializable]
    public class ParametsViewModel : ViewModel
    {
        public ParametsViewModel()
        {
            _Strips = new ObservableCollection<Strip>();
        }

        private ObservableCollection<Strip> _Strips;
        private Knife _SelectedKnife;
        private double _RollWidth;
        private double _Thickness;
        private int _CuttingMachine;
        private string _Msg;

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
    }
}
