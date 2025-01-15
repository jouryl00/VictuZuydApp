using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace VictuZuydApp.Models
{
    [Table("Activity")]
    public class Activity
    {
        [PrimaryKey, AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("Time")]
        public DateTime Time { get; set; }
        [Column("Location")]
        public string Location { get; set; }
        [Column("Image")]
        public string Image { get; set; }

    }
}
