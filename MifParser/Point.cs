using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MifParser
{
    public class Point
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int Region { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public virtual Owner Owner { get; set; }
    }
}
