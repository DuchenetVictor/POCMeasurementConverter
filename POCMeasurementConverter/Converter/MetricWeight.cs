using POCMeasurementConverter.Model;
using System;
using System.Collections.Generic;

namespace POCMeasurementConverter.Converter
{
    public class MetricWeight : ConverterBase
    {
        public override List<Unit> GetUnits()
        {
            return new List<Unit> { new Unit(0, "milligram",10),
                                    new Unit(1, "centigram",10),
                                    new Unit(2, "decigram",10),
                                    new Unit(3, "gram",10),
                                    new Unit(4, "dekagram",10),
                                    new Unit(4, "hektogram",10),
                                    new Unit(5, "Kilogram") };

        }

    }
}
