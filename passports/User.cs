using System.ComponentModel.DataAnnotations;

namespace passports
{
    public class User
    {
        
        public int Id { get; set; }
        
        [Key]
        public string Login { get; set; }
        public string Fam { get; set; }
        public string Name { get; set; }
        public string Otch { get; set; }
        public string Pass { get; set; }
        public User() { }

    }
}