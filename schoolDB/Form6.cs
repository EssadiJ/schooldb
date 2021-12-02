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
    public partial class Form6 : Form
    {
        schoolDBEntities context = new schoolDBEntities();
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != ""&&comboBox1.SelectedValue!=null)
            {
                Table_Attendnce att = new Table_Attendnce();
                att.remark = textBox1.Text;
                att.id_students = int.Parse(comboBox1.SelectedValue.ToString());
                att.date = DateTime.Parse(dateTimePicker1.Text);
                context.Table_Attendnce.Add(att);
                context.SaveChanges();
                MessageBox.Show("ajouter OK!");
            }
            else
            {
                MessageBox.Show("touts les champ obligtoire!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var query = context.Table_Attendnce.FirstOrDefault(p => p.id == id);
                if (query != null)
                {
                    context.Table_Attendnce.Remove(query);
                    context.SaveChanges();
                    MessageBox.Show("suppristion OK!");
                }
                else
                {
                    MessageBox.Show("ne existe pas OK!");
                }
            }
            else
            {
                MessageBox.Show("ne existe pas OK!");
            }
        }
        public void dataAttendnce()
        {
            var query = context.Table_Attendnce.Where(p=>p.Table_students.full_name.Contains(textBox4.Text)).Select(p => new
            {
                p.id,
                p.Table_students.full_name,
                p.remark,
                p.date
            });
            dataGridView1.DataSource = query.ToList();
        }
        public void studentData()
        {
            var query = context.Table_students.Select(p => p);
            comboBox1.DataSource = query.ToList();
            comboBox1.DisplayMember = "full_name";
            comboBox1.ValueMember = "id";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                if (textBox1.Text != "")
                {
                    int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    var query = context.Table_Attendnce.FirstOrDefault(p => p.id == id);
                    if (query != null)
                    {
                        query.remark = textBox1.Text;
                        query.id_students = int.Parse(comboBox1.SelectedValue.ToString());
                        query.date = DateTime.Parse(dateTimePicker1.Text);
                        context.SaveChanges();
                        MessageBox.Show("Modification OK!");
                    }
                    else
                    {
                        MessageBox.Show("ne existe pas OK!");
                    }
                }
                else
                {
                    MessageBox.Show("touts les champs obligtoire OK!");
                }
            }
        }

        private void Form6_Activated(object sender, EventArgs e)
        {
            dataAttendnce();
            studentData();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            dataAttendnce();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataAttendnce();
            studentData();
        }
    }
}
