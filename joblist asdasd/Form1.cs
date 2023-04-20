using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace joblist_asdasd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadfile();
            update("");
        }

        void loadfile()
        {
            StreamReader sr = new StreamReader("file.txt");

            for (int i = 0; i < pages.Length; i++)
            {
                pages[i].j1 = sr.ReadLine();
                pages[i].j2 = sr.ReadLine();
                pages[i].j3 = sr.ReadLine();
                pages[i].j4 = sr.ReadLine();
                pages[i].j5 = sr.ReadLine();
                pages[i].j6 = sr.ReadLine();
                pages[i].j7 = sr.ReadLine();

                pages[i].c1 = bool.Parse( sr.ReadLine());
                pages[i].c2 = bool.Parse( sr.ReadLine());
                pages[i].c3 = bool.Parse( sr.ReadLine());
                pages[i].c4 = bool.Parse( sr.ReadLine());
                pages[i].c5 = bool.Parse( sr.ReadLine());
                pages[i].c6 = bool.Parse( sr.ReadLine());
                pages[i].c7 = bool.Parse( sr.ReadLine());
            }
            sr.Close();


        }

        struct Page // j refers to job
        {
            public String j1;
            public String j2;
            public String j3;
            public String j4;
            public String j5;
            public String j6;
            public String j7;

            public bool c1;
            public bool c2;
            public bool c3;
            public bool c4;
            public bool c5;
            public bool c6;
            public bool c7;


        }

        Page[] pages = new Page[10]; // how many pages

        int pagepointer = 0;


        void savetofile()
        {
            

            StreamWriter sw = new StreamWriter("file.txt");

            for(int i = 0;i<pages.Length; i++)
            {
                sw.WriteLine(pages[i].j1);
                sw.WriteLine(pages[i].j2);
                sw.WriteLine(pages[i].j3);
                sw.WriteLine(pages[i].j4);
                sw.WriteLine(pages[i].j5);
                sw.WriteLine(pages[i].j6);
                sw.WriteLine(pages[i].j7);

                sw.WriteLine(pages[i].c1);
                sw.WriteLine(pages[i].c2);
                sw.WriteLine(pages[i].c3);
                sw.WriteLine(pages[i].c4);
                sw.WriteLine(pages[i].c5);
                sw.WriteLine(pages[i].c6);
                sw.WriteLine(pages[i].c7);

            }
            sw.Close();

            MessageBox.Show("The file has successfully been stored into non volatile memory.","System Information Module",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        void clear()
        {

            DialogResult d = MessageBox.Show("Are you sure you want to clear the list?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (d == DialogResult.Yes)
            {
                foreach (Control x in this.Controls)
                {
                    if (x.Tag == "job")
                    {
                        x.Text = "";
                    }
                }

                PictureBox[] boxes = { c1, c2, c3, c4, c5, c6, c7 };

                foreach (PictureBox box in boxes)
                {
                    box.Image = null;
                    box.BackColor = Color.White;


                }


                for (int i = 0; i < pages.Length; i++)
                {
                    pages[i].j1 = "";
                    pages[i].j2 = "";
                    pages[i].j3 = "";
                    pages[i].j4 = "";
                    pages[i].j5 = "";
                    pages[i].j6 = "";
                    pages[i].j7 = "";

                    pages[i].c1 = false;
                    pages[i].c2 = false;
                    pages[i].c3 = false;
                    pages[i].c4 = false;
                    pages[i].c5 = false;
                    pages[i].c6 = false;
                    pages[i].c7 = false;
                }

                MessageBox.Show("The list has been cleared", "System Information Module", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The list has not been cleared", "System Information Module", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
        }
        

        void click(PictureBox checkbox, ref bool state,bool clicked)
        {

            if (clicked)
            {
                state = !state;
            }
            

            if (state)
            {
                checkbox.Image = Properties.Resources.tick;


            }
            else
            {
                checkbox.Image = null;
                checkbox.BackColor = Color.White;


            }
        }

        void update(string increment)
        {

            if (increment != "")
            {
                pages[pagepointer].j1 = j1.Text;
                pages[pagepointer].j2 = j2.Text;
                pages[pagepointer].j3 = j3.Text;
                pages[pagepointer].j4 = j4.Text;
                pages[pagepointer].j5 = j5.Text;
                pages[pagepointer].j6 = j6.Text;
                pages[pagepointer].j7 = j7.Text;





                if (increment == "true" && pagepointer < pages.Length - 1)
                {
                    pagepointer++;
                }
                else if (increment == "false" && pagepointer != 0)
                {
                    pagepointer--;
                }
            }






            j1.Text = pages[pagepointer].j1;
            j2.Text = pages[pagepointer].j2;
            j3.Text = pages[pagepointer].j3;
            j4.Text = pages[pagepointer].j4;
            j5.Text = pages[pagepointer].j5;
            j6.Text = pages[pagepointer].j6;
            j7.Text = pages[pagepointer].j7;

            click(c1, ref pages[pagepointer].c1, false);
            click(c2, ref pages[pagepointer].c2, false);
            click(c3, ref pages[pagepointer].c3, false);
            click(c4, ref pages[pagepointer].c4, false);
            click(c5, ref pages[pagepointer].c5, false);
            click(c6, ref pages[pagepointer].c6, false);
            click(c7, ref pages[pagepointer].c7, false);
            



            status.Text = "Page " + (pagepointer + 1).ToString() + " of " + pages.Length.ToString();
        }







        






        private void savebutton_Click(object sender, EventArgs e)
        {
            

            savetofile();
        }

        

        private void prev_Click(object sender, EventArgs e)
        {
            update("false");
        }

        private void next_Click(object sender, EventArgs e)
        {
            update("true");
        }

        













        private void c1_Click(object sender, EventArgs e)
        {
            click(c1, ref pages[pagepointer].c1,true);
        }

        private void c2_Click(object sender, EventArgs e)
        {
            click(c2, ref pages[pagepointer].c2, true);
        }
        private void c3_Click(object sender, EventArgs e)
        {
            click(c3, ref pages[pagepointer].c3, true);
        }

        private void c4_Click(object sender, EventArgs e)
        {
            click(c4, ref pages[pagepointer].c4, true);
        }

        private void c5_Click(object sender, EventArgs e)
        {
            click(c5, ref pages[pagepointer].c5, true);
        }

        private void c6_Click(object sender, EventArgs e)
        {
            click(c6, ref pages[pagepointer].c6, true);
        }

        private void c7_Click(object sender, EventArgs e)
        {
            click(c7, ref pages[pagepointer].c7, true);
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
