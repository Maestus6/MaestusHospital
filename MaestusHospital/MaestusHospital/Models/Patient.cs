﻿using MaestusHospital.Models;

namespace MaestusHospital.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MedicalHistory { get; set; } = string.Empty;

        //Navigation property
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}

