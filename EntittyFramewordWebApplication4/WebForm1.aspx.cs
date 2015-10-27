using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EntittyFramewordWebApplication4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int m =int.Parse(TextBox1.Text);
            EMSEntities dbcontext=new EMSEntities();
            var stud = from dd in dbcontext.StudentDetails 
            where
            dd.marks > m && dd.section == "A"
                       select dd;

            //string s = "Output";
            DataTable dt=new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            dt.Columns.Add("address");
            dt.Columns.Add("section");
            dt.Columns.Add("marks");
            foreach (var student  in stud)
            {
                DataRow r = dt.NewRow();
                r[0] = student.id;
                r[1] = student.name;
                r[2] = student.address;
                r[3] = student.section;
                r[4] = student.marks;
                //r[0] = "id";
                //r[1] = "name";
                //r[2] = "address";
                //r[3] = "section";
                //r[4] = 4;


                dt.Rows.Add(r);
                //s = s + "ID:" + student.id;
                //s = s + "name:" + student.name;
                //s = s + "Section::" + student.section;

            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            //Label1.Text = s;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            EMSEntities Context=new EMSEntities();

           
            EntittyFramewordWebApplication4.StudentDetail stud1=new StudentDetail();
            stud1.id = "67";
            stud1.name = "ziauddin";
            stud1.address = "chittagong";
            stud1.marks = 88;
            stud1.section = "C";
            Context.StudentDetails.Add(stud1);
            Context.SaveChanges();
            Label1.Text = "added";


        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string id = TextBox2.Text;
            EMSEntities dbcontext = new EMSEntities();
            var stud = from dd in dbcontext.StudentDetails
                       where dd.id==id select dd;
            bool flag = false;
            foreach (var student in stud)
            {
                TextBox3.Text = student.name;
                TextBox4.Text = student.address;
                TextBox5.Text = student.section;
                TextBox6.Text = student.marks.ToString();
                flag = true;

            }
            if (flag == false)
                Label1.Text = "not found";
            else
            {
                Label1.Text = "found";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            EMSEntities dbcontext = new EMSEntities();
            EntittyFramewordWebApplication4.StudentDetail stud1 = new StudentDetail();
            try

            {
                string idd = TextBox2.Text;
            
            stud1 = dbcontext.StudentDetails.FirstOrDefault(xx => xx.id == idd);
            stud1.marks = int.Parse(TextBox6.Text);
            stud1.section = TextBox5.Text;
            dbcontext.SaveChanges();
            Label1.Text = "updated successfull";
        }
            catch(Exception e1)
            {
                Label1.Text = "not found";
            }
            

    }

        protected void Button4_Click(object sender, EventArgs e)
        {
            EMSEntities dbcontext = new EMSEntities();
            EntittyFramewordWebApplication4.StudentDetail stud1 = new StudentDetail();
            try
            {
                string idd = TextBox2.Text;

                stud1 = dbcontext.StudentDetails.FirstOrDefault(xx => xx.id == idd);
                dbcontext.StudentDetails.Remove(stud1);
                dbcontext.SaveChanges();
                Label1.Text = "delated successfull";
            }
            catch (Exception e1)
            {
                Label1.Text = "not found";
            }

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            //int m = int.Parse(TextBox1.Text);
            EMSEntities dbcontext = new EMSEntities();
            var stud = from dd in dbcontext.StudentDetails
                    
                      select dd;

            //string s = "Output";
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            dt.Columns.Add("address");
            dt.Columns.Add("section");
            dt.Columns.Add("marks");
            foreach (var student in stud)
            {
                DataRow r = dt.NewRow();
                r[0] = student.id;
                r[1] = student.name;
                r[2] = student.address;
                r[3] = student.section;
                r[4] = student.marks;
               
                //r[0] = "id";
                //r[1] = "name";
                //r[2] = "address";
                //r[3] = "section";
                //r[4] = 4;


                dt.Rows.Add(r);
                //s = s + "ID:" + student.id;
                //s = s + "name:" + student.name;
                //s = s + "Section::" + student.section;

            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            //EMSEntities dbcontext = new EMSEntities();
            //emp e1 = new emp();
            //e1.empId = int.Parse(TextBox2.Text);
            //e1.name = TextBox4.Text;
            //e1.deptno = int.Parse(TextBox5.Text);
            //e1.job = TextBox5.Text;
            //e1.salary = int.Parse(TextBox6.Text);
            //dbcontext.emps.Add(e1);
            //dbcontext.SaveChanges();
            //Label1.Text = "added from emp table";
            EMSEntities dbcontext = new EMSEntities();
            emp e1 = new emp();
            e1.empId = 786;
            e1.name = "pabel";
            e1.deptno = 56;
            e1.job = "hr";
            e1.salary = 6700;
            dbcontext.emps.Add(e1);
            dbcontext.SaveChanges();
            Label1.Text = "added from emp table";
        }




        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
}