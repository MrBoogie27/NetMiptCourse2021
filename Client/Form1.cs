using System;
using System.IO;
using System.Windows.Forms;
using WriteToDB;

namespace Client
{
    public partial class Form1 : Form
    {
        readonly Client client = new Client();

        public Form1()
        {
            InitializeComponent();
        }

        private void ChangeFileButton_Click(object sender, EventArgs e)
        {
            openFileDb.Filter = @"C++ files (*.cpp)|*.cpp";
            openFileDb.Multiselect = false;
            openFileDb.ShowDialog();
            pathFileText.Text = openFileDb.FileName;
        }

        private StudentJob ObjectFormation()
        {
            return new StudentJob
            {
                Fio = fioText.Text,
                Group = groupText.Text,
                TaskNumber = (int)taskNumeric.Value,
                CodeContext = File.ReadAllText(pathFileText.Text)
            };
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
            var file = new FileInfo(pathFileText.Text);
            if (!file.Exists)
            {
                MessageBox.Show("Файл не существует");
                return false;
            }
            if (file.Length > 256 * 1024 * 1024) // if more than 256MB
            {
                MessageBox.Show("Размер файла превышает 256 MB, выберите другой файл");
                return false;
            }
            if (addressServerText.Text.Length == 0)
            {
                MessageBox.Show("Введите адрес сервера");
                return false;
            }
            return true;
        }

        private void Submit_Click(object sender, EventArgs e)
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
