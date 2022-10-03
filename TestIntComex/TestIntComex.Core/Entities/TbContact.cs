using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestIntComex.Core.Entities
{
    public class TbContact
    {
        [Key]
        public int Id { get; set; }
        public string strClientCode { get; set; }

        [Required]
        [MaxLength(6)]
        public string strUserName { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public string strName { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(10)]
        public string strPosition { get; set; }

        [Required]
        [MaxLength(10)]
        public string strPhone { get; set; }

        [Required]
        public string strEmail { get; set; }
        public string? strCellphone { get; set; }

        [Required]
        [ForeignKey("TbContactType")]
        public int IdContactType { get; set; }
        public TbContactType TbContactType { get; set; }

        public bool boolAutorizeWebStore { get; set; }
        public bool boolAutorizeOrders { get; set; }
        public bool boolSendInformation { get; set; }

        [Required]
        public string strPassword { get; set; }
    }
}
