using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CollegeCRUD_ADO_.Models;

namespace CollegeCRUD_ADO_.Models.Repository
{
    public class StudentRepository
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["StudentADOEntities"].ToString();
            con = new SqlConnection(constr);
        }

        public bool AddStudent(Student stud)
        {
            connection();
            SqlCommand com = new SqlCommand("AddDetails", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Fname", stud.Fname);
            com.Parameters.AddWithValue("@MiddleName", stud.MiddleName);
            com.Parameters.AddWithValue("@LastName", stud.LastName);
            com.Parameters.AddWithValue("@DOB", stud.DOB);
            com.Parameters.AddWithValue("@GenderID", stud.GenderID);
            com.Parameters.AddWithValue("@isActive", stud.isActive);
            com.Parameters.AddWithValue("@isDeleted", stud.isDeleted);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<Gender> GetGenders()
        {
            connection();
            List<Gender> genders = new List<Gender>();
            SqlCommand com = new SqlCommand("GetGender", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                genders.Add(
                    new Gender
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Gname = Convert.ToString(dr["Gname"]),
                    }
                    );
            }
            return genders;
        }

    }
}