using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R11546004FuzzySetNamespace
{
    public class TrapezoidalFuzzySet : FuzzySet
    {
        static int count = 1;
        [Category("參數")]
        [DisplayName("Left")]
        [Description("函數開始上升的地方")]
        public double LeftPoint
        {
            get
            {
                return parameters[0];
            }
            set
            {
                if (value <= LeftTop)
                {
                    parameters[0] = value;
                    ExecuteShapeChangedEvent();
                }
            }
        }
        [Category("參數")]
        [DisplayName("LeftTop")]
        [Description("函數抵達最高點的地方")]
        public double LeftTop
        {
            get
            {
                return parameters[1];
            }
            set
            {
                if (value >= LeftPoint && value <= RightTop)
                {
                    parameters[1] = value;
                    ExecuteShapeChangedEvent();
                }
            }
        }
        [Category("參數")]
        [DisplayName("RightTop")]
        [Description("函數開始下降的地方")]
        public double RightTop
        {
            get
            {
                return parameters[2];
            }
            set
            {
                if (value >= LeftTop && value <= Right)
                {
                    parameters[2] = value;
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
                return parameters[3];
            }
            set
            {
                if (value >= RightTop)
                {
                    parameters[3] = value;
                    ExecuteShapeChangedEvent();
                }
            }
        }
        public TrapezoidalFuzzySet(Universe theUniverse) : base(theUniverse)
        {
            parameters = new double[4] { 1+ randomizer.NextDouble(), 4+ randomizer.NextDouble(), 6+ randomizer.NextDouble(), 8+ randomizer.NextDouble() };
            title = $"Trapezoidal{count++}";
        }
        public override double GetMemberShipDegree(double x)
        {
            double y;
            y = Math.Max(Math.Min(Math.Min((x-LeftPoint)/(LeftTop-LeftPoint),1), (Right - x) / (Right - RightTop)), 0);
            return y;

        }
        public override double MaxDegree => 1.0;
    }
}

