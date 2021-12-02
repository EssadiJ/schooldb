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
    public partial class Form9 : Form
    {
        schoolDBEntities context = new schoolDBEntities();
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null&& comboBox3.SelectedValue != null&& comboBox4.SelectedValue != null&& comboBox5.SelectedValue != null&& comboBox6.SelectedValue != null)
            {
                Table_class classes = new Table_class();
                classes.id_student = int.Parse(comboBox1.SelectedValue.ToString());
                classes.id_teacher = int.Parse(comboBox2.SelectedValue.ToString());
                classes.id_modules = int.Parse(comboBox6.SelectedValue.ToString());
                classes.id_times = int.Parse(comboBox5.SelectedValue.ToString());
                //parents.id_parent = 
                context.Table_class.Add(classes);
                context.SaveChanges();
                MessageBox.Show("ajouter OK!");
            }
            else
            {
                MessageBox.Show("touts les champ obligtoire!");
            }
        }
        public void studentData()
        {
            var query = context.Table_students.Select(p => p);
            comboBox1.DataSource = query.ToList();
            comboBox1.DisplayMember = "full_name";
            comboBox1.ValueMember = "id";
        }
        public void TeacherData()
        {
            var query = context.Table_Teacher.Select(p => p);
            comboBox2.DataSource = query.ToList();
            comboBox2.DisplayMember = "full_name";
            comboBox2.ValueMember = "id";
        }
        public void proData()
        {
            var query = context.Table_programme.Select(p => p);
            comboBox3.DataSource = query.ToList();
            comboBox3.DisplayMember = "programme_name";
            comboBox3.ValueMember = "id";
        }
        public void JourData()
        {
            var query = context.Table_days.Select(p => p);
            comboBox4.DataSource = query.ToList();
            comboBox4.DisplayMember = "day";
            comboBox4.ValueMember = "id";
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = comboBox4.Text;
            var query = from c in context.Table_days
                        join t in context.Table_times
                        on c.id equals t.day_id
                        where c.day == text
                        select new
                        {
                            id = t.id,
                            t.time
                        };
            comboBox5.DataSource = query.ToList();
            comboBox5.ValueMember = "id";
            comboBox5.DisplayMember = "Time";
        }

        private void Form9_Activated(object sender, EventArgs e)
        {
            studentData();
            TeacherData();
            proData();
            JourData();
            dataTimes();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = comboBox3.Text;
            var query = from c in context.Table_programme
                        join t in context.Table_Modules
                        on c.id equals t.programme_id
                        where c.programme_name == text
                        select new
                        {
                            id = t.id,
                            MP = t.modules_name,
                        };
            comboBox6.DataSource = query.ToList();
            comboBox6.ValueMember = "id";
            comboBox6.DisplayMember = "MP";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var query = context.Table_class.FirstOrDefault(p => p.id == id);
                if (query != null)
                {
                    context.Table_class.Remove(query);
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
                if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null && comboBox4.SelectedValue != null && comboBox5.SelectedValue != null && comboBox6.SelectedValue != null)
                {
                    int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    var query = context.Table_class.FirstOrDefault(p => p.id == id);
                    if (query != null)
                    {
                        query.id_student = int.Parse(comboBox1.SelectedValue.ToString());
                        query.id_teacher = int.Parse(comboBox2.SelectedValue.ToString());
                        query.id_modules = int.Parse(comboBox6.SelectedValue.ToString());
                        query.id_times = int.Parse(comboBox5.SelectedValue.ToString());
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
            studentData();
            TeacherData();
            proData();
            JourData();
            dataTimes();
        }
        public void dataTimes()
        {
            var query = from s in context.Table_students
                        join c in context.Table_class
                        on s.id equals c.id_student
                        join t in context.Table_Teacher
                        on c.id_teacher equals t.id
                        join times in context.Table_times
                        on c.id_times equals times.id
                        join days in context.Table_days
                        on times.day_id equals days.id
                        join modules in context.Table_Modules
                        on c.id_modules equals modules.id
                        join pro in context.Table_programme
                        on modules.programme_id equals pro.id
                        where s.full_name.Contains(textBox1.Text)
                        select new
                        {
                            c.id,
                            s.full_name,
                            date_in = s.date_in,
                            date_fin = s.date_out,
                            formateur = t.full_name,
                            pro.programme_name,
                            modules.modules_name,
                            jour = days.day,
                            Horair = times.time,
                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            dataTimes();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataTimes();
        }
    }
}
