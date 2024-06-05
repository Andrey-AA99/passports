using System.ComponentModel.DataAnnotations;

namespace passports
{
    public class ClientsPassp
    {
        [Key]
        public int PassNumber {  get; set; }
        public int PassSeria { get; set; }
        public string PassFam {  get; set; }
        public string PassName {  get; set; }
        public string DateOfStart {  get; set; }
        public string DateOfEnd {  get; set; }

        public ClientsPassp() { }

        public ClientsPassp(int passNumber, int passSeria, string passFam, string passName, string dateOfStart, string dateOfEnd)
        {
            PassNumber = passNumber;
            PassSeria = passSeria;
            PassFam = passFam;
            PassName = passName;
            DateOfStart = dateOfStart;
            DateOfEnd = dateOfEnd;
        }
    }
}
