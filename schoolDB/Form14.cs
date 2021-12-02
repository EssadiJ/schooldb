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
    public partial class Form14 : Form
    {
        schoolDBEntities context = new schoolDBEntities();
        public Form14()
        {
            InitializeComponent();
            dataPayments();
            parentComobo();
        }
        public void parentComobo()
        {
            var query = context.Table_parents.Select(p => p);
            comboBox1.DataSource = query.ToList();
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "full_name";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && textBox2.Text != "" && comboBox2.SelectedItem != null && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                Table_paymentsDetails payment = new Table_paymentsDetails();
                payment.type = textBox2.Text;
                payment.amount = decimal.Parse(textBox3.Text);
                payment.blance = decimal.Parse(textBox4.Text);
                payment.recette = decimal.Parse(textBox5.Text);
                payment.sumistre = comboBox2.SelectedItem.ToString();
                payment.date = DateTime.Parse(dateTimePicker1.Text);
                payment.id_parents = int.Parse(comboBox1.SelectedValue.ToString());
                context.Table_paymentsDetails.Add(payment);
                context.SaveChanges();
                MessageBox.Show("ajouter OK!");
            }
            else
            {
                MessageBox.Show("touts les champ obligtoire!");
            }
        }
        public void dataPayments()
        {
            var query = context.Table_paymentsDetails.Where(p => p.Table_parents.full_name.Contains(textBox1.Text)).Select(p => new
            {
                p.id,
                nom_prenom = p.Table_parents.full_name,
                p.Table_parents.phone,
                p.type,
                p.amount,
                p.blance,
                p.recette,
                p.sumistre,
                p.date,
                
            });
            dataGridView1.DataSource = query.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var query = context.Table_paymentsDetails.FirstOrDefault(p => p.id == id);
                if (query != null)
                {
                    context.Table_paymentsDetails.Remove(query);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataPayments();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataPayments();
            parentComobo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var query = context.Table_paymentsDetails.FirstOrDefault(p => p.id == id);
                if (query != null)
                {
                    query.type = textBox2.Text;
                    query.amount = decimal.Parse(textBox3.Text);
                    query.blance = decimal.Parse(textBox4.Text);
                    query.recette = decimal.Parse(textBox5.Text);
                    query.sumistre = comboBox2.SelectedItem.ToString();
                    query.date = DateTime.Parse(dateTimePicker1.Text);
                    query.id_parents = int.Parse(comboBox1.SelectedValue.ToString());
                    context.SaveChanges();
                    MessageBox.Show("Modifuction OK!");
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
