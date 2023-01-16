using System.ComponentModel.DataAnnotations;

namespace PitShop.Models
{
    public class Mechanic
    {
        public int Id { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]
        public string Secondname { get; set; }

        public string Phone { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + Secondname;   
            }
        }
    }
}
