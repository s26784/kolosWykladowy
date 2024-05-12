using KolosGago.DTO;
using KolosGago.Interfaces;
using KolosGago.Models;

namespace KolosGago.Services;

public class PrescriptionsService : IPrescriptionsService
{
    private IPrescriptionsRepository _prescriptionsRepository;

    public PrescriptionsService(IPrescriptionsRepository prescriptionsRepository)
    {
        _prescriptionsRepository = prescriptionsRepository;
    }

    public Task<Prescription> AddPrescriptionAsync(PrescriptionDTO prescriptionDto)
    {
        return _prescriptionsRepository.AddPrescriptionAsync(prescriptionDto);
    }

    public Task<List<List<string>>> GetPrescriptionsAsync(string doctorLastName)
    {
        return _prescriptionsRepository.GetPrescriptionsAsync(doctorLastName);
    }
}