using KolosGago.DTO;
using KolosGago.Interfaces;
using KolosGago.Models;
using KolosGago.Services;
using Microsoft.AspNetCore.Mvc;

namespace KolosGago.Controllers;
[Route("api/prescriptions")]
[ApiController]

public class PrescriptionsController : ControllerBase
{
    private IPrescriptionsService _prescriptionsService;

    public PrescriptionsController(IPrescriptionsService prescriptionsService)
    {
        _prescriptionsService = prescriptionsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPrescriptionsAsync(string doctorLastName = "default")
    {
        var prescriptionsList = await _prescriptionsService.GetPrescriptionsAsync(doctorLastName);
        return Ok(prescriptionsList);
    }
    
    [HttpPost]
    public async Task<Prescription> AddPrescriptionAsync(PrescriptionDTO prescriptionDto)
    {
        var prescriptionAdded = await _prescriptionsService.AddPrescriptionAsync(prescriptionDto);
        return prescriptionAdded;
    }
    
    
    
}