using Microsoft.AspNetCore.Identity;

namespace Agri_Energy_Connect_Application_4_.Models
{/// <summary>
/// Details For registration
/// </summary>
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        private string cellNo;
        public string CellNo
        {
            get { return cellNo; }
            set
            {
                // Ensure the string is exactly 10 digits long and contains only digits
                if (value.Length != 10 || !value.All(char.IsDigit))
                {
                    throw new ArgumentException("Cell number must be exactly 10 digits.");
                }
                cellNo = value;
            }
        }
    }
}
