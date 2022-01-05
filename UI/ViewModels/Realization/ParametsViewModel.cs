using MathCore.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using UI.Base;

namespace UI.ViewModels.Realization
{
    [Serializable()]
    public class ParametsViewModel : ViewModel
    {
        public ParametsViewModel()
        {
            _Strips = new ObservableCollection<Strip>();
        }

        private ObservableCollection<Strip> _Strips;
        private Strip _SelectedStrip;
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
                Calculace();
                OnPropertyChanged();
            }
        }
        /// <summary>selected strip</summary>
        public Strip SelectedStrip
        {
            get => _SelectedStrip;
            set
            {
                if (_SelectedStrip == value)
                {
                    return;
                }
                _SelectedStrip = value;
                Calculace();
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
                Calculace();
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
                Calculace();
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
                Calculace();
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
                Calculace();
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

        public void Calculace()
        {
            try
            {
                float sum = 0f;
                foreach (Strip strip in Strips)
                {
                    sum += strip.Count * strip.Size;
                }
                int count = Strips.Sum(i => i.Count);
                Msg = $"Total length of the tapes - { $"{sum,12:N3}" }\nTotal number of tapes - { count }";
            }
            catch
            {
                Msg = "Error calculate";
            }
        }
    }
}
