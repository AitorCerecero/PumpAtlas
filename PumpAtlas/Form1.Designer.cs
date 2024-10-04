namespace PumpAtlas
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            TabView = new TabControl();
            tabPage1 = new TabPage();
            conn_state = new Label();
            button3 = new Button();
            Clear_select = new Button();
            SizeList = new ListBox();
            TableView = new DataGridView();
            SpeedList = new ListBox();
            FlowList = new ListBox();
            HeadList = new ListBox();
            CompanyList = new ListBox();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            pictureBox1 = new PictureBox();
            TabView.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TableView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(667, 9);
            label1.Name = "label1";
            label1.Size = new Size(151, 37);
            label1.TabIndex = 0;
            label1.Text = "Pump Atlas";
            // 
            // TabView
            // 
            TabView.Controls.Add(tabPage1);
            TabView.Controls.Add(tabPage2);
            TabView.Controls.Add(tabPage3);
            TabView.Location = new Point(12, 41);
            TabView.Name = "TabView";
            TabView.SelectedIndex = 0;
            TabView.Size = new Size(1469, 794);
            TabView.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(conn_state);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(Clear_select);
            tabPage1.Controls.Add(SizeList);
            tabPage1.Controls.Add(TableView);
            tabPage1.Controls.Add(SpeedList);
            tabPage1.Controls.Add(FlowList);
            tabPage1.Controls.Add(HeadList);
            tabPage1.Controls.Add(CompanyList);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1461, 766);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Map";
            // 
            // conn_state
            // 
            conn_state.AutoSize = true;
            conn_state.Location = new Point(27, 702);
            conn_state.Name = "conn_state";
            conn_state.Size = new Size(104, 45);
            conn_state.TabIndex = 10;
            conn_state.Text = "Connection State: \r\n\r\n\r\n";
            // 
            // button3
            // 
            button3.Location = new Point(226, 235);
            button3.Name = "button3";
            button3.Size = new Size(192, 33);
            button3.TabIndex = 8;
            button3.Text = "Run Filters";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Clear_select
            // 
            Clear_select.Location = new Point(226, 185);
            Clear_select.Name = "Clear_select";
            Clear_select.Size = new Size(192, 33);
            Clear_select.TabIndex = 6;
            Clear_select.Text = "Clear Results\r\n";
            Clear_select.UseVisualStyleBackColor = true;
            Clear_select.Click += Clear_select_Click;
            // 
            // SizeList
            // 
            SizeList.FormattingEnabled = true;
            SizeList.ItemHeight = 15;
            SizeList.Location = new Point(226, 16);
            SizeList.Name = "SizeList";
            SizeList.SelectionMode = SelectionMode.MultiSimple;
            SizeList.Size = new Size(190, 154);
            SizeList.TabIndex = 5;
            // 
            // TableView
            // 
            TableView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TableView.GridColor = SystemColors.Control;
            TableView.Location = new Point(447, 16);
            TableView.Name = "TableView";
            TableView.Size = new Size(1005, 744);
            TableView.TabIndex = 4;
            // 
            // SpeedList
            // 
            SpeedList.FormattingEnabled = true;
            SpeedList.ItemHeight = 15;
            SpeedList.Location = new Point(18, 516);
            SpeedList.Name = "SpeedList";
            SpeedList.SelectionMode = SelectionMode.MultiSimple;
            SpeedList.Size = new Size(190, 154);
            SpeedList.TabIndex = 3;
            // 
            // FlowList
            // 
            FlowList.FormattingEnabled = true;
            FlowList.ItemHeight = 15;
            FlowList.Location = new Point(18, 356);
            FlowList.Name = "FlowList";
            FlowList.SelectionMode = SelectionMode.MultiSimple;
            FlowList.Size = new Size(190, 154);
            FlowList.TabIndex = 2;
            // 
            // HeadList
            // 
            HeadList.FormattingEnabled = true;
            HeadList.ItemHeight = 15;
            HeadList.Location = new Point(18, 185);
            HeadList.Name = "HeadList";
            HeadList.SelectionMode = SelectionMode.MultiSimple;
            HeadList.Size = new Size(190, 154);
            HeadList.TabIndex = 1;
            // 
            // CompanyList
            // 
            CompanyList.FormattingEnabled = true;
            CompanyList.ItemHeight = 15;
            CompanyList.Location = new Point(18, 16);
            CompanyList.Name = "CompanyList";
            CompanyList.SelectionMode = SelectionMode.MultiSimple;
            CompanyList.Size = new Size(190, 154);
            CompanyList.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1461, 766);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "RP vs Others";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1461, 766);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "RP vs Market";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1307, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(167, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(1480, 838);
            Controls.Add(pictureBox1);
            Controls.Add(TabView);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            TabView.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TableView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TabControl TabView;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private ListBox CompanyList;
        private ListBox HeadList;
        private ListBox SpeedList;
        private ListBox FlowList;
        private ListBox SizeList;
        private DataGridView TableView;
        private Button Clear_select;
        private Label conn_state;
        private Button button3;
        private PictureBox pictureBox1;
    }
}
