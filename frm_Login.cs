using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YC_Student_Management_System
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }

        private void btn_Submit_Click(object sender, EventArgs e)
       
        {
             if(tb_Username.Text == "Roshan" && tb_Password.Text=="3434")
            {
                MessageBox.Show("Login Successful", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frm_Add_New_Student_Details obj = new frm_Add_New_Student_Details();
                obj.Show();
                this.Hide();

            }
            else 
            {   
             
             lbl_Error.Text="Innvalid Username or Password";
             lbl_Error.ForeColor=Color.Red;
        }
             tb_Username.Clear();
             tb_Password.Clear();
    }

        

     
       
    }
}
      