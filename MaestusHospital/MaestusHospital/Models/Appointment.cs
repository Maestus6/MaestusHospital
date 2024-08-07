namespace MaestusHospital.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; } = string.Empty;

        //Foreign keys
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;

        //Appointment status (scheduled, completed, canceled)
        public string Status { get; set; } = "Scheduled";
    }
}
