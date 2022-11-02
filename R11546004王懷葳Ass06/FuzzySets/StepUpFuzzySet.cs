using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R11546004FuzzySetNamespace
{
    public class StepUpFuzzySet : FuzzySet
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
                if (value <= Right)
                {
                    parameters[0] = value;
                    ExecuteShapeChangedEvent();
                }
            }
        }
        [Category("參數")]
        [DisplayName("Right")]
        [Description("函數抵達最高點的地方")]
        public double Right
        {
            get
            {
                return parameters[1];
            }
            set
            {
                if (value >= Left)
                {
                    parameters[1] = value;
                    ExecuteShapeChangedEvent();
                }
            }
        }
        public StepUpFuzzySet(Universe theUniverse) : base(theUniverse)
        {
            double left = 2.0;
            double right = 7.0;
            parameters = new double[2] { left + randomizer.NextDouble(), right + randomizer.NextDouble() };
            title = $"StepUp{count++}";
        }
        public override double GetMemberShipDegree(double x)
        {
            double y;
            if (x <= parameters[0]) { y = 0.0; }
            else if (x <= parameters[1]) { y = (x - parameters[0]) / (parameters[1] - parameters[0]); }
            else { y = 1.0; }
            return y;

        }
        public override double MaxDegree => 1.0;
    }
}
