namespace MaestusHospital.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty; //Planning to use them hashed
        public string Role { get; set; } = "User"; //Admin, Doctor, Patient

        //Additional user information
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
