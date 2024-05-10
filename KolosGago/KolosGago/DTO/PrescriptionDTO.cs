namespace KolosGago.DTO;

public record PrescriptionDTO
{
    int IdPrescription { get; set; }
    DateTime Date { get; set; }
    int IdPatient { get; set; }
    int IdDoctor { get; set; }
}