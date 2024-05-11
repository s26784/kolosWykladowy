using KolosGago.DTO;
using KolosGago.Models;
using Microsoft.AspNetCore.Mvc;

namespace KolosGago.Interfaces;

public interface IPrescriptionsService
{
    Task<Prescription> AddPrescriptionAsync(PrescriptionDTO prescriptionDto);
    Task<string> GetPrescriptionsAsync(string doctorLastName);
}