namespace PitShop.Models
{
    public class Mechanic
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

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
