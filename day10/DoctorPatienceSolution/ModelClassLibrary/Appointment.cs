using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClassLibrary
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int  DoctorID { get; set; }
        public int PatienceID { get; set; }
        public DateTime dateTime { get; set; } = DateTime.Now;
        public string Status { get; set; }

        public Appointment()
        {
            AppointmentID = 0;
            DoctorID = 0;
            PatienceID = 0;
            dateTime = DateTime.Now;
            Status = string.Empty;
        }

        public Appointment(int appointmentID, int doctorID, int patienceID, DateTime dateTime, string status)
        {
            AppointmentID = appointmentID;
            DoctorID = doctorID;
            PatienceID = patienceID;
            this.dateTime = dateTime;
            Status = status;
        }

    }
}
