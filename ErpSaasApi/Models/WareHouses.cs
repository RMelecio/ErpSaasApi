using System.ComponentModel.DataAnnotations.Schema;

namespace ErpSaasApi.Models
{
    public class WareHouses
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Status { get; set; }

        [ForeignKey("Offices")]
        public long OfficeId { get; set; }
        public Offices Office { get; set; }
    }
}
