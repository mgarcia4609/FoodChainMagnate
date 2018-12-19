using Phase = GameHelper.StaticFiles.Constants.ActivePhase;

namespace GameHelper.Models
{
    public class EmployeeType
    {
        public string Type { get; set; }
        public int Magnitude { get; set; }
        public Phase Phase { get; set; }

        public EmployeeType(string type)
        {
            Type = type;
        }
    }
}
