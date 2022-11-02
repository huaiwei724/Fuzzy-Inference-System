using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R11546004FuzzySetNamespace
{
    public class GuassianFuzzySet : FuzzySet
    {
        static int count = 1;
        [Category("參數")]
        [DisplayName("平均")]
        [Description("高斯函數中平均值")]
        public double Center
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
        [DisplayName("標準差")]
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
        public GuassianFuzzySet(Universe theUniverse): base(theUniverse)
        {
            double c = randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound) + theUniverse.LowerBound;
            double std = randomizer.NextDouble() * 0.15 * (theUniverse.UpperBound - theUniverse.LowerBound);
            parameters = new double[2] { c,  std};
            title = $"Guassian{count++}";
        }
        public override double GetMemberShipDegree(double x)
        {
            double y = new double();
            y = Math.Exp(-0.5 * (x - parameters[0]) * (x - parameters[0]) / (parameters[1] * parameters[1]));
            
            return y;
        }
        public override double MaxDegree => 1.0;
        public override double COACrispvalue => Center;
        //public override double MaxDegree { get => 1.0;}
        /*
        public double[,] GetControlPoint()
        {
            double[,] arr = new double[2,2] { { Center, GetMemberShipDegree(Center) }, { Center-standardDeviation, GetMemberShipDegree(Center-standardDeviation) } }; 
            return arr;
        }*/
    }
}
