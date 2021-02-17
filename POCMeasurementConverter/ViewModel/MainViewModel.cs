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
        //Default Converter
        private IConverter _converter = new MetricVolume();


        /// <summary>
        /// list of unit get from Converter.GetUnits()
        /// </summary>
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

        public ICommand SelectedMeasurementCommand { get; set; }

        public MainViewModel()
        {
            ResetData();
            SelectedMeasurementCommand = new SimpleCommand<string>((e) => InitConverter(e));
        }

        private void CalculationLeftToRigh()
        {
            if (decimal.TryParse(_valueLeft, out decimal valueFromInDecimal))
            {
                UnitSelectedLeft.Value = valueFromInDecimal;
                _valueRight = _converter.Convert(UnitSelectedLeft, UnitSelectedRight).ToString();
            }
            else
                _valueRight = "0";

            OnPropertyChanged("ValueRight");
        }

        private void CalculationRightToLeft()
        {
            if (decimal.TryParse(_valueRight, out decimal valueToInDecimal))
            {
                UnitSelectedRight.Value = valueToInDecimal;
                _valueLeft = _converter.Convert(UnitSelectedRight, UnitSelectedLeft).ToString();
            }
            else
                _valueLeft = "0";

            OnPropertyChanged("ValueLeft");
        }

        /// <summary>
        /// set your data to there default value 
        /// call every timethe converter change
        /// </summary>
        private void ResetData()
        {
            Units = _converter.GetUnits();
            UnitSelectedLeft = Units[0];
            UnitSelectedRight = Units[0];
            ValueLeft = "0";
            ValueRight = "0";
        }


        /// <summary>
        /// Use to link the button with the correct parameter to the right Converter
        /// </summary>
        /// <param name="converterParameter"></param>
       private void InitConverter(string converterParameter)
        {
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
