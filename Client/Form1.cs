using System;
using System.Windows.Forms;
using WriteToDB;

namespace Client
{
    public partial class Form1 : Form
    {
        Client client = new Client();

        public Form1()
        {
            InitializeComponent();
        }

        private void changeFileButton_Click(object sender, EventArgs e)
        {
            openFileDb.Filter = @"C++ files (*.cpp)|*.cpp";
            openFileDb.Multiselect = false;
            openFileDb.ShowDialog();
            pathFileText.Text = openFileDb.FileName;
        }

        private StudentJob ObjectFormation()
        {
            StudentJob studentJob = new StudentJob();

            return studentJob;
        }

        private bool CheckedField()
        {
            if (fioText.Text.Length == 0)
            {
                MessageBox.Show("Заполните строку с именем");
                return false;
            }
            if (groupText.Text.Length == 0)
            {
                MessageBox.Show("Заполните строку с группой");
                return false;
            }    
            if (pathFileText.Text.Length == 0)
            {
                MessageBox.Show("Выберите файл");
                return false;
            }
            if (addressServerText.Text.Length == 0)
            {
                MessageBox.Show("Введите адрес сервера");
                return false;
            }
            return true;
        }

        private void StartNormalize_Click(object sender, EventArgs e)
        {
            if (!CheckedField())
                return;

            var record = ObjectFormation();
            var address = addressServerText.Text;
            if (record == null)
                return;
            if (bySoket.Checked)
                client.SendSocket(record, address);
            else if (byMQ.Checked)
                client.SendMQ(record, address);
            else if (byRPC.Checked)
                client.SendGRPC(record, address);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            addressServerText.Text = "localhost";
        }
    }
}
