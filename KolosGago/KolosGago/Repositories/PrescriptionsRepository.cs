﻿using System.Data.SqlClient;
using KolosGago.DTO;
using KolosGago.Interfaces;
using KolosGago.Models;

namespace KolosGago.Repositories;

public class PrescriptionsRepository : IPrescriptionsRepository
{
    private IConfiguration _configuration;

    public PrescriptionsRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<List<List<string>>> GetPrescriptionsAsync(string doctorLastName)
    {
        using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
        {
            var nameFilter = FilterByNameAsync(doctorLastName).Result;
            
            
            
            await using var command = new SqlCommand();
            command.CommandText = "SELECT IdPrescription, Date, DueDate, pt.LastName AS PatientLastName, d.LastName AS DoctorLastName FROM PRESCRIPTION p JOIN Doctor d ON p.IdDoctor = d.IdDoctor JOIN Patient pt ON pt.IdPatient = p.IdPatient" + nameFilter + " ORDER BY d.LastName DESC";
            command.Connection = connection;
            await connection.OpenAsync();
            var returnList = new List<List<string>>();
            await using SqlDataReader dr = await command.ExecuteReaderAsync();
            while (await dr.ReadAsync())
            {
                
                
                string idPrescription = Convert.ToString(dr["IdPrescription"]);
                DateTime dateTimeValue = (DateTime)dr["Date"];
                string date = dateTimeValue.ToString("yyyy-MM-dd");
                DateTime dateDue = (DateTime)dr["DueDate"];
                string dueDate = dateDue.ToString("yyyy-MM-dd");
                string patientLastname = (string)dr["PatientLastName"];
                string doctorLastname = (string)dr["DoctorLastName"];
                
                
                
                List<string> prescriptionInfo = new List<string>();
                prescriptionInfo.Add(idPrescription);
                prescriptionInfo.Add(date);
                prescriptionInfo.Add(dueDate);
                prescriptionInfo.Add(patientLastname);
                prescriptionInfo.Add(doctorLastname);
                returnList.Add(prescriptionInfo);
            }
            return returnList;
        }
    }
    
    public async Task<Prescription> AddPrescriptionAsync(PrescriptionDTO prescriptionDto)
    {
        throw new NotImplementedException();
    }

    public async Task<string> FilterByNameAsync(string doctorLastName)
    {
        var doctorsLastNames = GetDoctorsLastNames().Result;
        if (doctorsLastNames.Contains(doctorLastName.ToLower()))
        {
            string correctedName = char.ToUpper(doctorLastName[0]) + doctorLastName.Substring(1);
            return " WHERE d.LastName = '" + correctedName + "'";
        }
        if(doctorLastName.Equals("default"))
        {
            return " WHERE 1 = 1";
        }

        throw new InvalidDataException("There isn't any doctor with that LastName...");
    }

    public async Task<List<string>> GetDoctorsLastNames()
    {
        List<string> lastNamesList = new List<string>();
        using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
        {
            await using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT LastName FROM Doctor ";
            await connection.OpenAsync();
            await using SqlDataReader dataReader = await command.ExecuteReaderAsync();
            while (await dataReader.ReadAsync())
            {
                string name = (string)dataReader["LastName"];
                lastNamesList.Add(name.ToLower());
            }
        }
        return lastNamesList;
    }
    
}