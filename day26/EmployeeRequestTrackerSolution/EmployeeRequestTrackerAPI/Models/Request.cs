using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRequestTrackerAPI.Models
{
    public class Request
    {
        [Key]
        public int RequestNumber { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; } = System.DateTime.Now;
        public DateTime? ClosedDate { get; set; } = null;
        public string RequestStatus { get; set; }

        public int RaisedByEmployeeId { get; set; }
        [ForeignKey("RaisedByEmployeeId")]
        public Employee RaisedByEmployee { get; set; }
    }
}
