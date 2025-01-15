using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace VictuZuydApp.Models
{
    [Table("Event")]
    public class Event : TableData
    {

        [Column("Name")]
        public string Name { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("Date")]
        public DateTime Date { get; set; }
        [Column("Location")]
        public string Location { get; set; }
        [Column("Image")]
        public string Image { get; set; }
        [Column("MaxParticipants")]
        public int MaxParticipants { get; set; }
        [Column("CurrentParticipants")]
        public int CurrentParticipants { get; set; }
        [Column("IsActive")]
        public bool IsActive { get; set; }
    }
}
