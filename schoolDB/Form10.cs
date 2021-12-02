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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void manageStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool f = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "Form1")
                {
                    f = true;
                }
            }
            if (!f)
            {
                Form1 form = new Form1();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void newClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool f = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "Form9")
                {
                    f = true;
                }
            }
            if (!f)
            {
                Form9 form = new Form9();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void newTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool f = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "Form3")
                {
                    f = true;
                }
            }
            if (!f)
            {
                Form3 form = new Form3();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void attendnceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool f = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "Form6")
                {
                    f = true;
                }
            }
            if (!f)
            {
                Form6 form = new Form6();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void programmeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool f = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "Form7")
                {
                    f = true;
                }
            }
            if (!f)
            {
                Form7 form = new Form7();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void modulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool f = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "Form8")
                {
                    f = true;
                }
            }
            if (!f)
            {
                Form8 form = new Form8();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void lhorairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool f = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "Form4")
                {
                    f = true;
                }
            }
            if (!f)
            {
                Form4 form = new Form4();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void leJourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool f = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "Form5")
                {
                    f = true;
                }
            }
            if (!f)
            {
                Form5 form = new Form5();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void filterClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool f = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "Form11")
                {
                    f = true;
                }
            }
            if (!f)
            {
                Form11 form = new Form11();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool f = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "Form14")
                {
                    f = true;
                }
            }
            if (!f)
            {
                Form14 form = new Form14();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            bool f = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "Form1")
                {
                    f = true;
                }
            }
            if (!f)
            {
                Form1 form = new Form1();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool f = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "Form15")
                {
                    f = true;
                }
            }
            if (!f)
            {
                Form15 form = new Form15();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void documentInscriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool f = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "Form16")
                {
                    f = true;
                }
            }
            if (!f)
            {
                Form16 form = new Form16();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
