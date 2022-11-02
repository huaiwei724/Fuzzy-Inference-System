using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace R11546004FuzzySetNamespace
{
    public class Universe
    {
        private static int count = 0;
        public string title;
        private double lowerBound = 0;
        private double upperBound = 10;
        private double increment = 0.01;
        private ChartArea theArea;
        private Legend theLegend;
        public event EventHandler BoundChanged;
        protected TreeNode theNode;
        private static TreeView theTree;
        protected bool isInput = true;
        protected DataGridViewColumn theRuleCol;
        protected DataGridViewColumn theInferCol;
        private static DataGridView dgv_rule;
        private static DataGridView dgv_infer;
        [Browsable(false)]
        public DataGridView Dgv_rule { set { dgv_rule = value; } get { return dgv_rule; } }
        [Browsable(false)]
        public DataGridView Dgv_infer { set { dgv_infer = value; }get { return dgv_infer; } }
        [Browsable(false)]
        public DataGridViewColumn TheRuleCol { get => theRuleCol;set {theRuleCol = value; } }
        [Browsable(false)]
        public DataGridViewColumn TheInferCol { get => theInferCol; set {theInferCol = value; } }
        [Browsable(false)]
        public bool IsInput { get => isInput; 
            set { isInput = value;
            if (!isInput)
                {
                    theRuleCol.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    theRuleCol.DefaultCellStyle.ForeColor = Color.Gold;
                    theInferCol = null;
                }
            } 
        }

        [Browsable(false)]
        //[TypeConverter(typeof(ExpandableObjectConverter))]
        public Legend TheLegend { get => theLegend; }
        [Browsable(false)]
        public TreeView TheTree
        {
            get { return theTree; }
            set { theTree = value; }
        }

        [Browsable(false)]
        public TreeNode TheNode
        {
            get { return theNode; }
            set
            {
                theNode = value;
                theNode.Text = theArea.AxisX.Title;
            }
        }
        [Category("識別屬性")]
        [Description("Universe名稱")]
        public string Title
        {
            get { return theArea.AxisX.Title; }
            set { theArea.AxisX.Title = value;
                theNode.Text = theArea.AxisX.Title;
                if (theInferCol!= null)
                    theInferCol.HeaderText = Title;
                if (theRuleCol!=null)
                    theRuleCol.HeaderText = Title;
            }
        }
        // C# Property definition
        [Category("參數")]
        [Description("Universe的下限(實數值)")]
        public double LowerBound
        {
            get
            {
                return lowerBound;
            }
            set
            {
                if (value <= upperBound)
                {
                    lowerBound = value;
                    theArea.AxisX.Minimum = lowerBound;
                    //Trigger Bound changed event
                    if (BoundChanged != null)
                    {
                        BoundChanged(this, null);
                    }
                }
            }
        }
        [Category("參數")]
        [Description("Universe的上限(實數值)")]
        public double UpperBound { get => upperBound;
            set
            {
                if (value >= lowerBound)
                { 
                    upperBound = value;
                    increment = (upperBound-lowerBound)/ 200;
                    theArea.AxisX.Maximum = upperBound;
                    if (BoundChanged != null)
                    {
                        BoundChanged(this, null);
                    }
                }
            }
        }

        [Browsable(false)]
        public ChartArea TheArea { get => theArea; }
        [Category("參數")]
        [Description("Universe上的間格距離)")]
        public double Increment { get => increment; set
        { 
             if (value > 0) increment = value; }
        }

        public Universe()
        {
            title = $"Universe{count++}";
            theArea = new ChartArea();
            theArea.AxisY.Title = "Degree";
            theArea.AxisX.Title = theArea.Name = title;
            theArea.AxisX.Enabled = theArea.AxisY.Enabled = AxisEnabled.True;

            theLegend = new Legend();
            theLegend.Docking = Docking.Top;
            theLegend.Name = theArea.AxisX.Title;
            theLegend.Alignment = System.Drawing.StringAlignment.Center;
            theLegend.IsDockedInsideChartArea = false;
            theLegend.DockedToChartArea = theArea.Name;
            theLegend.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;

            theArea.AxisX.Minimum = lowerBound;
            theArea.AxisX.Maximum = upperBound;


            TheNode = new TreeNode();
            TheNode.Tag = this;
            TheNode.ImageIndex = 2;
            TheNode.SelectedImageIndex = TheNode.ImageIndex;

            theRuleCol = new DataGridViewTextBoxColumn();
            theRuleCol.HeaderText = Title;
            //theRuleCol.HeaderCell
            //theRuleCol.DefaultCellStyle.Font = new Font("Arial", 10);
            theRuleCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            theRuleCol.Tag = this;

            theInferCol = new DataGridViewTextBoxColumn();
            theInferCol.HeaderText = Title;
            //theInferCol.DefaultCellStyle.Font = new Font("Arial", 10);//, FontStyle.Bold);
            theInferCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            theInferCol.Tag = this;

        }
        public override string ToString()
        {
            return Title;
        }
        public void deleteUniverse()
        {
            //TheTree.SelectedNode.Remove();
            theTree.Nodes.Remove(TheNode);
            TheArea.Visible = false;
            if (theInferCol != null && isInput)
            { 
                Dgv_infer.Columns.Remove(TheInferCol);
            }
            if (theRuleCol != null)
            {
                Dgv_rule.Columns.Remove(TheRuleCol);
            }
        }
        public void Save(StreamWriter sw)
        {
            sw.WriteLine($"Title/LowerBound/UpperBound/Increment:" +
                $"{Title}: {LowerBound} : {UpperBound} : {Increment}");
        }
        public void Open(StreamReader sr)
        {
            //string str;
            string[] items;
            items = sr.ReadLine().Split(':');
            Title = items[1];
            LowerBound = Convert.ToDouble(items[2]);
            UpperBound = Convert.ToDouble(items[3]);
            Increment = Convert.ToDouble(items[4]);
        }
    }
}
