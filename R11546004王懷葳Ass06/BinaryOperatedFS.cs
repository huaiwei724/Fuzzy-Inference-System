using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R11546004FuzzySetNamespace
{
    public class BinaryOperatedFS : FuzzySet
    {
        BinaryFSOperator theOperator;
        FuzzySet theOperand1;
        FuzzySet theOperand2;
        protected double[] operatorParam;
        [Browsable(false)]
        public int Operand1HashCode { get; set; }
        [Browsable(false)]
        public int Operand2HashCode { get; set; }
        public override void ExtraSave(StreamWriter sw)
        {
            //Save the hash code of the operand
            sw.WriteLine($"*OperandFSHashCode:{TheOperand1.GetHashCode()}");
            sw.WriteLine($"*OperandFSHashCode:{TheOperand2.GetHashCode()}");
            //Save the information of the  operator
            sw.WriteLine($"*OperatorType:{TheOperator.GetType().Name}");
            //theOperator.Save(sw);

            int num = 0;
            if (OperatorParam != null) { num = OperatorParam.Length; }
            sw.WriteLine($"NumberOfParameters:{num}");
            for (int i = 0; i < num; i++)
            {
                sw.WriteLine($"Par{i + 1}:{OperatorParam[i]}");
            }
        }
        public override void ExtraOpen(StreamReader sr)
        {
            string[] items;
            items = sr.ReadLine().Split(':');
            Operand1HashCode= Convert.ToInt32(items[1]);
            items = sr.ReadLine().Split(':');
            Operand2HashCode = Convert.ToInt32(items[1]);
            // read in type of the operator
            items = sr.ReadLine().Split(':');
            Type opType = Type.GetType($"R11546004FuzzySetNamespace.{items[1]}");
            theOperator = (BinaryFSOperator)Activator.CreateInstance(opType);
            //theOperator.Open(sr);

            items = sr.ReadLine().Split(':');
            int num = Convert.ToInt32(items[1]);
            OperatorParam = new double[num];
            for (int i = 0; i < num; i++)
            {
                items = sr.ReadLine().Split(':');
                OperatorParam[i] = Convert.ToDouble(items[1]);
            }
        }
        [Browsable(false)]
        public FuzzySet TheOperand1
        {
            get => theOperand1; set
            {
                theOperand1 = value;
                ExecuteShapeChangedEvent();
            }
        }
        [Browsable(false)]
        public FuzzySet TheOperand2
        {
            get => theOperand2; set
            {
                theOperand2 = value;
                ExecuteShapeChangedEvent();
            }
        }
        [Category("運算子")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public BinaryFSOperator TheOperator
        {
            get
            {
                return theOperator;
            }
            set
            {
                theOperator = value;
                ExecuteShapeChangedEvent();
            }
        }
        public BinaryOperatedFS(Universe u) : base(u)
        {

        }
        [Browsable(false)]
        public double[] OperatorParam
        {
            get { return theOperator.OperatorParameters; }
            set
            {

                theOperator.OperatorParameters = value;
                operatorParam = theOperator.OperatorParameters;
                ExecuteShapeChangedEvent();
            }
        }

        /// <summary>
        /// Constructor of generic uniary operator operated fuzzy set.
        /// </summary>
        /// <param name="theOperator"></param>
        /// <param name="theFS"></param>
        public BinaryOperatedFS(BinaryFSOperator theOperator, FuzzySet theFS1, FuzzySet theFS2) : base(theFS1.TheUniverse)
        {
            this.theOperator = theOperator;
            this.theOperand1 = theFS1;
            this.theOperand2 = theFS2;
            title= $"{theFS1.Title}{theOperator.Title}{theFS2.Title}";
            //theSeries.ChartArea = theUniverse.TheArea.Name;
            //theSeries.Legend = theUniverse.TheLegend.Name;
            //subscribe shapechanged
            theOperand1.ShapeChanged += TheOperand_ShapeChanged;
            theOperand2.ShapeChanged += TheOperand_ShapeChanged;
        }

        private void TheOperand_ShapeChanged(object sender, EventArgs e)
        {
            Title = $"{theOperand1.Title}{theOperator.Title}{theOperand2.Title}";
            ExecuteShapeChangedEvent();
        }

        public override double GetMemberShipDegree(double x)
        {
            
            if (theOperand1 == null || theOperand2 == null) return 0.0;
            double originalDegree1 = theOperand1.GetMemberShipDegree(x);
            double originalDegree2 = theOperand2.GetMemberShipDegree(x);
            double degree = theOperator.GetResult(originalDegree1, originalDegree2);
            return degree;
        }
        public override void RebuildFuzzySetReferences(List<FuzzySet> newFSs)
        {

            foreach (FuzzySet fs in newFSs)
            {
                if (fs.SavedHashCode == Operand1HashCode)
                {
                    TheOperand1 = fs;
                }
                else if(fs.SavedHashCode == Operand2HashCode)
                {
                    TheOperand2 = fs;
                }
            }
        }
    }
}
