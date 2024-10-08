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
        string db_conn = "server=localhost;database=rp;uid=root;pwd=FireSystems25;";

        MySqlDataAdapter adapter;
        DataTable Full_data = new DataTable();
        DataTable dt = new DataTable();

        String fileContent = string.Empty;
        String filePath = string.Empty;


        public Form1()
        {
            InitializeComponent();
            this.Text = "Ruhrpumpen Pump Atlas";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection cnn = new MySqlConnection(db_conn);
                conn_state.Text = conn_db_state.Text;
                fill_selectors();
            }
            catch (Exception)
            {
                conn_state.Text = conn_db_state.Text;
            }
        }

        private void fill_selectors()
        {

            using (MySqlConnection connection = new MySqlConnection(db_conn))
            {
                connection.Open();

                //Company Filler for all 3 Tabs of Data Processing
                String query1 = ("SELECT Company FROM pumps GROUP BY Company");
                adapter = new MySqlDataAdapter(query1, connection);
                DataTable comp = new DataTable();
                DataTable comp_rpvsothers = new DataTable();
                DataTable comp_rpvsmkt = new DataTable();
                adapter.Fill(comp);
                adapter.Fill(comp_rpvsothers);
                adapter.Fill(comp_rpvsmkt);
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

                //Head Filler for all 3 Tabs of Data Processing
                String query2 = ("SELECT Head FROM pumps GROUP BY Head ORDER BY Head");
                adapter = new MySqlDataAdapter(query2, connection);
                DataTable head = new DataTable();
                DataTable head_rpvsothers = new DataTable();
                DataTable head_rpvsmkt = new DataTable();
                adapter.Fill(head);
                adapter.Fill(head_rpvsothers);
                adapter.Fill(head_rpvsmkt);
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

                //Flow Filler for all 3 Tabs of Data Processing
                String query3 = ("SELECT Flow FROM pumps GROUP BY Flow ORDER BY Flow ASC");
                adapter = new MySqlDataAdapter(query3, connection);
                DataTable flow = new DataTable();
                DataTable flow_rpvsothers = new DataTable();
                DataTable flow_rpvsmkt = new DataTable();
                adapter.Fill(flow);
                adapter.Fill(flow_rpvsothers);
                adapter.Fill(flow_rpvsmkt);
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

                //Speed Filler for all 3 Tabs of Data Processing (Only used once)
                String query4 = ("SELECT Pump_Speed_in_RPM FROM pumps GROUP BY Pump_Speed_in_RPM ORDER BY Pump_Speed_in_RPM ASC");
                adapter = new MySqlDataAdapter(query4, connection);
                DataTable speed = new DataTable();
                adapter.Fill(speed);
                SpeedList.DataSource = null;
                SpeedList.DataSource = new BindingSource(speed, null);
                SpeedList.DisplayMember = "Pump_Speed_in_RPM";

                //Pump Size Filler for all 3 Tabs of Data Processing
                String query5 = ("SELECT Pump_Size FROM pumps GROUP BY Pump_Size ORDER BY Pump_Size ASC");
                adapter = new MySqlDataAdapter(query5, connection);
                DataTable size = new DataTable();
                DataTable size_rpvsothers = new DataTable();
                DataTable size_rpvsmkt = new DataTable();
                adapter.Fill(size);
                adapter.Fill(size_rpvsothers);
                adapter.Fill(size_rpvsmkt);
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

                //Stages Filler for all 3 Tabs of data processing
                String query6 = ("SELECT Stages FROM pumps GROUP BY Stages ORDER BY Stages ASC");
                adapter = new MySqlDataAdapter(query6, connection);
                DataTable stage = new DataTable();
                DataTable stage_rpvsothers = new DataTable();
                DataTable stage_rpvsmkt = new DataTable();
                adapter.Fill(stage);
                adapter.Fill(stage_rpvsothers);
                adapter.Fill(stage_rpvsmkt);
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

            }
        }

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
            string StagesCondition = string.IsNullOrEmpty(Sizes) ? "TRUE" : $"Stages IN ('{Stages}')";


            string Bigquery = $"SELECT Company, Flow, Head, Pump_Speed_in_RPM as 'Speed (RPM)',Pump_Size, MIN(Max_BHP) as 'Min BHP' " +
                           $"FROM pumps " +
                           $"WHERE {CompaniesCondition} " +
                           $"AND {FlowsCondition} " +
                           $"AND {HeadsCondition} " +
                           $"AND {SpeedsCondition} " +
                           $"AND {SizesCondition} " +
                           $"AND {StagesCondition} " +
                           $"GROUP BY Head, Company, Flow, Pump_Speed_in_RPM,Pump_Size " +
                           $"ORDER BY Flow DESC";

            using (MySqlConnection connection = new MySqlConnection(db_conn))
            {
                connection.Open();
                adapter = new MySqlDataAdapter(Bigquery, connection);
                adapter.Fill(Full_data);
                TableView.DataSource = Full_data;
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Big_query();
        }

        private void Clear_select_Click(object sender, EventArgs e)
        {
            clear_results_and_filter_map();
            TableView.DataSource = null;
            TableView.Refresh();
            TableView.DataContext = null;
            Full_data.Clear();
        }

        private void clear_results_and_filter_map()
        {
            CompanyList.ClearSelected();
            FlowList.ClearSelected();
            HeadList.ClearSelected();
            SpeedList.ClearSelected();
            SizeList.ClearSelected();
            StagesList.ClearSelected();
        }

        private void clear_results_and_filter_rpvsothers()
        {
            Company_rpvsothers.ClearSelected();
            Flow_rpvsothers.ClearSelected();
            Head_rpvsothers.ClearSelected();
            Size_rpvsothers.ClearSelected();
            Stages_rpvsothers.ClearSelected();
        }

        private void clear_results_and_filter_rpvsmkt()
        {
            Company_rpvsmkt.ClearSelected();
            Flow_rpvsmkt.ClearSelected();
            Head_rpvsmkt.ClearSelected();
            Size_rpvsmkt.ClearSelected();
            Stages_rpvsmkt.ClearSelected();
        }

        private void button1_Click(object sender, EventArgs e)
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

        public void clear_visor()
        {
            csv_view.DataSource = null;
            csv_view.Refresh();
            csv_view.DataContext = null;
            csv_label.Text = String.Empty;
            string start_fail = "No File Selected";
            viewer.Text = start_fail;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            visor();
        }

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

                                                await Task.Delay(6000);

                                                sel_insert_label.Text = string.Empty;
                                                insert_state.Text = string.Empty;
                                            }
                                            else
                                            {

                                                await Task.Delay(5000);

                                                sel_insert_label.Text = string.Empty;
                                                insert_state.Text = string.Empty;
                                            }

                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        insert_state.Text = ($"An error occurred: {ex.Message}");
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

        private void button7_Click(object sender, EventArgs e)
        {
            select_file_to_insert_to_database();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CompanyList.DataSource = null;
            SizeList.DataSource = null;
            HeadList.DataSource = null;
            SpeedList.DataSource = null;
            FlowList.DataSource = null;

            fill_selectors();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            clear_results_and_filter_rpvsothers();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            clear_results_and_filter_rpvsmkt();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
