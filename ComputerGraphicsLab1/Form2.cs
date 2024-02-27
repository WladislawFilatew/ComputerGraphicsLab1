using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGraphicsLab1
{
    public partial class Form2 : Form
    {
        public event EventHandler<int[,]> Matrix;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int size = int.Parse(textBox1.Text);
           double znach = double.Parse(textBox2.Text);
            dataGridView1.RowCount = size;
            dataGridView1.ColumnCount = size;
            for (int i = 0;i < size; i++)
            {
                dataGridView1.Columns[i].Width = splitContainer1.Panel2.Width / size;
                dataGridView1.Rows[i].Height = splitContainer1.Panel2.Height / size;
                for (int j = 0;j < size; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = znach;
                }
            }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox textBox = e.Control as TextBox;
            if (textBox != null)
            {
                textBox.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int size = int.Parse(textBox1.Text);
            int[,] matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i,j] = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                }
            }
            Matrix?.Invoke(this, matrix);
            this.Close();
        }
    }
}
