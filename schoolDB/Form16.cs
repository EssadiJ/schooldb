using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace schoolDB
{
    public partial class Form16 : Form
    {
        schoolDBEntities context = new schoolDBEntities();
        public Form16()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog image = new OpenFileDialog();
            image.Filter = "image jpg(*.jpg)|*.jpg|image png(.png)|*.png";
            if (image.ShowDialog() == DialogResult.OK)
            {
                string xmlPath = image.FileName;
                pictureBox2.ImageLocation = xmlPath;
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float margin = 20;
            DateTime d = new DateTime();
            d = DateTime.Now;
            System.Drawing.Font f = new System.Drawing.Font("Arial", 15, FontStyle.Bold);
            System.Drawing.Font FS = new System.Drawing.Font("Arial", 20, FontStyle.Underline);
            System.Drawing.Font FSM = new System.Drawing.Font("Arial", 15, FontStyle.Italic);
            string id = "FICHE D'INSCRIPTION";
            string name = "Nom de eleve: " + textBoxNomStudent.Text;
            string dateN = "Date et lieu de naissance: " + textBoxAge.Text;
            string woring = "NB: les cheque doivent etre tous remis a l'inscription.";
            string dsale = "casablanca le:\t" + d.ToString("dd/MM/yyyy");
            string singnature = "SINGNATURE";
            string Address = "Address:" + textBoxAddress.Text;
            string profession = "profession:" + textBoxJob.Text;
            string GSM = "GSM:" + textBoxPhone.Text;
            string Email = "Email: " + textBoxEmail.Text;
            string namePre = "Nom et prenom du Pere/Mere: " + textBoxNomPere.Text;
            string dateIn = "Date D'inscription: " + textBoxdatein.Text;
            string dateOut = "Date fin: " + textBoxDateout.Text;
            string datepayment = "Date payment: " + textBoxDatePayments.Text;
            string info = "CMAV Menetal Math Maroc:";
            string info1 = "21 Boulevard ZERKTOUNI Residence EL BORJ 20000.CASABLANCA";
            string info2 = "Email:cma.mental.math@gmail.com";
            string info3 = "Tel:05222753557/0664867176";
            string paiment = "Methode de payment:" + " " + textBox1.Text;
            string paiments = "A forfait:" + " " + textBox2.Text;
            string Recette = "A forfait:" + " " + textBox2.Text;

            SizeF fonsizeNo = e.Graphics.MeasureString(id, f);
            SizeF fonsizeDate = e.Graphics.MeasureString(dsale, f);
            SizeF fonsizeNM = e.Graphics.MeasureString(name, f);
            SizeF fontsizeAddres = e.Graphics.MeasureString(Address, f);

            e.Graphics.DrawImage(Properties.Resources.logo_large, 300, 20, 250, 90);
            //MessageBox.Show(e.PageBounds.ToString());
            e.Graphics.DrawImage(pictureBox2.Image, 600, margin + 200, 200, 200);

            e.Graphics.DrawString(id, FS, Brushes.Black, (e.PageBounds.Width - fonsizeNo.Width) / 2, 140);
            e.Graphics.DrawString(info, FSM, Brushes.Black, (e.PageBounds.Width - fonsizeNo.Width) / 2, 950);
            e.Graphics.DrawString(info1, FSM, Brushes.Black, (e.PageBounds.Width - fonsizeNo.Width - 400) / 2, 980);
            e.Graphics.DrawString(info2, FSM, Brushes.Blue, (e.PageBounds.Width - fonsizeNo.Width) / 2, 1010);
            e.Graphics.DrawString(info3, FSM, Brushes.Black, (e.PageBounds.Width - fonsizeNo.Width) / 2, 1040);
            e.Graphics.DrawString(woring, f, Brushes.Red, margin + 10, 800);
            e.Graphics.DrawString(dsale, f, Brushes.Black, margin + 10, 840);
            e.Graphics.DrawString(singnature, f, Brushes.Black, e.PageBounds.Width - margin - 200, 840);
            e.Graphics.DrawString(name, f, Brushes.Black, margin + 10, 180 + fonsizeNo.Height + fonsizeNM.Height);
            e.Graphics.DrawString(dateN, f, Brushes.Black, margin + 10, 270);
            e.Graphics.DrawString(namePre, f, Brushes.Black, margin + 10, 340);
            e.Graphics.DrawString(Address, f, Brushes.Black, margin + 10, 380);
            e.Graphics.DrawString(profession, f, Brushes.Black, margin + 10, 420);
            e.Graphics.DrawString(GSM, f, Brushes.Black, margin + 10, 460);
            e.Graphics.DrawString(Email, f, Brushes.Black, margin + 10, 500);
            e.Graphics.DrawString(paiment, f, Brushes.Black, margin + 10, 540);
            e.Graphics.DrawString(paiments, f, Brushes.Black, margin + 10, 580);
            e.Graphics.DrawString(dateIn, f, Brushes.Black, margin + 10, 620);
            e.Graphics.DrawString(dateOut, f, Brushes.Black, margin + 10, 660);
            e.Graphics.DrawString(datepayment, f, Brushes.Black, margin + 10, 700);
            e.Graphics.DrawString(Recette, f, Brushes.Black, margin + 10, 740);
            float preheihts = margin + fonsizeNo.Height + fonsizeDate.Height + fonsizeNM.Height + 100;
            //DrawRectangle
            e.Graphics.DrawRectangle(Pens.Black, margin, preheihts, e.PageBounds.Width - margin * 2, e.PageBounds.Height - margin - preheihts);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        public void remplirData()
        {
            var query = from S in context.Table_students
                        join P in context.Table_parents
                        on S.id_parent equals P.id
                        join py in context.Table_paymentsDetails
                        on P.id equals py.id_parents
                        where S.full_name.Contains(textBoxSearch.Text)
                        select new
                        {
                            P.id,
                            S.full_name,
                            S.age,
                            Sexe = S.gender,
                            S.date_in.Value,
                            S.date_out,
                            Nom_de_pre = P.full_name,
                            Profession = P.job,
                            P.address,
                            GSM = P.phone,
                            P.email,
                            py.date,
                            py.amount,
                            py.blance,
                            PAIEMENT = py.type,
                            py.recette,
                            Forfait = py.sumistre,
                        };
            dataGridView1.DataSource = query.ToList();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBoxAddress.Clear();
            textBoxAmount.Clear();
            textBoxBalnce.Clear();
            textBoxCin.Clear();
            textBoxEmail.Clear();
            textBoxNomPere.Clear();
            textBoxNomStudent.Clear();
            textBoxJob.Clear();
            textBoxSexe.Clear();
            textBoxPhone.Clear();
            textBoxAge.Clear();
            textBoxDateout.Clear();
            textBoxDatePayments.Clear();
            textBoxSearch.Clear();
            textBoxdatein.Clear();
            textBoxRecette.Clear();
            textBoxBalnce.Clear();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var cin = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var query = from S in context.Table_students
                        join P in context.Table_parents
                        on S.id_parent equals P.id
                        join py in context.Table_paymentsDetails
                        on P.id equals py.id_parents
                        select new
                        {
                            P.id,
                            S.full_name,
                            S.age,
                            Sexe = S.gender,
                            S.date_in,
                            S.date_out,
                            Nom_de_pre = P.full_name,
                            Profession = P.job,
                            P.address,
                            GSM = P.phone,
                            P.email,
                            py.date,
                            py.amount,
                            py.blance,
                            PAIEMENT = py.type,
                            py.recette,
                            Forfait = py.sumistre,
                        };
            foreach (var item in query)
            {
                textBoxNomStudent.Text = item.full_name;
                textBoxCin.Text = item.full_name;
                textBoxAge.Text = item.age.ToString();
                textBoxSexe.Text = item.Sexe;
                textBoxdatein.Text = item.date_in.ToString();
                textBoxDateout.Text = item.date_out.ToString();
                textBoxEmail.Text = item.email;
                textBoxAmount.Text = item.amount.ToString();
                textBoxBalnce.Text = item.blance.ToString();
                textBoxAddress.Text = item.address;
                textBoxPhone.Text = item.GSM;
                textBoxJob.Text = item.Profession;
                textBoxNomPere.Text = item.Nom_de_pre;
                textBoxRecette.Text = item.recette.ToString();
                textBox1.Text = item.PAIEMENT;
                textBoxDatePayments.Text = item.date.ToString();
                textBox2.Text = item.Forfait;
            }
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            remplirData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow!=null)
            {
                dataGridView1.SelectAll();
                DataObject copydata = dataGridView1.GetClipboardContent();
                if (copydata != null) Clipboard.SetDataObject(copydata);
                Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
                xlapp.Visible = true;
                Workbook xlWbook;
                Worksheet xlsheet;
                //Add columns 

                object miseddata = System.Reflection.Missing.Value;
                xlWbook = xlapp.Workbooks.Add(miseddata);

                xlsheet = (Worksheet)xlWbook.Worksheets.get_Item(1);
                Worksheet ws = (Worksheet)xlWbook.ActiveSheet;
                ws.Cells[1, 2] = "id";
                ws.Cells[1, 3] = "nom et prenom";
                ws.Cells[1, 4] = "age";
                ws.Cells[1, 4] = "sexe";
                ws.Cells[1, 6] = "date in";
                ws.Cells[1, 7] = "date out";
                ws.Cells[1, 8] = "nom de pere/mere";
                ws.Cells[1, 9] = "profession";
                ws.Cells[1, 10] = "address";
                ws.Cells[1, 11] = "GSM";
                ws.Cells[1, 12] = "email";
                ws.Cells[1, 13] = "date paimenet";
                ws.Cells[1, 14] = "amount";
                ws.Cells[1, 15] = "balnce";
                ws.Cells[1, 16] = "paiement";
                ws.Cells[1, 17] = "Recette";
                ws.Cells[1, 18] = "A Forfait";
                Range xlr = (Range)xlsheet.Cells[2, 1];
                xlr.Select();
                xlsheet.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            }
            else
            {
                MessageBox.Show("ne existe pas !OK");
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            remplirData();
        }
    }
}
