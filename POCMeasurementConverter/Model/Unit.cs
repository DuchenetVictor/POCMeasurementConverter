namespace POCMeasurementConverter.Model
{
    public class Unit
    {
        public int Rank { get; set; }
        public string Name { get; set; }

        public decimal Value { get; set; }

        public decimal EquationForUpperValue { get; set; }

        public Unit(int rank, string name)
        {
            Rank = rank;
            Name = name;
            Value = 0;
            EquationForUpperValue = 0;
        }

        public Unit(int rank, string name, decimal equationForUpperValue)
        { 
            Rank = rank;
            Name = name;
            Value = 0;
            EquationForUpperValue = equationForUpperValue;
        }
    }
}