
using POCMeasurementConverter.Model;
using System;
using System.Collections.Generic;

namespace POCMeasurementConverter.Converter
{
    public class MetricVolume : ConverterBase
    {

        public override List<Unit> GetUnits()
        {
            return new List<Unit> { new Unit(0, "milliliter",10),
                                    new Unit(1, "centiliter",10),
                                    new Unit(2, "deciliter",10),
                                    new Unit(3, "liter",10),
                                    new Unit(4, "dekaliter",10),
                                    new Unit(5, "hektoliter") };
                                
        }
    }
}
