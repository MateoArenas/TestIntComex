using System.ComponentModel.DataAnnotations;

namespace TestIntComex.Core.Entities
{
    public class TbContactType
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public ICollection<TbContact> TbContact { get; set; }
    }
}
