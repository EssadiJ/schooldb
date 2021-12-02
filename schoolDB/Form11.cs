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
    public partial class Form11 : Form
    {
        schoolDBEntities context = new schoolDBEntities();
        public Form11()
        {
            InitializeComponent();
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
        public void dataTimes()
        {
            var module = comboBox6.Text;
            var time = comboBox5.Text;
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
                        where modules.modules_name ==module &&times.time ==time
                        select new
                        {
                            id = c.id,
                            full_name = s.full_name,
                            date_in = s.date_in,
                            date_fin = s.date_out,
                            formateur = t.full_name,
                            programme = pro.programme_name,
                            Module = modules.modules_name,
                            jour = days.day,
                            Horair = times.time,
                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataTimes();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            JourData();
            proData();
            dataTimes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.SelectAll();
                DataObject copydata = dataGridView1.GetClipboardContent();
                if (copydata != null) Clipboard.SetDataObject(copydata);
                Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
                xlapp.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook xlWbook;
                Microsoft.Office.Interop.Excel.Worksheet xlsheet;
                object miseddata = System.Reflection.Missing.Value;
                xlWbook = xlapp.Workbooks.Add(miseddata);

                xlsheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWbook.Worksheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)xlWbook.ActiveSheet;
                ws.Cells[1, 2] = "id";
                ws.Cells[1, 3] = "nom et prenom";
                ws.Cells[1, 4] = "date in";
                ws.Cells[1, 5] = "date fin";
                ws.Cells[1, 6] = "formateur";
                ws.Cells[1, 7] = "programme";
                ws.Cells[1, 8] = "Module";
                ws.Cells[1, 9] = "jour";
                ws.Cells[1, 10] = "Horair";
                Microsoft.Office.Interop.Excel.Range xlr = (Microsoft.Office.Interop.Excel.Range)xlsheet.Cells[2, 1];
                xlr.Select();

                xlsheet.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            }
            else
            {
                MessageBox.Show("ne existe pas!");
            }
        }
    }
}
