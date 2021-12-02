using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace schoolDB
{
    public partial class Form1 : Form
    {
        schoolDBEntities context = new schoolDBEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue!=null&&textBox1.Text!=""&&comboBox2.SelectedItem!=null)
            {
                Table_students student = new Table_students();
                student.full_name = textBox1.Text;
                student.gender = comboBox2.SelectedItem.ToString();
                student.age = DateTime.Parse(dateTimePicker1.Text);
                student.date_in = DateTime.Parse(dateTimePicker2.Text);
                student.date_out = DateTime.Parse(dateTimePicker3.Text);
                student.id_parent = int.Parse(comboBox1.SelectedValue.ToString());
                context.Table_students.Add(student);
                context.SaveChanges();
                MessageBox.Show("ajouter OK!");
            }
            else
            {
                MessageBox.Show("touts les champ obligtoire!");
            }
        }
        public void parentComobo()
        {
            var query = context.Table_parents.Select(p => p);
            comboBox1.DataSource = query.ToList();
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "full_name";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            parentComobo();
            dataGridviewData();
        }
        public void dataGridviewData()
        {
            var query = context.Table_students.Where(p => p.full_name.Contains(textBox2.Text)).Select(p => new
            {
                p.id,
                nom_prenom = p.full_name,
                p.gender,
                p.date_in,
                p.date_out,
                p.Table_parents.full_name,
            });
            dataGridView1.DataSource = query.ToList();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            parentComobo();
            dataGridviewData();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dataGridviewData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var query = context.Table_students.FirstOrDefault(p => p.id == id);
            if (query!=null)
            {
                context.Table_students.Remove(query);
                context.SaveChanges();
                MessageBox.Show("suppristion OK!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
                if (comboBox1.SelectedValue != null && textBox1.Text != "" && comboBox2.SelectedItem != null)
                {
                    int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    var query = context.Table_students.FirstOrDefault(p => p.id == id);
                    if (query != null)
                    {
                        query.full_name = textBox1.Text;
                        query.gender = comboBox2.SelectedItem.ToString();
                        query.age = DateTime.Parse(dateTimePicker1.Text);
                        query.date_in = DateTime.Parse(dateTimePicker2.Text);
                        query.date_out = DateTime.Parse(dateTimePicker3.Text);
                        query.id_parent = int.Parse(comboBox1.SelectedValue.ToString());
                        context.SaveChanges();
                        MessageBox.Show("Modification OK!");
                    }
                }
                else
                {
                    MessageBox.Show("touts les champ obligtoire OK!");
                }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 parent = new Form2();
            parent.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            parentComobo();
            dataGridviewData();
        }
    }
}
