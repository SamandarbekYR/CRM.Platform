using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.DataAccess.EfClass
{
    public class License : BaseEntity
    {
        public long PartnerId { get; set; }
        public string MacAddress { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public bool IsActive { get; set; } = true;
        public string ProductName { get; set; } = string.Empty;
        [ForeignKey("PartnerId")]
        [InverseProperty(nameof(Partner.Licenses))]
        public virtual Partner Partner { get; set; } = null!; 
    }
}
