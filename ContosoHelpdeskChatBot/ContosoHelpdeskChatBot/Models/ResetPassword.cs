namespace ContosoHelpdeskChatBot.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ResetPassword")]
    public partial class ResetPassword
    {
        [Key]
        public int Id { get; set; }

        public string EmailAddress { get; set; }

        public long? MobileNumber { get; set; }

        public int? PassCode { get; set; }

        public string TempPassword { get; set; }
    }
}
