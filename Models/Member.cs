using System.ComponentModel.DataAnnotations.Schema;

namespace task3.Models
{
    [Table("member")]
    class Member
    {
        [Column("id")]
        public int id { get; set; }
        [Column("fio")]
        public string fio { get; set; }
        [ForeignKey("sport_id")]
        public Sport sport { get; set; }
    }
}
