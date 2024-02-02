using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VineforceShivamPratapSinghDb.Entitymodels
{
    [Table("State", Schema = "dbo")]
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int? CountryId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
