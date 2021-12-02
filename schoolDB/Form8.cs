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
    public partial class Form8 : Form
    {
        schoolDBEntities context = new schoolDBEntities();
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && textBox1.Text != "")
            {
                Table_Modules module = new Table_Modules();
                module.modules_name = textBox1.Text;
                module.programme_id = int.Parse(comboBox1.SelectedValue.ToString());
                //parents.id_parent = 
                context.Table_Modules.Add(module);
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
                var query = context.Table_Modules.FirstOrDefault(p => p.id == id);
                if (query != null)
                {
                    context.Table_Modules.Remove(query);
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
        public void dataModules()
        {
            var query = context.Table_Modules.Select(p => new
            {
                p.id,
                p.modules_name,
                p.Table_programme.programme_name
            });
            dataGridView1.DataSource = query.ToList();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                if (comboBox1.SelectedValue != null && textBox1.Text != "")
                {
                    int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    var query = context.Table_Modules.FirstOrDefault(p => p.id == id);
                    if (query != null)
                    {
                        query.modules_name = textBox1.Text;
                        query.programme_id = int.Parse(comboBox1.SelectedValue.ToString());
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
            var query = context.Table_programme.Select(p => p);
            comboBox1.DataSource = query.ToList();
            comboBox1.DisplayMember = "programme_name";
            comboBox1.ValueMember = "id";
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            dataprogramme();
            dataModules();
        }
    }
}
