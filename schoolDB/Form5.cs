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
    public partial class Form5 : Form
    {
        schoolDBEntities context = new schoolDBEntities();
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Table_days day = new Table_days();
                day.day = textBox1.Text;
                //parents.id_parent = 
                context.Table_days.Add(day);
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
                var query = context.Table_days.FirstOrDefault(p => p.id == id);
                if (query != null)
                {
                    context.Table_days.Remove(query);
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                if (textBox1.Text != "")
                {
                    int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    var query = context.Table_days.FirstOrDefault(p => p.id == id);
                    if (query != null)
                    {
                        query.day = textBox1.Text;
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
        public void datadays()
        {
            var query = context.Table_days.Select(p => new
            {
                p.id,
                p.day,
            });
            dataGridView1.DataSource = query.ToList();
        }

        private void Form5_Activated(object sender, EventArgs e)
        {
            datadays();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
