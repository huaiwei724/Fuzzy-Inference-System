using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R11546004FuzzySetNamespace
{
    class PiFuzzySet:FuzzySet
    {
        static int count = 1;

        [Category("參數")]
        [DisplayName("LeftBase")]
        [Description("函數開始上升的地方")]
        public double LeftBase
        {
            get
            {
                return parameters[0];
            }
            set
            {
                if (value <= LeftTop) parameters[0] = value;
                ExecuteShapeChangedEvent();
            }
        }
        [Category("參數")]
        [DisplayName("LeftTop")]
        [Description("函數抵達最高點的地方")]
        public double LeftTop
        {
            get => parameters[1];
            set
            {
                if (value >= LeftBase && value <= RightTop ) parameters[1] = value;
                ExecuteShapeChangedEvent();
            }
        }
        [Category("參數")]
        [DisplayName("RightTop")]
        [Description("函數開始下降的地方")]
        public double RightTop
        {
            get => parameters[2];
            set
            {
                if (value >= LeftTop && value <= RightBase) parameters[2] = value;
                ExecuteShapeChangedEvent();
            }
        }
        [Category("參數")]
        [DisplayName("RightBase")]
        [Description("函數回到最低點的地方")]
        public double RightBase
        {
            get => parameters[3];
            set
            {
                if (value >= RightTop) parameters[3] = value;
                ExecuteShapeChangedEvent();
            }
        }
        public PiFuzzySet(Universe theUniverse) : base(theUniverse)
        {
            
            parameters = new double[4] { 1.0+ randomizer.NextDouble(), 3.0+ randomizer.NextDouble(), 5.0+ randomizer.NextDouble(), 7.0+ randomizer.NextDouble() };
            title = $"Pi{count++}";
        }
        public override double GetMemberShipDegree(double x)
        {
            double y;
            if (x <= parameters[0])
            {
                y = 0;
            }
            else if (x <= (parameters[0] + parameters[1]) / 2)
            {
                y = 2 * ((x - parameters[0]) / (parameters[1] - parameters[0])) * ((x - parameters[0]) / (parameters[1] - parameters[0]));
            }
            else if (x < parameters[1])
            {
                y = 1 - 2 * ((x - parameters[1]) / (parameters[1] - parameters[0])) * ((x - parameters[1]) / (parameters[1] - parameters[0]));
            }
            else if (x <= parameters[2])
            {
                y = 1;
            }
            else if (x <= (parameters[2] + parameters[3]) / 2)
            {
                y = 1 - 2 * ((x - parameters[2]) / (parameters[3] - parameters[2])) * ((x - parameters[2]) / (parameters[3] - parameters[2]));
            }
            else if (x < parameters[3])
            {
                y = 2 * ((x - parameters[3]) / (parameters[3] - parameters[2])) * ((x - parameters[3]) / (parameters[3] - parameters[2]));
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
