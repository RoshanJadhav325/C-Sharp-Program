using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace YC_Student_Management_System
{
    public partial class frm_Add_New_Student_Details : Form
    {
        public frm_Add_New_Student_Details()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=YC_Student_Management_System;Integrated Security=True");

        void con_open()
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
        }
        void con_close()
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
        }

        private void Only_Numeric(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void Only_Text(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {
                e.Handled = true;

            }
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            con_open();

            if (tb_Roll_No.Text != "" && tb_Name.Text != "" && tb_Mobile_No.TextLength == 10 && cmb_Course.Text != "")
            {
                con_open();

                SqlCommand Cmd = new SqlCommand();

                Cmd.Connection = con;
                Cmd.CommandText = "Insert into Student_List(Roll_No,Name,DOB,Mobile_No,Course) Values(@Rno,@Nm,@Dob,@Mn,@Course) ";

                Cmd.Parameters.Add("Rno",SqlDbType.Int).Value = tb_Roll_No.Text;
                Cmd.Parameters.Add("Nm", SqlDbType.VarChar).Value = tb_Name.Text;
                Cmd.Parameters.Add("Dob", SqlDbType.Date).Value = dtp_DOB.Value.Date;
                Cmd.Parameters.Add("Mn", SqlDbType.Decimal).Value = tb_Mobile_No.Text;
                Cmd.Parameters.Add("Course", SqlDbType.NVarChar).Value = cmb_Course.Text;

                Cmd.ExecuteNonQuery();

                MessageBox.Show("Record Inserted Successfully ", "Successfull", MessageBoxButtons.OK,MessageBoxIcon.Information);

                tb_Name.Text = "";
                tb_Roll_No.Text = "";
                tb_Mobile_No.Text = "";
                dtp_DOB.Text = "";
                cmb_Course.SelectedIndex = -1;

                
                con_close();
            }
            else
            {
                MessageBox.Show("First fill all fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con_close();
        }


       


        private void btn_View_Student_List_Click(object sender, EventArgs e)
        {
            frm_View_Student_List obj = new frm_View_Student_List();
            obj.Show();
            this.Hide();
        }

        private void btn_Log_Out_Click(object sender, EventArgs e)
        {
            frm_Login obj = new frm_Login();
            obj.Show();
            this.Hide();
        }

      
    }
}
        
