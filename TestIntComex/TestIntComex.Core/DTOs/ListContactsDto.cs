namespace TestIntComex.Core.DTOs
{
    public class ListContactsDto
    {
        public string strClientCode { get; set; }
        public string strUserName { get; set; }
        public string strName { get; set; }
        public string strPosition { get; set; }
        public string strPhone { get; set; }
        public string strEmail { get; set; }
        public string? strCellphone { get; set; }
        public string ContactTypeName { get; set; }
        public bool boolAutorizeWebStore { get; set; }
        public bool boolAutorizeOrders { get; set; }
        public bool boolSendInformation { get; set; }
        public string strPassword { get; set; }
    }
}
