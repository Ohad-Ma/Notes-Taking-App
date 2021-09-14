using System;
using System.Data;
using System.Windows.Forms;

namespace Notes_Taking_App
{
    public partial class Form1 : Form
    {
        DataTable table;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Messages", typeof(string));
            dataGridView1.DataSource = table;
            dataGridView1.Columns["Messages"].Visible = false;
            dataGridView1.Columns["Title"].Width = 176;
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtMsg.Clear();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if(txtTitle.Text.Length != 0) { 
                table.Rows.Add(txtTitle.Text, txtMsg.Text);
                txtTitle.Clear();
                txtMsg.Clear();
            }else if(txtTitle.Text.Length == 0)
            {
                MessageBox.Show("Please write something in the header first");
            }
        }

        private void readBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                if (index > -1)
                {
                    txtTitle.Text = table.Rows[index].ItemArray[0].ToString();
                    txtMsg.Text = table.Rows[index].ItemArray[1].ToString();
                }
            }
            else if(dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("There is nothing to read");
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentCell != null) { 
                int index = dataGridView1.CurrentCell.RowIndex;
                table.Rows[index].Delete();
            }
            else
            {
                MessageBox.Show("There is nothing to delete");
            }
        }
    }
}
