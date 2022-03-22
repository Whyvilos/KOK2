using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KOK2
{
    public partial class Form1 : Form
    {

        int sizeMas = 2;
        double[,] Mas = new double[2, 2];
        double[] Vector = new double[2];
        double[,] Mas2 = new double[2, 2];


        public const double E = 2.7182818284590451;
        bool[] flag = new bool[3] { false, false, false }; 


        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox1.Enabled = true;
            sizeMas = comboBox1.SelectedIndex+2;
            Mas = new double[sizeMas, sizeMas];
            Mas2 = new double[sizeMas, sizeMas];
            Vector = new double[sizeMas];



        }


        private double[] mxm(double[] v, double[,] m)
        {
            double[] Net0 = new double[sizeMas];
            for (int i = 0; i < sizeMas; i++)
            {
                
                double NetZ = 0;
                for (int k = 0; k < sizeMas; k++)
                {
                    NetZ += v[k] * m[k,i]; 
                }
                Net0[i] = NetZ;
                
            }
            return Net0;
        }
        
        private double[] vxc(double[] m)
        {
            double[] Out0 = new double[sizeMas];

            for (int i = 0; i < sizeMas; i++)
            {
                Out0[i] = 1 / (1 + Math.Pow(E, -m[i]));
            }

            return Out0;
        }

        private string outVector(double[] m)
        {
            string str = "( ";
            foreach (double v in m)
            {
                
                str+= v.ToString() + " ";
            }
            str+=" )";
            return str;
        }

        public void result()
        {
            double[] vctr = mxm(Vector, Mas);
            textBox4.Text = outVector(vctr);
            vctr = vxc(vctr);
            textBox5.Text = outVector(vctr);
            vctr = mxm(vctr, Mas2);
            textBox6.Text = outVector(vctr);
            vctr = vxc(vctr);
            textBox7.Text = outVector(vctr);

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            int number2 = e.KeyChar;
           

            int z = 0;
            int y = 0;
            foreach (char i in textBox2.Text)
            {
                
                if (i==' ')
                {
                    z++;
                }
                if (z >= (sizeMas-1) * sizeMas+1)
                {
                    if (number != 8)
                    {
                        e.Handled = true;
                    }
                }
                if (i == 13)
                {
                    y++;
                    
                    if (y == sizeMas)
                    {
                        //label4.Text = "sdfsdf";
                        string str = "";
                        int c0 = 0;
                        int c1 = 0;
                        for(int i2 = 0; i2 < textBox2.TextLength; i2++)
                        {
                            if(textBox2.Text[i2] == 32)
                            {
                                Mas[c0, c1] = Convert.ToDouble(str);
                                c1++;
                                str = "";
                                continue;
                            }
                            if (textBox2.Text[i2] == 13)
                            {
                                Mas[c0, c1] = Convert.ToDouble(str);
                                c0++;
                                c1 = 0;
                                str = "";
                                continue;
                            }

                            str += textBox2.Text[i2];
                            
                        }

                       
                        
                        e.Handled = true;
                        textBox2.Enabled = false;
                        flag[0] = true;
                        if(flag[0] && flag[1] && flag[2])
                        {
                            button1.Enabled = true;
                        }
                    }
                }
            }

            
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 32 && number != 13) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            int number2 = e.KeyChar;
           

            int z = 0;
            int y = 0;
            foreach (char i in textBox3.Text)
            {
                
                if (i == ' ')
                {
                    z++;
                }
                if (z >= (sizeMas - 1) * sizeMas + 1)
                {
                    if (number != 8)
                    {
                        e.Handled = true;
                    }
                }
                if (i == 13)
                {
                    y++;

                    if (y == sizeMas)
                    {
                        //label4.Text = "sdfsdf";
                        string str = "";
                        int c0 = 0;
                        int c1 = 0;
                        for (int i2 = 0; i2 < textBox3.TextLength; i2++)
                        {
                            if (textBox3.Text[i2] == 32)
                            {
                                Mas2[c0, c1] = Convert.ToDouble(str);
                                c1++;
                                str = "";
                                continue;
                            }
                            if (textBox3.Text[i2] == 13)
                            {
                                Mas2[c0, c1] = Convert.ToDouble(str);
                                c0++;
                                c1 = 0;
                                str = "";
                                continue;
                            }

                            str += textBox3.Text[i2];

                        }

                       

                        e.Handled = true;
                        textBox3.Enabled = false;
                        flag[1] = true;
                        if (flag[0] && flag[1] && flag[2])
                        {
                            button1.Enabled = true;
                        }
                    }
                }
            }


            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 32 && number != 13) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            int sp = 0;
            foreach (char i in textBox1.Text)
            { 
                if(i == 32)
                {
                    sp++;
                    if(sp == sizeMas)
                    {
                        e.Handled = true;
                        string str = "";
                        int c0 = 0;
                        for (int i2 = 0; i2 < textBox1.TextLength; i2++)
                        {
                            if (textBox1.Text[i2] == 32)
                            {
                                Vector[c0] = Convert.ToDouble(str);
                                c0++;
                                str = "";
                                continue;
                            }


                            str += textBox1.Text[i2];

                        }

                       


                        textBox1.Enabled = false;
                        flag[2] = true;
                        if (flag[0] && flag[1] && flag[2])
                        {
                            button1.Enabled = true;
                        }
                    }
                }

            }



                if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 32) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result();
            button1.Enabled=false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Enabled = true;
            flag[0] = false;
            button1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.Enabled = true;
            flag[1] = false;
            button1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox3.Enabled = true;
            flag[2] = false;
            button1.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            flag[0] = false;
            flag[1] = false;
            flag[2] = false;
            button1.Enabled = true;
        }
    }
}
