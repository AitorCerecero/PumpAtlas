﻿namespace PumpAtlas
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
            label28 = new Label();
            StagesList = new ListBox();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
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
            Head_rpvsothers = new ListBox();
            label26 = new Label();
            Stages_rpvsothers = new ListBox();
            label19 = new Label();
            button9 = new Button();
            button10 = new Button();
            dataGridView1 = new DataGridView();
            label18 = new Label();
            Size_rpvsothers = new ListBox();
            label17 = new Label();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            label16 = new Label();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            label2 = new Label();
            label15 = new Label();
            Company_rpvsothers = new ListBox();
            Flow_rpvsothers = new ListBox();
            tabPage3 = new TabPage();
            label27 = new Label();
            Head_rpvsmkt = new ListBox();
            Company_rpvsmkt = new ListBox();
            label20 = new Label();
            button11 = new Button();
            button12 = new Button();
            dataGridView2 = new DataGridView();
            label21 = new Label();
            Flow_rpvsmkt = new ListBox();
            label22 = new Label();
            checkBox5 = new CheckBox();
            checkBox6 = new CheckBox();
            label23 = new Label();
            checkBox7 = new CheckBox();
            checkBox8 = new CheckBox();
            label24 = new Label();
            label25 = new Label();
            Size_rpvsmkt = new ListBox();
            Stages_rpvsmkt = new ListBox();
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
            viewer = new Label();
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
            button8 = new Button();
            label8 = new Label();
            TabView.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TableView).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
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
            tabPage1.Controls.Add(label28);
            tabPage1.Controls.Add(StagesList);
            tabPage1.Controls.Add(label14);
            tabPage1.Controls.Add(label13);
            tabPage1.Controls.Add(label12);
            tabPage1.Controls.Add(label11);
            tabPage1.Controls.Add(label10);
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
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(228, 177);
            label28.Name = "label28";
            label28.Size = new Size(41, 15);
            label28.TabIndex = 53;
            label28.Text = "Stages";
            // 
            // StagesList
            // 
            StagesList.FormattingEnabled = true;
            StagesList.ItemHeight = 15;
            StagesList.Location = new Point(230, 195);
            StagesList.Name = "StagesList";
            StagesList.SelectionMode = SelectionMode.MultiSimple;
            StagesList.Size = new Size(190, 34);
            StagesList.TabIndex = 52;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(226, 3);
            label14.Name = "label14";
            label14.Size = new Size(62, 15);
            label14.TabIndex = 18;
            label14.Text = "Pump Size";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(18, 3);
            label13.Name = "label13";
            label13.Size = new Size(59, 15);
            label13.TabIndex = 17;
            label13.Text = "Company";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(18, 177);
            label12.Name = "label12";
            label12.Size = new Size(35, 15);
            label12.TabIndex = 16;
            label12.Text = "Head";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(18, 352);
            label11.Name = "label11";
            label11.Size = new Size(32, 15);
            label11.TabIndex = 15;
            label11.Text = "Flow";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(18, 527);
            label10.Name = "label10";
            label10.Size = new Size(80, 15);
            label10.TabIndex = 14;
            label10.Text = "Speed in RPM";
            // 
            // conn_state
            // 
            conn_state.AutoSize = true;
            conn_state.Location = new Point(18, 715);
            conn_state.Name = "conn_state";
            conn_state.Size = new Size(104, 45);
            conn_state.TabIndex = 10;
            conn_state.Text = "Connection State: \r\n\r\n\r\n";
            // 
            // button3
            // 
            button3.Location = new Point(226, 312);
            button3.Name = "button3";
            button3.Size = new Size(192, 33);
            button3.TabIndex = 8;
            button3.Text = "Run Selections";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Clear_select
            // 
            Clear_select.Location = new Point(226, 262);
            Clear_select.Name = "Clear_select";
            Clear_select.Size = new Size(192, 33);
            Clear_select.TabIndex = 6;
            Clear_select.Text = "Clear Selections and Results";
            Clear_select.UseVisualStyleBackColor = true;
            Clear_select.Click += Clear_select_Click;
            // 
            // SizeList
            // 
            SizeList.FormattingEnabled = true;
            SizeList.ItemHeight = 15;
            SizeList.Location = new Point(228, 20);
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
            SpeedList.Location = new Point(18, 545);
            SpeedList.Name = "SpeedList";
            SpeedList.SelectionMode = SelectionMode.MultiSimple;
            SpeedList.Size = new Size(190, 154);
            SpeedList.TabIndex = 3;
            // 
            // FlowList
            // 
            FlowList.FormattingEnabled = true;
            FlowList.ItemHeight = 15;
            FlowList.Location = new Point(18, 370);
            FlowList.Name = "FlowList";
            FlowList.SelectionMode = SelectionMode.MultiSimple;
            FlowList.Size = new Size(190, 154);
            FlowList.TabIndex = 2;
            // 
            // HeadList
            // 
            HeadList.FormattingEnabled = true;
            HeadList.ItemHeight = 15;
            HeadList.Location = new Point(18, 195);
            HeadList.Name = "HeadList";
            HeadList.SelectionMode = SelectionMode.MultiSimple;
            HeadList.Size = new Size(190, 154);
            HeadList.TabIndex = 1;
            // 
            // CompanyList
            // 
            CompanyList.FormattingEnabled = true;
            CompanyList.ItemHeight = 15;
            CompanyList.Location = new Point(18, 20);
            CompanyList.Name = "CompanyList";
            CompanyList.SelectionMode = SelectionMode.MultiSimple;
            CompanyList.Size = new Size(190, 154);
            CompanyList.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(Head_rpvsothers);
            tabPage2.Controls.Add(label26);
            tabPage2.Controls.Add(Stages_rpvsothers);
            tabPage2.Controls.Add(label19);
            tabPage2.Controls.Add(button9);
            tabPage2.Controls.Add(button10);
            tabPage2.Controls.Add(dataGridView1);
            tabPage2.Controls.Add(label18);
            tabPage2.Controls.Add(Size_rpvsothers);
            tabPage2.Controls.Add(label17);
            tabPage2.Controls.Add(checkBox3);
            tabPage2.Controls.Add(checkBox4);
            tabPage2.Controls.Add(label16);
            tabPage2.Controls.Add(checkBox2);
            tabPage2.Controls.Add(checkBox1);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(label15);
            tabPage2.Controls.Add(Company_rpvsothers);
            tabPage2.Controls.Add(Flow_rpvsothers);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1461, 766);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "RP vs Others";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Head_rpvsothers
            // 
            Head_rpvsothers.FormattingEnabled = true;
            Head_rpvsothers.ItemHeight = 15;
            Head_rpvsothers.Location = new Point(16, 601);
            Head_rpvsothers.Name = "Head_rpvsothers";
            Head_rpvsothers.SelectionMode = SelectionMode.MultiSimple;
            Head_rpvsothers.Size = new Size(190, 154);
            Head_rpvsothers.TabIndex = 37;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(14, 583);
            label26.Name = "label26";
            label26.Size = new Size(35, 15);
            label26.TabIndex = 36;
            label26.Text = "Head";
            // 
            // Stages_rpvsothers
            // 
            Stages_rpvsothers.FormattingEnabled = true;
            Stages_rpvsothers.ItemHeight = 15;
            Stages_rpvsothers.Location = new Point(216, 286);
            Stages_rpvsothers.Name = "Stages_rpvsothers";
            Stages_rpvsothers.SelectionMode = SelectionMode.MultiSimple;
            Stages_rpvsothers.Size = new Size(190, 34);
            Stages_rpvsothers.TabIndex = 35;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(214, 268);
            label19.Name = "label19";
            label19.Size = new Size(41, 15);
            label19.TabIndex = 34;
            label19.Text = "Stages";
            // 
            // button9
            // 
            button9.Location = new Point(214, 234);
            button9.Name = "button9";
            button9.Size = new Size(192, 33);
            button9.TabIndex = 33;
            button9.Text = "Run Selections";
            button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            button10.Location = new Point(214, 184);
            button10.Name = "button10";
            button10.Size = new Size(192, 33);
            button10.TabIndex = 32;
            button10.Text = "Clear Selections and Results";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = SystemColors.Control;
            dataGridView1.Location = new Point(412, 11);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1028, 744);
            dataGridView1.TabIndex = 31;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(18, 202);
            label18.Name = "label18";
            label18.Size = new Size(32, 15);
            label18.TabIndex = 30;
            label18.Text = "Flow";
            // 
            // Size_rpvsothers
            // 
            Size_rpvsothers.FormattingEnabled = true;
            Size_rpvsothers.ItemHeight = 15;
            Size_rpvsothers.Location = new Point(18, 411);
            Size_rpvsothers.Name = "Size_rpvsothers";
            Size_rpvsothers.SelectionMode = SelectionMode.MultiSimple;
            Size_rpvsothers.Size = new Size(190, 154);
            Size_rpvsothers.TabIndex = 29;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(226, 116);
            label17.Name = "label17";
            label17.Size = new Size(65, 15);
            label17.TabIndex = 28;
            label17.Text = "Best Motor";
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(226, 159);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(42, 19);
            checkBox3.TabIndex = 27;
            checkBox3.Text = "No";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(226, 134);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(43, 19);
            checkBox4.TabIndex = 26;
            checkBox4.Text = "Yes";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(226, 33);
            label16.Name = "label16";
            label16.Size = new Size(84, 15);
            label16.TabIndex = 25;
            label16.Text = "Best Company";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(226, 76);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(42, 19);
            checkBox2.TabIndex = 24;
            checkBox2.Text = "No";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(226, 51);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(43, 19);
            checkBox1.TabIndex = 23;
            checkBox1.Text = "Yes";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 393);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 22;
            label2.Text = "Pump Size";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(18, 15);
            label15.Name = "label15";
            label15.Size = new Size(59, 15);
            label15.TabIndex = 21;
            label15.Text = "Company";
            // 
            // Company_rpvsothers
            // 
            Company_rpvsothers.FormattingEnabled = true;
            Company_rpvsothers.ItemHeight = 15;
            Company_rpvsothers.Location = new Point(18, 33);
            Company_rpvsothers.Name = "Company_rpvsothers";
            Company_rpvsothers.SelectionMode = SelectionMode.MultiSimple;
            Company_rpvsothers.Size = new Size(190, 154);
            Company_rpvsothers.TabIndex = 20;
            // 
            // Flow_rpvsothers
            // 
            Flow_rpvsothers.FormattingEnabled = true;
            Flow_rpvsothers.ItemHeight = 15;
            Flow_rpvsothers.Location = new Point(18, 220);
            Flow_rpvsothers.Name = "Flow_rpvsothers";
            Flow_rpvsothers.SelectionMode = SelectionMode.MultiSimple;
            Flow_rpvsothers.Size = new Size(190, 154);
            Flow_rpvsothers.TabIndex = 19;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label27);
            tabPage3.Controls.Add(Head_rpvsmkt);
            tabPage3.Controls.Add(Company_rpvsmkt);
            tabPage3.Controls.Add(label20);
            tabPage3.Controls.Add(button11);
            tabPage3.Controls.Add(button12);
            tabPage3.Controls.Add(dataGridView2);
            tabPage3.Controls.Add(label21);
            tabPage3.Controls.Add(Flow_rpvsmkt);
            tabPage3.Controls.Add(label22);
            tabPage3.Controls.Add(checkBox5);
            tabPage3.Controls.Add(checkBox6);
            tabPage3.Controls.Add(label23);
            tabPage3.Controls.Add(checkBox7);
            tabPage3.Controls.Add(checkBox8);
            tabPage3.Controls.Add(label24);
            tabPage3.Controls.Add(label25);
            tabPage3.Controls.Add(Size_rpvsmkt);
            tabPage3.Controls.Add(Stages_rpvsmkt);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1461, 766);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "RP vs Market";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(18, 573);
            label27.Name = "label27";
            label27.Size = new Size(35, 15);
            label27.TabIndex = 54;
            label27.Text = "Head";
            // 
            // Head_rpvsmkt
            // 
            Head_rpvsmkt.FormattingEnabled = true;
            Head_rpvsmkt.ItemHeight = 15;
            Head_rpvsmkt.Location = new Point(20, 591);
            Head_rpvsmkt.Name = "Head_rpvsmkt";
            Head_rpvsmkt.SelectionMode = SelectionMode.MultiSimple;
            Head_rpvsmkt.Size = new Size(190, 154);
            Head_rpvsmkt.TabIndex = 53;
            // 
            // Company_rpvsmkt
            // 
            Company_rpvsmkt.FormattingEnabled = true;
            Company_rpvsmkt.ItemHeight = 15;
            Company_rpvsmkt.Location = new Point(20, 33);
            Company_rpvsmkt.Name = "Company_rpvsmkt";
            Company_rpvsmkt.SelectionMode = SelectionMode.MultiSimple;
            Company_rpvsmkt.Size = new Size(190, 154);
            Company_rpvsmkt.TabIndex = 52;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(214, 276);
            label20.Name = "label20";
            label20.Size = new Size(41, 15);
            label20.TabIndex = 51;
            label20.Text = "Stages";
            // 
            // button11
            // 
            button11.Location = new Point(216, 234);
            button11.Name = "button11";
            button11.Size = new Size(192, 33);
            button11.TabIndex = 50;
            button11.Text = "Run Selections";
            button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            button12.Location = new Point(216, 184);
            button12.Name = "button12";
            button12.Size = new Size(192, 33);
            button12.TabIndex = 49;
            button12.Text = "Clear Selections and Results";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.GridColor = SystemColors.Control;
            dataGridView2.Location = new Point(414, 11);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(1028, 744);
            dataGridView2.TabIndex = 48;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(20, 202);
            label21.Name = "label21";
            label21.Size = new Size(32, 15);
            label21.TabIndex = 47;
            label21.Text = "Flow";
            // 
            // Flow_rpvsmkt
            // 
            Flow_rpvsmkt.FormattingEnabled = true;
            Flow_rpvsmkt.ItemHeight = 15;
            Flow_rpvsmkt.Location = new Point(20, 220);
            Flow_rpvsmkt.Name = "Flow_rpvsmkt";
            Flow_rpvsmkt.SelectionMode = SelectionMode.MultiSimple;
            Flow_rpvsmkt.Size = new Size(190, 154);
            Flow_rpvsmkt.TabIndex = 46;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(228, 116);
            label22.Name = "label22";
            label22.Size = new Size(65, 15);
            label22.TabIndex = 45;
            label22.Text = "Best Motor";
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(228, 159);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(42, 19);
            checkBox5.TabIndex = 44;
            checkBox5.Text = "No";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Location = new Point(228, 134);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(43, 19);
            checkBox6.TabIndex = 43;
            checkBox6.Text = "Yes";
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(228, 33);
            label23.Name = "label23";
            label23.Size = new Size(84, 15);
            label23.TabIndex = 42;
            label23.Text = "Best Company";
            // 
            // checkBox7
            // 
            checkBox7.AutoSize = true;
            checkBox7.Location = new Point(228, 76);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(42, 19);
            checkBox7.TabIndex = 41;
            checkBox7.Text = "No";
            checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            checkBox8.AutoSize = true;
            checkBox8.Location = new Point(228, 51);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new Size(43, 19);
            checkBox8.TabIndex = 40;
            checkBox8.Text = "Yes";
            checkBox8.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(18, 393);
            label24.Name = "label24";
            label24.Size = new Size(62, 15);
            label24.TabIndex = 39;
            label24.Text = "Pump Size";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(20, 15);
            label25.Name = "label25";
            label25.Size = new Size(59, 15);
            label25.TabIndex = 38;
            label25.Text = "Company";
            // 
            // Size_rpvsmkt
            // 
            Size_rpvsmkt.FormattingEnabled = true;
            Size_rpvsmkt.ItemHeight = 15;
            Size_rpvsmkt.Location = new Point(20, 411);
            Size_rpvsmkt.Name = "Size_rpvsmkt";
            Size_rpvsmkt.SelectionMode = SelectionMode.MultiSimple;
            Size_rpvsmkt.Size = new Size(190, 154);
            Size_rpvsmkt.TabIndex = 37;
            // 
            // Stages_rpvsmkt
            // 
            Stages_rpvsmkt.FormattingEnabled = true;
            Stages_rpvsmkt.ItemHeight = 15;
            Stages_rpvsmkt.Location = new Point(216, 294);
            Stages_rpvsmkt.Name = "Stages_rpvsmkt";
            Stages_rpvsmkt.SelectionMode = SelectionMode.MultiSimple;
            Stages_rpvsmkt.Size = new Size(190, 34);
            Stages_rpvsmkt.TabIndex = 36;
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
            pictureBox2.Location = new Point(532, 20);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(465, 97);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
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
            tabPage6.Controls.Add(viewer);
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
            // viewer
            // 
            viewer.AutoSize = true;
            viewer.Location = new Point(15, 174);
            viewer.Name = "viewer";
            viewer.Size = new Size(77, 15);
            viewer.TabIndex = 3;
            viewer.Text = "Now Viewing";
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
            tabPage7.Controls.Add(label8);
            tabPage7.Controls.Add(button8);
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
            label7.Location = new Point(343, 226);
            label7.Name = "label7";
            label7.Size = new Size(790, 30);
            label7.TabIndex = 10;
            label7.Text = "Note: Once selected the file, the process is Automated so it will be executed, make sure to review the file you are about to insert in the File Viewer Tab\r\n\r\n";
            label7.Click += label7_Click;
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
            button7.Location = new Point(597, 167);
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
            pictureBox1.Size = new Size(125, 56);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(606, 1);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(368, 58);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            // 
            // button8
            // 
            button8.Location = new Point(597, 397);
            button8.Name = "button8";
            button8.Size = new Size(250, 43);
            button8.TabIndex = 12;
            button8.Text = "Refresh Database";
            button8.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(212, 349);
            label8.Name = "label8";
            label8.Size = new Size(1076, 45);
            label8.TabIndex = 13;
            label8.Text = resources.GetString("label8.Text");
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            TabView.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TableView).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
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
        private Label viewer;
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
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label14;
        private Label label2;
        private Label label15;
        private ListBox Company_rpvsothers;
        private ListBox Flow_rpvsothers;
        private Label label17;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private Label label16;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Button button9;
        private Button button10;
        private DataGridView dataGridView1;
        private Label label18;
        private ListBox Size_rpvsothers;
        private ListBox Stages_rpvsothers;
        private Label label19;
        private ListBox Company_rpvsmkt;
        private Label label20;
        private Button button11;
        private Button button12;
        private DataGridView dataGridView2;
        private Label label21;
        private ListBox Flow_rpvsmkt;
        private Label label22;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private Label label23;
        private CheckBox checkBox7;
        private CheckBox checkBox8;
        private Label label24;
        private Label label25;
        private ListBox Size_rpvsmkt;
        private ListBox Stages_rpvsmkt;
        private ListBox Head_rpvsothers;
        private Label label26;
        private Label label27;
        private ListBox Head_rpvsmkt;
        private Label label28;
        private ListBox StagesList;
        private Button button8;
        private Label label8;
    }
}
