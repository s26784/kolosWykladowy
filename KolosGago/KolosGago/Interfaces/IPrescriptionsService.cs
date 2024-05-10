using KolosGago.DTO;
using KolosGago.Models;

namespace KolosGago.Interfaces;

public interface IPrescriptionsService
{
    Task<Prescription> AddPrescriptionAsync(PrescriptionDTO prescriptionDto);
    Task<List<Prescription>> GetPrescriptionsAsync(string doctorLastName);
}