using System.ComponentModel.DataAnnotations;

namespace Agri_Energy_Connect_Application_4_.Models
{/// <summary>
/// Product Details
/// </summary>
    public class AddProduct
    {
        public int Id { get; set; }  // This is the primary key

        [Required(ErrorMessage = "Farmer ID is required.")]
        public int FarmerId { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Production Date is required.")]
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }

        // Navigation property
        public AddFarmer Farmer { get; set; }
    }
}
