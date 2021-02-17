using System.Collections.Generic;
using System.Windows.Input;
using System;
using POCMeasurementConverter.Command;
using POCMeasurementConverter.Converter;
using POCMeasurementConverter.Enum;
using POCMeasurementConverter.Model;

namespace POCMeasurementConverter.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
        private const string _iconLeftToRight = "\uE893;";
        private const string _iconRightToLeft = "\uE892;";
        private const string _iconError = "\uE894";


        //Default Converter
        private IConverter _converter = new MetricVolume();

        private List<Unit> _units;
        public List<Unit> Units
        {
            get { return _units; }
            set
            {
                _units = value;
                UnitSelectedLeft = value[0];
                UnitSelectedRight = value[0];
                OnPropertyChanged();

            }
        }

        public ICommand SelectedMeasurmentCommand { get; set; }

        private Unit _unitSelectedLeft;
        public Unit UnitSelectedLeft
        {
            get { return _unitSelectedLeft; }
            set
            {
                _unitSelectedLeft = value;
                OnPropertyChanged();

                if (LastTexBoxFocus == DirectionEnum.TOTHELEFT)
                    CalculationRightToLeft();
                else
                    if (LastTexBoxFocus == DirectionEnum.TOTHERIGH)
                    CalculationLeftToRigh();
            }
        }

        private Unit _unitSelectedRight;
        public Unit UnitSelectedRight
        {
            get { return _unitSelectedRight; }
            set
            {
                _unitSelectedRight = value;

                OnPropertyChanged();
                if (LastTexBoxFocus == DirectionEnum.TOTHELEFT)
                    CalculationRightToLeft();
                else
                    if (LastTexBoxFocus == DirectionEnum.TOTHERIGH)
                    CalculationLeftToRigh();
            }
        }

        private DirectionEnum LastTexBoxFocus { get; set; }

        private string _icon = _iconLeftToRight;
        public string Icon
        {
            get { return _icon; }
            set { _icon = value; OnPropertyChanged(); }
        }

        private string _valueLeft;
        public string ValueLeft
        {
            get { return _valueLeft; }
            set
            {
                _valueLeft = value;
                LastTexBoxFocus = DirectionEnum.TOTHERIGH;
                OnPropertyChanged();
                CalculationLeftToRigh();

            }
        }

        private string _valueRight;
        public string ValueRight
        {
            get { return _valueRight; }
            set
            {
                _valueRight = value;
                LastTexBoxFocus = DirectionEnum.TOTHERIGH;
                OnPropertyChanged();
                CalculationRightToLeft();
            }
        }

        public MainViewModel()
        {
            ResetData();
            SelectedMeasurmentCommand = new SimpleCommand<string>((e) => InitConverter(e));
        }

        private void TurnIcon(DirectionEnum direction)
        {
            if (direction == DirectionEnum.ERROR)
            {
                Icon = _iconError;
                return;
            }

            if (direction == DirectionEnum.TOTHELEFT)
                Icon = _iconRightToLeft;
            else
                Icon = _iconLeftToRight;
        }

        private void CalculationLeftToRigh()
        {
            TurnIcon(DirectionEnum.TOTHERIGH);

            if (decimal.TryParse(_valueLeft, out decimal valueFromInDecimal))
            {
                UnitSelectedLeft.Value = valueFromInDecimal;
                _valueRight = _converter.Convert(UnitSelectedLeft, UnitSelectedRight).ToString();
            }
            else
            {
                TurnIcon(DirectionEnum.ERROR);
                _valueRight = "0";
            }
            OnPropertyChanged("ValueRight");
        }

        private void CalculationRightToLeft()
        {
            TurnIcon(DirectionEnum.TOTHELEFT);
            if (decimal.TryParse(_valueRight, out decimal valueToInDecimal))
            {
                UnitSelectedRight.Value = valueToInDecimal;
                _valueLeft = _converter.Convert(UnitSelectedRight, UnitSelectedLeft).ToString();
            }
            else
            {
                _valueLeft = "0";
                TurnIcon(DirectionEnum.ERROR);
            }
            OnPropertyChanged("ValueLeft");
        }

        private void ResetData()
        {
            Units = _converter.GetUnits();
            UnitSelectedLeft = Units[0];
            UnitSelectedRight = Units[0];
            ValueLeft = "0";
            ValueRight = "0";
        }

       private void InitConverter(string converterParameter)
        {
            ResetData();
            if (System.Enum.TryParse(converterParameter, out ConverterParameterEnum converterParameterEnum))
            {
                switch (converterParameterEnum)
                {
                    case ConverterParameterEnum.MetricVolume:
                        _converter = new MetricVolume();
                        break;
                    case ConverterParameterEnum.MetricWeight:
                        _converter = new MetricWeight();
                        break;
                    case ConverterParameterEnum.ImperialDistance:
                        _converter = new ImperialDistance();
                        break;
                }
                ResetData();
            }
        }
    }
}
