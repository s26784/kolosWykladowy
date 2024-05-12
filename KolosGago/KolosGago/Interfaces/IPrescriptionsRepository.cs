using KolosGago.DTO;
using KolosGago.Models;

namespace KolosGago.Interfaces;

public interface IPrescriptionsRepository
{
    Task<Prescription> AddPrescriptionAsync(PrescriptionDTO prescriptionDto);
    Task<List<List<string>>> GetPrescriptionsAsync(string doctorLastName);

}