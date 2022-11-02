using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R11546004FuzzySetNamespace
{
    public class SigmoidFuzzySet : FuzzySet
    {
        static int count = 1;
        [Category("參數")]
        [DisplayName("斜率")]
        [Description("函數的傾斜程度")]
        public double Slope
        {
            get
            {
                return parameters[0];
            }
            set
            {
                parameters[0] = value;
                ExecuteShapeChangedEvent();
            }
        }
        [Category("參數")]
        [DisplayName("Inflect")]
        [Description("函數的反曲點")]
        public double Inflect
        {
            get => parameters[1];
            set
            {
                parameters[1] = value;
                ExecuteShapeChangedEvent();
            }
        }
        public SigmoidFuzzySet(Universe theUniverse) : base(theUniverse)
        {
            double c = randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound) + theUniverse.LowerBound;
            double std = randomizer.NextDouble() * 0.15 * (theUniverse.UpperBound - theUniverse.LowerBound);
            parameters = new double[2] { c, std };
            title = $"Sigmoid{count++}";
        }
        public override double GetMemberShipDegree(double x)
        {
            double y;
            y = 1 / (1 + Math.Exp(-1 * parameters[0] * (x - parameters[1])));
            return y;
        }
        public override double MaxDegree => 1.0;
        public override bool IsMonotonic => true;
    }
}
