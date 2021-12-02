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
    public partial class Form15 : Form
    {
        schoolDBEntities context = new schoolDBEntities();
        public Form15()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!=""&&textBox2.Text!="")
            {
                Table_admin admin = new Table_admin();
                admin.admin_name = textBox1.Text;
                admin.password = textBox2.Text;
                context.Table_admin.Add(admin);
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
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var query = context.Table_admin.FirstOrDefault(p => p.admin_id == id);
            if (query != null)
            {
                context.Table_admin.Remove(query);
                context.SaveChanges();
                MessageBox.Show("suppristion OK!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var query = context.Table_admin.FirstOrDefault(p => p.admin_id == id);
                if (query != null)
                {
                    query.admin_name = textBox1.Text;
                    query.password = textBox2.Text;
                    context.SaveChanges();
                    MessageBox.Show("Modification OK!");
                }
            }
            else
            {
                MessageBox.Show("touts les champ obligtoire OK!");
            }
        }
        public void dataGridviewData()
        {
            var query = context.Table_admin.Select(p => new
            {
                p.admin_id,
                p.admin_name,
                p.password
            });
            dataGridView1.DataSource = query.ToList();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            dataGridviewData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridviewData();
        }
    }
}
