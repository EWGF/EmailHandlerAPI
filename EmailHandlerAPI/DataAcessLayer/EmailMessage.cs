using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EmailHandlerAPI.DataAcessLayer
{
    [Table("messages")]
    public class EmailMessage
    {
        [Key]
        [Required]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("date")]
        public DateTime Date { get; set; }

        [Required]
        [Column("subject")]
        public string Subject { get; set; }

        [Required]
        [Column("body")]
        public string Body { get; set; }

        [Required]
        [Column("recipient")]
        public string Recipient { get; set; }

        [Column("carbon_copy_recipients")]
        public List<string> Carbon_copy_recipients { get; set; }

        [Column("delivery_status")]
        public string DeliveryStatus { get; set; }
    }
}
