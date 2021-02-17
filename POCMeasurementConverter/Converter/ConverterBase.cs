using POCMeasurementConverter.Converter;
using POCMeasurementConverter.Model;
using System.Collections.Generic;

public abstract class ConverterBase : IConverter
{
    /// <summary>
    /// Convert your measure into another measure
    /// 
    /// </summary>
    /// <param name="unitFrom"></param>
    /// <param name="unitTo"></param>
    /// <returns> the new amount converted from the UnitFrom Value</returns>
    public decimal Convert(Unit unitFrom, Unit unitTo)
    {
        if (unitFrom.Value == 0) return 0;
        if (unitFrom.Rank == unitTo.Rank) return unitFrom.Value;


        decimal value = unitFrom.Value;
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
                value *= units[i - 1].EquationForUpperValue;
            }
            return value;
        }
    }

    public abstract List<Unit> GetUnits();
}
