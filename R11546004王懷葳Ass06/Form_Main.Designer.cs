
using System.Drawing;
using System.Windows.Forms;

namespace R11546004FuzzySetNamespace
{
    partial class Form_Main
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Input Universe");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Output Universe");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btn_addUniverse = new System.Windows.Forms.Button();
            this.treeView_Main = new System.Windows.Forms.TreeView();
            this.imageList_TreeViewMain = new System.Windows.Forms.ImageList(this.components);
            this.propertyGrid_Main = new System.Windows.Forms.PropertyGrid();
            this.chart_Main = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBox_chooseFuzzy = new System.Windows.Forms.ComboBox();
            this.btn_addFuzzySet = new System.Windows.Forms.Button();
            this.splitContainer_LeftRight = new System.Windows.Forms.SplitContainer();
            this.splitContainer_InferenceSelection = new System.Windows.Forms.SplitContainer();
            this.propertyGrid_InferSys = new System.Windows.Forms.PropertyGrid();
            this.radioButton_Tsukamoto = new System.Windows.Forms.RadioButton();
            this.radioButton_Sugeno = new System.Windows.Forms.RadioButton();
            this.radioButton_Mamdani = new System.Windows.Forms.RadioButton();
            this.textBox_InferType = new System.Windows.Forms.TextBox();
            this.splitContainer_DataGrid_fuzzySet = new System.Windows.Forms.SplitContainer();
            this.splitContainer_Tree_property = new System.Windows.Forms.SplitContainer();
            this.label_SelectedFS = new System.Windows.Forms.Label();
            this.tabControl_AddFuzzy = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox_BinaryOpFS = new System.Windows.Forms.GroupBox();
            this.btn_Binary_FS2 = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_addBinary = new System.Windows.Forms.Button();
            this.btn_Binary_FS1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Binary = new System.Windows.Forms.ComboBox();
            this.groupBox_UnaryOpFS = new System.Windows.Forms.GroupBox();
            this.btn_addUnary = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Unary = new System.Windows.Forms.ComboBox();
            this.groupBox_PrimaryFS = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox_Rule = new System.Windows.Forms.GroupBox();
            this.button_Rule_Delete = new System.Windows.Forms.Button();
            this.button_addAllRule = new System.Windows.Forms.Button();
            this.button_addRule = new System.Windows.Forms.Button();
            this.dataGridView_Rule = new System.Windows.Forms.DataGridView();
            this.groupBox_Condition = new System.Windows.Forms.GroupBox();
            this.checkBox_Cut = new System.Windows.Forms.CheckBox();
            this.button_infer = new System.Windows.Forms.Button();
            this.dataGridView_Infer = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.listBox_SugenoOutput = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.splitContainer_Chart_TeeMap = new System.Windows.Forms.SplitContainer();
            this.tabControl_InputOutputMap = new System.Windows.Forms.TabControl();
            this.tabPage_3D = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.button_InferneceAll = new System.Windows.Forms.Button();
            this.textBox_Universe2 = new System.Windows.Forms.TextBox();
            this.textBox_Universe1 = new System.Windows.Forms.TextBox();
            this.numericUpDown_U1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_U2 = new System.Windows.Forms.NumericUpDown();
            this.panel_TeeChart = new System.Windows.Forms.Panel();
            this.teehartController = new Steema.TeeChart.ChartController();
            this.teeChart = new Steema.TeeChart.TChart();
            this.surface1 = new Steema.TeeChart.Styles.Surface();
            this.tabPage_2D = new System.Windows.Forms.TabPage();
            this.chart_InputOutputMap = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_InferAll_2D = new System.Windows.Forms.Button();
            this.menuStrip_Main = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_Main = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_New = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Open = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Save = new System.Windows.Forms.ToolStripButton();
            this.imageList_NewOpenSave = new System.Windows.Forms.ImageList(this.components);
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.toolStripButton_invert = new System.Windows.Forms.ToolStripButton();
            this.imageList_invert = new System.Windows.Forms.ImageList(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_LeftRight)).BeginInit();
            this.splitContainer_LeftRight.Panel1.SuspendLayout();
            this.splitContainer_LeftRight.Panel2.SuspendLayout();
            this.splitContainer_LeftRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_InferenceSelection)).BeginInit();
            this.splitContainer_InferenceSelection.Panel1.SuspendLayout();
            this.splitContainer_InferenceSelection.Panel2.SuspendLayout();
            this.splitContainer_InferenceSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_DataGrid_fuzzySet)).BeginInit();
            this.splitContainer_DataGrid_fuzzySet.Panel1.SuspendLayout();
            this.splitContainer_DataGrid_fuzzySet.Panel2.SuspendLayout();
            this.splitContainer_DataGrid_fuzzySet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Tree_property)).BeginInit();
            this.splitContainer_Tree_property.Panel1.SuspendLayout();
            this.splitContainer_Tree_property.Panel2.SuspendLayout();
            this.splitContainer_Tree_property.SuspendLayout();
            this.tabControl_AddFuzzy.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox_BinaryOpFS.SuspendLayout();
            this.groupBox_UnaryOpFS.SuspendLayout();
            this.groupBox_PrimaryFS.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox_Rule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Rule)).BeginInit();
            this.groupBox_Condition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Infer)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Chart_TeeMap)).BeginInit();
            this.splitContainer_Chart_TeeMap.Panel1.SuspendLayout();
            this.splitContainer_Chart_TeeMap.Panel2.SuspendLayout();
            this.splitContainer_Chart_TeeMap.SuspendLayout();
            this.tabControl_InputOutputMap.SuspendLayout();
            this.tabPage_3D.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_U1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_U2)).BeginInit();
            this.panel_TeeChart.SuspendLayout();
            this.tabPage_2D.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_InputOutputMap)).BeginInit();
            this.menuStrip_Main.SuspendLayout();
            this.toolStrip_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_addUniverse
            // 
            this.btn_addUniverse.AutoSize = true;
            this.btn_addUniverse.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_addUniverse.Enabled = false;
            this.btn_addUniverse.Location = new System.Drawing.Point(0, 0);
            this.btn_addUniverse.Name = "btn_addUniverse";
            this.btn_addUniverse.Size = new System.Drawing.Size(271, 46);
            this.btn_addUniverse.TabIndex = 0;
            this.btn_addUniverse.Text = "Select Input/Output to Add";
            this.btn_addUniverse.UseVisualStyleBackColor = true;
            this.btn_addUniverse.Click += new System.EventHandler(this.btn_addUniverse_Click);
            // 
            // treeView_Main
            // 
            this.treeView_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView_Main.HideSelection = false;
            this.treeView_Main.ImageIndex = 0;
            this.treeView_Main.ImageList = this.imageList_TreeViewMain;
            this.treeView_Main.Location = new System.Drawing.Point(0, 46);
            this.treeView_Main.Name = "treeView_Main";
            treeNode3.ImageKey = "letter-i.png";
            treeNode3.Name = "Node_Input";
            treeNode3.SelectedImageKey = "letter-i.png";
            treeNode3.Text = "Input Universe";
            treeNode4.ImageKey = "o.png";
            treeNode4.Name = "Node_Output";
            treeNode4.SelectedImageKey = "o.png";
            treeNode4.Text = "Output Universe";
            this.treeView_Main.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            this.treeView_Main.SelectedImageIndex = 0;
            this.treeView_Main.Size = new System.Drawing.Size(271, 214);
            this.treeView_Main.TabIndex = 1;
            this.treeView_Main.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView_Main.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView_Main_KeyDown);
            // 
            // imageList_TreeViewMain
            // 
            this.imageList_TreeViewMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_TreeViewMain.ImageStream")));
            this.imageList_TreeViewMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_TreeViewMain.Images.SetKeyName(0, "letter-f.png");
            this.imageList_TreeViewMain.Images.SetKeyName(1, "letter-i.png");
            this.imageList_TreeViewMain.Images.SetKeyName(2, "letter-u.png");
            this.imageList_TreeViewMain.Images.SetKeyName(3, "o.png");
            // 
            // propertyGrid_Main
            // 
            this.propertyGrid_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid_Main.Location = new System.Drawing.Point(0, 49);
            this.propertyGrid_Main.Name = "propertyGrid_Main";
            this.propertyGrid_Main.Size = new System.Drawing.Size(327, 210);
            this.propertyGrid_Main.TabIndex = 6;
            this.propertyGrid_Main.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_Main_PropertyValueChanged);
            // 
            // chart_Main
            // 
            this.chart_Main.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.chart_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart_Main.Location = new System.Drawing.Point(0, 0);
            this.chart_Main.Name = "chart_Main";
            this.chart_Main.Size = new System.Drawing.Size(681, 490);
            this.chart_Main.TabIndex = 2;
            this.chart_Main.Text = "chart1";
            this.chart_Main.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart_Main_MouseDown);
            // 
            // comboBox_chooseFuzzy
            // 
            this.comboBox_chooseFuzzy.DisplayMember = "null";
            this.comboBox_chooseFuzzy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_chooseFuzzy.FormattingEnabled = true;
            this.comboBox_chooseFuzzy.Items.AddRange(new object[] {
            "Triangular",
            "Guassian",
            "Bell",
            "Sigmoidal",
            "LeftRight",
            "S",
            "Z",
            "Trapezoidal",
            "Pi"});
            this.comboBox_chooseFuzzy.Location = new System.Drawing.Point(34, 55);
            this.comboBox_chooseFuzzy.Name = "comboBox_chooseFuzzy";
            this.comboBox_chooseFuzzy.Size = new System.Drawing.Size(352, 31);
            this.comboBox_chooseFuzzy.TabIndex = 8;
            // 
            // btn_addFuzzySet
            // 
            this.btn_addFuzzySet.AutoSize = true;
            this.btn_addFuzzySet.Location = new System.Drawing.Point(417, 52);
            this.btn_addFuzzySet.Name = "btn_addFuzzySet";
            this.btn_addFuzzySet.Size = new System.Drawing.Size(146, 34);
            this.btn_addFuzzySet.TabIndex = 9;
            this.btn_addFuzzySet.Text = "Add Fuzzy Set";
            this.btn_addFuzzySet.UseVisualStyleBackColor = true;
            this.btn_addFuzzySet.Click += new System.EventHandler(this.btn_addFuzzySet_Click);
            // 
            // splitContainer_LeftRight
            // 
            this.splitContainer_LeftRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer_LeftRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_LeftRight.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_LeftRight.Location = new System.Drawing.Point(0, 74);
            this.splitContainer_LeftRight.Name = "splitContainer_LeftRight";
            // 
            // splitContainer_LeftRight.Panel1
            // 
            this.splitContainer_LeftRight.Panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.splitContainer_LeftRight.Panel1.Controls.Add(this.splitContainer_InferenceSelection);
            // 
            // splitContainer_LeftRight.Panel2
            // 
            this.splitContainer_LeftRight.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.splitContainer_LeftRight.Panel2.Controls.Add(this.splitContainer_Chart_TeeMap);
            this.splitContainer_LeftRight.Size = new System.Drawing.Size(1293, 818);
            this.splitContainer_LeftRight.SplitterDistance = 606;
            this.splitContainer_LeftRight.TabIndex = 10;
            // 
            // splitContainer_InferenceSelection
            // 
            this.splitContainer_InferenceSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_InferenceSelection.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_InferenceSelection.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_InferenceSelection.Name = "splitContainer_InferenceSelection";
            this.splitContainer_InferenceSelection.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_InferenceSelection.Panel1
            // 
            this.splitContainer_InferenceSelection.Panel1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.splitContainer_InferenceSelection.Panel1.Controls.Add(this.propertyGrid_InferSys);
            this.splitContainer_InferenceSelection.Panel1.Controls.Add(this.radioButton_Tsukamoto);
            this.splitContainer_InferenceSelection.Panel1.Controls.Add(this.radioButton_Sugeno);
            this.splitContainer_InferenceSelection.Panel1.Controls.Add(this.radioButton_Mamdani);
            this.splitContainer_InferenceSelection.Panel1.Controls.Add(this.textBox_InferType);
            // 
            // splitContainer_InferenceSelection.Panel2
            // 
            this.splitContainer_InferenceSelection.Panel2.Controls.Add(this.splitContainer_DataGrid_fuzzySet);
            this.splitContainer_InferenceSelection.Size = new System.Drawing.Size(604, 816);
            this.splitContainer_InferenceSelection.SplitterDistance = 138;
            this.splitContainer_InferenceSelection.TabIndex = 11;
            // 
            // propertyGrid_InferSys
            // 
            this.propertyGrid_InferSys.Dock = System.Windows.Forms.DockStyle.Right;
            this.propertyGrid_InferSys.HelpVisible = false;
            this.propertyGrid_InferSys.Location = new System.Drawing.Point(193, 0);
            this.propertyGrid_InferSys.Name = "propertyGrid_InferSys";
            this.propertyGrid_InferSys.Size = new System.Drawing.Size(411, 138);
            this.propertyGrid_InferSys.TabIndex = 8;
            this.propertyGrid_InferSys.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_InferSys_PropertyValueChanged);
            // 
            // radioButton_Tsukamoto
            // 
            this.radioButton_Tsukamoto.AutoSize = true;
            this.radioButton_Tsukamoto.Location = new System.Drawing.Point(24, 107);
            this.radioButton_Tsukamoto.Name = "radioButton_Tsukamoto";
            this.radioButton_Tsukamoto.Size = new System.Drawing.Size(132, 28);
            this.radioButton_Tsukamoto.TabIndex = 15;
            this.radioButton_Tsukamoto.Text = "Tsukamoto";
            this.radioButton_Tsukamoto.UseVisualStyleBackColor = true;
            this.radioButton_Tsukamoto.Click += new System.EventHandler(this.FuzzySystemChanged);
            // 
            // radioButton_Sugeno
            // 
            this.radioButton_Sugeno.AutoSize = true;
            this.radioButton_Sugeno.Location = new System.Drawing.Point(24, 73);
            this.radioButton_Sugeno.Name = "radioButton_Sugeno";
            this.radioButton_Sugeno.Size = new System.Drawing.Size(101, 28);
            this.radioButton_Sugeno.TabIndex = 14;
            this.radioButton_Sugeno.Text = "Sugeno";
            this.radioButton_Sugeno.UseVisualStyleBackColor = true;
            this.radioButton_Sugeno.CheckedChanged += new System.EventHandler(this.radioButton_Sugeno_CheckedChanged);
            this.radioButton_Sugeno.Click += new System.EventHandler(this.FuzzySystemChanged);
            // 
            // radioButton_Mamdani
            // 
            this.radioButton_Mamdani.AutoSize = true;
            this.radioButton_Mamdani.Checked = true;
            this.radioButton_Mamdani.Location = new System.Drawing.Point(24, 39);
            this.radioButton_Mamdani.Name = "radioButton_Mamdani";
            this.radioButton_Mamdani.Size = new System.Drawing.Size(116, 28);
            this.radioButton_Mamdani.TabIndex = 13;
            this.radioButton_Mamdani.TabStop = true;
            this.radioButton_Mamdani.Text = "Mamdani\r\n";
            this.radioButton_Mamdani.UseVisualStyleBackColor = true;
            this.radioButton_Mamdani.Click += new System.EventHandler(this.FuzzySystemChanged);
            // 
            // textBox_InferType
            // 
            this.textBox_InferType.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.textBox_InferType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_InferType.ForeColor = System.Drawing.Color.Blue;
            this.textBox_InferType.Location = new System.Drawing.Point(24, 8);
            this.textBox_InferType.Name = "textBox_InferType";
            this.textBox_InferType.ReadOnly = true;
            this.textBox_InferType.Size = new System.Drawing.Size(163, 25);
            this.textBox_InferType.TabIndex = 12;
            this.textBox_InferType.Text = "Inference System";
            // 
            // splitContainer_DataGrid_fuzzySet
            // 
            this.splitContainer_DataGrid_fuzzySet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer_DataGrid_fuzzySet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_DataGrid_fuzzySet.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_DataGrid_fuzzySet.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_DataGrid_fuzzySet.Name = "splitContainer_DataGrid_fuzzySet";
            this.splitContainer_DataGrid_fuzzySet.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_DataGrid_fuzzySet.Panel1
            // 
            this.splitContainer_DataGrid_fuzzySet.Panel1.Controls.Add(this.splitContainer_Tree_property);
            // 
            // splitContainer_DataGrid_fuzzySet.Panel2
            // 
            this.splitContainer_DataGrid_fuzzySet.Panel2.Controls.Add(this.tabControl_AddFuzzy);
            this.splitContainer_DataGrid_fuzzySet.Size = new System.Drawing.Size(604, 674);
            this.splitContainer_DataGrid_fuzzySet.SplitterDistance = 261;
            this.splitContainer_DataGrid_fuzzySet.SplitterWidth = 5;
            this.splitContainer_DataGrid_fuzzySet.TabIndex = 10;
            // 
            // splitContainer_Tree_property
            // 
            this.splitContainer_Tree_property.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Tree_property.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Tree_property.Name = "splitContainer_Tree_property";
            // 
            // splitContainer_Tree_property.Panel1
            // 
            this.splitContainer_Tree_property.Panel1.Controls.Add(this.btn_addUniverse);
            this.splitContainer_Tree_property.Panel1.Controls.Add(this.treeView_Main);
            // 
            // splitContainer_Tree_property.Panel2
            // 
            this.splitContainer_Tree_property.Panel2.Controls.Add(this.label_SelectedFS);
            this.splitContainer_Tree_property.Panel2.Controls.Add(this.propertyGrid_Main);
            this.splitContainer_Tree_property.Size = new System.Drawing.Size(602, 259);
            this.splitContainer_Tree_property.SplitterDistance = 271;
            this.splitContainer_Tree_property.TabIndex = 7;
            // 
            // label_SelectedFS
            // 
            this.label_SelectedFS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label_SelectedFS.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_SelectedFS.ForeColor = System.Drawing.Color.LightGreen;
            this.label_SelectedFS.Location = new System.Drawing.Point(0, 0);
            this.label_SelectedFS.Name = "label_SelectedFS";
            this.label_SelectedFS.Size = new System.Drawing.Size(327, 46);
            this.label_SelectedFS.TabIndex = 7;
            this.label_SelectedFS.Text = "FuzzySet";
            this.label_SelectedFS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl_AddFuzzy
            // 
            this.tabControl_AddFuzzy.Controls.Add(this.tabPage1);
            this.tabControl_AddFuzzy.Controls.Add(this.tabPage2);
            this.tabControl_AddFuzzy.Controls.Add(this.tabPage4);
            this.tabControl_AddFuzzy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_AddFuzzy.Location = new System.Drawing.Point(0, 0);
            this.tabControl_AddFuzzy.Name = "tabControl_AddFuzzy";
            this.tabControl_AddFuzzy.SelectedIndex = 0;
            this.tabControl_AddFuzzy.Size = new System.Drawing.Size(602, 406);
            this.tabControl_AddFuzzy.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage1.Controls.Add(this.groupBox_BinaryOpFS);
            this.tabPage1.Controls.Add(this.groupBox_UnaryOpFS);
            this.tabPage1.Controls.Add(this.groupBox_PrimaryFS);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(594, 370);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "FuzzySet";
            // 
            // groupBox_BinaryOpFS
            // 
            this.groupBox_BinaryOpFS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox_BinaryOpFS.Controls.Add(this.btn_Binary_FS2);
            this.groupBox_BinaryOpFS.Controls.Add(this.btn_Clear);
            this.groupBox_BinaryOpFS.Controls.Add(this.btn_addBinary);
            this.groupBox_BinaryOpFS.Controls.Add(this.btn_Binary_FS1);
            this.groupBox_BinaryOpFS.Controls.Add(this.label4);
            this.groupBox_BinaryOpFS.Controls.Add(this.label3);
            this.groupBox_BinaryOpFS.Controls.Add(this.comboBox_Binary);
            this.groupBox_BinaryOpFS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_BinaryOpFS.Enabled = false;
            this.groupBox_BinaryOpFS.Location = new System.Drawing.Point(3, 203);
            this.groupBox_BinaryOpFS.Name = "groupBox_BinaryOpFS";
            this.groupBox_BinaryOpFS.Size = new System.Drawing.Size(588, 164);
            this.groupBox_BinaryOpFS.TabIndex = 11;
            this.groupBox_BinaryOpFS.TabStop = false;
            this.groupBox_BinaryOpFS.Text = "Binary Operated Fuzzy Set";
            // 
            // btn_Binary_FS2
            // 
            this.btn_Binary_FS2.Location = new System.Drawing.Point(241, 118);
            this.btn_Binary_FS2.Name = "btn_Binary_FS2";
            this.btn_Binary_FS2.Size = new System.Drawing.Size(172, 34);
            this.btn_Binary_FS2.TabIndex = 19;
            this.btn_Binary_FS2.Text = "Click to Set 2nd";
            this.btn_Binary_FS2.UseVisualStyleBackColor = true;
            this.btn_Binary_FS2.Click += new System.EventHandler(this.btn_Binary_FS2_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.AutoSize = true;
            this.btn_Clear.Location = new System.Drawing.Point(464, 118);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(99, 34);
            this.btn_Clear.TabIndex = 18;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_addBinary
            // 
            this.btn_addBinary.AutoSize = true;
            this.btn_addBinary.Enabled = false;
            this.btn_addBinary.Location = new System.Drawing.Point(417, 57);
            this.btn_addBinary.Name = "btn_addBinary";
            this.btn_addBinary.Size = new System.Drawing.Size(146, 34);
            this.btn_addBinary.TabIndex = 13;
            this.btn_addBinary.Text = "Add Fuzzy Set";
            this.btn_addBinary.UseVisualStyleBackColor = true;
            this.btn_addBinary.Click += new System.EventHandler(this.btn_addBinary_Click);
            // 
            // btn_Binary_FS1
            // 
            this.btn_Binary_FS1.Location = new System.Drawing.Point(34, 118);
            this.btn_Binary_FS1.Name = "btn_Binary_FS1";
            this.btn_Binary_FS1.Size = new System.Drawing.Size(188, 34);
            this.btn_Binary_FS1.TabIndex = 16;
            this.btn_Binary_FS1.Text = "Click to Set 1st";
            this.btn_Binary_FS1.UseVisualStyleBackColor = true;
            this.btn_Binary_FS1.Click += new System.EventHandler(this.btn_Binary_FS1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 24);
            this.label4.TabIndex = 15;
            this.label4.Text = "Operands";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "Type Of Operator";
            // 
            // comboBox_Binary
            // 
            this.comboBox_Binary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Binary.FormattingEnabled = true;
            this.comboBox_Binary.Items.AddRange(new object[] {
            "Intersect Operator",
            "Union Operator",
            "Substraction Operator",
            "Algebraic T-norm",
            "Bounded T-norm",
            "Drastic T-norm",
            "Algebraic S-norm",
            "Bounded S-norm",
            "Drastic S-norm",
            "Algebraic Product",
            "Hamacher\'s Sum",
            "Yager T-norm",
            "Schweizer T-norm"});
            this.comboBox_Binary.Location = new System.Drawing.Point(34, 57);
            this.comboBox_Binary.Name = "comboBox_Binary";
            this.comboBox_Binary.Size = new System.Drawing.Size(352, 31);
            this.comboBox_Binary.TabIndex = 13;
            // 
            // groupBox_UnaryOpFS
            // 
            this.groupBox_UnaryOpFS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.groupBox_UnaryOpFS.Controls.Add(this.btn_addUnary);
            this.groupBox_UnaryOpFS.Controls.Add(this.label2);
            this.groupBox_UnaryOpFS.Controls.Add(this.comboBox_Unary);
            this.groupBox_UnaryOpFS.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_UnaryOpFS.Enabled = false;
            this.groupBox_UnaryOpFS.Location = new System.Drawing.Point(3, 103);
            this.groupBox_UnaryOpFS.Name = "groupBox_UnaryOpFS";
            this.groupBox_UnaryOpFS.Size = new System.Drawing.Size(588, 100);
            this.groupBox_UnaryOpFS.TabIndex = 7;
            this.groupBox_UnaryOpFS.TabStop = false;
            this.groupBox_UnaryOpFS.Text = "Unary Operated Fuzzy Set";
            // 
            // btn_addUnary
            // 
            this.btn_addUnary.AutoSize = true;
            this.btn_addUnary.Location = new System.Drawing.Point(417, 54);
            this.btn_addUnary.Name = "btn_addUnary";
            this.btn_addUnary.Size = new System.Drawing.Size(146, 34);
            this.btn_addUnary.TabIndex = 20;
            this.btn_addUnary.Text = "Add Fuzzy Set";
            this.btn_addUnary.UseVisualStyleBackColor = true;
            this.btn_addUnary.Click += new System.EventHandler(this.btn_addUnary_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Type of Operator";
            // 
            // comboBox_Unary
            // 
            this.comboBox_Unary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Unary.FormattingEnabled = true;
            this.comboBox_Unary.Items.AddRange(new object[] {
            "NegateOperator",
            "ConcentrationOperator",
            "DilationOperator",
            "IntensifyOperator",
            "DiminisherOperator",
            "CutOperator",
            "ScaleOperator"});
            this.comboBox_Unary.Location = new System.Drawing.Point(34, 57);
            this.comboBox_Unary.Name = "comboBox_Unary";
            this.comboBox_Unary.Size = new System.Drawing.Size(352, 31);
            this.comboBox_Unary.TabIndex = 10;
            // 
            // groupBox_PrimaryFS
            // 
            this.groupBox_PrimaryFS.BackColor = System.Drawing.Color.Silver;
            this.groupBox_PrimaryFS.Controls.Add(this.label1);
            this.groupBox_PrimaryFS.Controls.Add(this.comboBox_chooseFuzzy);
            this.groupBox_PrimaryFS.Controls.Add(this.btn_addFuzzySet);
            this.groupBox_PrimaryFS.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_PrimaryFS.Enabled = false;
            this.groupBox_PrimaryFS.Location = new System.Drawing.Point(3, 3);
            this.groupBox_PrimaryFS.Name = "groupBox_PrimaryFS";
            this.groupBox_PrimaryFS.Size = new System.Drawing.Size(588, 100);
            this.groupBox_PrimaryFS.TabIndex = 10;
            this.groupBox_PrimaryFS.TabStop = false;
            this.groupBox_PrimaryFS.Text = "Primary Fuzzy Set";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Type Of Fuzzy Set";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(594, 370);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "If-Then Rule";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Wheat;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox_Rule);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.LightCyan;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox_Condition);
            this.splitContainer1.Size = new System.Drawing.Size(594, 370);
            this.splitContainer1.SplitterDistance = 205;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox_Rule
            // 
            this.groupBox_Rule.Controls.Add(this.button_Rule_Delete);
            this.groupBox_Rule.Controls.Add(this.button_addAllRule);
            this.groupBox_Rule.Controls.Add(this.button_addRule);
            this.groupBox_Rule.Controls.Add(this.dataGridView_Rule);
            this.groupBox_Rule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Rule.Font = new System.Drawing.Font("微軟正黑體", 13F);
            this.groupBox_Rule.Location = new System.Drawing.Point(0, 0);
            this.groupBox_Rule.Name = "groupBox_Rule";
            this.groupBox_Rule.Size = new System.Drawing.Size(594, 205);
            this.groupBox_Rule.TabIndex = 2;
            this.groupBox_Rule.TabStop = false;
            this.groupBox_Rule.Text = "Rule";
            // 
            // button_Rule_Delete
            // 
            this.button_Rule_Delete.Enabled = false;
            this.button_Rule_Delete.Font = new System.Drawing.Font("微軟正黑體", 11F);
            this.button_Rule_Delete.Location = new System.Drawing.Point(486, 0);
            this.button_Rule_Delete.Name = "button_Rule_Delete";
            this.button_Rule_Delete.Size = new System.Drawing.Size(114, 31);
            this.button_Rule_Delete.TabIndex = 3;
            this.button_Rule_Delete.Text = "Delete";
            this.button_Rule_Delete.UseVisualStyleBackColor = true;
            this.button_Rule_Delete.Click += new System.EventHandler(this.button_Rule_Delete_Click);
            // 
            // button_addAllRule
            // 
            this.button_addAllRule.Enabled = false;
            this.button_addAllRule.Font = new System.Drawing.Font("微軟正黑體", 11F);
            this.button_addAllRule.Location = new System.Drawing.Point(350, 0);
            this.button_addAllRule.Name = "button_addAllRule";
            this.button_addAllRule.Size = new System.Drawing.Size(114, 31);
            this.button_addAllRule.TabIndex = 2;
            this.button_addAllRule.Text = "Add All";
            this.button_addAllRule.UseVisualStyleBackColor = true;
            this.button_addAllRule.Click += new System.EventHandler(this.button_addAllRule_Click);
            // 
            // button_addRule
            // 
            this.button_addRule.Enabled = false;
            this.button_addRule.Font = new System.Drawing.Font("微軟正黑體", 11F);
            this.button_addRule.Location = new System.Drawing.Point(217, 0);
            this.button_addRule.Name = "button_addRule";
            this.button_addRule.Size = new System.Drawing.Size(114, 31);
            this.button_addRule.TabIndex = 1;
            this.button_addRule.Text = "Add Rule";
            this.button_addRule.UseVisualStyleBackColor = true;
            this.button_addRule.Click += new System.EventHandler(this.button_addRule_Click);
            // 
            // dataGridView_Rule
            // 
            this.dataGridView_Rule.AllowUserToAddRows = false;
            this.dataGridView_Rule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Rule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Rule.Location = new System.Drawing.Point(3, 32);
            this.dataGridView_Rule.Name = "dataGridView_Rule";
            this.dataGridView_Rule.ReadOnly = true;
            this.dataGridView_Rule.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView_Rule.RowTemplate.Height = 27;
            this.dataGridView_Rule.Size = new System.Drawing.Size(588, 170);
            this.dataGridView_Rule.TabIndex = 0;
            this.dataGridView_Rule.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Rule_CellClick);
            // 
            // groupBox_Condition
            // 
            this.groupBox_Condition.Controls.Add(this.checkBox_Cut);
            this.groupBox_Condition.Controls.Add(this.button_infer);
            this.groupBox_Condition.Controls.Add(this.dataGridView_Infer);
            this.groupBox_Condition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Condition.Font = new System.Drawing.Font("微軟正黑體", 13F);
            this.groupBox_Condition.Location = new System.Drawing.Point(0, 0);
            this.groupBox_Condition.Name = "groupBox_Condition";
            this.groupBox_Condition.Size = new System.Drawing.Size(594, 161);
            this.groupBox_Condition.TabIndex = 0;
            this.groupBox_Condition.TabStop = false;
            this.groupBox_Condition.Text = "Condition";
            // 
            // checkBox_Cut
            // 
            this.checkBox_Cut.AutoSize = true;
            this.checkBox_Cut.Font = new System.Drawing.Font("微軟正黑體", 11F);
            this.checkBox_Cut.Location = new System.Drawing.Point(521, 2);
            this.checkBox_Cut.Name = "checkBox_Cut";
            this.checkBox_Cut.Size = new System.Drawing.Size(64, 28);
            this.checkBox_Cut.TabIndex = 3;
            this.checkBox_Cut.Text = "Cut";
            this.checkBox_Cut.UseVisualStyleBackColor = true;
            // 
            // button_infer
            // 
            this.button_infer.Enabled = false;
            this.button_infer.Font = new System.Drawing.Font("微軟正黑體", 11F);
            this.button_infer.Location = new System.Drawing.Point(367, 0);
            this.button_infer.Name = "button_infer";
            this.button_infer.Size = new System.Drawing.Size(114, 31);
            this.button_infer.TabIndex = 2;
            this.button_infer.Text = "Inference";
            this.button_infer.UseVisualStyleBackColor = true;
            this.button_infer.Click += new System.EventHandler(this.button_infer_Click);
            // 
            // dataGridView_Infer
            // 
            this.dataGridView_Infer.AllowUserToAddRows = false;
            this.dataGridView_Infer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Infer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Infer.Location = new System.Drawing.Point(3, 32);
            this.dataGridView_Infer.Name = "dataGridView_Infer";
            this.dataGridView_Infer.ReadOnly = true;
            this.dataGridView_Infer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView_Infer.RowTemplate.Height = 27;
            this.dataGridView_Infer.Size = new System.Drawing.Size(588, 126);
            this.dataGridView_Infer.TabIndex = 0;
            this.dataGridView_Infer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Infer_CellClick);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.tabPage4.Controls.Add(this.listBox_SugenoOutput);
            this.tabPage4.Controls.Add(this.textBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(594, 377);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "Output Equations";
            // 
            // listBox_SugenoOutput
            // 
            this.listBox_SugenoOutput.FormattingEnabled = true;
            this.listBox_SugenoOutput.ItemHeight = 23;
            this.listBox_SugenoOutput.Items.AddRange(new object[] {
            "(0) Y=0.1X + 6.4",
            "(1) Y=-0.5X + 4",
            "(2) Y= X - 2",
            "(3) Z = -X + Y + 1",
            "(4) Z = -Y+3",
            "(5) Z = -X+3",
            "(6) Z = X+Y+2"});
            this.listBox_SugenoOutput.Location = new System.Drawing.Point(19, 67);
            this.listBox_SugenoOutput.Name = "listBox_SugenoOutput";
            this.listBox_SugenoOutput.Size = new System.Drawing.Size(554, 280);
            this.listBox_SugenoOutput.TabIndex = 14;
            this.listBox_SugenoOutput.SelectedIndexChanged += new System.EventHandler(this.listBox_SugenoOutput_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.textBox1.Location = new System.Drawing.Point(19, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(163, 25);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "Sugeno Output";
            // 
            // splitContainer_Chart_TeeMap
            // 
            this.splitContainer_Chart_TeeMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer_Chart_TeeMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Chart_TeeMap.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Chart_TeeMap.Name = "splitContainer_Chart_TeeMap";
            this.splitContainer_Chart_TeeMap.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_Chart_TeeMap.Panel1
            // 
            this.splitContainer_Chart_TeeMap.Panel1.Controls.Add(this.chart_Main);
            // 
            // splitContainer_Chart_TeeMap.Panel2
            // 
            this.splitContainer_Chart_TeeMap.Panel2.BackColor = System.Drawing.SystemColors.Menu;
            this.splitContainer_Chart_TeeMap.Panel2.Controls.Add(this.tabControl_InputOutputMap);
            this.splitContainer_Chart_TeeMap.Size = new System.Drawing.Size(683, 818);
            this.splitContainer_Chart_TeeMap.SplitterDistance = 492;
            this.splitContainer_Chart_TeeMap.TabIndex = 3;
            // 
            // tabControl_InputOutputMap
            // 
            this.tabControl_InputOutputMap.Controls.Add(this.tabPage_3D);
            this.tabControl_InputOutputMap.Controls.Add(this.tabPage_2D);
            this.tabControl_InputOutputMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_InputOutputMap.Location = new System.Drawing.Point(0, 0);
            this.tabControl_InputOutputMap.Name = "tabControl_InputOutputMap";
            this.tabControl_InputOutputMap.SelectedIndex = 0;
            this.tabControl_InputOutputMap.Size = new System.Drawing.Size(681, 320);
            this.tabControl_InputOutputMap.TabIndex = 0;
            // 
            // tabPage_3D
            // 
            this.tabPage_3D.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage_3D.Controls.Add(this.splitContainer2);
            this.tabPage_3D.Location = new System.Drawing.Point(4, 32);
            this.tabPage_3D.Name = "tabPage_3D";
            this.tabPage_3D.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_3D.Size = new System.Drawing.Size(673, 284);
            this.tabPage_3D.TabIndex = 0;
            this.tabPage_3D.Text = "3D Input/Output Map";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.button_InferneceAll);
            this.splitContainer2.Panel1.Controls.Add(this.textBox_Universe2);
            this.splitContainer2.Panel1.Controls.Add(this.textBox_Universe1);
            this.splitContainer2.Panel1.Controls.Add(this.numericUpDown_U1);
            this.splitContainer2.Panel1.Controls.Add(this.numericUpDown_U2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel_TeeChart);
            this.splitContainer2.Size = new System.Drawing.Size(667, 278);
            this.splitContainer2.SplitterDistance = 218;
            this.splitContainer2.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Bisque;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(218, 45);
            this.label5.TabIndex = 16;
            this.label5.Text = "3D Resolution";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_InferneceAll
            // 
            this.button_InferneceAll.BackColor = System.Drawing.Color.RosyBrown;
            this.button_InferneceAll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_InferneceAll.Enabled = false;
            this.button_InferneceAll.Location = new System.Drawing.Point(0, 193);
            this.button_InferneceAll.Name = "button_InferneceAll";
            this.button_InferneceAll.Size = new System.Drawing.Size(218, 85);
            this.button_InferneceAll.TabIndex = 0;
            this.button_InferneceAll.Text = "Inference All Crisp Inputs";
            this.button_InferneceAll.UseVisualStyleBackColor = false;
            this.button_InferneceAll.Click += new System.EventHandler(this.button_InferneceAll_Click);
            // 
            // textBox_Universe2
            // 
            this.textBox_Universe2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_Universe2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Universe2.Location = new System.Drawing.Point(8, 126);
            this.textBox_Universe2.Name = "textBox_Universe2";
            this.textBox_Universe2.ReadOnly = true;
            this.textBox_Universe2.Size = new System.Drawing.Size(120, 25);
            this.textBox_Universe2.TabIndex = 5;
            this.textBox_Universe2.Text = "Universe2";
            this.textBox_Universe2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Universe1
            // 
            this.textBox_Universe1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_Universe1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Universe1.ForeColor = System.Drawing.Color.Black;
            this.textBox_Universe1.Location = new System.Drawing.Point(9, 67);
            this.textBox_Universe1.Name = "textBox_Universe1";
            this.textBox_Universe1.ReadOnly = true;
            this.textBox_Universe1.Size = new System.Drawing.Size(119, 25);
            this.textBox_Universe1.TabIndex = 4;
            this.textBox_Universe1.Text = "Universe1";
            this.textBox_Universe1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown_U1
            // 
            this.numericUpDown_U1.Location = new System.Drawing.Point(143, 65);
            this.numericUpDown_U1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_U1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_U1.Name = "numericUpDown_U1";
            this.numericUpDown_U1.Size = new System.Drawing.Size(72, 32);
            this.numericUpDown_U1.TabIndex = 3;
            this.numericUpDown_U1.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numericUpDown_U2
            // 
            this.numericUpDown_U2.Location = new System.Drawing.Point(143, 124);
            this.numericUpDown_U2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_U2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_U2.Name = "numericUpDown_U2";
            this.numericUpDown_U2.Size = new System.Drawing.Size(72, 32);
            this.numericUpDown_U2.TabIndex = 2;
            this.numericUpDown_U2.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // panel_TeeChart
            // 
            this.panel_TeeChart.Controls.Add(this.teehartController);
            this.panel_TeeChart.Controls.Add(this.teeChart);
            this.panel_TeeChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_TeeChart.Location = new System.Drawing.Point(0, 0);
            this.panel_TeeChart.Name = "panel_TeeChart";
            this.panel_TeeChart.Size = new System.Drawing.Size(445, 278);
            this.panel_TeeChart.TabIndex = 1;
            // 
            // teehartController
            // 
            this.teehartController.ButtonSize = Steema.TeeChart.ControllerButtonSize.x16;
            this.teehartController.Chart = this.teeChart;
            this.teehartController.LabelValues = true;
            this.teehartController.Location = new System.Drawing.Point(0, 0);
            this.teehartController.Name = "teehartController";
            this.teehartController.Size = new System.Drawing.Size(445, 25);
            this.teehartController.TabIndex = 1;
            this.teehartController.Text = "chartController1";
            this.teehartController.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.teehartController_MouseDoubleClick);
            // 
            // teeChart
            // 
            // 
            // 
            // 
            this.teeChart.Aspect.Chart3DPercent = 100;
            this.teeChart.Aspect.Orthogonal = false;
            this.teeChart.Aspect.Perspective = 51;
            this.teeChart.Aspect.Zoom = 72;
            this.teeChart.Aspect.ZoomFloat = 72D;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.teeChart.Axes.Bottom.Title.Caption = "InputUniverse1";
            this.teeChart.Axes.Bottom.Title.Lines = new string[] {
        "InputUniverse1"};
            // 
            // 
            // 
            this.teeChart.Axes.Depth.LabelsAsSeriesTitles = true;
            // 
            // 
            // 
            this.teeChart.Axes.Depth.Title.Caption = "Uni2";
            this.teeChart.Axes.Depth.Title.Lines = new string[] {
        "Uni2"};
            this.teeChart.Axes.Depth.Visible = true;
            // 
            // 
            // 
            this.teeChart.Axes.DepthTop.LabelsAsSeriesTitles = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.teeChart.Axes.Left.Title.Caption = "Output";
            this.teeChart.Axes.Left.Title.Lines = new string[] {
        "Output"};
            // 
            // 
            // 
            this.teeChart.Axes.Right.Visible = false;
            // 
            // 
            // 
            this.teeChart.Axes.Top.Visible = false;
            this.teeChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teeChart.Location = new System.Drawing.Point(0, 0);
            this.teeChart.Name = "teeChart";
            this.teeChart.Series.Add(this.surface1);
            this.teeChart.Size = new System.Drawing.Size(445, 278);
            this.teeChart.TabIndex = 0;
            this.teeChart.DoubleClick += new System.EventHandler(this.teeChart_DoubleClick);
            // 
            // surface1
            // 
            // 
            // 
            // 
            this.surface1.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.surface1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.surface1.ColorEach = false;
            this.surface1.PaletteMin = 0D;
            this.surface1.PaletteStep = 0D;
            this.surface1.PaletteStyle = Steema.TeeChart.Styles.PaletteStyles.Pale;
            this.surface1.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.surface1.Title = "surface1";
            // 
            // 
            // 
            this.surface1.XValues.DataMember = "X";
            // 
            // 
            // 
            this.surface1.YValues.DataMember = "Y";
            // 
            // 
            // 
            this.surface1.ZValues.DataMember = "Z";
            // 
            // tabPage_2D
            // 
            this.tabPage_2D.Controls.Add(this.chart_InputOutputMap);
            this.tabPage_2D.Controls.Add(this.button_InferAll_2D);
            this.tabPage_2D.Location = new System.Drawing.Point(4, 25);
            this.tabPage_2D.Name = "tabPage_2D";
            this.tabPage_2D.Size = new System.Drawing.Size(671, 291);
            this.tabPage_2D.TabIndex = 1;
            this.tabPage_2D.Text = "2D InputOutput Map";
            this.tabPage_2D.UseVisualStyleBackColor = true;
            // 
            // chart_InputOutputMap
            // 
            this.chart_InputOutputMap.BackColor = System.Drawing.Color.NavajoWhite;
            chartArea4.AxisX.IsStartedFromZero = false;
            chartArea4.Name = "ChartArea1";
            this.chart_InputOutputMap.ChartAreas.Add(chartArea4);
            this.chart_InputOutputMap.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.BackColor = System.Drawing.Color.NavajoWhite;
            legend4.BorderColor = System.Drawing.Color.NavajoWhite;
            legend4.Name = "Legend1";
            legend4.TitleBackColor = System.Drawing.Color.White;
            this.chart_InputOutputMap.Legends.Add(legend4);
            this.chart_InputOutputMap.Location = new System.Drawing.Point(152, 0);
            this.chart_InputOutputMap.Name = "chart_InputOutputMap";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart_InputOutputMap.Series.Add(series4);
            this.chart_InputOutputMap.Size = new System.Drawing.Size(519, 291);
            this.chart_InputOutputMap.TabIndex = 0;
            this.chart_InputOutputMap.Text = "chart_InputOutputMap";
            this.chart_InputOutputMap.Visible = false;
            // 
            // button_InferAll_2D
            // 
            this.button_InferAll_2D.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button_InferAll_2D.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_InferAll_2D.Enabled = false;
            this.button_InferAll_2D.Location = new System.Drawing.Point(0, 0);
            this.button_InferAll_2D.Name = "button_InferAll_2D";
            this.button_InferAll_2D.Size = new System.Drawing.Size(152, 291);
            this.button_InferAll_2D.TabIndex = 1;
            this.button_InferAll_2D.Text = "Inference All Crisp Inputs";
            this.button_InferAll_2D.UseVisualStyleBackColor = false;
            this.button_InferAll_2D.Click += new System.EventHandler(this.button_InferAll_2D_Click);
            // 
            // menuStrip_Main
            // 
            this.menuStrip_Main.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip_Main.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_Main.Name = "menuStrip_Main";
            this.menuStrip_Main.Size = new System.Drawing.Size(1293, 27);
            this.menuStrip_Main.TabIndex = 12;
            this.menuStrip_Main.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(47, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(130, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(130, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click_1);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(130, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStrip_Main
            // 
            this.toolStrip_Main.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_New,
            this.toolStripButton_Open,
            this.toolStripButton_Save});
            this.toolStrip_Main.Location = new System.Drawing.Point(0, 27);
            this.toolStrip_Main.Name = "toolStrip_Main";
            this.toolStrip_Main.Size = new System.Drawing.Size(1293, 47);
            this.toolStrip_Main.TabIndex = 13;
            this.toolStrip_Main.Text = "toolStrip_Main";
            // 
            // toolStripButton_New
            // 
            this.toolStripButton_New.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_New.Image")));
            this.toolStripButton_New.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_New.Name = "toolStripButton_New";
            this.toolStripButton_New.Size = new System.Drawing.Size(85, 44);
            this.toolStripButton_New.Text = "New";
            this.toolStripButton_New.ToolTipText = "New";
            this.toolStripButton_New.Click += new System.EventHandler(this.toolStripButton_New_Click);
            // 
            // toolStripButton_Open
            // 
            this.toolStripButton_Open.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Open.Image")));
            this.toolStripButton_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Open.Name = "toolStripButton_Open";
            this.toolStripButton_Open.Size = new System.Drawing.Size(91, 44);
            this.toolStripButton_Open.Text = "Open";
            this.toolStripButton_Open.Click += new System.EventHandler(this.toolStripButton_Open_Click);
            // 
            // toolStripButton_Save
            // 
            this.toolStripButton_Save.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Save.Image")));
            this.toolStripButton_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Save.Name = "toolStripButton_Save";
            this.toolStripButton_Save.Size = new System.Drawing.Size(86, 44);
            this.toolStripButton_Save.Text = "Save";
            this.toolStripButton_Save.Click += new System.EventHandler(this.toolStripButton_Save_Click);
            // 
            // imageList_NewOpenSave
            // 
            this.imageList_NewOpenSave.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_NewOpenSave.ImageStream")));
            this.imageList_NewOpenSave.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_NewOpenSave.Images.SetKeyName(0, "disk.png");
            this.imageList_NewOpenSave.Images.SetKeyName(1, "folder.png");
            this.imageList_NewOpenSave.Images.SetKeyName(2, "new-document.png");
            // 
            // toolStripButton_invert
            // 
            this.toolStripButton_invert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_invert.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_invert.Image")));
            this.toolStripButton_invert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_invert.Name = "toolStripButton_invert";
            this.toolStripButton_invert.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton_invert.Text = "toolStripButton1";
            // 
            // imageList_invert
            // 
            this.imageList_invert.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_invert.ImageStream")));
            this.imageList_invert.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_invert.Images.SetKeyName(0, "axis.png");
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.Color.Wheat;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(40, 40);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1293, 892);
            this.Controls.Add(this.splitContainer_LeftRight);
            this.Controls.Add(this.toolStrip_Main);
            this.Controls.Add(this.menuStrip_Main);
            this.Font = new System.Drawing.Font("微軟正黑體", 11F);
            this.MainMenuStrip = this.menuStrip_Main;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fuzzy System";
            ((System.ComponentModel.ISupportInitialize)(this.chart_Main)).EndInit();
            this.splitContainer_LeftRight.Panel1.ResumeLayout(false);
            this.splitContainer_LeftRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_LeftRight)).EndInit();
            this.splitContainer_LeftRight.ResumeLayout(false);
            this.splitContainer_InferenceSelection.Panel1.ResumeLayout(false);
            this.splitContainer_InferenceSelection.Panel1.PerformLayout();
            this.splitContainer_InferenceSelection.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_InferenceSelection)).EndInit();
            this.splitContainer_InferenceSelection.ResumeLayout(false);
            this.splitContainer_DataGrid_fuzzySet.Panel1.ResumeLayout(false);
            this.splitContainer_DataGrid_fuzzySet.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_DataGrid_fuzzySet)).EndInit();
            this.splitContainer_DataGrid_fuzzySet.ResumeLayout(false);
            this.splitContainer_Tree_property.Panel1.ResumeLayout(false);
            this.splitContainer_Tree_property.Panel1.PerformLayout();
            this.splitContainer_Tree_property.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Tree_property)).EndInit();
            this.splitContainer_Tree_property.ResumeLayout(false);
            this.tabControl_AddFuzzy.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox_BinaryOpFS.ResumeLayout(false);
            this.groupBox_BinaryOpFS.PerformLayout();
            this.groupBox_UnaryOpFS.ResumeLayout(false);
            this.groupBox_UnaryOpFS.PerformLayout();
            this.groupBox_PrimaryFS.ResumeLayout(false);
            this.groupBox_PrimaryFS.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox_Rule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Rule)).EndInit();
            this.groupBox_Condition.ResumeLayout(false);
            this.groupBox_Condition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Infer)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.splitContainer_Chart_TeeMap.Panel1.ResumeLayout(false);
            this.splitContainer_Chart_TeeMap.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Chart_TeeMap)).EndInit();
            this.splitContainer_Chart_TeeMap.ResumeLayout(false);
            this.tabControl_InputOutputMap.ResumeLayout(false);
            this.tabPage_3D.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_U1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_U2)).EndInit();
            this.panel_TeeChart.ResumeLayout(false);
            this.panel_TeeChart.PerformLayout();
            this.tabPage_2D.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_InputOutputMap)).EndInit();
            this.menuStrip_Main.ResumeLayout(false);
            this.menuStrip_Main.PerformLayout();
            this.toolStrip_Main.ResumeLayout(false);
            this.toolStrip_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_addUniverse;
        private System.Windows.Forms.TreeView treeView_Main;
        private System.Windows.Forms.PropertyGrid propertyGrid_Main;
        private System.Windows.Forms.ComboBox comboBox_chooseFuzzy;
        private System.Windows.Forms.Button btn_addFuzzySet;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Main;
        private System.Windows.Forms.SplitContainer splitContainer_LeftRight;
        private System.Windows.Forms.SplitContainer splitContainer_DataGrid_fuzzySet;
        private System.Windows.Forms.TabControl tabControl_AddFuzzy;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox_PrimaryFS;
        private System.Windows.Forms.GroupBox groupBox_BinaryOpFS;
        private System.Windows.Forms.GroupBox groupBox_UnaryOpFS;
        private System.Windows.Forms.ComboBox comboBox_Unary;
        private System.Windows.Forms.SplitContainer splitContainer_Tree_property;
        private System.Windows.Forms.Label label_SelectedFS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Binary;
        private System.Windows.Forms.Button btn_Binary_FS1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_addBinary;
        private System.Windows.Forms.Button btn_Binary_FS2;
        private System.Windows.Forms.Button btn_addUnary;
        private ImageList imageList_TreeViewMain;
        private TabPage tabPage2;
        private SplitContainer splitContainer1;
        private GroupBox groupBox_Rule;
        private GroupBox groupBox_Condition;
        private DataGridView dataGridView_Rule;
        private DataGridView dataGridView_Infer;
        private Button button_addRule;
        private Button button_infer;
        private CheckBox checkBox_Cut;
        private Button button_Rule_Delete;
        private Button button_addAllRule;
        private SplitContainer splitContainer_InferenceSelection;
        private MenuStrip menuStrip_Main;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStrip toolStrip_Main;
        private ToolStripButton toolStripButton_New;
        private ToolStripButton toolStripButton_Open;
        private ToolStripButton toolStripButton_Save;
        private ImageList imageList_NewOpenSave;
        private PropertyGrid propertyGrid_InferSys;
        private TextBox textBox_InferType;
        private SplitContainer splitContainer_Chart_TeeMap;
        private TabControl tabControl_InputOutputMap;
        private TabPage tabPage_3D;
        private Button button_InferneceAll;
        private Panel panel_TeeChart;
        private Steema.TeeChart.TChart teeChart;
        private Steema.TeeChart.ChartController teehartController;
        private Steema.TeeChart.Styles.Surface surface1;
        private RadioButton radioButton_Tsukamoto;
        private RadioButton radioButton_Sugeno;
        private RadioButton radioButton_Mamdani;
        private TabPage tabPage4;
        private TextBox textBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_InputOutputMap;
        private NumericUpDown numericUpDown_U1;
        private TabPage tabPage_2D;
        private Button button_InferAll_2D;
        private TextBox textBox_Universe2;
        private TextBox textBox_Universe1;
        private NumericUpDown numericUpDown_U2;
        private ListBox listBox_SugenoOutput;
        private SplitContainer splitContainer2;
        private SaveFileDialog dlgSave;
        private OpenFileDialog dlgOpen;
        private ToolStripButton toolStripButton_invert;
        private ImageList imageList_invert;
        public ToolStripButton toolStripButton1;
        private ErrorProvider errorProvider1;
        private Label label5;
    }
}

