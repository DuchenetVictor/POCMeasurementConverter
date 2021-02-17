using POCMeasurementConverter.Model;
using System.Collections.Generic;

namespace POCMeasurementConverter.Converter
{
    interface IConverter
    {
        List<Unit> GetUnits();

        decimal Convert(Unit unitFrom, Unit unitTo);
    }
}
