using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R11546004FuzzySetNamespace
{
    public class ZFuzzySet : FuzzySet
    {
        static int count = 1;
        [Category("參數")]
        [DisplayName("Top")]
        [Description("函數開始下降的地方")]
        public double Top
        {
            get
            {
                return parameters[0];
            }
            set
            {
                if (value <= Base) parameters[0] = value;
                ExecuteShapeChangedEvent();
            }
        }
        [Category("參數")]
        [DisplayName("Right")]
        [Description("函數落到最低點的地方")]
        public double Base
        {
            get => parameters[1];
            set
            {
                if (value >= Top) parameters[1] = value;
                ExecuteShapeChangedEvent();
            }
        }
        public ZFuzzySet(Universe theUniverse) : base(theUniverse)
        {
            parameters = new double[2] { 1.0+ randomizer.NextDouble(), 5.0+ randomizer.NextDouble() };
            title = $"Z{count++}";
        }
        public override double GetMemberShipDegree(double x)
        {
            double y;
            if (x <= parameters[0])
            {
                y = 1;
            }
            else if (x <= (parameters[0] + parameters[1]) / 2)
            {
                y = 1 - 2 * ((x - parameters[0]) / (parameters[1] - parameters[0])) * ((x - parameters[0]) / (parameters[1] - parameters[0]));
            }
            else if (x < parameters[1])
            {
                y = 2 * ((x - parameters[1]) / (parameters[1] - parameters[0])) * ((x - parameters[1]) / (parameters[1] - parameters[0]));
            }
            else
            {
                y = 0.0;
            }
            return y;
        }
        public override double MaxDegree => 1.0;
    }
}


