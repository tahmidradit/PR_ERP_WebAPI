using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_ERP_WebAPI.Domain.DTO.Order
{
    public class UpdateOrderDTO
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string CustomerName { get; set; }

        [StringLength(100)]
        public string? CustomerAddress { get; set; }

        [Required, StringLength(100)]
        public string ShippingAddress { get; set; }

        [Required, StringLength(100)]
        public string ItemName { get; set; }

        [Required, Range(1, int.MinValue, ErrorMessage = "Minimum Unit Price is 1")]
        public double UnitPrice { get; set; }

        [Range(1, int.MinValue, ErrorMessage = "Minimum Quantity is 1")]
        public int Quantity { get; set; }
        public int? Discount { get; set; }
        public double TotalPrice { get; set; }
        public int OrderInvoiceNo { get; set; }
        public DateTime OrderDateTime { get; set; }
        public DateTime ShippingDate { get; set; }
    }
}
