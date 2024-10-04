using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System.Data;
using System.Windows;
using System.Windows.Forms;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection cnn = new MySqlConnection(db_conn);
                conn_state.Text = "Successfully Connected";
                fill_selectors();

            }
            catch (Exception)
            {
                conn_state.Text = "Warning, not connected";
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
    }
}
