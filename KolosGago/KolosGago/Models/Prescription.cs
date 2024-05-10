using System.Runtime.InteropServices.JavaScript;

namespace KolosGago.Models;

public class Prescription
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public int IdPatient { get; set; }
    public int IdDoctor { get; set; }
}