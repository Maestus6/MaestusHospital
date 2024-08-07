namespace MaestusHospital.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public DateTime BillDate { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public string PaymentMethod { get; set; } = "Cash";

        //Foreign key
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;
    }
}
