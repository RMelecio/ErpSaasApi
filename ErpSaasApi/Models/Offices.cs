namespace ErpSaasApi.Models
{
    public class Offices
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string? Addrees { get; set; }
        public string? Address2 { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string ZipCode { get; set; }
        public int Status { get; set; }
    }
}
