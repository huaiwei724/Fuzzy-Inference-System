using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Windows.Input;
using System.Threading;
using System.Reflection;
using System.Collections;
using System.IO;

namespace R11546004FuzzySetNamespace
{
    public partial class Form_Main : Form
    {
        // FuzzySet's List for combobox
        List<Type> FSList = new List<Type>(){typeof(StepUpFuzzySet), typeof(StepDownFuzzySet)
            , typeof(TriangularFuzzySet), typeof(GuassianFuzzySet) ,typeof(BellFuzzySet), typeof(SigmoidFuzzySet)
                        , typeof(LeftRightFuzzySet), typeof(SFuzzySet), typeof(ZFuzzySet), typeof(TrapezoidalFuzzySet), typeof(PiFuzzySet)
                        , typeof(TwoSidedGuassianFuzzySet)};
        List<Type> UnaryList = new List<Type>(){ typeof(Negate), typeof(Concentration)
            ,typeof(VeryVery),typeof(Extremely), typeof(Dilation)
        , typeof(Intensification), typeof(Diminisher),typeof(ValueCut),typeof(ValueScale)};
        List<Type> BinaryList = new List<Type>(){ typeof(Intersect), typeof(Union), typeof(Subtraction)
        , typeof(AlgebraicTnormOperator),typeof(BoundedTnormOperator),typeof(DrasticTnormOperator)
        ,typeof(AlgebraicSnormOperator),typeof(BoundedSnormOperator),typeof(DrasticSnormOperator)
        ,typeof(AlgebraicProduct),typeof(HamachersSnorm),typeof(YagerTnormOperator)
        , typeof(DuboisTnormOperator)
            ,typeof(HamachersTnorm),typeof(FrankSnorm),typeof(FrankTnorm),typeof(YagerSnormOperator)
        , typeof(SugenoSnormOperator),typeof(SugenoTnormOperator),typeof(DombiTnormOperator),typeof(DombiSnormOperator) };
        //,typeof(SchweizerTnormOperator), typeof(SchweizerSnormOperator) };
        List<Type> Monotonic_FSList = new List<Type>(){typeof(StepUpFuzzySet), typeof(StepDownFuzzySet)
            , typeof(SigmoidFuzzySet), typeof(SFuzzySet), typeof(ZFuzzySet)
                        };
        public Form_Main()
        {
            InitializeComponent();
            comboBox_chooseFuzzy.SelectedIndex = 1;
            comboBox_Binary.SelectedIndex = 0;
            comboBox_Unary.SelectedIndex = 0;
            comboBox_chooseFuzzy.ValueMember = null;
            comboBox_chooseFuzzy.DataSource = FSList;
            comboBox_chooseFuzzy.DisplayMember = "Name";
            comboBox_Unary.ValueMember = null;
            comboBox_Unary.DataSource = UnaryList;
            comboBox_Unary.DisplayMember = "Name";
            comboBox_Binary.ValueMember = null;
            comboBox_Binary.DataSource = BinaryList;
            comboBox_Binary.DisplayMember = "Name";


            Universe theU = new Universe();
            theU.TheTree = treeView_Main;
            theU.Dgv_infer = dataGridView_Infer;
            theU.Dgv_rule = dataGridView_Rule;

            FuzzySystemChanged(null, null);

        }
        public static Type GetAnyElementType(Type type)
        {
            // Type is Array
            // short-circuit if you expect lots of arrays 
            if (type.IsArray)
                return type.GetElementType();

            // type is IEnumerable<T>;
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                return type.GetGenericArguments()[0];

            // type implements/extends IEnumerable<T>;
            var enumType = type.GetInterfaces()
                                    .Where(t => t.IsGenericType &&
                                           t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                                    .Select(t => t.GenericTypeArguments[0]).FirstOrDefault();
            return enumType ?? type;
        }
        public IEnumerable<Type> GetGenericIEnumerables(object o)
        {
            return o.GetType()
                    .GetInterfaces()
                    .Where(t => t.IsGenericType
                        && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                    .Select(t => t.GetGenericArguments()[0]);
        }
        IEnumerable<TreeNode> Collect(TreeNodeCollection nodes)
        {
            // 一個用來疊代所有的Tree node的Function 後面會用到
            foreach (TreeNode node in nodes)
            {
                yield return node;

                foreach (var child in Collect(node.Nodes))
                    yield return child;
            }
        }
        private void btn_addUniverse_Click(object sender, EventArgs e)
        {
            // Button 新增一個Universe 

            Universe universe = new Universe();
            int index;
            // 將Area 跟Legend 加入圖表(將不同Area的Legend分開)
            //chart_Main.ChartAreas.Add(universe.TheArea);
            index = treeView_Main.Nodes[0].GetNodeCount(false);
            if (treeView_Main.SelectedNode.Index == 1)
            {
                index += treeView_Main.Nodes[1].GetNodeCount(false);
                universe.IsInput = false;
                btn_addUniverse.Enabled = false;
            }
            //chart_Main.ChartAreas.Add(universe.TheArea);
            chart_Main.ChartAreas.Insert(index, universe.TheArea);
            chart_Main.Legends.Insert(index, universe.TheLegend);
            dataGridView_Rule.Columns.Insert(index, universe.TheRuleCol);
            if (universe.IsInput)
            {
                dataGridView_Infer.Columns.Insert(index, universe.TheInferCol);
                button_addRule.Enabled = true;
                button_addAllRule.Enabled = true;
            }
            // 在TreeView 上顯示
            treeView_Main.SelectedNode.Nodes.Add(universe.TheNode);
            treeView_Main.ExpandAll();
            treeView_Main.Focus();

            radioButton_Mamdani.Enabled = false;
            radioButton_Sugeno.Enabled = false;
            radioButton_Tsukamoto.Enabled = false;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // 在選擇TreeView下面的node後
            // 利用groupbox 讓下面的物件button 無法被點選
            if (treeView_Main.SelectedNode == null) { return; }
            if (treeView_Main.SelectedNode.Level == 0)
            {
                btn_addUniverse.Enabled = true;
                groupBox_PrimaryFS.Enabled = false;
                groupBox_UnaryOpFS.Enabled = false;
                groupBox_BinaryOpFS.Enabled = false;
                if (treeView_Main.SelectedNode.Index == 0)
                    btn_addUniverse.Text = "Add an Input Universe";
                else
                {
                    if (treeView_Main.Nodes[1].GetNodeCount(false) == 1)
                    {
                        btn_addUniverse.Enabled = false;
                        btn_addUniverse.Text = "Output Universe";
                    }
                    else { btn_addUniverse.Text = "Add an Output Universe"; }
                }
                return;
            }
            else {
                btn_addUniverse.Text = "Select Input/Output to add";
                btn_addUniverse.Enabled = false; }
            propertyGrid_Main.SelectedObject = treeView_Main.SelectedNode.Tag;
  
            if (treeView_Main.SelectedNode.Tag.GetType() == typeof(Universe))
            {
                groupBox_PrimaryFS.Enabled = true;
                groupBox_UnaryOpFS.Enabled = false;
                groupBox_BinaryOpFS.Enabled = false;
                Universe theU;
                theU = (Universe)treeView_Main.SelectedNode.Tag;
                label_SelectedFS.Text = theU.Title;
                if (radioButton_Sugeno.Checked == true && !theU.IsInput)
                {
                    groupBox_PrimaryFS.Enabled = false;
                }
                if (radioButton_Tsukamoto.Checked == true && !theU.IsInput)
                {
                    comboBox_chooseFuzzy.SelectedIndex = 0;
                    comboBox_chooseFuzzy.ValueMember = null;
                    comboBox_chooseFuzzy.DataSource = Monotonic_FSList;
                    comboBox_chooseFuzzy.DisplayMember = "Name";
                }
                else
                {
                    comboBox_chooseFuzzy.SelectedIndex = 0;
                    comboBox_chooseFuzzy.ValueMember = null;
                    comboBox_chooseFuzzy.DataSource = FSList;
                    comboBox_chooseFuzzy.DisplayMember = "Name";
                }
            }
            else if (treeView_Main.SelectedNode.Tag is FuzzySet)
            {
                groupBox_PrimaryFS.Enabled = false;
                groupBox_UnaryOpFS.Enabled = true;
                groupBox_BinaryOpFS.Enabled = true;
                FuzzySet theFS;
                foreach (TreeNode node in treeView_Main.SelectedNode.Parent.Nodes)
                {

                    theFS = (FuzzySet)node.Tag;
                    theFS.HighLight = false;
                }
                theFS = (FuzzySet)treeView_Main.SelectedNode.Tag;
                label_SelectedFS.Text = theFS.Title;
                theFS.HighLight = true;  // 被選取的資料被HighLight 然後由類別自己將他更新
            }
        }
        private void treeView_Main_KeyDown(object sender, KeyEventArgs e)
        {
            //刪除按鈕 選擇後按delete鍵
            if (e.KeyCode == Keys.Delete)
            {
                //Universe: 刪除整個Universe以及移除ChartArea
                //FuzzySet: 移除單一個Function
                if (treeView_Main.SelectedNode == null) { return; }
                if (treeView_Main.SelectedNode.Level == 0) { return; }
                if (treeView_Main.SelectedNode.Tag.GetType() == typeof(Universe))
                {
                    TreeNode tn = treeView_Main.SelectedNode;
                    Universe theU = (Universe)tn.Tag;
                    theU.deleteUniverse();
                    CheckAllowAddRule();
                }
                else if (treeView_Main.SelectedNode.Tag is FuzzySet)
                {
                    FuzzySet theFS = (FuzzySet)treeView_Main.SelectedNode.Tag;
                    theFS.deleteFuzzySet();
                    if (dataGridView_Infer.Rows.Count == 0)
                        dataGridView_Infer.Rows.Add();
                    dataGridView_Rule.Rows.Clear();
                }
                propertyGrid_Main_PropertyValueChanged(sender, null);
                btn_Clear_Click(sender, null);
            }
        }
        private void CheckAllowAddRule()
        {
            foreach (var node in Collect(treeView_Main.Nodes))
            {
                if (node.Level == 1)
                {
                    button_addRule.Enabled = true;
                    button_addAllRule.Enabled = true;
                    return;
                }
            }
            button_addRule.Enabled = false;
            button_addAllRule.Enabled = false;
        }

        private void btn_addFuzzySet_Click(object sender, EventArgs e)
        {
            //依照所選的FuzzySet新增
            //新增完之後將新增的那格展開
            //再將新增的Function設為選取的Function
            if (treeView_Main.SelectedNode == null) { return; }
            
            if (treeView_Main.SelectedNode.Tag.GetType() == typeof(Universe))
            {
                Universe theU = (Universe)treeView_Main.SelectedNode.Tag;
                FuzzySet aFS;
                //利用一開始定義的List選取ComboBox
                if (radioButton_Tsukamoto.Checked && !theU.IsInput)
                {
                    aFS = (FuzzySet)Activator.CreateInstance(Monotonic_FSList[comboBox_chooseFuzzy.SelectedIndex], theU);
                }
                else
                {
                    aFS = (FuzzySet)Activator.CreateInstance(FSList[comboBox_chooseFuzzy.SelectedIndex], theU);
                }
                aFS.VisualDisplay = true;

                treeView_Main.SelectedNode.Nodes.Add(aFS.TheNode);
                chart_Main.Series.Add(aFS.TheSeries);
                treeView_Main.SelectedNode.ExpandAll();
                treeView_Main.Focus();
                //treeView_Main.SelectedNode = aFS.TheNode;
            }
        }
        private void btn_addUnary_Click(object sender, EventArgs e)
        {
            UnaryFSOperator op = (UnaryFSOperator)Activator.CreateInstance(UnaryList[comboBox_Unary.SelectedIndex]);
            FuzzySet aFS = (FuzzySet)treeView_Main.SelectedNode.Tag;
            FuzzySet newFS = new UnaryOperatedFS(op, aFS);
            if (radioButton_Tsukamoto.Checked && !newFS.TheUniverse.IsInput && !newFS.IsMonotonic)
            {
                return;
            }
            try {
                newFS.VisualDisplay = true;
                // 為了避免添加重複的FS，可以將先前的FS改名後再新增
                chart_Main.Series.Add(newFS.TheSeries);
                treeView_Main.SelectedNode.Parent.Nodes.Add(newFS.TheNode);
                treeView_Main.SelectedNode.ExpandAll();
                treeView_Main.Focus();
                //treeView_Main.SelectedNode = newFS.TheNode;
            }
            catch { }
        }

        private void btn_addBinary_Click(object sender, EventArgs e)
        {
            // add binary fuzzy set 
            BinaryFSOperator op = (BinaryFSOperator) Activator.CreateInstance(BinaryList[comboBox_Binary.SelectedIndex]);
            // get fs from button tag 
            FuzzySet firstFS = (FuzzySet)btn_Binary_FS1.Tag;
            FuzzySet secondFS = (FuzzySet)btn_Binary_FS2.Tag;
            // check fuzzy same universe
            if (firstFS.TheUniverse != secondFS.TheUniverse){return;}

            try 
            {
                // add fs to series
                FuzzySet newFS = new BinaryOperatedFS(op, firstFS, secondFS);
                // check if tsukamoto output universe is monotonic
                if (radioButton_Tsukamoto.Checked && !newFS.TheUniverse.IsInput && !newFS.IsMonotonic)
                {
                    Console.Beep();
                    return;
                }
                newFS.VisualDisplay = true;
                chart_Main.Series.Add(newFS.TheSeries);
                treeView_Main.SelectedNode.Parent.Nodes.Add(newFS.TheNode);
                treeView_Main.SelectedNode.ExpandAll();
                treeView_Main.SelectedNode = newFS.TheNode;
                treeView_Main.Focus();
            }
            catch { }
        }

        private void propertyGrid_Main_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (btn_Binary_FS1.Tag != null) { btn_Binary_FS1.Text = ((FuzzySet)btn_Binary_FS1.Tag).Title; }
            if (btn_Binary_FS2.Tag != null) { btn_Binary_FS2.Text = ((FuzzySet)btn_Binary_FS1.Tag).Title; }
            treeView1_AfterSelect(s, null);
        }

        private void btn_Binary_FS1_Click(object sender, EventArgs e)
        {
            if (treeView_Main.SelectedNode.Tag is FuzzySet)
            {
                FuzzySet aFS = (FuzzySet)treeView_Main.SelectedNode.Tag;
                btn_Binary_FS1.Tag = treeView_Main.SelectedNode.Tag;
                btn_Binary_FS1.Text = aFS.Title;
                if (btn_Binary_FS2.Tag != null)
                {
                    btn_addBinary.Enabled = true;
                    FuzzySet firstFS = (FuzzySet)btn_Binary_FS1.Tag;
                    FuzzySet secondFS = (FuzzySet)btn_Binary_FS2.Tag;
                    if (firstFS.TheUniverse != secondFS.TheUniverse) { btn_addBinary.Enabled = false; }
                }
            }
        }

        private void btn_Binary_FS2_Click(object sender, EventArgs e)
        {
            if (treeView_Main.SelectedNode.Tag is FuzzySet)
            {
                FuzzySet aFS = (FuzzySet)treeView_Main.SelectedNode.Tag;
                btn_Binary_FS2.Tag = treeView_Main.SelectedNode.Tag;
                btn_Binary_FS2.Text = aFS.Title;
                if (btn_Binary_FS1.Tag != null)
                {
                    btn_addBinary.Enabled = true;
                    FuzzySet firstFS = (FuzzySet)btn_Binary_FS1.Tag;
                    FuzzySet secondFS = (FuzzySet)btn_Binary_FS2.Tag;
                    if (firstFS.TheUniverse != secondFS.TheUniverse) { btn_addBinary.Enabled = false; }
                }
            }
            
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            // clear binary fs button
            btn_Binary_FS1.Tag = null;
            btn_Binary_FS2.Tag = null;
            btn_Binary_FS1.Text = "Click to Set 1st Fuzzy Set";
            btn_Binary_FS2.Text = "Click to Set 2nd Fuzzy Set";
        }

        private void chart_Main_MouseDown(object sender, MouseEventArgs e)
        {
            //點選線條後，線條加粗的功能
            HitTestResult click_item = new HitTestResult();
            click_item = chart_Main.HitTest(e.X, e.Y);
            if (click_item.Series == null)
            {
                return;
            }
            if (click_item.Series.BorderWidth != 5) { click_item.Series.BorderWidth = 5; }
            else { click_item.Series.BorderWidth = 2; }
            // show selected fs property
            FuzzySet theU;
            foreach (var node in Collect(treeView_Main.Nodes))
            {
                if (node.Tag is FuzzySet)
                {
                    theU = (FuzzySet)node.Tag;  // Cast
                    if (click_item.Series.Name == theU.TheSeries.Name)
                    {
                        treeView_Main.SelectedNode = node;
                        return;
                    }
                }
            }
        }

        private void button_addRule_Click(object sender, EventArgs e)
        {
            // add rule to data grid view rule
            dataGridView_Rule.Rows.Add();
            dataGridView_Rule.Rows[dataGridView_Rule.Rows.Count - 1].HeaderCell.Value = (dataGridView_Rule.Rows.Count).ToString();
            if (dataGridView_Infer.Rows.Count == 0 && radioButton_Mamdani.Checked)
                dataGridView_Infer.Rows.Add();
            button_Rule_Delete.Enabled = true;
            CheckDataGridNotNull();
        }

        private void dataGridView_Rule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // click fs and click cell to add rule
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == -1) return;

            DataGridViewCell cell = dataGridView_Rule.Rows[e.RowIndex].Cells[e.ColumnIndex];
            Universe colUn = (Universe)dataGridView_Rule.Columns[e.ColumnIndex].Tag;

            if (colUn.IsInput == false && radioButton_Sugeno.Checked == true)
            {
                // check if its sugeno then the output should be equation
                cell.Value = listBox_SugenoOutput.Items[SugenoOutput_SelectedIndex].ToString();
                cell.Tag = SugenoOutput_SelectedIndex;
                CheckDataGridNotNull();
            }
            TreeNode tn = treeView_Main.SelectedNode;
            if (tn == null) return;
            if (tn.Level != 2) return;
            Universe un = (Universe)tn.Parent.Tag;
            // check un
            // check un and column un
            if(un!= colUn)
            {
                //Console.Beep();
                return;
            }
            FuzzySet fs = (FuzzySet)tn.Tag;
            cell.Value = fs;
            Console.WriteLine("Good4");
            // 檢查dgv rule 是不是 not null 然後設定相關按鈕 的Enable
            CheckDataGridNotNull();

        }
        private bool CheckDataGridNotNull()
        {
            // 檢查dgv rule 是不是 not null 然後設定相關按鈕 的Enable
            if (dataGridView_Rule.RowCount == 0)
            {
                button_InferneceAll.Enabled = false;
                button_infer.Enabled = false;
                button_Rule_Delete.Enabled = false;
                return false;
            }
            button_Rule_Delete.Enabled = true;
            for (int i = 0; i <= dataGridView_Rule.ColumnCount - 1; i++)
            {
                for(int j= 0; j <= dataGridView_Rule.RowCount -1; j++)
                {
                    if (dataGridView_Rule.Rows[j].Cells[i].Value==null)
                    {
                        button_InferneceAll.Enabled = false;
                        button_infer.Enabled = false;
                        return false;
                    }
                }
            }
            
            button_InferneceAll.Enabled = true;
            button_InferAll_2D.Enabled = true;
            for (int i = 0; i <= dataGridView_Infer.ColumnCount - 1; i++)
            {
                for (int j = 0; j <= dataGridView_Infer.RowCount - 1; j++)
                {
                    if (dataGridView_Infer.Rows[j].Cells[i].Value == null)
                    {
                        button_infer.Enabled = false;
                        return true;
                    }
                }
            }
            if (treeView_Main.Nodes["Node_Output"].GetNodeCount(true) == 0)
            {
                button_infer.Enabled = false;
                return true;
            }
            if (radioButton_Mamdani.Checked == false)
            {
                button_infer.Enabled = false;
            }
            button_infer.Enabled = true;
            return true;
        }
        int SugenoOutput_SelectedIndex = 0;
        private void listBox_SugenoOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            SugenoOutput_SelectedIndex = listBox_SugenoOutput.SelectedIndex;
        }
        private void dataGridView_Infer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == -1) return;
            // check un
            Universe colUn = (Universe)dataGridView_Infer.Columns[e.ColumnIndex].Tag;
            DataGridViewCell cell = dataGridView_Infer.Rows[e.RowIndex].Cells[e.ColumnIndex];
            TreeNode tn = treeView_Main.SelectedNode;
            if (tn.Level != 2) return;
            Universe un = (Universe)tn.Parent.Tag;
            // check un and column un
            if (un != colUn)
            {
                //Console.Beep();
                return;
            }
            
            FuzzySet fs = (FuzzySet)tn.Tag;
            cell.Value = fs;
            // 檢查dgv rule 是不是 not null 然後設定相關按鈕 的Enable
            CheckDataGridNotNull();
        }

        FuzzySet inferencedResult;
        Series DefuzPoint;
        private void button_infer_Click(object sender, EventArgs e)
        {
            if (inferencedResult != null)
                chart_Main.Series.Remove(inferencedResult.TheSeries);
            if (DefuzPoint != null)
                chart_Main.Series.Remove(DefuzPoint);
            MamdaniFuzzySystem sys;
            if (!(myFuzzySystem is MamdaniFuzzySystem))
            {
                sys = new MamdaniFuzzySystem();
            }
            else
            {
                sys = (MamdaniFuzzySystem) myFuzzySystem;
            }
            sys.CutInferecing = checkBox_Cut.Checked;
            sys.ConstructRule(dataGridView_Rule);

            FuzzySet[] cond = new FuzzySet[dataGridView_Infer.ColumnCount];
            for (int i = 0; i < dataGridView_Infer.ColumnCount ; i++)
            {
                cond[i] = (FuzzySet)dataGridView_Infer.Rows[0].Cells[i].Value;
            }
            inferencedResult = sys.FuzzyInFuzzyOutInferencing(cond);
            inferencedResult.VisualDisplay = true;
            inferencedResult.TheSeries.ChartType = SeriesChartType.Area;
            inferencedResult.TheSeries.Color = Color.FromArgb(127, Color.Red);
            inferencedResult.TheSeries.Name = "FinalOutput";

            double x = sys.Get_Defuzzification(inferencedResult);
            double y = inferencedResult.GetMemberShipDegree(x);

            DefuzPoint = new Series();

            DefuzPoint.ChartArea = inferencedResult.TheSeries.ChartArea;
            DefuzPoint.Points.AddXY(x, y);
            DefuzPoint.ChartType = SeriesChartType.Point;
            DefuzPoint.MarkerSize = 10;
            DefuzPoint.Legend = inferencedResult.TheUniverse.TheLegend.Name;
            DefuzPoint.Name = sys.Defuzzification.ToString() ;


            try
            {
                chart_Main.Series.Add(inferencedResult.TheSeries);
                chart_Main.Series.Add(DefuzPoint);
            }
            catch
            {

            }
        }
        private void button_Rule_Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView_Rule.SelectedRows == null) return;
            foreach(DataGridViewRow row in dataGridView_Rule.SelectedRows)
            {
                dataGridView_Rule.Rows.Remove(row);
            }
            // 檢查dgv rule 是不是 not null 然後設定相關按鈕 的Enable
            CheckDataGridNotNull();
        }
        private void button_addAllRule_Click(object sender, EventArgs e)
        {
            if (dataGridView_Infer.Rows.Count == 0 && radioButton_Mamdani.Checked)
                dataGridView_Infer.Rows.Add();
            dataGridView_Rule.Rows.Clear();
            int num_Universe = treeView_Main.Nodes[0].GetNodeCount(false);
            int totalRuleNum = 1;
            int[][] items = new int[num_Universe][];
            for (int i = 0; i < num_Universe; i++)
            {
                int count = treeView_Main.Nodes[0].Nodes[i].GetNodeCount(false);
                totalRuleNum *= count;
                items[i] = Enumerable.Range(0, count).ToArray();
            }

            if (totalRuleNum == 0) return;
            dataGridView_Rule.Rows.Add(totalRuleNum);

            for (int i = 0; i < totalRuleNum; i++)
            {
                dataGridView_Rule.Rows[i].HeaderCell.Value = (i+1).ToString();
            }

            var combinations = IE.CartesianProduct(items);

            int rowNum = 0;
            foreach (var arr in combinations)
            {
                int colNum = 0;

                foreach (var v in arr)
                {
                    FuzzySet fs = (FuzzySet)treeView_Main.Nodes[0].Nodes[colNum].Nodes[v].Tag;
                    dataGridView_Rule.Rows[rowNum].Cells[colNum].Value = fs;
                    colNum += 1;
                }
                rowNum += 1;
            }
            // 檢查dgv rule 是不是 not null 然後設定相關按鈕 的Enable
            CheckDataGridNotNull();
        }


        IFuzzySystem myFuzzySystem = null;
        private void button_InferneceAll_Click(object sender, EventArgs e)
        {
            if (myFuzzySystem == null)
            {
                if (radioButton_Mamdani.Checked)
                {
                    myFuzzySystem = new MamdaniFuzzySystem();
                }
                else if (radioButton_Sugeno.Checked)
                {
                    myFuzzySystem = new SugenoFuzzySystem();
                }
                else if (radioButton_Tsukamoto.Checked)
                {
                    myFuzzySystem = new TsukamotoFuzzySystem();
                }
            }
            propertyGrid_InferSys.SelectedObject = myFuzzySystem;
            myFuzzySystem.ConstructRule(dataGridView_Rule);
            if (treeView_Main.Nodes[0].GetNodeCount(false) == 2)
            {
                surface1.IrregularGrid = true;
                surface1.NumXValues = (int)numericUpDown_U1.Value;
                surface1.NumZValues = (int)numericUpDown_U2.Value;
                double[] conditions = new double[2];

                Universe theU1 = (Universe)treeView_Main.Nodes[0].Nodes[0].Tag;
                Universe theU2 = (Universe)treeView_Main.Nodes[0].Nodes[1].Tag;
                surface1.Chart.Axes.Bottom.Title.Text = textBox_Universe1.Text = theU1.Title;
                surface1.Chart.Axes.Depth.Title.Text = textBox_Universe2.Text = theU2.Title;

                double inc1 = (theU1.UpperBound - theU1.LowerBound) / surface1.NumXValues;
                double inc2 = (theU2.UpperBound - theU2.LowerBound) / surface1.NumZValues;

                for (int i=0; i< surface1.NumXValues; i++)
                {
                    double x = theU1.LowerBound + inc1*i;
                    for(int j = 0; j< surface1.NumZValues; j++)
                    {
                        double z = theU2.LowerBound + inc2 * j;
                        conditions[0] = x;
                        conditions[1] = z;
                        double y = myFuzzySystem.CrispInCrispOutInferencing(conditions);
                        surface1.Add(x, y, z);
                    }
                }

                tabControl_InputOutputMap.SelectedIndex = 0;
            }
            else if (treeView_Main.Nodes[0].GetNodeCount(false) == 1)
            {
                chart_InputOutputMap.Series.Clear();
                chart_InputOutputMap.Visible = true;
                Series theSeries = new Series();
                theSeries.ChartType = SeriesChartType.Line;
                theSeries.BorderWidth = 5;
                theSeries.Name = "Output";
                Universe theU1 = (Universe)treeView_Main.Nodes[0].Nodes[0].Tag;
                for (double i = theU1.LowerBound; i < theU1.UpperBound; i+= theU1.Increment)
                {
                    double x = i;
                    double[] conditions = new double[1];
                    conditions[0] = i;
                    double y = myFuzzySystem.CrispInCrispOutInferencing(conditions);
                    theSeries.Points.AddXY(x, y);
                }
                chart_InputOutputMap.Series.Add(theSeries);
                chart_InputOutputMap.ChartAreas[0].RecalculateAxesScale();

                tabControl_InputOutputMap.SelectedIndex = 1;
            }
        }

        private void button_InferAll_2D_Click(object sender, EventArgs e)
        {
            button_InferneceAll_Click(sender, e);
        }

        private void radioButton_Sugeno_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ClearAllUniverse(int idx)
        {
            int num = treeView_Main.Nodes[idx].Nodes.Count;
            for (int i = 0; i < num; i++)
            {
                Universe u = (Universe)treeView_Main.Nodes[idx].Nodes[0].Tag;
                chart_Main.ChartAreas.Remove(u.TheArea);
                chart_Main.Legends.Remove(u.TheLegend);

                u.deleteUniverse();
            }
        }
        private void toolStripButton_New_Click(object sender, EventArgs e)
        {
            ClearAllUniverse(0); //Clear Input Universe
            ClearAllUniverse(1); //Clear Output Universe
            //chart_Main.ChartAreas.Clear();
            chart_Main.Series.Clear();
            radioButton_Mamdani.Enabled = true;
            radioButton_Sugeno.Enabled = true;
            radioButton_Tsukamoto.Enabled = true;
            button_addRule.Enabled = false;
            button_addAllRule.Enabled = false;
            surface1.Clear();
            chart_InputOutputMap.Series.Clear();
            label_SelectedFS.Text = "Add a Universe";
            propertyGrid_Main.SelectedObject = null;
        }

        private void newToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            toolStripButton_New_Click(sender, e);
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton_Open_Click(sender, e);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton_Save_Click(sender, e);
        }
        private void SaveUniverse(StreamWriter sw, bool isInput)
        {
            // 存Universe and fuzzy set
            int idx = 0;
            if (!isInput) { idx = 1; }
            int num = treeView_Main.Nodes[idx].Nodes.Count;

            if (isInput){sw.WriteLine($"NumberOfInputUniverses:{treeView_Main.Nodes[idx].Nodes.Count}");}
            else{sw.WriteLine($"NumberOfOutputUniverses:{treeView_Main.Nodes[idx].Nodes.Count}");}

            for (int i = 0; i < num; i++)
            {
                Universe u = (Universe)treeView_Main.Nodes[idx].Nodes[i].Tag;
                u.Save(sw);
                int nfs = treeView_Main.Nodes[idx].Nodes[i].Nodes.Count;

                if (isInput) {sw.WriteLine($"NumberOfInputFuzzySets:{nfs}");}
                else{sw.WriteLine($"NumberOfOutputFuzzySets:{nfs}");}

                for (int j = 0; j < nfs; j++)
                {
                    FuzzySet fs = (FuzzySet)treeView_Main.Nodes[idx].Nodes[i].Nodes[j].Tag;
                    sw.WriteLine($"FuzzySetType:{fs.GetType().Name}");
                    fs.Save(sw);
                }
            }
        }
        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            DialogResult result = dlgSave.ShowDialog();
            if (result != DialogResult.OK) return;
            StreamWriter sw = new StreamWriter(dlgSave.FileName);
            sw.WriteLine($"Model:{myFuzzySystem.SystemType}");
            //save universe and its FSs
            SaveUniverse(sw, true); // Save Input universe
            SaveUniverse(sw, false); // Save Output universe
            // save rules
            if (CheckDataGridNotNull())
            {
                sw.WriteLine($"SaveSystem:{true}");
                myFuzzySystem.ConstructRule(dataGridView_Rule);
                myFuzzySystem.Save(sw);
            }
            else
            {
                sw.WriteLine($"SaveSystem:{false}");
            }
            sw.Close();
        }
        private void toolStripButton_Open_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            //clear old contents
            toolStripButton_New_Click(sender, e);

            StreamReader sr = new StreamReader(dlgOpen.FileName);
            string str;
            string[] items;
            str = sr.ReadLine();
            items = str.Split(':');
            Type systemType = Type.GetType($"R11546004FuzzySetNamespace.{items[1]}");
            myFuzzySystem = (IFuzzySystem) Activator.CreateInstance(systemType);
            propertyGrid_InferSys.SelectedObject = myFuzzySystem;
            CheckSysRadio(systemType);
            radioButton_Mamdani.Enabled = false;
            radioButton_Sugeno.Enabled = false;
            radioButton_Tsukamoto.Enabled = false;

            allFSs = new List<FuzzySet>();
            //read input universe and its fs
            ReadUniverseUpdateTreeView(sr, true);
            ReadUniverseUpdateTreeView(sr, false);
            // clear dgv

            //read in rule and maintain dgvrules
            items = sr.ReadLine().Split(':');
            bool savesys = Convert.ToBoolean(items[1]);
            if (savesys)
            {
                myFuzzySystem.Open(sr, allFSs, dataGridView_Rule);
            }

            // Resume references of unary and binary fs
            foreach(FuzzySet fs in allFSs)
            {
                if (fs is UnaryOperatedFS|| fs is BinaryOperatedFS)
                {
                    fs.RebuildFuzzySetReferences(allFSs);
                }
            }

            // reconneect rule FS reference

            // End
            sr.Close();

            if (dataGridView_Infer.Rows.Count == 0 && radioButton_Mamdani.Checked)
                dataGridView_Infer.Rows.Add();
            CheckAllowAddRule();
            CheckDataGridNotNull();
            if (!radioButton_Mamdani.Checked)
                button_infer.Enabled = false ;
            //Console.WriteLine(myFuzzySystem.ToString());
            //Console.WriteLine("hi");
            if (button_InferneceAll.Enabled == true)
            {
                //Console.WriteLine("click");
                button_InferneceAll_Click(sender, e);
                //button_InferneceAll.PerformClick();
                return;
            }
            else if (button_InferAll_2D.Enabled == true)
            {
                button_InferAll_2D.PerformClick();
                return;
            }
        }

        List<FuzzySet> allFSs = new List<FuzzySet>();
        private void ReadUniverseUpdateTreeView(StreamReader sr, bool isInput)
        {
            // read universe 
            string[] items;
            int idx = 0;
            if (!isInput) { idx = 1; }
            int num;
            items = sr.ReadLine().Split(':');
            num = Convert.ToInt32(items[1]);
            for (int i = 0; i < num; i++)
            {
                Universe universe = new Universe();
                universe.Open(sr);
                // update chart
                chart_Main.ChartAreas.Add(universe.TheArea);
                chart_Main.Legends.Add(universe.TheLegend);
                // update tree view 
                dataGridView_Rule.Columns.Add(universe.TheRuleCol);
                treeView_Main.Nodes[idx].Nodes.Add(universe.TheNode);
                if (!isInput) { universe.IsInput = false; }
                else { dataGridView_Infer.Columns.Add(universe.TheInferCol); }

                items = sr.ReadLine().Split(':');
                int nfs = Convert.ToInt32(items[1]);

                for (int j = 0; j < nfs; j++)
                {
                    items = sr.ReadLine().Split(':');
                    Type fsType;
                    fsType = Type.GetType($"R11546004FuzzySetNamespace.{items[1]}");
                    FuzzySet fs = (FuzzySet)Activator.CreateInstance(fsType, universe);
                    fs.Open(sr);

                    fs.VisualDisplay = true;
                    treeView_Main.Nodes[idx].Nodes[i].Nodes.Add(fs.TheNode);
                    chart_Main.Series.Add(fs.TheSeries);
                    allFSs.Add(fs);
                }

                radioButton_Mamdani.Enabled = false;
                radioButton_Sugeno.Enabled = false;
                radioButton_Tsukamoto.Enabled = false;
            }
            // 在TreeView 上顯示
            treeView_Main.ExpandAll();
        }
        private void CheckSysRadio(Type systype)
        {
            if (systype == typeof(MamdaniFuzzySystem))
            {
                radioButton_Mamdani.Checked = true;
            }
            else if (systype == typeof(SugenoFuzzySystem))
            {
                radioButton_Sugeno.Checked = true;
            }
            else if (systype == typeof(TsukamotoFuzzySystem))
            {
                radioButton_Tsukamoto.Checked = true;
            }
        }

        private void FuzzySystemChanged(object sender, EventArgs e)
        {
            if (radioButton_Mamdani.Checked)
            {
                myFuzzySystem = new MamdaniFuzzySystem();
            }
            else if (radioButton_Sugeno.Checked)
            {
                myFuzzySystem = new SugenoFuzzySystem();
            }
            else if (radioButton_Tsukamoto.Checked)
            {
                myFuzzySystem = new TsukamotoFuzzySystem();
            }
            propertyGrid_InferSys.SelectedObject = myFuzzySystem;

        }

        int invert_idx = 0;

        private void teehartController_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // double click to invert axes for visibility
            if (invert_idx == 0)
            {
                surface1.Chart.Axes.Bottom.Inverted = true;
                surface1.Chart.Axes.Depth.Inverted = true;
                invert_idx = 1;
            }
            else if (invert_idx == 1)
            {
                surface1.Chart.Axes.Bottom.Inverted = false;
                surface1.Chart.Axes.Depth.Inverted = true;
                invert_idx = 2;
            }
            else if (invert_idx == 2)
            {
                surface1.Chart.Axes.Bottom.Inverted = true;
                surface1.Chart.Axes.Depth.Inverted = false;
                invert_idx = 3;
            }
            else if (invert_idx == 3)
            {
                surface1.Chart.Axes.Bottom.Inverted = false;
                surface1.Chart.Axes.Depth.Inverted = false;
                invert_idx = 0;
            }
        }

        private void teeChart_DoubleClick(object sender, EventArgs e)
        {
            teehartController_MouseDoubleClick(sender,null);
        }

        private void propertyGrid_InferSys_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (button_infer.Enabled == true)
            {
                button_infer.PerformClick();
            }
            if (button_InferneceAll.Enabled == true)
            {
                button_InferneceAll_Click(null, e);
                return;
            }
            else if (button_InferAll_2D.Enabled == true)
            {
                button_InferAll_2D.PerformClick();
                return;
            }
        }
    }
    //https://stackoverflow.com/questions/4423838/cartesian-product-n-x-m-dynamic-array
    public static class IE
    {
        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(
this IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };
            return sequences.Aggregate(
                emptyProduct,
                (accumulator, sequence) =>
                    from accseq in accumulator
                    from item in sequence
                    select accseq.Concat(new[] { item }));
        }
    }
}
