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
    public partial class Form4 : Form
    {
        schoolDBEntities context = new schoolDBEntities();
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue!=null&&textBox1.Text!="")
            {
                Table_times times = new Table_times();
                times.time = textBox1.Text;
                times.day_id = int.Parse(comboBox1.SelectedValue.ToString());
                //parents.id_parent = 
                context.Table_times.Add(times);
                context.SaveChanges();
                MessageBox.Show("ajouter OK!");
            }
            else
            {
                MessageBox.Show("touts les champ obligtoire!");
            }
        }
        public void daysData()
        {
            var query = context.Table_days.Select(p => p);
            comboBox1.DataSource = query.ToList();
            comboBox1.DisplayMember = "day";
            comboBox1.ValueMember = "id";
        }

        private void Form4_Activated(object sender, EventArgs e)
        {
            daysData();
            dataTimes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var query = context.Table_times.FirstOrDefault(p => p.id == id);
                if (query != null)
                {
                    context.Table_times.Remove(query);
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
        public void dataTimes()
        {
            var query = context.Table_times.Select(p => new
            {
                p.id,
                p.time,
                p.Table_days.day
            });
            dataGridView1.DataSource = query.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                if (comboBox1.SelectedValue!=null&&textBox1.Text!="")
                {
                    int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    var query = context.Table_times.FirstOrDefault(p => p.id == id);
                    if (query != null)
                    {
                        query.time = textBox1.Text;
                        query.day_id = int.Parse(comboBox1.SelectedValue.ToString());
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

        private void button4_Click(object sender, EventArgs e)
        {
            dataTimes();
            daysData();
        }
    }
}
