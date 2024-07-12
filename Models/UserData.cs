using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace UserCaptureTest1.Models
{
    [XmlType("User")]
    public class UserData
    {
        [Key]
        [XmlAttribute("UserId", DataType = "int")]
        public int UserId { get; set; }

        [XmlElement("FirstName")]
        public required string FirstName { get; set; }

        [XmlElement("LastName")]
        public required string LastName { get; set; }

        [XmlElement("Email")]
        public required string Email { get; set; } //username and email can be used interchangebly 

        [XmlElement("Cellphone")]
        public required string Cellphone { get; set; }
    }        
}
