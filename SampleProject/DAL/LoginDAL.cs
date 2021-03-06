﻿
using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
//using Oracle.DataAccess;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;

namespace SampleProject.DAL
{
    public class LoginDAL
    {
        internal DataTable Check(string user, string pass)
        {
            var userName="";
            var password="";
            string[] res = new string[10];
            //SqlConnection objcon = new SqlConnection();
            //objcon.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
            //objcon.Open();
            SqlCommand cmd;
            
            
            SqlConnection con = GlobalConnection.getConnection();
            cmd = new SqlCommand("CheckUSerExistence", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@User", user);
            cmd.Parameters.Add("@pass", pass);
<<<<<<< HEAD
=======

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable DS = new DataTable();
            sd.Fill(DS);

            //GlobalConnection conn = new GlobalConnection();
            //OracleCommand cmd = new OracleCommand();
            //cmd.Connection = conn.getConnection();
            //cmd.CommandText = "CheckUSerExistence";
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Transaction = null;
            //cmd.Parameters.Add("User", OracleDbType.Varchar2).Value = user;
            //cmd.Parameters.Add("pass", OracleDbType.Varchar2).Value = pass;
            //cmd.Parameters.Add("p_resultset", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //OracleDataAdapter da = new OracleDataAdapter(cmd);
            //DataSet DS = new DataSet();
            //da.Fill(DS);
            // conn.Close();
            foreach (DataRow dR in DS.Rows)
            {
>>>>>>> 134391b1a4dd6d0125334e8aad2f6f86a7809c89

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable DS = new DataTable();
            sd.Fill(DS);
            //foreach (DataRow dR in DS.Rows)
            //{

            //    userName = Convert.ToString(dR["userName"]);
            //    password = Convert.ToString(dR["password"]);

            //}

            //if ((userName == user) && (password == pass))  //when you click login
            //{
            //    res[0] = "1";
            //}




            return DS;
        }

        internal string[] Register(LoginModel regLog)
        {
            string[] status = new string[10];
            SqlConnection objcon = new SqlConnection();
            objcon.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
            SqlCommand cmd=null;
            objcon.Open();
            //GlobalConnection conn = new GlobalConnection();
            //OracleCommand cmd = new OracleCommand();
            //cmd.Connection = conn.getConnection();
<<<<<<< HEAD
            //status = Check(regLog.userName, regLog.password);
=======
            status = Check(regLog.userName, regLog.password);
>>>>>>> 134391b1a4dd6d0125334e8aad2f6f86a7809c89
            if (status[0] == "1")
            {
                status[1] = "Exists";
            }
            else
            {

                //cmd = new SqlCommand("AddUser", objcon);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddUser";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = null;
                cmd.Parameters.Add("p_User", OracleDbType.Varchar2).Value = regLog.userName;
                cmd.Parameters.Add("p_pass", OracleDbType.Varchar2).Value = regLog.password;
                cmd.Parameters.Add("p_firstname", OracleDbType.Varchar2).Value = regLog.FirstName;
                cmd.Parameters.Add("p_lastname", OracleDbType.Varchar2).Value = regLog.LastName;
                cmd.Parameters.Add("p_middlename", OracleDbType.Varchar2).Value = regLog.MiddleName;
                cmd.Parameters.Add("p_mobile", OracleDbType.Long).Value = regLog.MobileNO;
                cmd.Parameters.Add("p_address", OracleDbType.Varchar2).Value = regLog.Address;
                cmd.Parameters.Add("p_lastlogindate", OracleDbType.Date).Value = DateTime.Now;

                cmd.ExecuteNonQuery();
                status[1] = "User Added";

            }


            return status;

        }
    }
}