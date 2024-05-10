using KolosGago.DTO;
using KolosGago.Models;
using KolosGago.Services;
using Microsoft.AspNetCore.Mvc;

namespace KolosGago.Controllers;
[Route("api/prescriptions")]
[ApiController]

public class PrescriptionsController : ControllerBase
{
    private PrescriptionsService _prescriptionsService;

    public PrescriptionsController(PrescriptionsService prescriptionsService)
    {
        _prescriptionsService = prescriptionsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPrescriptionsAsync(string doctorLastName)
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