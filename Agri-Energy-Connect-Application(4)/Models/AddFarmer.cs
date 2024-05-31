namespace Agri_Energy_Connect_Application_4_.Models
{/// <summary>
/// Framer Details
/// </summary>
    public class AddFarmer
    {
        public int Id { get; set; }  // This is the primary key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        // Navigation property
        public ICollection<AddProduct> Products { get; set; }
    }
}
