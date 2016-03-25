﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmaTicaWebService.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace FarmaTicaWebService.DataBase
{
    public class DoctorsAccess
    {
        public List<Doctor> getAllDoctors()
        {
            List<Doctor> listDoctores = new List<Doctor>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "select NoDoctor,Cedula,Nombre,Apellido,FechaNacimiento,Residencia from doctor ; ", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) //si existe en la base de datos
                {
                    Doctor doctor = new Doctor();
                    doctor.NoDoctor = Convert.ToInt32(rdr["NoDoctor"]);
                    doctor.Cedula = rdr["Cedula"].ToString();
                    doctor.Nombre = rdr["Nombre"].ToString();
                    doctor.Apellido = rdr["Apellido"].ToString();
                    doctor.FechaNacimiento = rdr["FechaNacimiento"].ToString();
                    doctor.Residencia = rdr["Residencia"].ToString();
                    listDoctores.Add(doctor);
                }
            }
            return listDoctores;

        }
        public Doctor addDoctor(Doctor doctor)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "insert into doctor (NoDoctor,Cedula,Nombre,Apellido,FechaNacimiento,Residencia)" +
                    " values("+doctor.NoDoctor+ ", '"+doctor.Cedula+"', '"+doctor.Nombre+"', '"+doctor.Apellido+"', '"+doctor.FechaNacimiento+"', '"+doctor.Residencia+"'); "
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            return doctor;
        }
        public Doctor updateDoctor(int NoDoctor, Doctor doctor)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Doctor SET Cedula = '"+doctor.Cedula+"', Nombre = '"+doctor.Nombre+"', Apellido = '"+doctor.Apellido+"', FechaNacimiento = '"+doctor.FechaNacimiento+"', Residencia = '"+doctor.Residencia+"' "
                    +" WHERE NoDoctor = "+NoDoctor+" ; "
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            return doctor;
        }
        public void deleteDoctor(int NoDoctor)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM DOCTOR WHERE NoDoctor = "+ NoDoctor + " ; "
                    , con);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}