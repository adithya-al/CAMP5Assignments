using PatientsRegistration.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Reflection;

namespace PatientsRegistration.Repository
{
    public class PatientRepositoryImpl : IPatientRepository
    {
        private readonly string connectionString;

        public PatientRepositoryImpl(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("MVCConnectionString");
        }
        #region Create Patient

        public void InsertPatient(Patients patient)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AddPatient", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RegisterNo", patient.RegisterNo);
                cmd.Parameters.AddWithValue("@PatientName", patient.PatientName);
                cmd.Parameters.AddWithValue("@DOB", patient.DOB);
                cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                cmd.Parameters.AddWithValue("@Address", patient.Address);
                cmd.Parameters.AddWithValue("@PhoneNo", patient.PhoneNo);
                cmd.Parameters.AddWithValue("@MemberId", patient.MemberId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


               
            }
        }
        #endregion
        #region List All Patients
        public IEnumerable<Patients> SelectAllPatients()
        {
            List<Patients> patients = new List<Patients>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllPatients", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Patients pat = new Patients
                        {
                            PatientId = Convert.ToInt32(reader["PatientId"]),
                            RegisterNo = reader["RegisterNo"].ToString(),
                            PatientName = reader["PatientName"].ToString(),
                            DOB = Convert.ToDateTime(reader["DOB"]),
                            Gender = reader["Gender"].ToString(),
                            Address = reader["Address"].ToString(),
                            PhoneNo = reader["PhoneNo"].ToString(),
                            MemberId = Convert.ToInt32(reader["MemberId"]),

                            // Nested Membership object
                            Membership = new Membership
                            {
                                MemberId = Convert.ToInt32(reader["MemberId"]),
                                MemberDescrip = reader["MemberDescrip"].ToString(),
                                InsureAmt = Convert.ToDecimal(reader["InsureAmt"])
                            }
                        };

                        patients.Add(pat);
                    }
                }
                con.Close();
            }

            return patients;
        }
        #endregion
        #region Get All menberships
        public List<Membership> SelectAllMembership()
        {
            List<Membership> memberships = new List<Membership>();
            using(SqlConnection con=new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_SelectAllMembership",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                using(SqlDataReader reader=cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Membership membership = new Membership
                        {
                            MemberId = Convert.ToInt32(reader["MemberId"]),
                            MemberDescrip = Convert.ToString(reader["MemberDescrip"]),
                            InsureAmt = Convert.ToDecimal(reader["InsureAmt"])
                        };
                        memberships.Add(membership);
                    }
                }
                con.Close();
            }
            return memberships;
        }
        #endregion
        #region 
        public void UpdatePatient(Patients patients)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_EditPatient", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PatientId", patients.PatientId);
                cmd.Parameters.AddWithValue("@RegisterNo", patients.RegisterNo);
                cmd.Parameters.AddWithValue("@PatientName", patients.PatientName);
                cmd.Parameters.AddWithValue("@DOB", patients.DOB);
                cmd.Parameters.AddWithValue("@Gender", patients.Gender);
                cmd.Parameters.AddWithValue("@Address", patients.Address);
                cmd.Parameters.AddWithValue("@PhoneNo", patients.PhoneNo);
                cmd.Parameters.AddWithValue("@MemberId", patients.MemberId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
       
        #endregion
        #region Search Patient By Id
        public Patients SelectPatientById(int? PatientId)
        {
            Patients patients = new Patients();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetPatientById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PatientId", PatientId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    patients.PatientId = Convert.ToInt32(dr["PatientId"].ToString());
                    patients.RegisterNo = dr["RegisterNo"].ToString();
                    patients.PatientName = dr["PatientName"].ToString();
                    patients.DOB = Convert.ToDateTime(dr["DOB"]);
                    patients.Gender = dr["Gender"].ToString();
                    patients.Address = dr["Address"].ToString();
                    patients.PhoneNo = dr["PhoneNo"].ToString();
                    patients.MemberId = Convert.ToInt32(dr["MemberId"].ToString());



                }
                con.Close();
            }
            return patients;
        }
        #endregion

    }
}


