using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using StaffManagement.DTO;
using StaffManagement.Models;

namespace Procedure
{
    public class SQLProcedure
    {
        private IConfiguration config;
        public SQLProcedure(IConfiguration _config)
        {
            this.config = _config;
        }

        public async Task<int> Insert(StaffUpdateDTO staff)
        {
            SqlConnection connection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();
            SqlCommand cmd = new SqlCommand(@"dbo.[InsertData]", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", SqlDbType.NVarChar).Value = staff.UserName;
            cmd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = staff.Password;
            cmd.Parameters.AddWithValue("@Experience", SqlDbType.Int).Value = staff.Experience;
            cmd.Parameters.AddWithValue("@DateOfJoining", SqlDbType.DateTime).Value = staff.DateOfJoining;
            cmd.Parameters.AddWithValue("@PhoneNumber", SqlDbType.NVarChar).Value = staff.PhoneNumber;
            cmd.Parameters.AddWithValue("@Subject", SqlDbType.NVarChar).Value = staff.Subject;
            cmd.Parameters.AddWithValue("@Type", SqlDbType.NVarChar).Value = staff.Type;
            int res = cmd.ExecuteNonQuery();
            connection.Close();
            return res;

        }

        public async Task<int> Update(int id, StaffUpdateDTO staff)
        {
            SqlConnection connection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();
            SqlCommand cmd = new SqlCommand(@"dbo.[UpdateData]", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
            cmd.Parameters.AddWithValue("@UserName", SqlDbType.NVarChar).Value = staff.UserName;
            cmd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = staff.Password;
            cmd.Parameters.AddWithValue("@Experience", SqlDbType.Int).Value = staff.Experience;
            cmd.Parameters.AddWithValue("@DateOfJoining", SqlDbType.DateTime).Value = staff.DateOfJoining;
            cmd.Parameters.AddWithValue("@PhoneNumber", SqlDbType.NVarChar).Value = staff.PhoneNumber;
            cmd.Parameters.AddWithValue("@Subject", SqlDbType.NVarChar).Value = staff.Subject;
            cmd.Parameters.AddWithValue("@Type", SqlDbType.NVarChar).Value = staff.Type;
            int res = cmd.ExecuteNonQuery();
            connection.Close();
            return res;
        }

        public async Task<List<Staff>> GetAllData()
        {
            DataTable table = new DataTable();
            List<Staff> staffs = new List<Staff>();
            SqlConnection connection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();
            SqlCommand cmd = new SqlCommand(@"dbo.[GetData]", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(table);
            foreach (DataRow row in table.Rows)
            {
                staffs.Add(
                    new Staff
                    {
                        Id = Convert.ToInt32(row["Id"].ToString()),
                        UserName = row["Username"].ToString(),
                        Password = row["Password"].ToString(),
                        Experience = Convert.ToInt32(row["Experience"].ToString()),
                        DateOfJoining = DateTime.Parse(row["DateOfJoining"].ToString()),
                        Subject = row["Subject"].ToString(),
                        PhoneNumber = row["PhoneNumber"].ToString(),
                        Type = row["Type"].ToString()
                    }
                );
            }

            return staffs;

        }

        public async Task<Staff> Login(LogonDTO logon)
        {
            SqlConnection connection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();
            SqlCommand cmd = new SqlCommand(@"dbo.[Login]", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", SqlDbType.NVarChar).Value = logon.UserName;
            cmd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = logon.Password;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {         
                return new Staff
                {
                    Id = reader.GetInt32(0),
                    UserName = reader.GetString(1),
                    Password = reader.GetString(2),
                    DateOfJoining = reader.GetDateTime(4),
                    Experience = reader.GetInt32(3),
                    PhoneNumber = reader.GetString(5),
                    Subject = reader.GetString(6),
                    Type = reader.GetString(7)
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<Staff> GetDataOfId(int id)
        {
            SqlConnection connection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();
            SqlCommand cmd = new SqlCommand(@"dbo.[GetWithId]", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = id;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {      
                return new Staff
                {
                    Id = reader.GetInt32(0),
                    UserName = reader.GetString(1),
                    Password = reader.GetString(2),
                    DateOfJoining = reader.GetDateTime(4),
                    Experience = reader.GetInt32(3),
                    PhoneNumber = reader.GetString(5),
                    Subject = reader.GetString(6),
                    Type = reader.GetString(7)
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<int> DeleteDataOfId(int id)
        {
            SqlConnection connection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();
            SqlCommand cmd = new SqlCommand(@"dbo.[DeleteWithId]", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
            return cmd.ExecuteNonQuery(); ;
        }

    }
}