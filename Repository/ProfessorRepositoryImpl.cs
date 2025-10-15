using ProfessorList.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProfessorList.Repository
{
    public class ProfessorRepositoryImpl : IProfessorRepository
    {
        private readonly string connectionString;

        public ProfessorRepositoryImpl(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("MVCConnectionString");
        }
        #region List of All Professor
        public IEnumerable<Professor> SelectAllProfessor()
        {
            List<Professor> professors = new List<Professor>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllProfessor", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader()) // Use SqlDataReader
                {
                    while (reader.Read())
                    {
                        Professor pro = new Professor
                        {
                            ProfessorId = Convert.ToInt32(reader["ProfessorId"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            Gender = reader["Gender"].ToString(),
                            Salary = Convert.ToDecimal(reader["Salary"]),
                            JoinDate = Convert.ToDateTime(reader["JoinDate"]),
                            HOD = reader["HOD"].ToString(),

                            // Nested Department Object
                            Department = new Department
                            {
                                DepartmentName = reader["DepartmentName"].ToString()
                            }
                        };

                        professors.Add(pro); // Add to the list
                    }
                }
                con.Close();
            }

            return professors; // Return the list
        }
        #endregion 
        #region Add Professor
        public void InsertProfessor(Professor professor)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AddProfessor", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", professor.FirstName);
                cmd.Parameters.AddWithValue("@LastName", professor.LastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", professor.DateOfBirth);
                cmd.Parameters.AddWithValue("@Gender", professor.Gender);
                cmd.Parameters.AddWithValue("@Salary", professor.Salary);
                cmd.Parameters.AddWithValue("@JoinDate", professor.JoinDate);
                cmd.Parameters.AddWithValue("@HOD", professor.HOD);
                cmd.Parameters.AddWithValue("@DepartmentId", professor.DepartmentId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        #endregion
        #region All Departmment
        public List<Department> SelectAllDepartment()
        {
            List<Department> departments = new List<Department>();
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_SelectAllDepartment", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Department department = new Department
                        {
                            DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                            DepartmentName = Convert.ToString(reader["DepartmentName"])

                        };
                        departments.Add(department);
                    }
                }
                con.Close();
            }
            return departments;
        }

        #endregion
        #region Update Professor
        public void UpdateProfessor(Professor professor)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_EditProfessor", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProfessorId", professor.ProfessorId);
                cmd.Parameters.AddWithValue("@FirstName", professor.FirstName);
                cmd.Parameters.AddWithValue("@LastName", professor.LastName);
                cmd.Parameters.AddWithValue("@Salary", professor.Salary);
                cmd.Parameters.AddWithValue("@DateOfBirth", professor.DateOfBirth);
                cmd.Parameters.AddWithValue("@Gender", professor.Gender);
                cmd.Parameters.AddWithValue("@JoinDate", professor.JoinDate);
                cmd.Parameters.AddWithValue("@HOD", professor.HOD);
                cmd.Parameters.AddWithValue("@DepartmentId", professor.DepartmentId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


            }
        }
        #endregion
        #region Search Professor By Id
        public Professor SelectProfessorById(int? ProfessorId)
        {
            Professor professor = new Professor();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetProfessorById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProfessorId", ProfessorId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    professor.ProfessorId = Convert.ToInt32(dr["ProfessorId"].ToString());
                    professor.FirstName = dr["FirstName"].ToString();
                    professor.LastName = dr["LastName"].ToString();
                    professor.Salary = Convert.ToDecimal(dr["Salary"]);
                    professor.DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]);
                    professor.Gender = dr["Gender"].ToString();
                    professor.JoinDate = Convert.ToDateTime(dr["JoinDate"]);
                    professor.HOD = dr["HOD"].ToString();
                    professor.DepartmentId = Convert.ToInt32(dr["DepartmentId"].ToString());



                }
                con.Close();
            }
            return professor;
        }
        #endregion

    }
}

