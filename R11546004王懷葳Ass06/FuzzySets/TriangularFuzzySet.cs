using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R11546004FuzzySetNamespace
{
    public class TriangularFuzzySet: FuzzySet
    {
        static int count = 1;
        [Category("參數")]
        [DisplayName("Left")]
        [Description("函數開始上升的地方")]
        public double Left
        {
            get
            {
                return parameters[0];
            }
            set
            {
                if (value <= Peak)
                {
                    parameters[0] = value;
                    ExecuteShapeChangedEvent();
                }
            }
        }
        [Category("參數")]
        [DisplayName("Peak")]
        [Description("最高點")]
        public double Peak
        {
            get
            {
                return parameters [1];
            }
            set
            {
                if (value >= Left && value <= Right)
                {
                    parameters[1] = value;
                    ExecuteShapeChangedEvent();
                }
            }
        }
        [Category("參數")]
        [DisplayName("Right")]
        [Description("函數回到最低點的地方")]
        public double Right
        {
            get
            {
                return parameters[2];
            }
            set
            {
                if (value >= Peak)
                {
                    parameters[2] = value;
                    ExecuteShapeChangedEvent();
                }
            }
        }
        public TriangularFuzzySet(Universe theUniverse) : base(theUniverse)
        {
            double left = 2.0;
            double peak = 5.0;
            double right = 7.0;
            parameters = new double[3] { left+ randomizer.NextDouble(), peak+ randomizer.NextDouble(), right+ randomizer.NextDouble() };
            title = $"Triangular{count++}";
        }
        public override double GetMemberShipDegree(double x)
        {
            double y;
            if (x <= parameters[0]) { y = 0.0; }
            else if (x <= parameters[1]) { y = (x - parameters[0]) / (parameters[1] - parameters[0]); }
            else if (x <= parameters[2]) { y = (parameters[2] - x) / (parameters[2] - parameters[1]); }
            else { y = 0.0; }
            return y;

        }
        public override double MaxDegree => 1.0;
    }
}
