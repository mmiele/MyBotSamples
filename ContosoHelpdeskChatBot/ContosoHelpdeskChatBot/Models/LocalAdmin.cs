namespace ContosoHelpdeskChatBot.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LocalAdmin")]
    public partial class LocalAdmin
    {
        [Key]
        public int Id { get; set; }

        public string MachineName { get; set; }

        public int? AdminDuration { get; set; }
    }
}
