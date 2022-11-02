using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R11546004FuzzySetNamespace
{
    public class BellFuzzySet : FuzzySet
    {
        static int count = 1;
        [Category("參數")]
        [DisplayName("HalfWidth")]
        [Description("鐘型函數的寬")]
        public double HalfWidth
        {
            get
            {
                return parameters[0];
            }
            set
            {
                if (value != 0)
                {
                    parameters[0] = value;
                    ExecuteShapeChangedEvent();
                }
            }
        }
        [Category("參數")]
        [DisplayName("Centre")]
        [Description("鐘型函數的中間值")]
        public double Centre
        {
            get => parameters[2];
            set
            {
                parameters[2] = value;
                ExecuteShapeChangedEvent();
            }
        }
        [Category("參數")]
        [DisplayName("Slope")]
        [Description("鐘型函數的斜率")]
        public double Slope
        {
            get => parameters[1];
            set
            {
                parameters[1] = value;
                ExecuteShapeChangedEvent();
            }
        }
        public BellFuzzySet(Universe theUniverse) : base(theUniverse)
        {
            parameters = new double[3] { 4+ randomizer.NextDouble(), 5+ randomizer.NextDouble(), 6+ randomizer.NextDouble() };
            title = $"Bell{count++}";
        }
        public override double GetMemberShipDegree(double x)
        {
            double y;
            y = 1 / (1 + Math.Pow(Math.Abs((x - parameters[2]) / parameters[0]), 2 * parameters[1]));

            return y;
        }
        public override double MaxDegree => 1.0;
    }
}
