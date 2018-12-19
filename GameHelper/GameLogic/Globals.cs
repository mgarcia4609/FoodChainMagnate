using Phase =  GameHelper.StaticFiles.Constants.ActivePhase;

namespace GameHelper.GameLogic
{
    public class Globals
    {
        Phase GamePhase { get; set; }

        public Globals()
        {
            GamePhase = Phase.Restructuring;
        }        
    }
}
