using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intepro.DataAccess;       
using System.Data.SqlClient;

namespace Student_Record.Models
{
    public class StudentModel
    {
        public long ID { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public int Year { get; set; }
        public string Course { get; set; }

        private DAL dl = new DAL();

        public void Add()
        {
            dl.Open();
            dl.SetSql("INSERT INTO Students VALUES (@id, @ln, @fn, @yr, @c)");
            dl.AddParam("@id", ID);
            dl.AddParam("@ln", Lastname);
            dl.AddParam("@fn", Firstname);
            dl.AddParam("@yr", Year);
            dl.AddParam("@c", Course);
            dl.Execute();
            dl.Close();
        }

        public void Delete()
        {
            dl.Open();
            dl.SetSql("DELETE Students WHERE StudentID = @id");
            dl.AddParam("@id", ID);
            dl.Execute();
            dl.Close();
        }

        public List<StudentModel> Get()
        {
            List < StudentModel > list = new List<StudentModel>();
            dl.Open();
            dl.SetSql("SELECT * FROM Students");
            SqlDataReader dr = dl.GetReader();
            while (dr.Read() == true)
            {
                StudentModel s = new StudentModel();
                s.ID = (long)dr[0];
                s.Lastname = dr[1].ToString();
                s.Firstname = dr[2].ToString();
                s.Year = (int)dr[3];
                s.Course = dr[4].ToString();
                list.Add(s);
            }
            dr.Close();
            dl.Close();
            return list;
        }

        public StudentModel GetStudent()
        {
            StudentModel stm = new StudentModel();
            dl.Open();
            dl.SetSql("SELECT * FROM Students WHERE StudentID = @id");
            dl.AddParam("@id", ID);
            SqlDataReader dr = dl.GetReader();
            if (dr.Read() == true)
            {
                stm.ID = (long)dr[0];
                stm.Lastname = dr[1].ToString();
                stm.Firstname = dr[2].ToString();
                stm.Year = (int)dr[3];
                stm.Course = dr[4].ToString();
            }
            dr.Close();
            dl.Close();
            return stm;
        }

        public void Update()
        {
            dl.Open();
            dl.SetSql("UPDATE Students SET StudentID = @id, Lastname = @ln, Firstname = @fn, Year = @yr, Course = @c WHERE StudentID = @id");
            dl.AddParam("@id", ID);
            dl.AddParam("@ln", Lastname);
            dl.AddParam("@fn", Firstname);
            dl.AddParam("@yr", Year);
            dl.AddParam("@c", Course);
            dl.Execute();
            dl.Close();
        }
    }
}