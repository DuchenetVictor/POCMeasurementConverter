
using POCMeasurementConverter.Model;
using System;
using System.Collections.Generic;

namespace POCMeasurementConverter.Converter
{
    public class MetricVolume : ConverterBase
    {

        public override List<Unit> GetUnits()
        {
            return new List<Unit> { new Unit(0, "millilitre",10),
                                    new Unit(1, "centilitre",10),
                                    new Unit(2, "decilitre",10),
                                    new Unit(3, "litre",10),
                                    new Unit(4, "dekalitre",10),
                                    new Unit(5, "hektolitre") };
                                
        }
    }
}
