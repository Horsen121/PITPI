using System.ComponentModel.DataAnnotations.Schema;

namespace task3.Models
{
    [Table("sport")]
    internal class Sport
    {
        [Column("id")]
        public int id { get; set; }
        [Column("name")]
        public string name { get; set; }
    }
}
