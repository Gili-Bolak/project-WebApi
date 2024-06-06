using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DTOs
{
    public class OrderDto
    {
        [Required]
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }
        [Required]
        public int OrderSum { get; set; }
        [Required]
        public int? UserId { get; set; }

        //public virtual ICollection<OrderItemDto>? OrderItems { get; set; } = new List<OrderItemDto>();
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();

    }
}
