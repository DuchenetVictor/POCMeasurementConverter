using POCMeasurementConverter.Model;
using System.Collections.Generic;

namespace POCMeasurementConverter.Converter
{
    public class ImperialDistance : ConverterBase
    {

        private const string inch = "inch";
        private const string foot = "foot";
        private const string yard = "yard";
        private const string mile = "mile";

        public override List<Unit> GetUnits()
        {
            return new List<Unit> {
            new Unit(0, inch,12),
            new Unit(1, foot,3),
            new Unit(2, yard,1760),
            new Unit(3, mile) };
        }
    }
}
