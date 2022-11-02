using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R11546004FuzzySetNamespace
{
    public class BinaryFSOperator
    {
        protected double[] operatorParameters;
        protected string title;
        public virtual double[] OperatorParameters { get { return operatorParameters; } set { operatorParameters = value; } }
        public string Title
        {
            get
            {
                return title;
            }
        }
        public virtual double GetResult(double degree1, double degree2)
        {
            throw new NotImplementedException("");
        }

    }
    public class Intersect: BinaryFSOperator
    {
        public Intersect()
        {
            title = "Intersect";
        }
        public override double[] OperatorParameters { get { return null; } set { } }
        public override double GetResult(double degree1, double degree2)
        {
            return Math.Min(degree1, degree2);
        }
        public override string ToString()
        {
            return "Intersect Operator";
        }

    }
    public class Union : BinaryFSOperator
    {
        public Union()
        {
            title = "Union";
        }
        public override double[] OperatorParameters { get { return null; } set { } }
        public override double GetResult(double degree1, double degree2)
        {
            return Math.Max(degree1, degree2);
        }
        public override string ToString()
        {
            return "Union Operator";
        }
    }
    public class AlgebraicProduct : BinaryFSOperator
    {
        public AlgebraicProduct()
        {
            title = "AlgebraicProduct";
        }
        //public override double[] OperatorParameters { get { return null; } set { } }
        public override double GetResult(double degree1, double degree2)
        {
            return degree1*degree2;
        }
        public override string ToString()
        {
            return "AlgebraicProduct Operator";
        }
    }
    public class Subtraction : BinaryFSOperator
    {
        public Subtraction()
        {
            title = "Subtraction";
        }
        public override double[] OperatorParameters { get { return null; } set { } }
        public override double GetResult(double degree1, double degree2)
        {
            return Math.Min(degree1, 1 - degree2);
        }
        public override string ToString()
        {
            return "Subtraction Operator";
        }
    }
    public class AlgebraicTnormOperator : BinaryFSOperator
    {
        public AlgebraicTnormOperator()
        {
            title = "AlgebraicTnorm";
        }
        public override double[] OperatorParameters { get { return null; } set { } }
        public override double GetResult(double degree1, double degree2)
        {
            return degree1*degree2;
        }
        public override string ToString()
        {
            return "AlgebraicTnorm";
        }
    }
    public class BoundedTnormOperator : BinaryFSOperator
    {
        public BoundedTnormOperator()
        {
            title = "BoundedTnorm";
        }
        public override double[] OperatorParameters { get { return null; } set { } }
        public override double GetResult(double degree1, double degree2)
        {
            return Math.Max(0, (degree1 + degree2 - 1));
        }
        public override string ToString()
        {
            return "BoundedTnorm";
        }
    }
    public class DrasticTnormOperator : BinaryFSOperator
    {
        public DrasticTnormOperator()
        {
            title = "DrasticTnorm";
        }
        public override double[] OperatorParameters { get { return null; } set { } }
        public override double GetResult(double degree1, double degree2)
        {
            if (degree1 == 1)
            {
                return degree2;
            }
            else if (degree2 == 1)
            {
                return degree1;
            }
            else
            {
                return 0;
            }
        }
        public override string ToString()
        {
            return "DrasticTnorm";
        }
    }
    public class AlgebraicSnormOperator : BinaryFSOperator
    {
        public AlgebraicSnormOperator()
        {
            title = "AlgebraicSnorm";
        }
        public override double[] OperatorParameters { get { return null; } set { } }
        public override double GetResult(double degree1, double degree2)
        {
            return degree1 + degree2 - (degree1 * degree2);
        }
        public override string ToString()
        {
            return "AlgebraicSnorm";
        }
    }
    public class BoundedSnormOperator : BinaryFSOperator
    {
        public BoundedSnormOperator()
        {
            title = "BoundedSnorm";
        }
        public override double[] OperatorParameters { get { return null; } set { } }
        public override double GetResult(double degree1, double degree2)
        {
            return Math.Min(1, (degree1 + degree2));
        }
        public override string ToString()
        {
            return "BoundedSnorm";
        }
    }
    public class DrasticSnormOperator : BinaryFSOperator
    {
        public DrasticSnormOperator()
        {
            title = "DrasticSnorm";
        }
        public override double[] OperatorParameters { get { return null; } set { } }
        public override double GetResult(double degree1, double degree2)
        {
            if (degree1 == 0)
            {
                return degree2;
            }
            else if (degree2 == 0)
            {
                return degree1;
            }
            else
            {
                return 1;
            }
        }
        public override string ToString()
        {
            return "DrasticSnorm";
        }
    }
    public class HamachersSnorm: BinaryFSOperator
    {
        public HamachersSnorm()
        {
            title = "Hamacher's Snorm";
            OperatorParameters = new double[1] { 1.0 };
        }
        public double Parameter
        {
            get { return OperatorParameters[0]; }
            set
            {
                if (value >= 0.0)
                {
                    OperatorParameters[0] = value;
                }
            }
        }
        public override double GetResult(double degree1, double degree2)
        {
            return (degree1 + degree2 - (2 - OperatorParameters[0]) * degree1 * degree2) / (1 - (1 - OperatorParameters[0]) * degree1 * degree2);
        }
        public override string ToString()
        {
            return "Hamacher's Snorm";
        }
    }
    public class HamachersTnorm : BinaryFSOperator
    {
        public HamachersTnorm()
        {
            title = "Hamacher's Tnorm";
            OperatorParameters = new double[1] { 1.0 };
        }
        public double Parameter
        {
            get { return OperatorParameters[0]; }
            set
            {
                if (value >= 0.0)
                {
                    OperatorParameters[0] = value;
                }
            }
        }
        public override double GetResult(double degree1, double degree2)
        {
            return (degree1*degree2)/(OperatorParameters[0]+(1-OperatorParameters[0])*(degree1+degree2-degree1*degree2));
        }
        public override string ToString()
        {
            return "Hamacher's Tnorm";
        }
    }
    public class FrankSnorm : BinaryFSOperator
    {
        public FrankSnorm()
        {
            title = "Frank Snorm";
            OperatorParameters = new double[1] { 2.0 };
        }
        public double Parameter
        {
            get { return OperatorParameters[0]; }
            set
            {
                if (value >= 0.0)
                {
                    OperatorParameters[0] = value;
                }
            }
        }
        public override double GetResult(double degree1, double degree2)
        {
            return 1 - Math.Log(1+((Math.Pow(OperatorParameters[0],1-degree1)-1)*(Math.Pow(OperatorParameters[0],1-degree2)-1)/(OperatorParameters[0]-1)),OperatorParameters[0]);
        }
        public override string ToString()
        {
            return "Frank Snorm";
        }
    }
    public class FrankTnorm : BinaryFSOperator
    {
        public FrankTnorm()
        {
            title = "Frank Tnorm";
            OperatorParameters = new double[1] { 2.0 };
        }
        public double Parameter
        {
            get { return OperatorParameters[0]; }
            set
            {
                if (value >= 0.0)
                {
                    OperatorParameters[0] = value;
                }
            }
        }
        public override double GetResult(double degree1, double degree2)
        {
            return Math.Log(1 + ((Math.Pow(OperatorParameters[0], degree1) - 1) * (Math.Pow(OperatorParameters[0], degree2) - 1) / (OperatorParameters[0] - 1)), OperatorParameters[0]);
        }
        public override string ToString()
        {
            return "Frank Tnorm";
        }
    }
    public class YagerTnormOperator : BinaryFSOperator
    {
        public YagerTnormOperator()
        {
            title = "YagerTnorm";
            OperatorParameters = new double[1] { 1.0 };
        }
        public double Parameter
        {
            get { return OperatorParameters[0]; }
            set
            {
                if (value >= 0.0)
                {
                    OperatorParameters[0] = value;
                }
            }
        }
        public override double GetResult(double degree1, double degree2)
        {
            return 1 - Math.Min(1,Math.Pow(Math.Pow(1-degree1,OperatorParameters[0])+Math.Pow(1-degree2,OperatorParameters[0]),1/OperatorParameters[0]));
        }
        public override string ToString()
        {
            return "YagerTnorm";
        }
    }
    public class YagerSnormOperator : BinaryFSOperator
    {
        public YagerSnormOperator()
        {
            title = "YagerSnorm";
            OperatorParameters = new double[1] { 1.0 };
        }
        public double Parameter
        {
            get { return OperatorParameters[0]; }
            set
            {
                if (value >= 0.0)
                {
                    OperatorParameters[0] = value;
                }
            }
        }
        public override double GetResult(double degree1, double degree2)
        {
            return Math.Min(1, Math.Pow(Math.Pow(degree1, OperatorParameters[0]) + Math.Pow(degree2, OperatorParameters[0]), 1 / OperatorParameters[0]));
        }
        public override string ToString()
        {
            return "YagerSnorm";
        }
    }
    public class SchweizerTnormOperator : BinaryFSOperator
    {
        public SchweizerTnormOperator()
        {
            title = "SchweizerTnorm";
            OperatorParameters = new double[1] { 2.0 };
        }
        public double Parameter
        {
            get { return OperatorParameters[0]; }
            set
            {
                if (value != 0) { OperatorParameters[0] = value; }
            }
        }
        public override double GetResult(double degree1, double degree2)
        {
            return Math.Pow(Math.Max(0,Math.Pow(degree1, -1*OperatorParameters[0]) + Math.Pow(degree2, -1*OperatorParameters[0]) -1), 1 / OperatorParameters[0]);
        }
        public override string ToString()
        {
            return "SchweizerTnorm";
        }
    }
    public class SchweizerSnormOperator : BinaryFSOperator
    {
        public SchweizerSnormOperator()
        {
            title = "SchweizerSnorm";
            OperatorParameters = new double[1] { 1.0 };
        }
        public double Parameter
        {
            get { return OperatorParameters[0]; }
            set
            {
                OperatorParameters[0] = value;
            }
        }
        public override double GetResult(double degree1, double degree2)
        {
            return 1 - Math.Pow(Math.Max(0, Math.Pow(1 - degree1, -1 * OperatorParameters[0]) + Math.Pow(1 - degree2, -1 * OperatorParameters[0]) - 1), 1 / OperatorParameters[0]);
        }
        public override string ToString()
        {
            return "SchweizerSnorm";
        }
    }
    public class DuboisTnormOperator : BinaryFSOperator
    {
        public DuboisTnormOperator()
        {
            title = "DuboisTnorm";
            OperatorParameters = new double[1] { 1.0 };
        }
        public double Parameter
        {
            get { return OperatorParameters[0]; }
            set
            {
                if (value >= 0.0 && value <= 1.0)
                {
                    OperatorParameters[0] = value;
                }
            }
        }
        public override double GetResult(double degree1, double degree2)
        {

            return (degree1*degree2)/(Math.Max(Math.Max(degree1,degree2),OperatorParameters[0]));
        }
        public override string ToString()
        {
            return "DuboisTnorm";
        }
    }
    public class DuboisSnormOperator : BinaryFSOperator
    {
        public DuboisSnormOperator()
        {
            title = "DuboisSnorm";
            OperatorParameters = new double[1] { 1.0 };
        }
        public double Parameter
        {
            get { return OperatorParameters[0]; }
            set
            {
                if (value >= 0.0 && value <= 1.0)
                {
                    OperatorParameters[0] = value;
                }
            }
        }
        public override double GetResult(double degree1, double degree2)
        {

            return degree1+degree2 - degree1*degree2 - (Math.Min(degree1,Math.Min(degree2,(1-OperatorParameters[0])))/Math.Max(Math.Max(1-degree1,1-degree2),OperatorParameters[0]));
        }
        public override string ToString()
        {
            return "DuboisSnorm";
        }
    }
    public class SugenoTnormOperator : BinaryFSOperator
    {
        public SugenoTnormOperator()
        {
            title = "SugenoTnorm";
            OperatorParameters = new double[1] { 1.0 };
        }
        public double Parameter
        {
            get { return OperatorParameters[0]; }
            set
            {
                if (value >= -1.0)
                {
                    OperatorParameters[0] = value;
                }
            }
        }
        public override double GetResult(double degree1, double degree2)
        {

            return Math.Max(0, (OperatorParameters[0]+1) * (degree1+degree2-1) - OperatorParameters[0] * degree1 * degree2);
        }
        public override string ToString()
        {
            return "SugenoTnorm";
        }
    }
    public class SugenoSnormOperator : BinaryFSOperator
    {
        public SugenoSnormOperator()
        {
            title = "SugenoSnorm";
            OperatorParameters = new double[1] { 1.0 };
        }
        public double Parameter
        {
            get { return OperatorParameters[0]; }
            set
            {
                if (value >= -1.0)
                {
                    OperatorParameters[0] = value;
                }
            }
        }
        public override double GetResult(double degree1, double degree2)
        {

            return Math.Min(1, (degree1 + degree2) - OperatorParameters[0] * degree1 * degree2);
        }
        public override string ToString()
        {
            return "SugenoSnorm";
        }
    }
    public class DombiTnormOperator : BinaryFSOperator
    {
        public DombiTnormOperator()
        {
            title = "DombiTnorm";
            OperatorParameters = new double[1] { 1.0 };
        }
        public double Parameter
        {
            get { return OperatorParameters[0]; }
            set
            {
                if (value >= 0.0)
                {
                    OperatorParameters[0] = value;
                }
            }
        }
        public override double GetResult(double degree1, double degree2)
        {
            double y;
            y = Math.Pow(Math.Pow((1 / degree1) - 1, OperatorParameters[0]) + Math.Pow((1 / degree2) - 1, OperatorParameters[0]), 1 / OperatorParameters[0]);
            return 1/(1+y);
        }
        public override string ToString()
        {
            return "DombiTnorm";
        }
    }
    public class DombiSnormOperator : BinaryFSOperator
    {
        public DombiSnormOperator()
        {
            title = "DombiSnorm";
            OperatorParameters = new double[1] { 1.0 };
        }
        public double Parameter
        {
            get { return OperatorParameters[0]; }
            set
            {
                if (value >= 0.0)
                {
                    OperatorParameters[0] = value;
                }
            }
        }
        public override double GetResult(double degree1, double degree2)
        {
            double y;
            y = Math.Pow(Math.Pow((1 / degree1) - 1,-1* OperatorParameters[0]) + Math.Pow((1 / degree2) - 1,-1* OperatorParameters[0]), -1 / OperatorParameters[0]);
            return 1 / (1 + y);
        }
        public override string ToString()
        {
            return "DombiSnorm";
        }
    }
}
