using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R11546004FuzzySetNamespace
{
    public class SFuzzySet : FuzzySet
    {
        static int count = 1;
        [Category("參數")]
        [DisplayName("Left")]
        [Description("函數開始上升的地方")]
        public double Base
        {
            get
            {
                return parameters[0];
            }
            set
            {
                if (value < Top) parameters[0] = value;
                ExecuteShapeChangedEvent();
            }
        }
        [Category("參數")]
        [DisplayName("Right")]
        [Description("函數抵達最高點的地方")]
        public double Top
        {
            get => parameters[1];
            set
            {
                if (value > Base) parameters[1] = value;
                ExecuteShapeChangedEvent();
            }
        }
        public SFuzzySet(Universe theUniverse) : base(theUniverse)
        {
            
            parameters = new double[2] { 1.0+ randomizer.NextDouble()*2, 5.0+ randomizer.NextDouble()*2 };
            title = $"S{count++}";
        }
        public override double GetMemberShipDegree(double x)
        {
            double y;
            if (x <= parameters[0])
            {
                y = 0;
            }
            else if (x <= (parameters[0]+parameters[1])/2)
            {
                y = 2 * ((x - parameters[0]) / (parameters[1] - parameters[0])) * ((x - parameters[0]) / (parameters[1] - parameters[0]));
            }
            else if (x < parameters[1])
            {
                y = 1- 2*((x - parameters[1]) / (parameters[1] - parameters[0])) * ((x - parameters[1]) / (parameters[1] - parameters[0]));
            }
            else
            {
                y = 1.0;
            }
            return y;
        }
        public override double MaxDegree => 1.0;
    }
}


