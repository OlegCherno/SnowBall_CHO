public class AnimControllerPl :AnimController
{    
    private void OnEnable()
    {
        Player.NotyfyPlStop += AnimIdle;
        Player.NotyfyPlMove += AnimRun;
    }

    private void OnDisable()
    {
        Player.NotyfyPlStop -= AnimIdle;
        Player.NotyfyPlMove -= AnimRun;
    }
}
