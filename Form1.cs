using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //helper function to display all the classes the user can take after a given class
        public bool check_after(string user_input)
        {
            //this variable will help to determine if the determination of the next classes has been successful
            bool success = true;
            //we will user switch block to determine the classes
            switch (user_input)
            {
                //first level
                case "MAC2281":
                    MessageBox.Show("You can take: PHY 2048, MAC 2282 or MAC 2312, COP 2510, COT 3100");
                    break;
                case "MAC2311":
                    MessageBox.Show("You can take: PHY 2048, MAC 2282 or MAC 2312, COP 2510, COT 3100");
                    break;

                //second level
                case "PHY2048":
                    MessageBox.Show("You can take: PHY 2049");
                    break;
                case "MAC2282":
                    MessageBox.Show("You can take: PHY 2049, MAC 2283 or MAC 2313");
                    break;
                case "MAC2312":
                    MessageBox.Show("You can take: PHY 2049, MAC 2283 or MAC 2313");
                    break;
                case "COP2510":
                    MessageBox.Show("You can take: CDA 3103, COP 3514");
                    break;
                case "COT3100":
                    MessageBox.Show("Error! You have to be in Upper Division to take a class after COT 3100, contact your advisor.");
                    break;

                //third level
                case "PHY2049":
                    MessageBox.Show("You do not have any other class to take after PHY 2049.");
                    break;
                case "MAC2283":
                    MessageBox.Show("You do not have any other class to take after MAC 2283.");
                    break;
                case "MAC2313":
                    MessageBox.Show("You do not have any other class to take after MAC 2313");
                    break;
                case "CDA3103":
                    MessageBox.Show("You can take: CDA 3201, COP 4530");
                    break;
                case "COP3514":
                    MessageBox.Show("You can take: CDA 3201, COP 4530");
                    break;

                //fourth level
                case "CDA3201":
                    MessageBox.Show("Error! You have to be in Upper Division to take a class after CDA 3201, contact your advisor");
                    break;
                case "COP4530":
                    MessageBox.Show("Error! You have to be in Upper Division to take a class after COP 4530, contact your advisor");
                    break;

                //invalid input
                default:
                    MessageBox.Show("Error! You have entered invalid input! Try again!");
                    success = false;
                    //reset the user input textbox
                    Class_TX.Text = "";
                    break;
            }

            return success;
        }


        //helper function to determine all the classes the user must have taken based on the class enterred
        public void check_before(string user_input)
        {
            //we will use if statements to deterime the classes the user must have taken
            
            //first level
            if (user_input == "MAC2281" || user_input == "MAC2311")
            {
                MessageBox.Show("You do not have any classes you have taken before MAC 2281 or MAC 2311");
            }

            //second level
            else if (user_input == "PHY2048" || user_input == "MAC2282" || user_input == "MAC2312" ||
                user_input == "COP2510" || user_input == "COT3100")
            {
                MessageBox.Show("You must have taken before: MAC 2281 or MAC 2311");
            }
    
            //third level
            else if (user_input == "PHY2049")
            {
                MessageBox.Show("You must have taken before: PHY 2048, MAC 2282 or MAC 2312, MAC 2281 or MAC 2311");
            }
            else if (user_input == "MAC2283" || user_input == "MAC2313")
            {
                MessageBox.Show("You must have taken before: MAC 2282 or MAC 2312, MAC 2281 or MAC 2311");
            }
            else if (user_input == "CDA3103")
            {
                MessageBox.Show("You must have taken before: COP 2510, MAC 2281 or MAC 2311");
            }
            else if (user_input == "COP3514")
            {
                MessageBox.Show("You must have taken before: COP 2510, MAC 2281, MAC 2311"); 
            }

            //fourth level
            else if (user_input == "CDA3201" || user_input == "COP4530")
            {
                MessageBox.Show("You must have taken before: CDA 3103, COP 3514, COP 2510, MAC 2281 or MAC 2311");
            }

            //if none of the if statements is true, we know the user input is invalid
            else
            {
                MessageBox.Show("Error! Invalid Input!");
            }

            //reset the input text box
            Class_TX.Text = "";
        }


        private void Submit_BTN_Click(object sender, EventArgs e)
        {
            //get the user input
            //we don't want the user to submit an empty input
            if (Class_TX.Text == "")
            {
                //let the user know about the empty input error
                MessageBox.Show("Error! Input cannot be empty!");
                return;
            }
            string user_input = Class_TX.Text;

            //let's first check the classes the user can take after the class entered
            //we will call the helper function to do this
            //if the next classes determination has been successful we proceed to check 
            //the classes the user must have already taken
            if (check_after(user_input))
            {
                check_before(user_input);
            }
        }
    }
}
