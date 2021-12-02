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
    
    public partial class Form2 : Form
    {
        schoolDBEntities context = new schoolDBEntities();
       
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!=""&& textBox3.Text != ""&& textBox4.Text != ""&& textBox5.Text != ""&& textBox6.Text != "")
            {
                Table_parents parents = new Table_parents();
                parents.full_name = textBox1.Text;
                parents.phone = textBox3.Text;
                parents.email = textBox4.Text;
                parents.address = textBox5.Text;
                parents.job = textBox6.Text;
                //parents.id_parent = 
                context.Table_parents.Add(parents);
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
            if (dataGridView1.CurrentRow!=null)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var query = context.Table_parents.FirstOrDefault(p => p.id == id);
                if (query != null)
                {
                    context.Table_parents.Remove(query);
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
            if (dataGridView1.CurrentRow!=null)
            {
                if (textBox1.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
                {
                    int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    var query = context.Table_parents.FirstOrDefault(p => p.id == id);
                    if (query != null)
                    {
                        query.full_name = textBox1.Text;
                        query.phone = textBox3.Text;
                        query.email = textBox4.Text;
                        query.address = textBox5.Text;
                        query.job = textBox6.Text;
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
        public void dataGridviewDataparents()
        {
            var query = context.Table_parents.Where(p => p.full_name.Contains(textBox2.Text)).Select(p => new
            {
                p.id,
                nom_prenom = p.full_name,
                p.phone,
                p.email,
                p.address,
                p.job
            });
            dataGridView1.DataSource = query.ToList();
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            dataGridviewDataparents();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dataGridviewDataparents();
        }
    }
}
