namespace ErpSaasApi.Models
{
    public class Companies
    {
        public long Id { get; set; }
        public string BusinessName { get; set; }
        public string BusinessId { get; set; }
        public string? BusinnesClasification { get; set; }
        public string? Addrees { get; set; }
        public string? Address2 { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string ZipCode { get; set; }
    }
}
