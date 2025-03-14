using Microsoft.Data.SqlClient;
using Spire.Xls;
using System;
using System.Data;
using CsvHelper;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;
using System.IO;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using Dapper;
using DevExpress.CodeParser;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;

namespace PumpAtlas
{
    public partial class Form1 : Form
    {

        //Database connection information String
        string db_conn = "Server=DC1FP1;Database=FireSystemsDB;TrustServerCertificate=True;User Id=firedb;Password=firedb;";

        public static bool IsKeyEntered = false;
        public static bool selectedFile = false;
        public static bool? SizeIsSelected = null;
        private bool allListsSelected = false;
        private bool allListsSpeedSelected = false;

        SqlDataAdapter adapter;
        DataTable Full_data = new DataTable();
        DataTable Full_data2 = new DataTable();
        DataTable Full_data3 = new DataTable();
        DataTable Full_data4 = new DataTable();
        DataTable dt = new DataTable();

        String fileContent = string.Empty;
        String filelocation;
        String filePath = string.Empty;

        System.Windows.Forms.Timer selectionTimer = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();
            this.Text = "Ruhrpumpen Pump Atlas";
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //this.MaximizeBox = true;

            xtraTabControl2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            xtraTabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            gridControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            gridControl2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            gridControl3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            gridControl4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            gridControl5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            panelControl1.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;

            HeadList.SelectedIndexChanged += HeadList_SelectedIndexChanged;
            HeadList.SelectedIndexChanged += HeadList_speed_SelectedIndexChanged;

            FlowList.SelectedIndexChanged += FlowList_SelectedIndexChanged;
            FlowList.SelectedIndexChanged += FlowList_speed_SelectedIndexChanged;

            CompanyList.SelectedIndexChanged += CompanyList_SelectedIndexChanged;
            CompanyList.SelectedIndexChanged += CompanyList_speed_SelectedIndexChanged;

            SpeedList.SelectedIndexChanged += SpeedList_SelectedIndexChanged;
            SpeedList.SelectedIndexChanged += SpeedList_speed_SelectedIndexChanged;


            selectionTimer.Interval = 1; // 
            selectionTimer.Tick += async (s, e) =>
            {
                selectionTimer.Stop();
                await fill_speeds();
            };

            selectionTimer.Interval = 1; // 
            selectionTimer.Tick += async (s, e) =>
            {
                selectionTimer.Stop();
                await fill_sizes();
            };
        }

        //Function that runs the method to connect to Database when the app starts
        private void Form1_Load(object sender, EventArgs e)
        {
            sql_connect();
        }
        //SQL Server connect test 
        public void sql_connect()
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(db_conn))
                {
                    cnn.Open();
                    conn_db_state.Text = "Connected Successfully to SQL Server Database";
                    fill_selectors();
                }
            }
            catch (SqlException ex)
            {
                conn_db_state.Text = "SQL Server Error: " + ex.Message + " " + ex.StackTrace;
            }
            catch (Exception ex)
            {
                conn_db_state.Text = "Connection Failed: " + ex.Message;
            }

        }
        //Method that fills the Listboxes all across the 3 Tabs of Data Manipulation
        private void fill_selectors()
        {

            using (SqlConnection connection = new SqlConnection(db_conn))
            {
                connection.Open();

                //Company Filler for all 4 Tabs of Data Processing
                String query1 = ("SELECT Company FROM pumps GROUP BY Company ORDER BY Company");
                adapter = new SqlDataAdapter(query1, connection);
                DataTable comp = new DataTable();
                DataTable comp_rpvsothers = new DataTable();
                DataTable comp_rpvsmkt = new DataTable();
                DataTable comp_all = new DataTable();
                adapter.Fill(comp);
                adapter.Fill(comp_rpvsothers);
                adapter.Fill(comp_rpvsmkt);
                adapter.Fill(comp_all);
                //MAP
                CompanyList.DataSource = null;
                CompanyList.DataSource = new BindingSource(comp, null);
                CompanyList.DisplayMember = "Company";
                //RP VS OTHER
                Company_rpvsothers.DataSource = null;
                Company_rpvsothers.DataSource = new BindingSource(comp_rpvsothers, null);
                Company_rpvsothers.DisplayMember = "Company";
                //RP VS MARKET
                Company_rpvsmkt.DataSource = null;
                Company_rpvsmkt.DataSource = new BindingSource(comp_rpvsmkt, null);
                Company_rpvsmkt.DisplayMember = "Company";
                //All Data
                Company_all.DataSource = null;
                Company_all.DataSource = new BindingSource(comp_all, null);
                Company_all.DisplayMember = "Company";

                //Head Filler for all 4 Tabs of Data Processing
                String query2 = ("SELECT Head FROM pumps GROUP BY Head ORDER BY Head");
                adapter = new SqlDataAdapter(query2, connection);
                DataTable head = new DataTable();
                DataTable head_rpvsothers = new DataTable();
                DataTable head_rpvsmkt = new DataTable();
                DataTable head_all = new DataTable();
                adapter.Fill(head);
                adapter.Fill(head_rpvsothers);
                adapter.Fill(head_rpvsmkt);
                adapter.Fill(head_all);
                //MAP
                HeadList.DataSource = null;
                HeadList.DataSource = new BindingSource(head, null);
                HeadList.DisplayMember = "Head";
                //RP VS OTHER
                Head_rpvsothers.DataSource = null;
                Head_rpvsothers.DataSource = new BindingSource(head_rpvsothers, null);
                Head_rpvsothers.DisplayMember = "Head";
                //RP VS MARKET
                Head_rpvsmkt.DataSource = null;
                Head_rpvsmkt.DataSource = new BindingSource(head_rpvsmkt, null);
                Head_rpvsmkt.DisplayMember = "Head";
                //All Data
                Head_all.DataSource = null;
                Head_all.DataSource = new BindingSource(head_all, null);
                Head_all.DisplayMember = "Head";

                //Flow Filler for all 4 Tabs of Data Processing
                String query3 = ("SELECT Flow FROM pumps GROUP BY Flow ORDER BY Flow ASC");
                adapter = new SqlDataAdapter(query3, connection);
                DataTable flow = new DataTable();
                DataTable flow_rpvsothers = new DataTable();
                DataTable flow_rpvsmkt = new DataTable();
                DataTable flow_all = new DataTable();
                adapter.Fill(flow);
                adapter.Fill(flow_rpvsothers);
                adapter.Fill(flow_rpvsmkt);
                adapter.Fill(flow_all);
                //MAP
                FlowList.DataSource = null;
                FlowList.DataSource = new BindingSource(flow, null);
                FlowList.DisplayMember = "Flow";
                //RP VS OTHER
                Flow_rpvsothers.DataSource = null;
                Flow_rpvsothers.DataSource = new BindingSource(flow_rpvsothers, null);
                Flow_rpvsothers.DisplayMember = "Flow";
                //RP VS MARKET
                Flow_rpvsmkt.DataSource = null;
                Flow_rpvsmkt.DataSource = new BindingSource(flow_rpvsmkt, null);
                Flow_rpvsmkt.DisplayMember = "Flow";
                //All Data
                Flow_all.DataSource = null;
                Flow_all.DataSource = new BindingSource(flow_all, null);
                Flow_all.DisplayMember = "Flow";

                //Speed Filler for all 4 Tabs of Data Processing (Only used once in All)
                String query4 = ("SELECT Speed_RPM FROM pumps GROUP BY Speed_RPM ORDER BY Speed_RPM ASC");
                adapter = new SqlDataAdapter(query4, connection);
                DataTable speed_all = new DataTable();
                adapter.Fill(speed_all);
                //All Data
                Speed_all.DataSource = null;
                Speed_all.DataSource = new BindingSource(speed_all, null);
                Speed_all.DisplayMember = "Speed_RPM";

                //Pump Size Filler for all  Tabs of Data Processing (Only used Once in Map)
                String query5 = ("SELECT Pump_Size FROM pumps GROUP BY Pump_Size ORDER BY Pump_Size ASC");
                adapter = new SqlDataAdapter(query5, connection);
                DataTable size_all = new DataTable();
                adapter.Fill(size_all);
                //All Data
                Size_all.DataSource = null;
                Size_all.DataSource = new BindingSource(size_all, null);
                Size_all.DisplayMember = "Pump_Size";

                String tables_Query = ("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'");
                adapter = new SqlDataAdapter(tables_Query, connection);
                DataTable tables = new DataTable();
                adapter.Fill(tables);
                DevExpress.XtraNavBar.NavBarControl navBarControl = new DevExpress.XtraNavBar.NavBarControl();

                //tables.DataSource = null;
            }
        }

        void HeadList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllLists_SelectedIndexChanged(sender, e);
        }

        void FlowList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllLists_SelectedIndexChanged(sender, e);
        }

        void CompanyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllLists_SelectedIndexChanged(sender, e);
        }

        void SpeedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllLists_SelectedIndexChanged(sender, e);
        }

        void HeadList_speed_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllLists_Speed_SelectedIndexChanged(sender, e);
        }

        void FlowList_speed_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllLists_Speed_SelectedIndexChanged(sender, e);
        }

        void CompanyList_speed_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllLists_Speed_SelectedIndexChanged(sender, e);
        }

        void SpeedList_speed_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllLists_Speed_SelectedIndexChanged(sender, e);
        }

        async Task fill_sizes()
        {
            string Heads = string.Join(",", HeadList.SelectedItems.OfType<DataRowView>().Select(item => $"'{item["Head"].ToString()}'"));
            string Flows = string.Join(",", FlowList.SelectedItems.OfType<DataRowView>().Select(item => $"'{item["Flow"].ToString()}'"));
            string Companies = string.Join(",", CompanyList.SelectedItems.OfType<DataRowView>().Select(item => $"'{item["Company"].ToString()}'"));
            string Speeds = string.Join(",", SpeedList.SelectedItems.OfType<DataRowView>().Select(item => $"'{item["Speed_RPM"].ToString()}'"));

            // Asegurar que si la lista está vacía, la condición sea válida
            string CompaniesCondition = string.IsNullOrEmpty(Companies) ? "1=1" : $"Company IN ({Companies})";
            string FlowsCondition = string.IsNullOrEmpty(Flows) ? "1=1" : $"Flow IN ({Flows})";
            string HeadsCondition = string.IsNullOrEmpty(Heads) ? "1=1" : $"Head IN ({Heads})";
            string SpeedsCondition = string.IsNullOrEmpty(Speeds) ? "1=1" : $"Speed_RPM IN ({Speeds})";

            using (SqlConnection connection = new SqlConnection(db_conn))
            {
                await connection.OpenAsync();

                string query = $@"
            SELECT Pump_Size 
            FROM pumps 
            WHERE {CompaniesCondition} 
              AND {FlowsCondition} 
              AND {HeadsCondition} 
              AND {SpeedsCondition}
            GROUP BY Pump_Size 
            ORDER BY Pump_Size ASC";

                string query2 = $@"
            SELECT Speed_RPM
            FROM pumps 
            WHERE {CompaniesCondition} 
              AND {FlowsCondition} 
              AND {HeadsCondition} 
            GROUP BY Speed_RPM
            ORDER BY Speed_RPM ASC";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable size_map = new DataTable();
                    adapter.Fill(size_map);
                    SizeMap.DataSource = null;
                    SizeMap.DataSource = new BindingSource(size_map, null);
                    SizeMap.DisplayMember = "Pump_Size";
                }


            }
        }
        async Task fill_speeds()
        {

            List<string> selectedSpeeds = SpeedList.SelectedItems
                .OfType<DataRowView>()
                .Select(item => item["Speed_RPM"].ToString())
                .ToList();

            string Heads = string.Join(",", HeadList.SelectedItems.OfType<DataRowView>().Select(item => $"'{item["Head"].ToString()}'"));
            string Flows = string.Join(",", FlowList.SelectedItems.OfType<DataRowView>().Select(item => $"'{item["Flow"].ToString()}'"));
            string Companies = string.Join(",", CompanyList.SelectedItems.OfType<DataRowView>().Select(item => $"'{item["Company"].ToString()}'"));

            string CompaniesCondition = string.IsNullOrEmpty(Companies) ? "1=1" : $"Company IN ({Companies})";
            string FlowsCondition = string.IsNullOrEmpty(Flows) ? "1=1" : $"Flow IN ({Flows})";
            string HeadsCondition = string.IsNullOrEmpty(Heads) ? "1=1" : $"Head IN ({Heads})";

            using (SqlConnection connection = new SqlConnection(db_conn))
            {
                await connection.OpenAsync();

                string query2 = $@"
        SELECT DISTINCT Speed_RPM
        FROM pumps 
        WHERE {CompaniesCondition} 
          AND {HeadsCondition} 
          AND {FlowsCondition} 
        ORDER BY Speed_RPM ASC";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query2, connection))
                {
                    DataTable speed_map = new DataTable();
                    adapter.Fill(speed_map);

                    Console.WriteLine($"Speeds Retrieved: {speed_map.Rows.Count}");


                    SpeedList.BeginUpdate();
                    SpeedList.DataSource = null;
                    SpeedList.DataSource = new BindingSource(speed_map, null);
                    SpeedList.DisplayMember = "Speed_RPM";


                    SpeedList.ClearSelected();

                    List<int> indexesToSelect = new List<int>();

                    for (int i = 0; i < SpeedList.Items.Count; i++)
                    {
                        DataRowView item = (DataRowView)SpeedList.Items[i];
                        string speedValue = item["Speed_RPM"].ToString();

                        if (selectedSpeeds.Contains(speedValue))
                        {
                            indexesToSelect.Add(i);
                        }
                    }

                    // ✅ Apply selection safely
                    foreach (int index in indexesToSelect)
                    {
                        SpeedList.SetSelected(index, true);
                    }

                    SpeedList.EndUpdate();
                }
            }
        }
        async void AllLists_Speed_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool allListsSelected = (HeadList.SelectedItems.Count > 0) &&
                                    (FlowList.SelectedItems.Count > 0) &&
                                    (CompanyList.SelectedItems.Count > 0);

            if (allListsSelected)
            {
                selectionTimer.Stop();
                selectionTimer.Start();
            }
            else
            {
                SpeedList.DataSource = null;
            }
        }
        async void AllLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool allListsSelected = (HeadList.SelectedItems.Count > 0) &&
                                    (FlowList.SelectedItems.Count > 0) &&
                                    (CompanyList.SelectedItems.Count > 0) &&
                                    (SpeedList.SelectedItems.Count > 0);

            if (allListsSelected)
            {
                selectionTimer.Stop();
                selectionTimer.Start();
            }
            else
            {
                SizeMap.DataSource = null;
            }
        }

        public async void Big_query()
        {
            try
            {
                // Construcción de filtros SQL
                string Heads = string.Join(",", HeadList.SelectedItems.Cast<DataRowView>().Select(item => $"'{item["Head"].ToString()}'"));
                string Flows = string.Join(",", FlowList.SelectedItems.Cast<DataRowView>().Select(item => $"'{item["Flow"].ToString()}'"));
                string Companies = string.Join(",", CompanyList.SelectedItems.Cast<DataRowView>().Select(item => $"'{item["Company"].ToString()}'"));
                string Speeds = string.Join(",", SpeedList.SelectedItems.Cast<DataRowView>().Select(item => $"'{item["Speed_RPM"].ToString()}'"));
                string Sizes = string.Join(",", SizeMap.SelectedItems.Cast<DataRowView>().Select(item => $"'{item["Pump_Size"].ToString()}'"));

                // Condiciones dinámicas
                string CompaniesCondition = string.IsNullOrEmpty(Companies) ? "1=1" : $"Company IN ({Companies})";
                string FlowsCondition = string.IsNullOrEmpty(Flows) ? "1=1" : $"Flow IN ({Flows})";
                string HeadsCondition = string.IsNullOrEmpty(Heads) ? "1=1" : $"Head IN ({Heads})";
                string SpeedsCondition = string.IsNullOrEmpty(Speeds) ? "1=1" : $"Speed_RPM IN ({Speeds})";
                string SizesCondition = string.IsNullOrEmpty(Sizes) ? "1=1" : $"Pump_Size IN ({Sizes})";

                // Construcción dinámica de las columnas
                string dynamicColumnsQuery = $@"
            SELECT DISTINCT
                REPLACE(CONCAT(Company, CHAR(13) + CHAR(10), Pump_Size, CHAR(13) + CHAR(10), Flow, CHAR(13) + CHAR(10), Speed_RPM), '\n', CHAR(13) + CHAR(10)) AS ColumnName
            FROM pumps
            WHERE {CompaniesCondition} AND {FlowsCondition} AND {HeadsCondition} AND {SpeedsCondition} AND {SizesCondition}";

                List<string> dynamicColumns = new List<string>();
                using (var connection = new SqlConnection(db_conn))
                {
                    connection.Open();
                    using (var command = new SqlCommand(dynamicColumnsQuery, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dynamicColumns.Add(reader["ColumnName"].ToString());
                        }
                    }
                }

                string caseStatements = string.Join(",\n", dynamicColumns.Select(col => $@"
            MIN(CASE WHEN REPLACE(CONCAT(Company, CHAR(13) + CHAR(10), Pump_Size, CHAR(13) + CHAR(10), Flow, CHAR(13) + CHAR(10), Speed_RPM), '\n', CHAR(13) + CHAR(10)) = '{col.Replace("'", "''")}' THEN BHP END) AS [{col}]"));

                string caseStatementsBestPrice = string.Join(",\n", dynamicColumns.Select(col => $@"
            MIN(CASE WHEN REPLACE(CONCAT(Company, CHAR(13) + CHAR(10), Pump_Size, CHAR(13) + CHAR(10), Flow, CHAR(13) + CHAR(10), Speed_RPM), '\n', CHAR(13) + CHAR(10)) = '{col.Replace("'", "''")}' 
                 THEN Best_Price 
            END) AS [Best_{col}]")
        );


                string Bigquery = $@"
            SELECT 
                Head,
                STUFF((
                    SELECT CHAR(13) + CHAR(10) + CONCAT(Company, CHAR(13) + CHAR(10), Flow, CHAR(13) + CHAR(10), Speed_RPM, CHAR(13) + CHAR(10), Pump_Size)
                    FROM pumps AS p
                    WHERE p.Head = p1.Head
                    AND {CompaniesCondition}
                    AND {FlowsCondition}
                    AND {HeadsCondition}
                    AND {SpeedsCondition}
                    AND {SizesCondition}
                    FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS CompanyFlow,
                {caseStatements},{caseStatementsBestPrice}
            FROM pumps AS p1
            WHERE {CompaniesCondition} 
              AND {FlowsCondition} 
              AND {HeadsCondition} 
              AND {SpeedsCondition} 
              AND {SizesCondition}
            GROUP BY Head
            ORDER BY Head";

                DataTable fullData = await Task.Run(() =>
                {
                    DataTable dataTable = new DataTable();
                    using (var connection = new SqlConnection(db_conn))
                    {
                        connection.Open();
                        using (var adapter = new SqlDataAdapter(Bigquery, connection))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                    return dataTable;
                });

                // Configurar el grid con los datos obtenidos
                gridControl1.DataSource = fullData;
                gridView1.OptionsView.ShowGroupPanel = false;
                gridView1.PopulateColumns();
                gridView1.OptionsView.ColumnAutoWidth = false;
                gridView1.BestFitColumns();
                gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView1.ColumnPanelRowHeight = 70;
                GridColumn zeroColumn = gridView1.Columns[0];
                zeroColumn.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

                hide_unused_columns();
                hide_price_columns();

                GridColumn firstColumn = gridView1.Columns[1];
                firstColumn.Visible = false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error: {ex.Message}");
            }
        }



        private void hide_unused_columns()
        {
            for (int j = gridView1.Columns.Count - 1; j >= 0; j--)
            {
                GridColumn column = gridView1.Columns[j];
                bool allCellsEmpty = true;

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    object cellValue = gridView1.GetRowCellValue(i, column);

                    if (cellValue != null && !string.IsNullOrWhiteSpace(cellValue.ToString()))
                    {
                        allCellsEmpty = false;
                        break;
                    }
                }

                column.Visible = !allCellsEmpty;
            }
        }

        private void hide_price_columns()
        {
            for (int j = gridView1.Columns.Count - 1; j >= 0; j--)
            {
                GridColumn column = gridView1.Columns[j];
                string lookfor = "Best";

                if (column.FieldName.Contains(lookfor) || column.Caption.Contains(lookfor))
                {
                    column.Visible = false; 
                }
            }

        }
        //Query that retrieves Data for the RP vs Others Tab
        private async void big_query2()
        {
            string Companies = string.Join("','", Company_rpvsothers.SelectedItems.Cast<DataRowView>().Select(item => item["Company"].ToString()));
            string Flows = string.Join("','", Flow_rpvsothers.SelectedItems.Cast<DataRowView>().Select(item => item["Flow"].ToString()));
            string Heads = string.Join("','", Head_rpvsothers.SelectedItems.Cast<DataRowView>().Select(item => item["Head"].ToString()));

            string CompaniesCondition = string.IsNullOrEmpty(Companies) ? "1=1" : $"Company IN ('{Companies}')";
            string FlowsCondition = string.IsNullOrEmpty(Flows) ? "1=1" : $"Flow IN ('{Flows}')";
            string HeadsCondition = string.IsNullOrEmpty(Heads) ? "1=1" : $"Head IN ('{Heads}')";

            try
            {
                // Construcción dinámica de las columnas
                string dynamicColumnsQuery = $@"
        SELECT DISTINCT
            CONCAT(Company, CHAR(13) + CHAR(10), Flow, CHAR(13) + CHAR(10)) AS ColumnName
        FROM pumps
        WHERE {CompaniesCondition} AND {FlowsCondition} AND {HeadsCondition}";

                List<string> dynamicColumns = new List<string>();
                using (var connection = new SqlConnection(db_conn))
                {
                    connection.Open();
                    using (var command = new SqlCommand(dynamicColumnsQuery, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dynamicColumns.Add(reader["ColumnName"].ToString());
                        }
                    }
                }

                string caseStatements = string.Join(",\n", dynamicColumns.Select(col => $@"
        MIN(CASE 
            WHEN CONCAT(Company, CHAR(13) + CHAR(10), Flow, CHAR(13) + CHAR(10)) = '{col.Replace("'", "''")}' 
            THEN BHP 
        END) AS [{col}]")
                );

                string Bigquery = $@"
        SELECT 
            Head,
            STUFF((
                SELECT CHAR(13) + CHAR(10) + CONCAT(Company, CHAR(13) + CHAR(10), Flow, CHAR(13) + CHAR(10))
                FROM pumps AS p
                WHERE p.Head = p1.Head
                AND {CompaniesCondition}
                AND {FlowsCondition}
                AND {HeadsCondition}
                FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS CompanyFlow,
            {caseStatements}
        FROM pumps AS p1
        WHERE {CompaniesCondition} 
          AND {FlowsCondition} 
          AND {HeadsCondition}
        GROUP BY Head
        ORDER BY Head";


                DataTable fullData2 = await Task.Run(() =>
                {
                    DataTable dataTable2 = new DataTable();
                    using (var connection = new SqlConnection(db_conn))
                    {
                        connection.Open();
                        using (var adapter = new SqlDataAdapter(Bigquery, connection))
                        {
                            adapter.Fill(dataTable2);
                        }
                    }
                    return dataTable2;
                });

                gridControl2.DataSource = fullData2;
                gridView2.OptionsView.ShowGroupPanel = false;
                gridView2.GroupPanelText = "";
                gridView2.PopulateColumns();
                gridView2.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
                gridView2.BestFitColumns();
                gridView2.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                gridView2.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                GridColumn zeroColumn = gridView2.Columns[0];
                zeroColumn.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

                GridColumn firstColumn = gridView2.Columns[1];
                firstColumn.Visible = false;

                hide_unused_columns();


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error: {ex.Message}");
            }
        }
        //Query that retrieves Data for the RP vs Market Tab
        private async void big_query3()
        {
            string Companies = string.Join("','", Company_rpvsmkt.SelectedItems.Cast<DataRowView>().Select(item => item["Company"].ToString()));
            string Flows = string.Join("','", Flow_rpvsmkt.SelectedItems.Cast<DataRowView>().Select(item => item["Flow"].ToString()));
            string Heads = string.Join("','", Head_rpvsmkt.SelectedItems.Cast<DataRowView>().Select(item => item["Head"].ToString()));


            string CompaniesCondition = string.IsNullOrEmpty(Companies) ? "1=1" : $"Company IN ('{Companies}')";
            string FlowsCondition = string.IsNullOrEmpty(Flows) ? "1=1" : $"Flow IN ('{Flows}')";
            string HeadsCondition = string.IsNullOrEmpty(Heads) ? "1=1" : $"Head IN ('{Heads}')";

            try
            {
                string dynamicColumnsQuery = $@"
        SELECT DISTINCT
            CONCAT(Company, CHAR(13) + CHAR(10), Flow, CHAR(13) + CHAR(10)) AS ColumnName
        FROM pumps
        WHERE {CompaniesCondition} AND {FlowsCondition} AND {HeadsCondition}";

                List<string> dynamicColumns = new List<string>();
                using (var connection = new SqlConnection(db_conn))
                {
                    connection.Open();
                    using (var command = new SqlCommand(dynamicColumnsQuery, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dynamicColumns.Add(reader["ColumnName"].ToString());
                        }
                    }
                }


                string caseStatements = string.Join(",\n", dynamicColumns.Select(col => $@"
        MIN(CASE 
            WHEN CONCAT(Company, CHAR(13) + CHAR(10), Flow, CHAR(13) + CHAR(10)) = '{col.Replace("'", "''")}' 
            THEN BHP 
        END) AS [{col}]")
);

                string Bigquery = $@"
    SELECT 
        Head,
        STUFF((
            SELECT CHAR(13) + CHAR(10) + CONCAT(Company, CHAR(13) + CHAR(10), Flow)
            FROM pumps p2
            WHERE p2.Head = p.Head
            AND {CompaniesCondition}
            AND {FlowsCondition}
            AND {HeadsCondition}
            ORDER BY Company, Flow
            FOR XML PATH('')
        ), 1, 1, '') AS CompanyFlow,
        {caseStatements}
    FROM 
        pumps p
    WHERE 
        {CompaniesCondition}
        AND {FlowsCondition}
        AND {HeadsCondition}
    GROUP BY 
        Head
    ORDER BY 
        Head";

                DataTable fullData3 = await Task.Run(() =>
                {
                    DataTable dataTable3 = new DataTable();
                    using (var connection = new SqlConnection(db_conn))
                    {
                        connection.Open();
                        using (var adapter = new SqlDataAdapter(Bigquery, connection))
                        {
                            adapter.Fill(dataTable3);
                        }
                    }
                    return dataTable3;
                });

                gridControl3.DataSource = fullData3;
                gridView3.OptionsView.ShowGroupPanel = false;
                gridView3.GroupPanelText = "";
                gridView3.PopulateColumns();
                gridView3.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
                gridView3.BestFitColumns();
                gridView3.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                gridView3.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView3.ColumnPanelRowHeight = 70;
                gridView3.OptionsView.ColumnAutoWidth = true;
                foreach (GridColumn column in gridView3.Columns)
                {
                    column.BestFit();
                    column.Width = 100; // Ajusta el ancho según necesites
                }


                GridColumn zeroColumn = gridView3.Columns[0];
                zeroColumn.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

                hide_unused_columns();

                GridColumn firstColumn = gridView3.Columns[1];
                firstColumn.Visible = false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error: {ex.Message}");
            }

        }
        //Query that retrieves Data for the All Data Tab
        private async void big_query4()
        {

            string Companies = string.Join("','", Company_all.SelectedItems.Cast<DataRowView>().Select(item => item["Company"].ToString()));
            string Flows = string.Join("','", Flow_all.SelectedItems.Cast<DataRowView>().Select(item => item["Flow"].ToString()));
            string Heads = string.Join("','", Head_all.SelectedItems.Cast<DataRowView>().Select(item => item["Head"].ToString()));
            string Speeds = string.Join("','", Speed_all.SelectedItems.Cast<DataRowView>().Select(item => item["Speed_RPM"].ToString()));
            string Sizes = string.Join("','", Size_all.SelectedItems.Cast<DataRowView>().Select(item => item["Pump_Size"].ToString()));


            string CompaniesCondition = string.IsNullOrEmpty(Companies) ? "1=1" : $"Company IN ('{Companies}')";
            string FlowsCondition = string.IsNullOrEmpty(Flows) ? "1=1" : $"Flow IN ({Flows})";  // Flows puede ser num�rico, no necesitas comillas
            string HeadsCondition = string.IsNullOrEmpty(Heads) ? "1=1" : $"Head IN ({Heads})";  // Similar para Heads, tambi�n num�rico
            string SpeedsCondition = string.IsNullOrEmpty(Speeds) ? "1=1" : $"Speed_RPM IN ({Speeds})";  // Speeds tambi�n es num�rico
            string SizesCondition = string.IsNullOrEmpty(Sizes) ? "1=1" : $"Pump_Size IN ('{Sizes}')";

            try
            {
                string Bigquery = $@"
        SELECT 
        *
        FROM pumps
        WHERE {CompaniesCondition}
        AND {FlowsCondition}
        AND {HeadsCondition}
        AND {SpeedsCondition}
        AND {SizesCondition};";

                DataTable fullData4 = await Task.Run(() =>
                {
                    DataTable dataTable4 = new DataTable();
                    using (var connection = new SqlConnection(db_conn))
                    {
                        connection.Open();
                        using (var adapter = new SqlDataAdapter(Bigquery, connection))
                        {
                            adapter.Fill(dataTable4);
                        }
                    }
                    return dataTable4;
                });

                gridControl4.DataSource = fullData4;
                gridView4.OptionsView.ShowGroupPanel = false;
                gridView4.GroupPanelText = "";
                gridView4.PopulateColumns();
                gridView1.OptionsView.ColumnAutoWidth = true;
                gridView4.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;

                // Ajustar el ancho de las columnas automáticamente considerando los encabezados
                gridView4.BestFitColumns();

                // Ajustar cada columna individualmente para que su ancho se adapte al encabezado y al contenido
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridView4.Columns)
                {
                    column.BestFit(); // Ajusta la columna al contenido y al encabezado
                    column.OptionsColumn.FixedWidth = false; // Permite redimensionamiento manual
                }

                // Asegurar que los nombres largos de las columnas se muestren completamente
                gridView4.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                gridView4.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView4.ColumnPanelRowHeight = 70;


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error: {ex.Message}");
            }
        }
        //Function that clears pivot table on Server side to allow new data go through and be optimized
        private void transform_data()
        {

            using (SqlConnection connection = new SqlConnection(db_conn))
            {
                connection.Open();
                String delete_statement = "EXEC UpdateData";
                SqlCommand cmd = new SqlCommand(delete_statement, connection);
                SqlDataReader runenr = cmd.ExecuteReader();
            }
        }
        //method that clears listboxes in map tab
        private void clear_filter_map()
        {
            CompanyList.ClearSelected();
            FlowList.ClearSelected();
            HeadList.ClearSelected();
            SpeedList.ClearSelected();
            SizeMap.ClearSelected();
        }
        //method that clears listboxes in rp vs others tab
        private void clear_filter_rpvsothers()
        {
            Company_rpvsothers.ClearSelected();
            Flow_rpvsothers.ClearSelected();
            Head_rpvsothers.ClearSelected();
        }
        //method that clears listboxes in rp vs market tab
        private void clear_filter_rpvsmkt()
        {
            Company_rpvsmkt.ClearSelected();
            Flow_rpvsmkt.ClearSelected();
            Head_rpvsmkt.ClearSelected();
        }
        //method that clears listboxes in all data tab
        private void clear_filter_all_data()
        {
            Company_all.ClearSelected();
            Flow_all.ClearSelected();
            Head_all.ClearSelected();
            Size_all.ClearSelected();
            Speed_all.ClearSelected();
        }
        //Method that opens File explorer and allows to select an Excel File
        private void open_excel()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\Downloads";
                openFileDialog.Filter = "Excel Files (*.xlsx,*.xlsm)|*.xlsx;*.xlsm";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    filePath = openFileDialog.FileName;
                    String name_of_file = Path.GetFileName(filePath);

                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        Excel_file_tag.Text = name_of_file;
                    }
                }
            }
        }
        //function that call method to open an excel file for CSV conversor
        private void button1_Click(object sender, EventArgs e)
        {
            open_excel();
        }
        //function Saves converted file as CSV after conversion
        private void save_file()
        {
            SaveFileDialog save_as = new SaveFileDialog();
            save_as.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            save_as.Title = "Save Converted File As";
            save_as.CheckFileExists = false;
            save_as.CheckPathExists = true;
            save_as.DefaultExt = "csv";
            save_as.Filter = "CSV files (*.csv)|*.csv";
            save_as.FilterIndex = 1;
            save_as.RestoreDirectory = true;

            String saved_name = FileNameBox.Text;
            save_as.FileName = saved_name + ".csv";
            String head = conv_state.Text;

            if (save_as.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Workbook WB = new Workbook();
                    WB.LoadFromFile(filePath);
                    Worksheet sheet = WB.Worksheets[0];

                    // Save to the selected file path
                    sheet.SaveToFile(save_as.FileName, ",");
                    conv_state.Text = head + "Success";

                    if (conv_state.Text.Contains("Success") || conv_state.Text.Contains("Failure: "))
                    {
                        FileNameBox.Text = String.Empty;
                        filePath = String.Empty;
                        Excel_file_tag.Text = String.Empty;
                    }

                }
                catch (Exception ex)
                {
                    conv_state.Text = head + "Failure: " + ex.Message;
                }

            }
            else
            {
                conv_state.Text = head + "Operation cancelled";
                FileNameBox = null;
                save_as = null;
            }
        }
        //Method that calls function function Saves converted file as CSV after conversion
        private void button2_Click(object sender, EventArgs e)
        {
            save_file();
        }
        //Method that reads CSV data and places it on a Datagrid 
        private void visor()
        {
            string start = csv_label.Text;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\Downloads";
                openFileDialog.Title = "Select CSV to View its Content";
                openFileDialog.Filter = "CSV files (*.csv)|*.csv";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    try
                    {
                        using (var reader = new StreamReader(filePath))
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {
                            using (var dr = new CsvDataReader(csv))
                            {
                                var dt = new DataTable();
                                dt.Load(dr);
                                gridControl5.DataSource = dt;
                                this.gridView5.OptionsView.ShowGroupPanel = false;
                                string start_ok = "Now Viewing";
                                viewer.Text = start_ok;
                                csv_label.Text = start + Path.GetFileName(filePath);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Error reading CSV file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    string start_fail = "No File Selected";
                    viewer.Text = start_fail;
                }
            }
        }
        //Clears the Datagrid and closes open CSV to be able to review a new one 
        public void clear_visor()
        {
            gridView5.Columns.Clear();
            gridControl5.DataSource = null;
            gridControl5.Refresh();
            gridControl5.DataContext = null;
            csv_label.Text = String.Empty;
            string start_fail = "No File Selected";
            viewer.Text = start_fail;
        }
        //Button that has method to read CSV 
        private void button4_Click(object sender, EventArgs e)
        {
            visor();
        }
        //Button that has method assigned to clear visor
        private void button5_Click(object sender, EventArgs e)
        {
            clear_visor();
        }
        //Async function that inserts a file to the Database
        public async void select_file_to_insert_to_database()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\Downloads";
                openFileDialog.Title = "Select a CSV to Insert onto Database";
                openFileDialog.Filter = "CSV files (*.csv)|*.csv";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    sel_insert_label.Text = Path.GetFileName(filePath);

                    try
                    {
                        insert_state.Text = "Performing Insertion, Hold on while we Insert the Data";

                        await Task.Run(async () =>
                        {
                            try
                            {
                                using (var connection = new SqlConnection(db_conn))
                                {
                                    connection.Open();

                                    DataTable dt = new DataTable();
                                    dt.Columns.Add("Company", typeof(string));
                                    dt.Columns.Add("Pump_Line", typeof(string));
                                    dt.Columns.Add("Flow", typeof(int));
                                    dt.Columns.Add("Head", typeof(int));
                                    dt.Columns.Add("Speed_RPM", typeof(int));
                                    dt.Columns.Add("BHP", typeof(int));
                                    dt.Columns.Add("Model", typeof(string));
                                    dt.Columns.Add("Line", typeof(string));
                                    dt.Columns.Add("Stages", typeof(int));
                                    dt.Columns.Add("Pump_Size", typeof(string));
                                    dt.Columns.Add("Pump_RPM", typeof(int));
                                    dt.Columns.Add("Kirloskar", typeof(string));
                                    dt.Columns.Add("Clarke", typeof(string));
                                    dt.Columns.Add("Rated_Head", typeof(int));
                                    dt.Columns.Add("K_R_RPM", typeof(string));
                                    dt.Columns.Add("C_R_RPM", typeof(string));
                                    dt.Columns.Add("Kirloskar_Price", typeof(decimal));
                                    dt.Columns.Add("Clarke_Price", typeof(decimal));
                                    dt.Columns.Add("Best_Price", typeof(decimal));
                                    dt.Columns.Add("CFH", typeof(string));
                                    dt.Columns.Add("FH", typeof(string));
                                    dt.Columns.Add("FHP", typeof(string));
                                    dt.Columns.Add("CFHS_Class", typeof(decimal));
                                    dt.Columns.Add("FH_Class", typeof(decimal));
                                    dt.Columns.Add("KFH_Class", typeof(decimal));
                                    dt.Columns.Add("CLFH_Class", typeof(decimal));
                                    dt.Columns.Add("BHP_FH_Class", typeof(decimal));
                                    dt.Columns.Add("Best_Selection", typeof(string));
                                    dt.Columns.Add("Best_Company", typeof(string));
                                    dt.Columns.Add("Best_Motor", typeof(string));
                                    dt.Columns.Add("Best_Clarke", typeof(string));
                                    dt.Columns.Add("Best_Kirloskar", typeof(string));
                                    dt.Columns.Add("Comp_Size_RPM", typeof(string));

                                    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                                    {
                                        HasHeaderRecord = false,
                                        Delimiter = ",",
                                        IgnoreBlankLines = true,
                                        TrimOptions = TrimOptions.Trim,
                                        BadDataFound = null,
                                        Mode = CsvMode.RFC4180,
                                        AllowComments = true,
                                        Quote = '"',
                                        ShouldQuote = args => true,
                                        MissingFieldFound = null
                                    };

                                    using (var reader = new StreamReader(filePath))
                                    using (var csv = new CsvReader(reader, csvConfig))
                                    {
                                        csv.Read();

                                        while (await csv.ReadAsync())
                                        {
                                            DataRow row = dt.NewRow();
                                            row["Company"] = csv.GetField(0);
                                            row["Pump_Line"] = csv.GetField(1);
                                            row["Flow"] = csv.GetField<int>(2);
                                            row["Head"] = csv.GetField<int>(3);
                                            row["Speed_RPM"] = csv.GetField<int>(4);
                                            row["BHP"] = csv.GetField<int>(5);
                                            row["Model"] = csv.GetField(6);
                                            row["Line"] = csv.GetField(7);
                                            row["Stages"] = csv.GetField<int>(8);
                                            row["Pump_Size"] = csv.GetField(9);
                                            row["Pump_RPM"] = csv.GetField<int>(10);
                                            row["Kirloskar"] = csv.GetField(11);
                                            row["Clarke"] = csv.GetField(12);
                                            row["Rated_Head"] = csv.GetField<int>(13);
                                            row["K_R_RPM"] = csv.GetField(14);
                                            row["C_R_RPM"] = csv.GetField(15);
                                            row["Kirloskar_Price"] = csv.GetField<decimal>(16);
                                            row["Clarke_Price"] = csv.GetField<decimal>(17);
                                            row["Best_Price"] = csv.GetField<decimal>(18);
                                            row["CFH"] = csv.GetField(19);
                                            row["FH"] = csv.GetField(20);
                                            row["FHP"] = csv.GetField(21);
                                            row["CFHS_Class"] = csv.GetField<decimal>(22);
                                            row["FH_Class"] = csv.GetField<decimal>(23);
                                            row["KFH_Class"] = csv.GetField<decimal>(24);
                                            row["CLFH_Class"] = csv.GetField<decimal>(25);
                                            row["BHP_FH_Class"] = csv.GetField<decimal>(26);
                                            row["Best_Selection"] = csv.GetField(27);
                                            row["Best_Company"] = csv.GetField(28);
                                            row["Best_Motor"] = csv.GetField(29);
                                            row["Best_Clarke"] = csv.GetField(30);
                                            row["Best_Kirloskar"] = csv.GetField(31);
                                            row["Comp_Size_RPM"] = csv.GetField(32);

                                            dt.Rows.Add(row);
                                        }
                                    }

                                    using (var bulkCopy = new SqlBulkCopy(connection))
                                    {
                                        bulkCopy.DestinationTableName = "pumps";
                                        try
                                        {
                                            await bulkCopy.WriteToServerAsync(dt);

                                            this.Invoke(new Action(() =>
                                            {
                                                insert_state.Text = "Data inserted successfully";
                                                transform_data();
                                                refresh_db();
                                                fill_selectors();
                                            }));
                                        }
                                        catch (Exception ex)
                                        {
                                            string errorMessage = string.Empty;
                                            if (ex.Message.Contains("Received an invalid column length from the bcp client for colid"))
                                            {
                                                errorMessage = GetBulkCopyColumnException(ex, bulkCopy);
                                                this.Invoke(new Action(() =>
                                                {
                                                    insert_state.Text = $"Error en columna: {errorMessage}";
                                                }));
                                            }
                                            else
                                            {
                                                this.Invoke(new Action(() =>
                                                {
                                                    insert_state.Text = $"Error en la inserción: {ex.Message}";
                                                }));
                                            }
                                        }
                                    }

                                    await Task.Delay(6000);
                                    this.Invoke(new Action(() =>
                                    {
                                        insert_state.Text = string.Empty;
                                        sel_insert_label.Text = string.Empty;
                                    }));
                                }
                            }
                            catch (Exception ex)
                            {
                                this.Invoke(new Action(() =>
                                {
                                    insert_state.Text = $"An error occurred: {ex.Message}";
                                }));

                                await Task.Delay(6000);
                                this.Invoke(new Action(() =>
                                {
                                    insert_state.Text = string.Empty;
                                    sel_insert_label.Text = string.Empty;
                                }));
                            }
                        });
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Error reading CSV file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    sel_insert_label.Text = "No File Selected";
                }
            }
        }

        private string GetBulkCopyColumnException(Exception ex, SqlBulkCopy bulkcopy)
        {
            string message = string.Empty;
            if (ex.Message.Contains("Received an invalid column length from the bcp client for colid"))
            {
                string pattern = @"\d+";
                Match match = Regex.Match(ex.Message.ToString(), pattern);
                var index = Convert.ToInt32(match.Value) - 1;

                FieldInfo fi = typeof(SqlBulkCopy).GetField("_sortedColumnMappings", BindingFlags.NonPublic | BindingFlags.Instance);
                var sortedColumns = fi.GetValue(bulkcopy);
                var items = (Object[])sortedColumns.GetType().GetField("_items", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(sortedColumns);

                FieldInfo itemdata = items[index].GetType().GetField("_metadata", BindingFlags.NonPublic | BindingFlags.Instance);
                var metadata = itemdata.GetValue(items[index]);
                var column = metadata.GetType().GetField("column", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(metadata);
                var length = metadata.GetType().GetField("length", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(metadata);
                message = (String.Format("Column: {0} contains data with a length greater than: {1}", column, length));
            }
            return message;
        }
        //Button that calls method to insert data in Database from Data management tab
        private void button7_Click(object sender, EventArgs e)
        {
            if (!IsKeyEntered)
            {
                Form2 form2 = new Form2(this);
                form2.ShowDialog();

                if (form2.Accessed)
                {
                    IsKeyEntered = true;
                    select_file_to_insert_to_database();
                }
            }
            else
            {
                select_file_to_insert_to_database();
            }
        }
        //refreshes all the selectors across the software
        private void refresh_db()
        {
            CompanyList.DataSource = null;
            HeadList.DataSource = null;
            SpeedList.DataSource = null;
            FlowList.DataSource = null;

            Company_rpvsothers.DataSource = null;
            Head_rpvsothers.DataSource = null;
            Flow_rpvsothers.DataSource = null;

            Company_rpvsmkt.DataSource = null;
            Head_rpvsmkt.DataSource = null;
            Flow_rpvsmkt.DataSource = null;

            Company_all.DataSource = null;
            Size_all.DataSource = null;
            Head_all.DataSource = null;
            Speed_all.DataSource = null;
            Flow_all.DataSource = null;

            fill_selectors();
        }
        //Clears map datagrid
        private void clear_results_map()
        {
            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            Full_data.Clear();
        }
        //Clears rp vs others datagrid
        private void clear_results_rpvsothers()
        {
            gridControl2.DataSource = null;
            gridView2.Columns.Clear();
            Full_data2.Clear();
        }
        //clears rp vs market datagrid
        private void clear_results_rpvsmkt()
        {
            gridControl3.DataSource = null;
            gridView3.Columns.Clear();
            Full_data3.Clear();
        }
        //clears all data datagrid
        private void clear_results_all_data()
        {
            gridControl4.DataSource = null;
            gridView4.Columns.Clear();
            Full_data4.Clear();
        }
        //Method that Clears grid result on MAP tab
        private void Clear_select_Click(object sender, EventArgs e)
        {
            clear_filter_map();
        }
        //Method that Clears grid result on RP VS OTHERS tab
        private void button10_Click(object sender, EventArgs e)
        {
            clear_results_rpvsothers();
        }
        //Method that Clears grid result on RP VS MKT tab
        private void button12_Click(object sender, EventArgs e)
        {
            clear_results_rpvsmkt();
        }
        //Method that Clears grid result on All Data Tab
        private void button13_Click(object sender, EventArgs e)
        {
            clear_results_all_data();
        }
        //Button linked to connect to Database method in Data Management Tab
        private void button6_Click(object sender, EventArgs e)
        {
            sql_connect();
        }
        //Buttons that are linked to methods that execute query on each tab
        private void button3_Click(object sender, EventArgs e)
        {
            Big_query();
        }
        //button that fetches result from database for rp vs others tab
        private void button9_Click(object sender, EventArgs e)
        {
            big_query2();
        }
        //button that fetches result from database for rp vs market tab 
        private void button11_Click(object sender, EventArgs e)
        {
            big_query3();
        }
        //method that clears selected info in selectors of all data tab
        private void button17_Click(object sender, EventArgs e)
        {
            clear_filter_all_data();
        }
        //button that fetches result from database for all data tab 
        private void button14_Click(object sender, EventArgs e)
        {
            big_query4();
        }
        //function that calls method to clear datagrid on map tab
        private void button15_Click(object sender, EventArgs e)
        {
            clear_results_map();
        }
        //function that calls method to clear datagrid on rp vs others tab
        private void button16_Click(object sender, EventArgs e)
        {
            clear_filter_rpvsothers();
        }
        //function that calls method to clear datagrid on rp vs market tab
        private void button18_Click(object sender, EventArgs e)
        {
            clear_filter_rpvsmkt();
        }
        //button that call the method that refreshes database 
        private void button8_Click(object sender, EventArgs e)
        {
            refresh_db();
        }
        //process that will open the link
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://ruhrpumpen.sharepoint.com/:x:/r/sites/RPFS-InsideSales/Shared%20Documents/Product%20Engineer/PRODUCT%20ENGINEER%20LUIS%20DAVILA/PRACTICANTES/AITOR%20CERECERO/Data%20Insertion%20Template.xlsx?d=w6be1803de5154790a8fe1b5e71a95549&csf=1&web=1&e=qN8q1l") { UseShellExecute = true });
        }

    }
}