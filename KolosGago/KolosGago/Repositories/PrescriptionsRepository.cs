using System.Data.SqlClient;
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

    public async Task<List<string>> GetPrescriptionsAsync(string doctorLastName)
    {
        using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
        {
            var nameFilter = FilterByNameAsync(doctorLastName);
            await using var command = new SqlCommand();
            command.CommandText = "SELECT * FROM PRESCRIPTION p JOIN Doctor d ON p.IdDoctor = d.IdDoctor JOIN Patient pt ON pt.IdPatient = p.IdPatient" + nameFilter + " ORDER BY DESCENDING";
            command.Connection = connection;
            await connection.OpenAsync();
            List<Prescription> prescriptions = new List<Prescription>();
            var dr = await command.ExecuteReaderAsync();
            while (dr.ReadAsync().Result)
            {
                int idPrescription = (int)dr["IdPrescription"];
                string date
            }


        }
        
    }
    
    public async Task<Prescription> AddPrescriptionAsync(PrescriptionDTO prescriptionDto)
    {
        throw new NotImplementedException();
    }

    public async Task<string> FilterByNameAsync(string doctorLastName)
    {
        var doctorsLastNames = await GetDoctorsLastNames();
        if (doctorsLastNames.Contains(doctorLastName.ToLower()))
        {
            string correctedName = char.ToUpper(doctorLastName[0]) + doctorLastName.Substring(1);
            return " WHERE LastName = " + correctedName;
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
            command.CommandText = "SELECT LastName FROM Doctor";
            await connection.OpenAsync();
            await using SqlDataReader dataReader = await command.ExecuteReaderAsync();
            while (dataReader.ReadAsync().Result)
            {
                string name = (string)dataReader["LastName"];
                lastNamesList.Add(name.ToLower());
            }
        }
        return lastNamesList;
    }
    
}