using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using Spire.Xls;
using System.Data;
using System.Text;
using CsvHelper;
using System.Globalization;
using System.Windows;
using System.Windows.Forms;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CsvHelper.Configuration;

namespace PumpAtlas

{
    public partial class Form1 : Form
    {
        string db_conn = "server=localhost;database=rp;uid=root;pwd=FireSystems25;";


        MySqlDataAdapter adapter;
        DataTable comp = new DataTable();
        DataTable head = new DataTable();
        DataTable flow = new DataTable();
        DataTable speed = new DataTable();
        DataTable size = new DataTable();
        DataTable Full_data = new DataTable();
        DataTable dt = new DataTable();


        String fileContent = string.Empty;
        String filePath = string.Empty;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection cnn = new MySqlConnection(db_conn);
                conn_state.Text = "Successfully Connected to Database";
                conn_db_state.Text = "Successfully Connected to Database";
                fill_selectors();

            }
            catch (Exception)
            {
                conn_state.Text = "Warning, not connected";
                conn_db_state.Text = "Warning, not connected";
            }
        }

        private void fill_selectors()
        {
            String query1 = ("SELECT Company FROM pumps GROUP BY Company");
            String query2 = ("SELECT Head FROM pumps GROUP BY Head ORDER BY Head");
            String query3 = ("SELECT Flow FROM pumps GROUP BY Flow ORDER BY Flow ASC");
            String query4 = ("SELECT Pump_Speed_in_RPM FROM pumps GROUP BY Pump_Speed_in_RPM ORDER BY Pump_Speed_in_RPM ASC");
            String query5 = ("SELECT Pump_Size FROM pumps GROUP BY Pump_Size ORDER BY Pump_Size ASC");


            using (MySqlConnection connection = new MySqlConnection(db_conn))
            {
                connection.Open();

                adapter = new MySqlDataAdapter(query1, connection);
                adapter.Fill(comp);
                CompanyList.DataSource = comp;
                CompanyList.DisplayMember = "Company";

            }

            using (MySqlConnection connection = new MySqlConnection(db_conn))
            {
                connection.Open();

                adapter = new MySqlDataAdapter(query2, connection);
                adapter.Fill(head);
                HeadList.DataSource = head;
                HeadList.DisplayMember = "Head";

            }

            using (MySqlConnection connection = new MySqlConnection(db_conn))
            {
                connection.Open();

                adapter = new MySqlDataAdapter(query3, connection);
                adapter.Fill(flow);
                FlowList.DataSource = flow;
                FlowList.DisplayMember = "Flow";

            }

            using (MySqlConnection connection = new MySqlConnection(db_conn))
            {
                connection.Open();

                adapter = new MySqlDataAdapter(query4, connection);
                adapter.Fill(speed);
                SpeedList.DataSource = speed;
                SpeedList.DisplayMember = "Pump_Speed_in_RPM";

            }

            using (MySqlConnection connection = new MySqlConnection(db_conn))
            {
                connection.Open();

                adapter = new MySqlDataAdapter(query5, connection);
                adapter.Fill(size);
                SizeList.DataSource = size;
                SizeList.DisplayMember = "Pump_Size";

            }
        }

        private void Big_query()
        {

            string Companies = string.Join("','", CompanyList.SelectedItems.Cast<DataRowView>().Select(item => item["Company"].ToString()));
            string Flows = string.Join("','", FlowList.SelectedItems.Cast<DataRowView>().Select(item => item["Flow"].ToString()));
            string Heads = string.Join("','", HeadList.SelectedItems.Cast<DataRowView>().Select(item => item["Head"].ToString()));
            string Speeds = string.Join("','", SpeedList.SelectedItems.Cast<DataRowView>().Select(item => item["Pump_Speed_in_RPM"].ToString()));
            string Sizes = string.Join("','", SizeList.SelectedItems.Cast<DataRowView>().Select(item => item["Pump_Size"].ToString()));

            string CompaniesCondition = string.IsNullOrEmpty(Companies) ? "TRUE" : $"Company IN ('{Companies}')";
            string FlowsCondition = string.IsNullOrEmpty(Flows) ? "TRUE" : $"Flow IN ('{Flows}')";
            string HeadsCondition = string.IsNullOrEmpty(Heads) ? "TRUE" : $"Head IN ('{Heads}')";
            string SpeedsCondition = string.IsNullOrEmpty(Speeds) ? "TRUE" : $"Pump_Speed_in_RPM IN ('{Speeds}')";
            string SizesCondition = string.IsNullOrEmpty(Sizes) ? "TRUE" : $"Pump_Size IN ('{Sizes}')";


            string Bigquery = $"SELECT Company, Flow, Head, Pump_Speed_in_RPM as 'Speed (RPM)',Pump_Size, MIN(Max_BHP) as 'Min BHP' " +
                           $"FROM pumps " +
                           $"WHERE {CompaniesCondition} " +
                           $"AND {FlowsCondition} " +
                           $"AND {HeadsCondition} " +
                           $"AND {SpeedsCondition} " +
                           $"AND {SizesCondition} " +
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
            CompanyList.ClearSelected();
            FlowList.ClearSelected();
            HeadList.ClearSelected();
            SpeedList.ClearSelected();
            SizeList.ClearSelected();

            TableView.DataSource = null;
            TableView.Refresh();
            TableView.DataContext = null;
            Full_data.Clear();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

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
                                csv_label.Text = start + Path.GetFileName(filePath);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error reading CSV file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void clear_visor()
        {
            csv_view.DataSource = null;
            csv_view.Refresh();
            csv_view.DataContext = null;
            csv_label.Text = String.Empty;
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

                                void insert_to_db()
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


            CompanyList.Items.Clear();
            SizeList.Items.Clear();
            HeadList.Items.Clear();
            SpeedList.Items.Clear();
            FlowList.Items.Clear();


            fill_selectors();
        }
    }
}
