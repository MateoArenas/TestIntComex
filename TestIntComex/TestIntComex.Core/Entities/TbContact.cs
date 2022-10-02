using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestIntComex.Core.Entities
{
    public class TbContact
    {
        [Key]
        public int Id { get; set; }
        public string strClientCode { get; set; }
        public string strUserName { get; set; }
        public string strName { get; set; }
        public string strPosition { get; set; }
        public string strPhone { get; set; }
        public string strEmail { get; set; }
        public string strCellphone { get; set; }

        [ForeignKey("TbContactType")]
        public int IdContactType { get; set; }
        public TbContactType TbContactType { get; set; }

        public bool boolAutorizeWebStore { get; set; }
        public bool boolAutorizeOrders { get; set; }
        public bool boolSendInformation { get; set; }

        public string strPassword { get; set; }
    }
}
