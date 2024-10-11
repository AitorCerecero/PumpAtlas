using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using Spire.Xls;
using System.Data;
using System.Text;
using CsvHelper;
using System.Globalization;
using System.Timers;
using System.Windows;
using System.Windows.Forms;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CsvHelper.Configuration;
using System.Threading;

namespace PumpAtlas

{
    public partial class Form1 : Form
    {

        private System.Timers.Timer timer;
        //Database connection information String
        string db_conn = "server=localhost;database=rp;uid=root;pwd=FireSystems25;";

        MySqlDataAdapter adapter;
        DataTable Full_data = new DataTable();
        DataTable Full_data2 = new DataTable();
        DataTable Full_data3 = new DataTable();
        DataTable Full_data4 = new DataTable();
        DataTable dt = new DataTable();

        String fileContent = string.Empty;
        String filePath = string.Empty;


        public Form1()
        {
            InitializeComponent();
            this.Text = "Ruhrpumpen Pump Atlas";
        }

        //Method that runs the method to connect to Database
        private void Form1_Load(object sender, EventArgs e)
        {
            db_connect();
        }

        //Method that established a connection between program and a MySQL Database
        public void db_connect()
        {
            try
            {
                MySqlConnection cnn = new MySqlConnection(db_conn);
                conn_db_state.Text = "Connected Successfully to Database";
                fill_selectors();
            }
            catch (Exception)
            {
                conn_db_state.Text = "Something Went Wrong";
            }
        }

        //Method that fills the Listboxes all across the 3 Tabs of Data Manipulation
        private void fill_selectors()
        {

            using (MySqlConnection connection = new MySqlConnection(db_conn))
            {
                connection.Open();

                //Company Filler for all 4 Tabs of Data Processing
                String query1 = ("SELECT Company FROM pumps GROUP BY Company");
                adapter = new MySqlDataAdapter(query1, connection);
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
                adapter = new MySqlDataAdapter(query2, connection);
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
                adapter = new MySqlDataAdapter(query3, connection);
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

                //Speed Filler for all 4 Tabs of Data Processing (Only used twice)
                String query4 = ("SELECT Pump_Speed_in_RPM FROM pumps GROUP BY Pump_Speed_in_RPM ORDER BY Pump_Speed_in_RPM ASC");
                adapter = new MySqlDataAdapter(query4, connection);
                DataTable speed = new DataTable();
                DataTable speed_all = new DataTable();
                adapter.Fill(speed);
                adapter.Fill(speed_all);
                SpeedList.DataSource = null;
                SpeedList.DataSource = new BindingSource(speed, null);
                SpeedList.DisplayMember = "Pump_Speed_in_RPM";
                //All Data
                Speed_all.DataSource = null;
                Speed_all.DataSource = new BindingSource(speed_all, null);
                Speed_all.DisplayMember = "Pump_Speed_in_RPM";

                //Pump Size Filler for all 4 Tabs of Data Processing
                String query5 = ("SELECT Pump_Size FROM pumps GROUP BY Pump_Size ORDER BY Pump_Size ASC");
                adapter = new MySqlDataAdapter(query5, connection);
                DataTable size = new DataTable();
                DataTable size_rpvsothers = new DataTable();
                DataTable size_rpvsmkt = new DataTable();
                DataTable size_all = new DataTable();
                adapter.Fill(size);
                adapter.Fill(size_rpvsothers);
                adapter.Fill(size_rpvsmkt);
                adapter.Fill(size_all);
                //MAP
                SizeList.DataSource = null;
                SizeList.DataSource = new BindingSource(size, null);
                SizeList.DisplayMember = "Pump_Size";
                //RP VS OTHERS
                Size_rpvsothers.DataSource = null;
                Size_rpvsothers.DataSource = new BindingSource(size_rpvsothers, null);
                Size_rpvsothers.DisplayMember = "Pump_Size";
                //RP VS MARKET
                Size_rpvsmkt.DataSource = null;
                Size_rpvsmkt.DataSource = new BindingSource(size_rpvsmkt, null);
                Size_rpvsmkt.DisplayMember = "Pump_Size";
                //All Data
                Size_all.DataSource = null;
                Size_all.DataSource = new BindingSource(size_all, null);
                Size_all.DisplayMember = "Pump_Size";

                //Stages Filler for all 4 Tabs of data processing
                String query6 = ("SELECT Stages FROM pumps GROUP BY Stages ORDER BY Stages ASC");
                adapter = new MySqlDataAdapter(query6, connection);
                DataTable stage = new DataTable();
                DataTable stage_rpvsothers = new DataTable();
                DataTable stage_rpvsmkt = new DataTable();
                DataTable stage_all = new DataTable();
                adapter.Fill(stage);
                adapter.Fill(stage_rpvsothers);
                adapter.Fill(stage_rpvsmkt);
                adapter.Fill(stage_all);
                //MAP
                StagesList.DataSource = null;
                StagesList.DataSource = new BindingSource(stage, null);
                StagesList.DisplayMember = "Stages";
                //RP VS OTHERS
                Stages_rpvsothers.DataSource = null;
                Stages_rpvsothers.DataSource = new BindingSource(stage_rpvsothers, null);
                Stages_rpvsothers.DisplayMember = "Stages";
                //RP VS MARKET
                Stages_rpvsmkt.DataSource = null;
                Stages_rpvsmkt.DataSource = new BindingSource(stage_rpvsmkt, null);
                Stages_rpvsmkt.DisplayMember = "Stages";
                //All Data
                Stages_all.DataSource = null;
                Stages_all.DataSource = new BindingSource(stage_all, null);
                Stages_all.DisplayMember = "Stages";

            }
        }
        //Query that retrieves Data for the Map Tab
        private void Big_query()
        {

            string Companies = string.Join("','", CompanyList.SelectedItems.Cast<DataRowView>().Select(item => item["Company"].ToString()));
            string Flows = string.Join("','", FlowList.SelectedItems.Cast<DataRowView>().Select(item => item["Flow"].ToString()));
            string Heads = string.Join("','", HeadList.SelectedItems.Cast<DataRowView>().Select(item => item["Head"].ToString()));
            string Speeds = string.Join("','", SpeedList.SelectedItems.Cast<DataRowView>().Select(item => item["Pump_Speed_in_RPM"].ToString()));
            string Sizes = string.Join("','", SizeList.SelectedItems.Cast<DataRowView>().Select(item => item["Pump_Size"].ToString()));
            string Stages = string.Join("','", StagesList.SelectedItems.Cast<DataRowView>().Select(item => item["Stages"].ToString()));

            string CompaniesCondition = string.IsNullOrEmpty(Companies) ? "TRUE" : $"Company IN ('{Companies}')";
            string FlowsCondition = string.IsNullOrEmpty(Flows) ? "TRUE" : $"Flow IN ('{Flows}')";
            string HeadsCondition = string.IsNullOrEmpty(Heads) ? "TRUE" : $"Head IN ('{Heads}')";
            string SpeedsCondition = string.IsNullOrEmpty(Speeds) ? "TRUE" : $"Pump_Speed_in_RPM IN ('{Speeds}')";
            string SizesCondition = string.IsNullOrEmpty(Sizes) ? "TRUE" : $"Pump_Size IN ('{Sizes}')";
            string StagesCondition = string.IsNullOrEmpty(Stages) ? "TRUE" : $"Stages IN ('{Stages}')";


            string Bigquery = $@"
                                SELECT 
                                Head, 
                                Company, 
                                Flow, 
                                Pump_Speed_in_RPM, 
                                Pump_Size, 
                                MIN(Max_BHP) AS Min_BHP
                                FROM pumps
                                WHERE {CompaniesCondition}
                                AND {FlowsCondition}
                                AND {HeadsCondition}
                                AND {SpeedsCondition}
                                AND {SizesCondition}
                                AND {StagesCondition}
                                GROUP BY 
                                Company, 
                                Head, 
                                Flow, 
                                Pump_Speed_in_RPM, 
                                Pump_Size
                                ORDER BY Head ASC, Flow ASC;";

            using (MySqlConnection connection = new MySqlConnection(db_conn))
            {
                connection.Open();
                adapter = new MySqlDataAdapter(Bigquery, connection);
                adapter.Fill(Full_data);
                TableView.DataSource = Full_data;
            }
        }

        //Query that retrieves Data for the RP vs Others Tab
        private void big_query2()
        {
            string Companies = string.Join("','", Company_rpvsothers.SelectedItems.Cast<DataRowView>().Select(item => item["Company"].ToString()));
            string Flows = string.Join("','", Flow_rpvsothers.SelectedItems.Cast<DataRowView>().Select(item => item["Flow"].ToString()));
            string Heads = string.Join("','", Head_rpvsothers.SelectedItems.Cast<DataRowView>().Select(item => item["Head"].ToString()));
            string Sizes = string.Join("','", Size_rpvsothers.SelectedItems.Cast<DataRowView>().Select(item => item["Pump_Size"].ToString()));
            string Stages = string.Join("','", Stages_rpvsothers.SelectedItems.Cast<DataRowView>().Select(item => item["Stages"].ToString()));

            string CompaniesCondition = string.IsNullOrEmpty(Companies) ? "TRUE" : $"Company IN ('{Companies}')";
            string FlowsCondition = string.IsNullOrEmpty(Flows) ? "TRUE" : $"Flow IN ('{Flows}')";
            string HeadsCondition = string.IsNullOrEmpty(Heads) ? "TRUE" : $"Head IN ('{Heads}')";
            string SizesCondition = string.IsNullOrEmpty(Sizes) ? "TRUE" : $"Pump_Size IN ('{Sizes}')";
            string StagesCondition = string.IsNullOrEmpty(Sizes) ? "TRUE" : $"Stages IN ('{Stages}')";

            string Bigquery = $@"
                            WITH RankedResults AS (
                            SELECT  
                            Company,
                            Head,
                            Flow, 
                            Pump_Size, 
                            MIN(Max_BHP) AS Min_BHP,
                            ROW_NUMBER() OVER (PARTITION BY Flow, Head ORDER BY MIN(Max_BHP) ASC) AS RowNum
                            FROM pumps
                            WHERE {CompaniesCondition}
                            AND {FlowsCondition}
                            AND {HeadsCondition}
                            AND {SizesCondition}
                            AND {StagesCondition}
                            GROUP BY Company, Head, Flow, Pump_Size
                            )
                            SELECT 
                            Head, 
                            Company, 
                            Flow, 
                            Pump_Size, 
                            Min_BHP
                            FROM RankedResults
                            WHERE RowNum = 1;";

            using (MySqlConnection connection = new MySqlConnection(db_conn))
            {
                connection.Open();
                adapter = new MySqlDataAdapter(Bigquery, connection);
                adapter.Fill(Full_data2);
                TableView2.DataSource = Full_data2;
            }
        }

        //Query that retrieves Data for the RP vs Market Tab
        public void big_query3()
        {
            string Companies = string.Join("','", Company_rpvsmkt.SelectedItems.Cast<DataRowView>().Select(item => item["Company"].ToString()));
            string Flows = string.Join("','", Flow_rpvsmkt.SelectedItems.Cast<DataRowView>().Select(item => item["Flow"].ToString()));
            string Heads = string.Join("','", Head_rpvsmkt.SelectedItems.Cast<DataRowView>().Select(item => item["Head"].ToString()));
            string Sizes = string.Join("','", Size_rpvsmkt.SelectedItems.Cast<DataRowView>().Select(item => item["Pump_Size"].ToString()));
            string Stages = string.Join("','", Stages_rpvsmkt.SelectedItems.Cast<DataRowView>().Select(item => item["Stages"].ToString()));

            string CompaniesCondition = string.IsNullOrEmpty(Companies) ? "TRUE" : $"Company IN ('{Companies}')";
            string FlowsCondition = string.IsNullOrEmpty(Flows) ? "TRUE" : $"Flow IN ('{Flows}')";
            string HeadsCondition = string.IsNullOrEmpty(Heads) ? "TRUE" : $"Head IN ('{Heads}')";
            string SizesCondition = string.IsNullOrEmpty(Sizes) ? "TRUE" : $"Pump_Size IN ('{Sizes}')";
            string StagesCondition = string.IsNullOrEmpty(Sizes) ? "TRUE" : $"Stages IN ('{Stages}')";


            string Bigquery = $@"WITH RankedResults AS (
                               SELECT
                               Company,
                               Head,  
                               Flow, 
                               Pump_Size, 
                               MIN(Max_BHP) as Min BHP,
                               ROW_NUMBER() OVER (PARTITION BY Flow,Head ORDER BY MIN(Max_BHP ASC) as RowNum
                               FROM pumps
                               WHERE {CompaniesCondition}
                               AND {FlowsCondition}
                               AND {HeadsCondition}
                               AND {SizesCondition}
                               AND {StagesCondition}
                               GROUP BY Company, Head, Flow, Pump_Size
                               )
                               SELECT Head,
                               Company, 
                               Flow, 
                               Pump_Size, 
                               `Min BHP`
                               FROM RankedResults
                               WHERE RowNum = 1";

            using (MySqlConnection connection = new MySqlConnection(db_conn))
            {
                connection.Open();
                adapter = new MySqlDataAdapter(Bigquery, connection);
                adapter.Fill(Full_data3);
                TableView3.DataSource = Full_data3;
            }
        }

        //Query that retrieves Data for the All Data Tab
        public void big_query4()
        {

            string Companies = string.Join("','", Company_all.SelectedItems.Cast<DataRowView>().Select(item => item["Company"].ToString()));
            string Flows = string.Join("','", Flow_all.SelectedItems.Cast<DataRowView>().Select(item => item["Flow"].ToString()));
            string Heads = string.Join("','", Head_all.SelectedItems.Cast<DataRowView>().Select(item => item["Head"].ToString()));
            string Speeds = string.Join("','", Speed_all.SelectedItems.Cast<DataRowView>().Select(item => item["Pump_Speed_in_RPM"].ToString()));
            string Sizes = string.Join("','", Size_all.SelectedItems.Cast<DataRowView>().Select(item => item["Pump_Size"].ToString()));
            string Stages = string.Join("','", Stages_all.SelectedItems.Cast<DataRowView>().Select(item => item["Stages"].ToString()));


            string CompaniesCondition = string.IsNullOrEmpty(Companies) ? "TRUE" : $"Company IN ('{Companies}')";
            string FlowsCondition = string.IsNullOrEmpty(Flows) ? "TRUE" : $"Flow IN ('{Flows}')";
            string HeadsCondition = string.IsNullOrEmpty(Heads) ? "TRUE" : $"Head IN ('{Heads}')";
            string SpeedsCondition = string.IsNullOrEmpty(Speeds) ? "TRUE" : $"Pump_Speed_in_RPM IN ('{Speeds}')";
            string SizesCondition = string.IsNullOrEmpty(Sizes) ? "TRUE" : $"Pump_Size IN ('{Sizes}')";
            string StagesCondition = string.IsNullOrEmpty(Stages) ? "TRUE" : $"Stages IN ('{Stages}')";


            string Bigquery = $@"SELECT
                                Company, 
                                Head,
                                Flow,  
                                Pump_Speed_in_RPM as 'Pump Speed', 
                                Max_BHP,
                                Pump_Model, 
                                Line,
                                Stages,
                                Pump_Size
                            FROM pumps                                
                            WHERE {CompaniesCondition}
                            AND {FlowsCondition}
                            AND {HeadsCondition}
                            AND {SpeedsCondition}
                            AND {SizesCondition}
                            AND {StagesCondition};";

            using (MySqlConnection connection = new MySqlConnection(db_conn))
            {
                connection.Open();
                adapter = new MySqlDataAdapter(Bigquery, connection);
                adapter.Fill(Full_data4);
                TableView4.DataSource = Full_data4;
            }
        }
        
        //Function that clears pivot table on Server side to allow new data go through and be optimized
        private void clear_pivot()
        {

            using (MySqlConnection connection = new MySqlConnection(db_conn))
            {
                connection.Open();
                String delete_statement = "TRUNCATE TABLE pumps_receiver";
                MySqlCommand cmd = new MySqlCommand(delete_statement,connection);
                MySqlDataReader runenr = cmd.ExecuteReader();
            }
        }

        private void clear_filter_map()
        {
            CompanyList.ClearSelected();
            FlowList.ClearSelected();
            HeadList.ClearSelected();
            SpeedList.ClearSelected();
            SizeList.ClearSelected();
            StagesList.ClearSelected();
        }

        private void clear_filter_rpvsothers()
        {
            Company_rpvsothers.ClearSelected();
            Flow_rpvsothers.ClearSelected();
            Head_rpvsothers.ClearSelected();
            Size_rpvsothers.ClearSelected();
            Stages_rpvsothers.ClearSelected();
        }

        private void clear_filter_rpvsmkt()
        {
            Company_rpvsmkt.ClearSelected();
            Flow_rpvsmkt.ClearSelected();
            Head_rpvsmkt.ClearSelected();
            Size_rpvsmkt.ClearSelected();
            Stages_rpvsmkt.ClearSelected();
        }

        private void clear_filter_all_data()
        {
            Company_all.ClearSelected();
            Flow_all.ClearSelected();
            Head_all.ClearSelected();
            Size_all.ClearSelected();
            Stages_all.ClearSelected();
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

        private void button1_Click(object sender, EventArgs e)
        {
            open_excel();
        }

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
                                csv_view.DataSource = dt;
                                string start_ok = "Now Viewing";
                                viewer.Text = start_ok;
                                csv_label.Text = start + Path.GetFileName(filePath);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error reading CSV file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            csv_view.DataSource = null;
            csv_view.Refresh();
            csv_view.DataContext = null;
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

        private void select_file_to_insert_to_database()
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
                    try
                    {
                        using (var reader = new StreamReader(filePath))
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {
                            using (var dr = new CsvDataReader(csv))
                            {
                                sel_insert_label.Text = Path.GetFileName(filePath);

                                async void insert_to_db()
                                {
                                    try
                                    {
                                        using (var connection = new MySqlConnection(db_conn))
                                        {
                                            connection.Open();

                                            using (var reader = new StreamReader(filePath))
                                            {
                                                // Leer y omitir la primera línea (encabezados)
                                                string headerLine = reader.ReadLine();

                                                // Ahora prepara la consulta para insertar los datos
                                                while (!reader.EndOfStream)
                                                {
                                                    string dataLine = reader.ReadLine();
                                                    string[] values = dataLine.Split(',');

                                                    // Escape de comillas simples en los valores y ponerlos entre comillas
                                                    for (int i = 0; i < values.Length; i++)
                                                    {
                                                        values[i] = "'" + values[i].Replace("'", "''") + "'";
                                                    }

                                                    string valueString = $"({string.Join(",", values)})";

                                                    // Ejecuta la inserción sin los encabezados
                                                    string insertQuery = $"INSERT INTO pumps (Company, Flow, Head, Pump_Speed_in_RPM,Max_BHP,Pump_Model,Line,Stages,Pump_Size) VALUES {valueString}";

                                                    using (var cmd = new MySqlCommand(insertQuery, connection))
                                                    {
                                                        cmd.ExecuteNonQuery();
                                                    }
                                                }
                                            }
                                            insert_state.Text = "Data inserted successfully";

                                            if (insert_state.Text.Contains("Data inserted successfully"))
                                            {
                                                CompanyList.DataSource = null;
                                                SizeList.DataSource = null;
                                                HeadList.DataSource = null;
                                                SpeedList.DataSource = null;
                                                FlowList.DataSource = null;

                                                fill_selectors();
                                                clear_pivot();

                                                await Task.Delay(6000);

                                                sel_insert_label.Text = string.Empty;
                                                insert_state.Text = string.Empty;
                                            }
                                            else
                                            {

                                                await Task.Delay(5000);

                                                clear_pivot();
                                                sel_insert_label.Text = string.Empty;
                                                insert_state.Text = string.Empty;
                                                
                                            }

                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        insert_state.Text = ($"An error occurred: {ex.Message}");

                                        await Task.Delay(5000);
                                        insert_state.Text = string.Empty;
                                    }
                                }
                                insert_to_db();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error reading CSV file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    sel_insert_label.Text = "No File Selected";
                }
            }
        }

        //Button that calls method to insert data in Database from Data management tab
        private void button7_Click(object sender, EventArgs e)
        {
            select_file_to_insert_to_database();
        }

        private void refresh_db()
        {
            CompanyList.DataSource = null;
            SizeList.DataSource = null;
            HeadList.DataSource = null;
            SpeedList.DataSource = null;
            FlowList.DataSource = null;

            Company_rpvsothers.DataSource = null;
            Size_rpvsothers.DataSource = null;
            Head_rpvsothers.DataSource = null;
            Flow_rpvsothers.DataSource = null;

            Company_rpvsmkt.DataSource = null;
            Size_rpvsmkt.DataSource = null;
            Head_rpvsmkt.DataSource = null;
            Flow_rpvsmkt.DataSource = null;

            Company_all.DataSource = null;
            Size_all.DataSource = null;
            Head_all.DataSource = null;
            Speed_all.DataSource = null;
            Flow_all.DataSource = null;

            fill_selectors();
        }

        private void clear_results_map()
        {
            TableView.DataSource = null;
            TableView.Refresh();
            TableView.DataContext = null;
            Full_data.Clear();
        }

        private void clear_results_rpvsothers()
        {
            TableView2.DataSource = null;
            TableView2.Refresh();
            TableView2.DataContext = null;
            Full_data2.Clear();
        }

        private void clear_results_rpvsmkt()
        {
            TableView3.DataSource = null;
            TableView3.Refresh();
            TableView3.DataContext = null;
            Full_data3.Clear();
        }


        private void clear_results_all_data()
        {
            TableView4.DataSource = null;
            TableView4.Refresh();
            TableView4.DataContext = null;
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
            db_connect();
        }
        //Buttons that are linked to methods that execute query on each tab
        private void button3_Click(object sender, EventArgs e)
        {
            Big_query();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            big_query2();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            big_query3();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            refresh_db();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            clear_filter_all_data();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            big_query4();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            clear_results_map();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            clear_filter_rpvsothers();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            clear_filter_rpvsmkt();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            clear_pivot();
        }
    }
}
