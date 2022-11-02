using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;

namespace R11546004FuzzySetNamespace
{
    public class FuzzySet
    {
        protected Random randomizer = new Random();
        protected double[] parameters;
        protected string title;
        protected Series theSeries;
        protected Universe theUniverse;
        protected bool highlight;
        protected TreeNode theNode;
        public event EventHandler ShapeChanged;
        protected bool visualDisplay = false;
        [Category("函數特徵")]
        [Description("是否為單調函數")]
        public virtual bool IsMonotonic 
        { 
            get
            {
                
                if (GetMemberShipDegree(theUniverse.LowerBound) >= GetMemberShipDegree(theUniverse.UpperBound))
                {
                    double prev = GetMemberShipDegree(theUniverse.LowerBound);
                    for (double x = theUniverse.LowerBound; x <= theUniverse.UpperBound; x += theUniverse.Increment)
                    {
                        if (prev < this.GetMemberShipDegree(x))
                        {
                            return false;
                        }
                        prev = this.GetMemberShipDegree(x);
                    }
                }
                else
                {
                    double prev = GetMemberShipDegree(theUniverse.LowerBound);
                    for (double x = theUniverse.LowerBound; x <= theUniverse.UpperBound; x += theUniverse.Increment)
                    {
                        if (prev > this.GetMemberShipDegree(x))
                        {
                            return false;
                        }
                        prev = this.GetMemberShipDegree(x);
                    }
                }
                return true;
            }
        }
        
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Category("識別屬性")]
        [Description("Fuzzy Set所屬的Universe")]
        public Universe TheUniverse
        {
            get => theUniverse;
            set { value = theUniverse; }
        }
        //public string UniverseName { get { return theUniverse.Title; } }
        [Category("外觀設定")]
        [Description("是否加粗線條")]
        public bool HighLight { get { return highlight; } set { highlight = value;
                if (theSeries != null) { 
                    UpdateSeries();
                }
            } }
        [Browsable(false)]
        public TreeNode TheNode
        {
            get { return theNode; }
            set
            {
                theNode = value;
            }
        }
        [Category("識別屬性")]
        [Description("Fuzzy Set名稱")]
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                if (theSeries!= null)
                {
                    try
                    {
                        //theSeries.LegendText = title;
                        //theSeries.Label = title;
                        theSeries.Name = title;
                    }
                    catch
                    {

                    }
                }
                if (theNode!=null)
                    theNode.Text = title;
                ExecuteShapeChangedEvent();
            }
        }

        [Browsable(false)]
        public Series TheSeries { get => theSeries; }

        public FuzzySet( Universe theUniverse )
        {
            this.theUniverse = theUniverse;
            this.TheUniverse.BoundChanged += TheUniverse_BoundChanged;
        }

        private void TheUniverse_BoundChanged(object sender, EventArgs e)
        {
            UpdateSeries();
        }

        public void UpdateSeries()
        {
            if (theUniverse == null)
            {
                return;
            }
            if (theSeries == null) { return; }
            
            theSeries.Points.Clear();
            int counter = 0;
            for (double x = theUniverse.LowerBound; x<= theUniverse.UpperBound; x += theUniverse.Increment)
            {
                double y = GetMemberShipDegree(x);
                theSeries.Points.AddXY(x, y);
                counter += 1;
            }
            if (HighLight)
            {
                theSeries.BorderWidth = 5;
            }
            else
            {
                theSeries.BorderWidth = 2;
            }
            theNode.Text = theSeries.Name;
        }

        protected void ExecuteShapeChangedEvent()
        {
            UpdateSeries();
            if (ShapeChanged!= null)
            {
                ShapeChanged(this, null);
            }
        }
        [Browsable(false)]
        public virtual double COACrispvalue
        {
            get
            {
                double area = 0;
                double sumOfxTimesDeltaArea = 0;
                double shift = 0;
                if (theUniverse.LowerBound < 0) { shift = Math.Abs(theUniverse.LowerBound); }
                for(double x = theUniverse.LowerBound; x<= theUniverse.UpperBound; x+= theUniverse.Increment)
                {
                    double deltaArea = this.GetMemberShipDegree(x) * theUniverse.Increment;
                    sumOfxTimesDeltaArea += (shift+x) * deltaArea;
                    area += deltaArea;
                }
                if (area == 0) { return (theUniverse.LowerBound+ theUniverse.UpperBound)/2; }
                return (sumOfxTimesDeltaArea/area) - shift;
            }
        }
        [Browsable(false)]
        public virtual double BOACrispvalue
        {
            get
            {
                int k = (int) (1+((theUniverse.UpperBound - theUniverse.LowerBound) / theUniverse.Increment));
                double[] deltaAreaArr = new double[k];
                int i = 0;
                for (double x = theUniverse.LowerBound; x <= theUniverse.UpperBound; x += theUniverse.Increment)
                {
                    deltaAreaArr[i] = this.GetMemberShipDegree(x) * theUniverse.Increment;
                    i++;
                }
                int left_idx = 0;
                int right_idx = k-1;
                double left_area = 0.0;
                double right_area = 0.0;
                while (left_idx < right_idx)
                {
                    if (left_area < right_area)
                    {
                        left_idx += 1;
                        left_area += deltaAreaArr[left_idx];
                    }
                    else if ((left_area > right_area))
                    {
                        right_idx -= 1;
                        right_area += deltaAreaArr[right_idx];
                    }
                    else
                    {
                        left_idx += 1;
                        left_area += deltaAreaArr[left_idx];
                        right_idx -= 1;
                        right_area += deltaAreaArr[right_idx];
                    }
                }
                return theUniverse.LowerBound + (theUniverse.Increment* left_idx);
            }
        }
        [Browsable(false)]
        public virtual double MOMCrispvalue
        {
            get
            {
                double max_value = double.MinValue;
                List<double> ls = new List<double> { };
                for (double x = theUniverse.LowerBound; x <= theUniverse.UpperBound; x += theUniverse.Increment)
                {
                    if(GetMemberShipDegree(x) > max_value)
                    {
                        ls = new List<double> { };
                        ls.Add(x);
                        max_value = GetMemberShipDegree(x);
                    }
                    else if (GetMemberShipDegree(x) == max_value)
                    {
                        ls.Add(x);
                    }
                }
                return ls.Sum() / ls.Count();
            }
        }
        [Browsable(false)]
        public virtual double SOMCrispvalue
        {
            get
            {
                double max_value = double.MinValue;
                double smallest = 0.0;
                for (double x = theUniverse.LowerBound; x <= theUniverse.UpperBound; x += theUniverse.Increment)
                {
                    if (GetMemberShipDegree(x) > max_value)
                    {
                        smallest = x;
                        max_value = GetMemberShipDegree(x);
                    }
                }
                return smallest;
            }
        }
        [Browsable(false)]
        public virtual double LOMCrispvalue
        {
            get
            {
                double max_value = double.MinValue;
                double largest = 0.0;
                for (double x = theUniverse.LowerBound; x <= theUniverse.UpperBound; x += theUniverse.Increment)
                {
                    if (GetMemberShipDegree(x) >= max_value)
                    {
                        largest = x;
                        max_value = GetMemberShipDegree(x);
                    }
                }
                return largest;
            }
        }
        public virtual double GetUniverseValueForADegree(double degree)
        {
            //if (degree == 1) { degree -= double.MinValue; }
            if (this.GetMemberShipDegree(theUniverse.LowerBound) >= this.GetMemberShipDegree(theUniverse.UpperBound))
            {
                for (double x = theUniverse.LowerBound; x <= theUniverse.UpperBound; x += theUniverse.Increment)
                {
                    if (degree > this.GetMemberShipDegree(x))
                    {
                        return x;
                    }
                }
            }
            else
            {
                for (double x = theUniverse.LowerBound; x <= theUniverse.UpperBound; x += theUniverse.Increment)
                {
                    if (degree < this.GetMemberShipDegree(x))
                    {
                        return x;
                    }
                }
            }

            return GetUniverseValueForADegree(degree - 0.01);
        }
        public virtual double GetMemberShipDegree(double x)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return title;
        }
        public void deleteFuzzySet()
        {
            theUniverse.TheTree.SelectedNode.Remove();
            TheSeries.Enabled = false;
        }
        [Category("函數特徵")]
        [Description("函數最大值")]
        public virtual double MaxDegree
        {
            get
            {
                double maxDegree = double.MinValue;
                if (theSeries != null)
                {
                    foreach (DataPoint dp in theSeries.Points)
                    {
                        double y = dp.YValues[0];
                        if (y > maxDegree)
                        {
                            maxDegree = y;
                        }
                    }
                }
                else
                {
                    for (double x = theUniverse.LowerBound;x <= theUniverse.UpperBound; x += theUniverse.Increment)
                    {
                        double y = GetMemberShipDegree(x);
                        if (y > maxDegree)
                        {
                            maxDegree = y;
                        }
                    }
                }
                return maxDegree;
            }
        }
        [Browsable(false)]
        public bool VisualDisplay
        { 
            get => visualDisplay;
            set
            {
                if (value && !visualDisplay) 
                {
                    if (theSeries == null)
                    {
                        theSeries = new Series();
                        theSeries.ChartType = SeriesChartType.Line;
                        theSeries.Name = title;
                        theSeries.Tag = this;
                        theSeries.ChartArea = TheUniverse.TheArea.Name;
                        theSeries.Legend = TheUniverse.TheLegend.Name;
                    } 
                   
                    if (theNode == null)
                    {
                        TheNode = new TreeNode();
                        TheNode.Tag = this;
                        TheNode.ImageIndex = 0;
                        TheNode.Text = title;
                        TheNode.SelectedImageIndex = TheNode.ImageIndex;
                    }
                    UpdateSeries();
                }

            } 
        }
        #region OPERATOR OVERLOADING
        /// <summary>
        /// Negate Operation
        /// </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        static public FuzzySet operator !(FuzzySet operand)
        {
            return new UnaryOperatedFS(new Negate(),operand);
        }
        // Intersection
        static public FuzzySet operator &(FuzzySet op1, FuzzySet op2)
        {
            return new BinaryOperatedFS(new Intersect(), op1,op2);
        }
        static public FuzzySet operator ^(FuzzySet op1, FuzzySet op2)
        {
            return new BinaryOperatedFS(new AlgebraicTnormOperator(), op1, op2);
        }
        static public FuzzySet operator %(FuzzySet op1, FuzzySet op2)
        {
            return new BinaryOperatedFS(new AlgebraicSnormOperator(), op1, op2);
        }
        static public FuzzySet operator >>(FuzzySet op1, int p)
        {
            Extremely op = new Extremely();
            op.OperatorParameters = new double[1] { (double) p };
            return new UnaryOperatedFS(op, op1);
        }
        static public FuzzySet operator <<(FuzzySet op1, int p )
        {
            Extremely op = new Extremely();
            op.OperatorParameters = new double[1] { (double)p };
            return new UnaryOperatedFS(op, op1);
        }

        static public FuzzySet operator |(FuzzySet op1, FuzzySet op2)
        {
            return new BinaryOperatedFS(new Union(), op1, op2);
        }
        static public FuzzySet operator -(double scaleFactor, FuzzySet fs)
        {
            ValueCut op = new ValueCut();
            op.OperatorParameters = new double[1] { scaleFactor };
            return new UnaryOperatedFS(op, fs);
        }
        static public FuzzySet operator *(double scaleFactor, FuzzySet fs)
        {
            ValueScale op = new ValueScale();
            op.OperatorParameters = new double[1] { scaleFactor };
            return new UnaryOperatedFS(op, fs);
        }
        static public FuzzySet operator + (FuzzySet fs)
        {
            Concentration op = new Concentration();
            return new UnaryOperatedFS(op,fs);
        }
        static public FuzzySet operator ++(FuzzySet fs)
        {
            VeryVery op = new VeryVery();
            return new UnaryOperatedFS(op, fs);
        }
        static public FuzzySet operator -(FuzzySet fs)
        {
            Dilation op = new Dilation();
            return new UnaryOperatedFS(op, fs);
        }
        static public FuzzySet operator --(FuzzySet fs)
        {
            return -(-fs);
        }

        [Browsable(false)]
        public int SavedHashCode { set; get; }
        internal void Save(StreamWriter sw)
        {
            sw.WriteLine($"Title:{title}");
            sw.WriteLine($"HashCode:{this.GetHashCode()}");
            int num = 0;
            if (parameters != null) { num = parameters.Length; }
            sw.WriteLine($"NumberOfParameters:{num}");
            for (int i = 0; i< num; i++)
            {
                sw.WriteLine($"Par{i + 1}:{parameters[i]}");
            }
            sw.WriteLine($"VisualDisplay:{visualDisplay}");
            //sw.WriteLine($"IsMonotonic:{IsMonotonic}");
            // invoke extra data
            ExtraSave(sw);
        }

        internal void Open(StreamReader sr)
        {
            string[] items;
            items = sr.ReadLine().Split(':');
            Title = items[1];
            items = sr.ReadLine().Split(':');
            SavedHashCode = Convert.ToInt32(items[1]);
            int num;
            items = sr.ReadLine().Split(':');
            num = Convert.ToInt32( items[1]);
            parameters = new double[num];
            for (int i = 0; i < num; i++)
            {
                items = sr.ReadLine().Split(':');
                parameters[i] = Convert.ToDouble(items[1]);
            }
            items = sr.ReadLine().Split(':');
            VisualDisplay = Convert.ToBoolean(items[1]);
            //items = sr.ReadLine().Split(':');
            //IsMonotonic = Convert.ToBoolean(items[1]);
            // invoke extra data
            ExtraOpen(sr);
        }
        public virtual void RebuildFuzzySetReferences(List<FuzzySet> newFSs) 
        { 
        }
        public virtual void ExtraOpen(StreamReader sr)
        {

        }
        public virtual void ExtraSave(StreamWriter sw)
        {

        }

        #endregion
    }
}
