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
            TabView = new TabControl();
            tabPage1 = new TabPage();
            button8 = new Button();
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
            tabPage4 = new TabPage();
            pictureBox2 = new PictureBox();
            tabControl1 = new TabControl();
            tabPage5 = new TabPage();
            conv_state = new Label();
            Excel_file_tag = new Label();
            sel_label = new Label();
            button2 = new Button();
            label1 = new Label();
            FileNameBox = new TextBox();
            button1 = new Button();
            tabPage6 = new TabPage();
            csv_label = new Label();
            label2 = new Label();
            csv_view = new DataGridView();
            button5 = new Button();
            button4 = new Button();
            tabPage7 = new TabPage();
            label7 = new Label();
            insert_state = new Label();
            label6 = new Label();
            sel_insert_label = new Label();
            label5 = new Label();
            button7 = new Button();
            conn_db_state = new Label();
            label4 = new Label();
            label3 = new Label();
            button6 = new Button();
            pictureBox1 = new PictureBox();
            pictureBox3 = new PictureBox();
            label8 = new Label();
            label9 = new Label();
            TabView.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TableView).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            tabControl1.SuspendLayout();
            tabPage5.SuspendLayout();
            tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)csv_view).BeginInit();
            tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // TabView
            // 
            TabView.Controls.Add(tabPage1);
            TabView.Controls.Add(tabPage2);
            TabView.Controls.Add(tabPage3);
            TabView.Controls.Add(tabPage4);
            TabView.Location = new Point(12, 41);
            TabView.Name = "TabView";
            TabView.SelectedIndex = 0;
            TabView.Size = new Size(1469, 794);
            TabView.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(button8);
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
            // button8
            // 
            button8.Location = new Point(226, 356);
            button8.Name = "button8";
            button8.Size = new Size(192, 33);
            button8.TabIndex = 11;
            button8.Text = "Refresh Database";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
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
            // tabPage4
            // 
            tabPage4.BackColor = Color.White;
            tabPage4.Controls.Add(pictureBox2);
            tabPage4.Controls.Add(tabControl1);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1461, 766);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Data Management";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(538, 6);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(465, 97);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage6);
            tabControl1.Controls.Add(tabPage7);
            tabControl1.Location = new Point(6, 99);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1446, 661);
            tabControl1.TabIndex = 0;
            // 
            // tabPage5
            // 
            tabPage5.BackColor = Color.White;
            tabPage5.Controls.Add(conv_state);
            tabPage5.Controls.Add(Excel_file_tag);
            tabPage5.Controls.Add(sel_label);
            tabPage5.Controls.Add(button2);
            tabPage5.Controls.Add(label1);
            tabPage5.Controls.Add(FileNameBox);
            tabPage5.Controls.Add(button1);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1438, 633);
            tabPage5.TabIndex = 0;
            tabPage5.Text = "File Conversor";
            // 
            // conv_state
            // 
            conv_state.AutoSize = true;
            conv_state.Location = new Point(685, 370);
            conv_state.Name = "conv_state";
            conv_state.Size = new Size(108, 15);
            conv_state.TabIndex = 6;
            conv_state.Text = "Conversion Status: ";
            // 
            // Excel_file_tag
            // 
            Excel_file_tag.AutoSize = true;
            Excel_file_tag.Location = new Point(784, 143);
            Excel_file_tag.Name = "Excel_file_tag";
            Excel_file_tag.Size = new Size(0, 15);
            Excel_file_tag.TabIndex = 5;
            // 
            // sel_label
            // 
            sel_label.AutoSize = true;
            sel_label.Location = new Point(703, 143);
            sel_label.Name = "sel_label";
            sel_label.Size = new Size(75, 15);
            sel_label.TabIndex = 4;
            sel_label.Text = "Selected File:";
            // 
            // button2
            // 
            button2.Location = new Point(581, 268);
            button2.Name = "button2";
            button2.Size = new Size(328, 52);
            button2.TabIndex = 3;
            button2.Text = "Save Conversed File";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(703, 182);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 2;
            label1.Text = "New File Name ";
            // 
            // FileNameBox
            // 
            FileNameBox.Location = new Point(581, 216);
            FileNameBox.Name = "FileNameBox";
            FileNameBox.Size = new Size(328, 23);
            FileNameBox.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(581, 60);
            button1.Name = "button1";
            button1.Size = new Size(328, 64);
            button1.TabIndex = 0;
            button1.Text = "Select File\r\n";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(csv_label);
            tabPage6.Controls.Add(label2);
            tabPage6.Controls.Add(csv_view);
            tabPage6.Controls.Add(button5);
            tabPage6.Controls.Add(button4);
            tabPage6.Location = new Point(4, 24);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new Padding(3);
            tabPage6.Size = new Size(1438, 633);
            tabPage6.TabIndex = 1;
            tabPage6.Text = "File Viewer";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // csv_label
            // 
            csv_label.AutoSize = true;
            csv_label.Location = new Point(15, 199);
            csv_label.Name = "csv_label";
            csv_label.Size = new Size(0, 15);
            csv_label.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 174);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 3;
            label2.Text = "Now Viewing";
            // 
            // csv_view
            // 
            csv_view.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            csv_view.Location = new Point(290, 19);
            csv_view.Name = "csv_view";
            csv_view.Size = new Size(1137, 609);
            csv_view.TabIndex = 2;
            // 
            // button5
            // 
            button5.Location = new Point(15, 106);
            button5.Name = "button5";
            button5.Size = new Size(254, 53);
            button5.TabIndex = 1;
            button5.Text = "Close CSV and Clear Visor";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Location = new Point(15, 21);
            button4.Name = "button4";
            button4.Size = new Size(254, 53);
            button4.TabIndex = 0;
            button4.Text = "Open CSV";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // tabPage7
            // 
            tabPage7.Controls.Add(label7);
            tabPage7.Controls.Add(insert_state);
            tabPage7.Controls.Add(label6);
            tabPage7.Controls.Add(sel_insert_label);
            tabPage7.Controls.Add(label5);
            tabPage7.Controls.Add(button7);
            tabPage7.Controls.Add(conn_db_state);
            tabPage7.Controls.Add(label4);
            tabPage7.Controls.Add(label3);
            tabPage7.Controls.Add(button6);
            tabPage7.Location = new Point(4, 24);
            tabPage7.Name = "tabPage7";
            tabPage7.Padding = new Padding(3);
            tabPage7.Size = new Size(1438, 633);
            tabPage7.TabIndex = 2;
            tabPage7.Text = "Data Insertion";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(343, 236);
            label7.Name = "label7";
            label7.Size = new Size(790, 30);
            label7.TabIndex = 10;
            label7.Text = "Note: Once selected the file, the process is Automated so it will be executed, make sure to review the file you are about to insert in the File Viewer Tab\r\n\r\n";
            // 
            // insert_state
            // 
            insert_state.AutoSize = true;
            insert_state.Location = new Point(678, 305);
            insert_state.Name = "insert_state";
            insert_state.Size = new Size(0, 15);
            insert_state.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(597, 305);
            label6.Name = "label6";
            label6.Size = new Size(88, 15);
            label6.TabIndex = 8;
            label6.Text = "Insertion State: ";
            // 
            // sel_insert_label
            // 
            sel_insert_label.AutoSize = true;
            sel_insert_label.Location = new Point(675, 266);
            sel_insert_label.Name = "sel_insert_label";
            sel_insert_label.Size = new Size(0, 15);
            sel_insert_label.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(597, 266);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 5;
            label5.Text = "Selected File:";
            // 
            // button7
            // 
            button7.Location = new Point(597, 177);
            button7.Name = "button7";
            button7.Size = new Size(250, 43);
            button7.TabIndex = 4;
            button7.Text = "Select File to Insert";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // conn_db_state
            // 
            conn_db_state.AutoSize = true;
            conn_db_state.Location = new Point(707, 137);
            conn_db_state.Name = "conn_db_state";
            conn_db_state.Size = new Size(0, 15);
            conn_db_state.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(597, 137);
            label4.Name = "label4";
            label4.Size = new Size(104, 15);
            label4.TabIndex = 2;
            label4.Text = "Connection State: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(408, 23);
            label3.Name = "label3";
            label3.Size = new Size(676, 15);
            label3.TabIndex = 1;
            label3.Text = "If not connected to database, click the next button. Otherwise leave the process as it is, the System will tell you the current state\r\n";
            // 
            // button6
            // 
            button6.Location = new Point(597, 66);
            button6.Name = "button6";
            button6.Size = new Size(250, 43);
            button6.TabIndex = 0;
            button6.Text = "Connect to Database";
            button6.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1308, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(148, 56);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(567, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(368, 58);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(226, 295);
            label8.Name = "label8";
            label8.Size = new Size(185, 15);
            label8.TabIndex = 12;
            label8.Text = "Button below should beused after\r\n";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(226, 310);
            label9.Name = "label9";
            label9.Size = new Size(124, 15);
            label9.TabIndex = 13;
            label9.Text = "insertion to refresh DB";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(1480, 838);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Controls.Add(TabView);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            TabView.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TableView).EndInit();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            tabPage6.ResumeLayout(false);
            tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)csv_view).EndInit();
            tabPage7.ResumeLayout(false);
            tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion
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
        private TabPage tabPage4;
        private TabControl tabControl1;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private TabPage tabPage7;
        private Button button1;
        private Button button2;
        private Label label1;
        private TextBox FileNameBox;
        private Label sel_label;
        private Label Excel_file_tag;
        private Label conv_state;
        private DataGridView csv_view;
        private Button button5;
        private Button button4;
        private Label csv_label;
        private Label label2;
        private Label label3;
        private Button button6;
        private Label conn_db_state;
        private Label label4;
        private Label label5;
        private Button button7;
        private Label sel_insert_label;
        private Label insert_state;
        private Label label6;
        private Label label7;
        private Button button8;
        private Label label9;
        private Label label8;
    }
}
