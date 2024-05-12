using KolosGago.DTO;
using KolosGago.Models;
using Microsoft.AspNetCore.Mvc;

namespace KolosGago.Interfaces;

public interface IPrescriptionsService
{
    Task<Prescription> AddPrescriptionAsync(PrescriptionDTO prescriptionDto);
    Task<List<List<string>>> GetPrescriptionsAsync(string doctorLastName);
}