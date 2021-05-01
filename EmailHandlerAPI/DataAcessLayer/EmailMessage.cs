using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmailHandlerAPI.DataAcessLayer
{
    [Table("messages")]
    public class EmailMessage
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public string Recipient { get; set; }

        public List<string> Carbon_copy_recipients { get; set; }

        public string DeliveryStatus { get; set; }
    }
}
