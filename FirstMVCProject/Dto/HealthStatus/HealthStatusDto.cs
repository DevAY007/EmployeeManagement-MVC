﻿namespace FirstMVCProject.Dto.HealthStatus
{
    public class HealthStatusDto
    {
        public Guid Id { get; set; }
        public string BloodGroup { get; set; }
        public string BloodType { get; set; }
        public string Allergies { get; set; }
        public string HealthStatus { get; set; }
        public string Precautions { get; set; }
        public string Comment { get; set; }
    }
}
