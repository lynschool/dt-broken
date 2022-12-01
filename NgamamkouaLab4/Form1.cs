using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NgamamkouaLab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*Name: Edwin Arcange Ngamakoua
         * Date: 11/17/2022
         *This program Books and calculate the cost of a trip base on the destination*/

        /*Name: ResetTrip
         *Sent: none
         *Return: none
         *This function resets to defaults */

        private void ResetTrip()
        {
            // hides the solution group box
            grpInformation.Hide();
            //checks the cuba radio button
            radCuba.Checked = true;
            //blanks out the people textbox
            txtPeople.Text = "";
            //blanks out price label
            lblPrice.Text = "";
            //checks the credit card radio button
            radCreditCard.Checked = true;
            //puts the cursor on the people textbox
            txtPeople.Focus();
        }

        /*Name: SetFlight
         *Sent: none
         *Return: none
         *This function checks or unchecks the flight checkbox if florida 
         is selected or not*/

        private void SetFlight()
        {
            // if florida radio button is checked
            if (radFlorida.Checked == true)
            {
                //uncheck flight checkbox
                chkFlight.Checked = false;
            }
            // if the condition is false
            else
            {
                //check flight checkbox
                chkFlight.Checked = true;
            }
            
        }
        /*Name: DisplayMsg
         *Sent: 2 string
         *Return: none
         * the function displays messagebox with message and title*/

        private void DisplayMsg(string message, string title)
        {
            MessageBox.Show(message, title);
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            //calls the ResetTrip function
            ResetTrip();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //calls the ResetTrip function
            ResetTrip();
        }

        private void radCuba_CheckedChanged(object sender, EventArgs e)
        {
            //calls the SetFlight function
            SetFlight();
        }

        private void radFlorida_CheckedChanged(object sender, EventArgs e)
        {
            //calls the SetFlight function
            SetFlight();
        }

        private void radMexico_CheckedChanged(object sender, EventArgs e)
        {
            //calls the SetFlight function
            SetFlight();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            double numx, num0;
            // declares variable within tryparse
            // if an int 
            if (int.TryParse(txtPeople.Text, out int num1))
            {
               switch (num1)
                {
                    // calls for the fuction DisplayMsg when integer called is 1 and 3
                    case 1: case 3: DisplayMsg("Special when booking single or triple.\nBOGO Special - Call 555-1212 to receive another person free!", "Limited Time Offer");
                        break;
                }
                //if between range 
                if (num1>= 1 && num1<= 10)
                {
                    //if Mexico radio button is checked
                    if (radMexico.Checked == true)
                    {
                        //calculate numx
                        numx = num1 * 2300.79;
                        // put it in price label formatted in currency
                        lblPrice.Text = numx.ToString("c");
                    }
                    else // condition false
                    {
                        //calculate numx
                        numx = num1 * 2150.50;
                        // put it in price label formatted in currency
                        lblPrice.Text = numx.ToString("c");
                    }
                    //if cash radio button is checked
                    if (radCash.Checked == true)
                    {
                        //calculate numx
                        num0= numx * 0.1;
                        numx= numx - num0;
                        // put it in price label formatted in currency
                        lblPrice.Text = numx.ToString("c");
                    }
                    // declaration of string variable
                    string flight, cash, location;
                    //if Fflight checkbox is checked
                    if (chkFlight.Checked== true)
                    {
                        flight = "\nflight Included" ;
                    }
                    else //condition false
                    {
                        flight = "";
                    }
                    //if cash radio button is checked
                    if (radCash.Checked == true)
                    {
                         cash = "\nCash Discount Applied";
                    }
                    else //condition false
                    {
                        cash = "";
                    }
                    //if cuba radio button is checked
                    if (radCuba.Checked == true)
                    {
                        location = "Cuba";
                    }
                    //if florida radio button is checked
                    else if (radFlorida.Checked == true)
                    {
                        location = "Florida";
                    }
                    else // conditions false
                    {
                        location = "Mexico";
                    }
                    //Display information groupbox
                    grpInformation.Show();
                    //display the msg
                    lblInformation.Text ="Booked by Edwin Tienteu \n\nPeople:  " + num1.ToString("d2") +
                        "\nLocation: " + location.ToUpper() + 
                         flight + cash + "\nPrice: " + numx.ToString("c");
                    // disable book groupbox 
                    grpBook.Enabled = false;
                }
                else // conditions false
                {
                    // call the DisplayMsg function to display the msg and title 
                    DisplayMsg("People must be between 1-10", "Input Error");
                    //Put the cursor on the txtbox
                    txtPeople.Focus();
                    // highlight the txtbox content
                    txtPeople.SelectAll();
                }
            }
            else // conditions false
            {
                // call the DisplayMsg function to display the msg and title 
                DisplayMsg("People must be a whole number", "Input Error");
                //Put the cursor on the txtbox
                txtPeople.Focus();
                // highlight the txtbox content
                txtPeople.SelectAll();
            }
            
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // variable store whatever was the price
            string numx = lblPrice.Text;
            // call the DisplayMsg function to display the msg and title
            DisplayMsg("Trip booked and paid\n Price: " + numx, "Confirmation Email Sent");
            // enable the book groupbox
            grpBook.Enabled =true;
            // call the ResetTrip function
            ResetTrip();
        }
    }
}
