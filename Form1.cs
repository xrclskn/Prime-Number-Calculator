using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        static int endPoint ;
        static Thread thread;
        

        public Form1()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender,EventArgs e)
        {
            listbox.Items.Clear();

            try
            {
                endPoint = Int32.Parse(numericUpDown1.Text);
                
                if (endPoint < 0)
                {
                    MessageBox.Show("Invalid number. Please enter an integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

               
                    
            }

            catch(Exception Hata)
            {
                MessageBox.Show("Invalid number. Please enter an integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

            //finally
            {
                //MessageBox.Show("Invalid number. Please enter an integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

            


            Control.CheckForIllegalCrossThreadCalls = false;
            

            thread = new Thread(new ThreadStart(PrimeFunc));
            thread.Start();
            
        }
        
        void PrimeFunc()
        {
            for (int i = 2; i < endPoint; i++)
            {
                if (isPrime(i))
                {
                    listbox.Items.Add(i.ToString());
                }

                    

            }

            

        }

        static bool isPrime(int num)
        {
            if (num >= 2)
            {
                for (int i = 2; i < num / 2 + 1; i++)
                {
                    if (num % i == 0)
                        return false;

                }
            }
            else
                return false;
            return true;
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to Prime Calculator", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

          
        }

        bool move;
        int mouse_x;
        int mouse_y;

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("See you later", "Bye", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Application.Exit();
            

            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("See you later", "Bye", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Application.Exit();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            label2.Text = mouse_x.ToString();
            label3.Text = mouse_y.ToString();

            label4.Text = MousePosition.Y.ToString();
            label5.Text = MousePosition.X.ToString();


            if(move==true)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;

        }

    }
}
