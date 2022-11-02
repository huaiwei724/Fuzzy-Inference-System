using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R11546004FuzzySetNamespace
{
    public class TwoSidedGuassianFuzzySet : FuzzySet
    {
        static int count = 1;
        [Category("參數")]
        [DisplayName("左邊平均")]
        [Description("高斯函數中平均值")]
        public double LeftCenter
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
        [DisplayName("左邊標準差")]
        [Description("高斯函數的標準差(正數)")]
        public double StandardDeviation
        {
            get => parameters[1];
            set
            {
                if (value > 0.0) parameters[1] = value;
                ExecuteShapeChangedEvent();
            }
        }
        [Category("參數")]
        [DisplayName("右邊平均")]
        [Description("高斯函數中平均值")]
        public double RightCenter
        {
            get
            {
                return parameters[2];
            }
            set
            {
                if (value >= parameters[0])
                    parameters[2] = value;
                ExecuteShapeChangedEvent();
            }
        }

        [Category("參數")]
        [DisplayName("右邊標準差")]
        [Description("高斯函數的標準差(正數)")]
        public double RightStandardDeviation
        {
            get => parameters[3];
            set
            {
                if (value > 0.0) parameters[3] = value;
                ExecuteShapeChangedEvent();
            }
        }
        public TwoSidedGuassianFuzzySet(Universe theUniverse) : base(theUniverse)
        {
            double c1 = randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound) /2 + theUniverse.LowerBound;
            double std1 = randomizer.NextDouble() * 0.15 * (theUniverse.UpperBound - theUniverse.LowerBound);
            double c2 = c1 + 1;
            double std2 = randomizer.NextDouble() * 0.15 * (theUniverse.UpperBound - theUniverse.LowerBound);

            parameters = new double[4] { c1, std1, c2,std2 };
            title = $"TwoSidedGuassian{count++}";
        }
        public override double GetMemberShipDegree(double x)
        {

            double y = new double();
            if (x < parameters[0])
                y = Math.Exp(-0.5 * (x - parameters[0]) * (x - parameters[0]) / (parameters[1] * parameters[1]));
            else if (x < parameters[2])
                y = 1;
            else
                y = Math.Exp(-0.5 * (x - parameters[2]) * (x - parameters[2]) / (parameters[3] * parameters[3]));



            return y;
        }
        public override double MaxDegree => 1.0;
        //public override double COACrispvalue => Center;
    }
}
