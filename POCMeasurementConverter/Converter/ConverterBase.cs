using POCMeasurementConverter.Converter;
using POCMeasurementConverter.Model;
using System.Collections.Generic;

public abstract class ConverterBase : IConverter
{

    public decimal Convert(Unit unitFrom, Unit unitTo)
    {
        decimal value =  unitFrom.Value; 
        List<Unit> units = GetUnits();
        if (unitFrom.Rank < unitTo.Rank)
        {
            for (int i = unitFrom.Rank; i < unitTo.Rank; i++)
            {
                value /= units[i].EquationForUpperValue;
            }
            return value;
        }
        else
        {
            for (int i = unitFrom.Rank; i > unitTo.Rank; i--)
            {
                value *= units[i-1].EquationForUpperValue;
            }
            return value;
        }

    }

    public abstract List<Unit> GetUnits();
}
