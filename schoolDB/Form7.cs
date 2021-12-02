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
    public partial class Form7 : Form
    {
        schoolDBEntities context = new schoolDBEntities();
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Table_programme pro = new Table_programme();
                pro.programme_name = textBox1.Text;
                //parents.id_parent = 
                context.Table_programme.Add(pro);
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
                var query = context.Table_programme.FirstOrDefault(p => p.id == id);
                if (query != null)
                {
                    context.Table_programme.Remove(query);
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
                    var query = context.Table_programme.FirstOrDefault(p => p.id == id);
                    if (query != null)
                    {
                        query.programme_name = textBox1.Text;
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
        public void dataprogramme()
        {
            var query = context.Table_programme.Select(p => new
            {
                p.id,
                p.programme_name,
            });
            dataGridView1.DataSource = query.ToList();
        }

        private void Form7_Activated(object sender, EventArgs e)
        {
            dataprogramme();
        }
    }
}
