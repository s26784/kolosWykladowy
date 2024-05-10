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

    public Task<Prescription> AddPrescriptionAsync(PrescriptionDTO prescriptionDto)
    {
        throw new NotImplementedException();
    }

    public Task<List<Prescription>> GetPrescriptionsAsync(string doctorLastName)
    {
        throw new NotImplementedException();
    }
}cs