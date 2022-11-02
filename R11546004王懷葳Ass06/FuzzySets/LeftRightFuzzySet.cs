using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R11546004FuzzySetNamespace
{
    public class LeftRightFuzzySet : FuzzySet
    {
        static int count = 1;
        [Category("參數")]
        [DisplayName("Peak")]
        [Description("函數最高點的位置")]
        public double Peak
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
        [DisplayName("Left")]
        [Description("函數開始上升的地方")]
        public double Left
        {
            get => parameters[1];
            set
            {
                if (value != 0.0) parameters[1] = value; ExecuteShapeChangedEvent();
            }
        }
        [Category("參數")]
        [DisplayName("Right")]
        [Description("函數回到最低點的地方")]
        public double Right
        {
            get => parameters[2];
            set
            {
                if(value != 0.0) parameters[2] = value; ExecuteShapeChangedEvent();
            }
        }
        public LeftRightFuzzySet(Universe theUniverse) : base(theUniverse)
        {
            
            parameters = new double[3] { 3.0+ randomizer.NextDouble()*2, 1.0+ randomizer.NextDouble()*2, 3.0+ randomizer.NextDouble()*2 };
            title = $"LeftRight{count++}";
            //theSeries.ChartArea = theUniverse.TheArea.Name;
            //theSeries.Legend = theUniverse.TheLegend.Name;

        }
        public override double GetMemberShipDegree(double x)
        {
            double y;
            double z;
            if (x <= parameters[0])
            {
                z = (parameters[0] - x) / parameters[1];
                y = Math.Sqrt(Math.Max(0, 1 - (z * z)));
            }
            else
            {
                z = (parameters[0] - x) / parameters[2];
                y = Math.Exp(-1 * Math.Pow(Math.Abs(z), 3));
            }
            return y;
        }
        public override double MaxDegree => 1.0;
    }
}

