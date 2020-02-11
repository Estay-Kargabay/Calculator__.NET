using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace secondProject
{
    public partial class Form1 : Form 
    {
        private List<double> value_list = new List<double>();//save value used  this  
        private List<int> operator_list = new List<int>();//  save opearatoration  
        //state save 
        private bool add_flag = false;//on clicked add
        private bool minus_flag = false;//on clicked add
        private bool multi_flag = false;//on clicked add
        private bool div_flag = false;//on clicked add
        private bool result_flag = false;//on clicked add
        private bool equal_flag = false;//on clicked add
        public Form1()
        {
            InitializeComponent();
        }

        //numer as clicked   include 0.，000001223
        private void num_down(string num)
        {
            if (add_flag || minus_flag || multi_flag || div_flag || result_flag)
            {
                if (result_flag)//as clicked equal buttonn 
                {
                    label1.Text = "";
                }
                textBox.Clear();//when finesh oneof the opreating
                add_flag = false;
                minus_flag = false;
                multi_flag = false;
                div_flag = false;
                result_flag = false;
            }
            if ((num.Equals(".") && textBox.Text.IndexOf(".") < 0) || !num.Equals("."))
            {
                // if the user is entering a decimal point..., you will only be allowed to enter if the number you have entered contains a decimal point
                textBox.Text += num;
                label1.Text += num;
                equal_flag = true;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }




        


        /// number here
        private void btnone_Click(object sender, EventArgs e)
        {
          //  textBox.Text = textBox.Text + "1";
            num_down("1");
        }

        private void btnnine_Click(object sender, EventArgs e)
        {
          //  textBox.Text = textBox.Text + "9";

            num_down("9");
        }
        private void btnsewen_Click(object sender, EventArgs e)
        {
          //  textBox.Text = textBox.Text + "7";

            num_down("7");
        }

        private void btnzero_Click(object sender, EventArgs e)
        {
           // textBox.Text = textBox.Text + "0";

            num_down("0");

        }
        private void btneight_Click(object sender, EventArgs e)
        {
           // textBox.Text = textBox.Text + "8";

            num_down("8");
        }

        private void btnthree_Click(object sender, EventArgs e)
        {
          //  textBox.Text = textBox.Text + "3";

            num_down("3");

        }

       

        private void btnfour_Click(object sender, EventArgs e)
        {
           // textBox.Text = textBox.Text + "4";

            num_down("4");

        }

        private void btnfive_Click(object sender, EventArgs e)
        {
           // textBox.Text = textBox.Text + "5";

            num_down("5");

        }

        private void btnsex_Click(object sender, EventArgs e)
        {
            //textBox.Text = textBox.Text + "6";

            num_down("6");


        }

        private void btntow_Click(object sender, EventArgs e)
        {
            ////textBox.Text = textBox.Text + "2";

            num_down("2");

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // textBox.Text = textBox.Text + ".";

            num_down(".");
        }



       
        //operator   there
        private void btnequal_Click(object sender, EventArgs e)
        {
            if (value_list.Count > 0 && operator_list.Count > 0 && equal_flag)
            {// to prevent the user from not entering a number, or only entering a number, press = .
                value_list.Add(double.Parse(textBox.Text));
                double total = value_list[0];
                for (int i = 0; i < operator_list.Count; i++)
                {
                    int _operator = operator_list[i];
                    //operator is an overloaded keyword for the C# operator, preceded by a _ to distinguish it
                    switch (_operator)
                    {
                        case 0:
                            total += value_list[i + 1];
                            break;
                        case 1:
                            total -= value_list[i + 1];
                            break;
                        case 2:
                            total *= value_list[i + 1];
                            break;
                        case 3:
                            total /= value_list[i + 1];
                            break;
                    }
                }
                textBox.Text = total + "";
                label1.Text = total + "";
                operator_list.Clear();//When you're done, you clear the array of cumulative Numbers and operations
                value_list.Clear();
                result_flag = true;//Means = press
            }


        }

        private void btnmultiply_Click(object sender, EventArgs e)
        {

           // textBox.Text = textBox.Text + "×";

            if (!multi_flag)
            {

                result_flag = false;
                value_list.Add(double.Parse(textBox.Text));
                operator_list.Add(2);
                label1.Text = "(" + label1.Text + ")" + "×";//I'm going to put parentheses around what I've already put in here。（运算符栈问题是一个很复杂的数据结构问题，这里不做，：P）
                multi_flag = true;
                equal_flag = false;
            }
            }

        private void btndivide_Click(object sender, EventArgs e)
        {

           // textBox.Text = textBox.Text + "÷";

            if (!div_flag)
            {
                result_flag = false;
                value_list.Add(double.Parse(textBox.Text));
                operator_list.Add(3);
                label1.Text = "(" + label1.Text + ")" + "÷";
                div_flag = true;
                equal_flag = false;
            }

        }


        private void btnplus_Click(object sender, EventArgs e)
        {
           // textBox.Text = textBox.Text + "+";


            if (!add_flag)// prevents the user from entering a symbol key more than once
            {
                result_flag = false;
                value_list.Add(double.Parse(textBox.Text));//save to value_list
                operator_list.Add(0);
                label1.Text += "+";
                add_flag = true;
                equal_flag = false;//// just entered the symbol, can not constitute a normal expression, such as 111+, set to unrun state
            }

        }


        private void btnminus_Click(object sender, EventArgs e)
        {
           // textBox.Text = textBox.Text + "-";

            if (!minus_flag)
            {
                result_flag = false;
                value_list.Add(double.Parse(textBox.Text));
                operator_list.Add(1);
                label1.Text += "-";
                minus_flag = true;
                equal_flag = false;


            }

        }
        private void btnclear_Click(object sender, EventArgs e)
        {
            textBox.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
