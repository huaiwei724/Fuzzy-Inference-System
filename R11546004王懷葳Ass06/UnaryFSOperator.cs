using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R11546004FuzzySetNamespace
{
    public class UnaryFSOperator
    {
        protected double[] operatorParameters;
        protected string title;
        [Browsable(false)]
        public virtual double[] OperatorParameters { get { return operatorParameters; } set { operatorParameters = value; } }
        public string Title
        {
            get
            {
                return title;
            }
        }
        public virtual double GetResult(double degree)
        {
            throw new NotImplementedException("");
        }

        internal void Save(StreamWriter sw)
        {
            throw new NotImplementedException();
        }

        internal void Open(StreamReader sr)
        {
            throw new NotImplementedException();
        }
    }
    public class Negate: UnaryFSOperator
    {
        public Negate()
        {
            title = "Negate";
        }
        public override double[] OperatorParameters { get { return null; } set { } }
        public override double GetResult(double degree)
        {
            return 1.0 - degree;
        }
        public override string ToString()
        {
            return "Negate Operator";
        }

    }
    public class Concentration: UnaryFSOperator
    {
        [Category("參數")]
        public double ConcentrationRatio
        {
            get
            {
                return OperatorParameters[0];
            }
            set
            {
                if (value >= 1){
                    OperatorParameters[0] = value;
                }
                
            }
        }
        public Concentration() { title = "Concentration"; OperatorParameters = new double[1] { 2.0}; }
        public override double[] OperatorParameters { get { return operatorParameters; }
            set { operatorParameters = value;} }
        public override double GetResult(double degree)
        {
            return Math.Pow(degree, operatorParameters[0]);
        }
        public override string ToString()
        {
            return "Concentration Operator";
        }
    }
    public class VeryVery: UnaryFSOperator
    {
        [Category("參數")]
        public double ConcentrationRatio
        {
            get
            {
                return OperatorParameters[0];
            }
            set
            {
                if (value >= 1)
                {
                    OperatorParameters[0] = value;
                }

            }
        }
        public VeryVery() { title = "VeryVery"; OperatorParameters = new double[1] { 4.0 }; }
        public override double[] OperatorParameters
        {
            get { return operatorParameters; }
            set { operatorParameters = value; }
        }
        public override double GetResult(double degree)
        {
            return Math.Pow(degree, operatorParameters[0]);
        }
        public override string ToString()
        {
            return "VeryVery Operator";
        }
    }
    public class Extremely: UnaryFSOperator
    {
        [Category("參數")]
        public double ConcentrationRatio
        {
            get
            {
                return OperatorParameters[0];
            }
            set
            {
                if (value >= 1)
                {
                    OperatorParameters[0] = value;
                }

            }
        }
        public Extremely() { title = "Extremely"; OperatorParameters = new double[1] { 8.0 }; }
        public override double[] OperatorParameters
        {
            get { return operatorParameters; }
            set { operatorParameters = value; }
        }
        public override double GetResult(double degree)
        {
            return Math.Pow(degree, operatorParameters[0]);
        }
        public override string ToString()
        {
            return "Extremely Operator";
        }
    }
    public class Dilation : UnaryFSOperator
    {
        public Dilation() { title = "Dilation"; OperatorParameters = new double[1] { 0.5 }; }
        [Category("參數")]
        public double DilationRatio{ get => OperatorParameters[0];
            set
            {
                if (value <= 1) { OperatorParameters[0] = value; }
            }
        }
        public override double[] OperatorParameters
        {
            get { return operatorParameters; }
            set { operatorParameters = value; }
        }
        public override double GetResult(double degree)
        {
            return Math.Pow(degree, operatorParameters[0]);
        }
        public override string ToString()
        {
            return "Dilation Operator";
        }
    }
    public class Intensification : UnaryFSOperator
    {
        public Intensification() { title = "Intensification"; OperatorParameters = new double[] {}; }
        public override double[] OperatorParameters
        {
            get { return operatorParameters; }
            set { operatorParameters = value; }
        }
        public override double GetResult(double degree)
        {
            if (degree <= 0.5)
            {
                return 2*degree*degree;
            }
            else
            {
                return 1 - (2 * (1 - degree) * (1 - degree));
            }
        }
        public override string ToString()
        {
            return "Intensification Operator";
        }
    }
    public class Diminisher: UnaryFSOperator
    {
        public Diminisher() { title = "Diminisher"; OperatorParameters = new double[] {}; }
        public override double[] OperatorParameters
        {
            get { return operatorParameters; }
            set { operatorParameters = value; }
        }
        public override double GetResult(double degree)
        {
            if (degree <= 0.5)
            {
                return Math.Sqrt(degree/2);
            }
            else
            {
                return 1-Math.Sqrt((1-degree)/2);
            }
        }
        public override string ToString()
        {
            return "Diminisher Operator";
        }
    }
    public class ValueCut : UnaryFSOperator
    {
        public ValueCut() { title = "ValueCut"; OperatorParameters = new double[1] { 0.5}; }
        [Category("參數")]
        [Description("函數切割的值")]
        public double Value
        {
            get => OperatorParameters[0];
            set
            {
                if (value <= 1) { OperatorParameters[0] = value; }
            }
        }
        public override double[] OperatorParameters
        {
            get { return operatorParameters; }
            set { if (value[0]>=0 && value[0]<= 1) { operatorParameters = value; } }
        }
        public override double GetResult(double degree)
        {
            if (degree <= OperatorParameters[0])
            {
                return degree;
            }
            else
            {
                return OperatorParameters[0];
            }
        }
        public override string ToString()
        {
            return "ValueCut Operator";
        }
    }
    public class ValueScale : UnaryFSOperator
    {
        public ValueScale() { title = "ValueScale"; OperatorParameters = new double[1] { 0.5 }; }
        [Category("參數")]
        [Description("函數的乘數")]
        public double Scaler
        {
            get => OperatorParameters[0];
            set
            {
                if (value <= 1 && value >= 0) { OperatorParameters[0] = value; }
            }
        }
        public override double[] OperatorParameters
        {
            get { return operatorParameters; }
            set { if (value[0] >= 0 && value[0] <= 1) { operatorParameters = value; } }
        }
        public override double GetResult(double degree)
        {
            return degree * OperatorParameters[0];
        }
        public override string ToString()
        {
            return "ValueScale Operator";
        }
    }

}
