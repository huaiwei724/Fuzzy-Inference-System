using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R11546004FuzzySetNamespace
{
    public class UnaryOperatedFS: FuzzySet
    {
        UnaryFSOperator theOperator;
        FuzzySet theOperand;

        [Browsable(false)]
        public int OperandHashCode { get; set; }

        public override void ExtraSave(StreamWriter sw)
        {
            //Save the hash code of the operand
            sw.WriteLine($"*OperandFSHashCode:{TheOperand.GetHashCode()}");
            //Save the information of the  operator
            sw.WriteLine($"*OperatorType:{TheOperator.GetType().Name}");
            //theOperator.Save(sw);

            int num = 0;
            if (OperatorParam!= null) { num = OperatorParam.Length; }
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
            OperandHashCode = Convert.ToInt32(items[1]);
            // read in type of the operator
            items = sr.ReadLine().Split(':');
            Type opType = Type.GetType($"R11546004FuzzySetNamespace.{items[1]}");
            theOperator = (UnaryFSOperator) Activator.CreateInstance(opType);
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
        public UnaryOperatedFS(Universe u) : base(u)
        {

        }
        [Category("運算子")]
        [Description("運算子種類")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public UnaryFSOperator TheOperator
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
        protected double[] operatorParam;
        [Browsable(false)]
        public double[] OperatorParam { get { return theOperator.OperatorParameters; }
            set { 
                
                theOperator.OperatorParameters = value;
                operatorParam = theOperator.OperatorParameters;
                ExecuteShapeChangedEvent();
            } }

        [Browsable(false)]
        public FuzzySet TheOperand { get => theOperand; set
            {
                theOperand = value;
                ExecuteShapeChangedEvent();
            } }

        /// <summary>
        /// Constructor of generic uniary operator operated fuzzy set.
        /// </summary>
        /// <param name="theOperator"></param>
        /// <param name="theFS"></param>
        public UnaryOperatedFS(UnaryFSOperator theOperator, FuzzySet theFS): base(theFS.TheUniverse)
        {
            this.theOperator = theOperator;
            this.TheOperand = theFS;
            title = $"{theOperator.Title}{theFS.Title}";
            //theSeries.ChartArea = theUniverse.TheArea.Name;
            //theSeries.Legend = theUniverse.TheLegend.Name;
            //subscribe shapechanged
            TheOperand.ShapeChanged += TheOperand_ShapeChanged;
        }

        private void TheOperand_ShapeChanged(object sender, EventArgs e)
        {
            Title = $"{theOperator.Title}{TheOperand.Title}";
            ExecuteShapeChangedEvent();
        }

        public override double GetMemberShipDegree(double x)
        {
            if (TheOperand == null || theOperator == null) return 0.0; 
            double originalDegree = TheOperand.GetMemberShipDegree(x);
            double degree = theOperator.GetResult(originalDegree);
            return degree;
        }

        public override void RebuildFuzzySetReferences(List<FuzzySet> newFSs)
        {

            foreach (FuzzySet fs in newFSs)
            {
                if (fs.SavedHashCode == OperandHashCode)
                {
                    TheOperand = fs;
                    break;
                }
            }
        }
    }
}
