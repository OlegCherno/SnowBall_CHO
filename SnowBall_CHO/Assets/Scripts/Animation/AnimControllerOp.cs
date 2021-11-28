public class AnimControllerOp : AnimController
{
    private void OnEnable()
    {
        // Opponent.NotifyOpStop += AnimIdle;
        // Opponent.NotifyOpMove += AnimRun;
    }

    private void OnDisable()
    {
        // Opponent.NotifyOpStop -= AnimIdle;
        // Opponent.NotifyOpMove -= AnimRun;
    }
}
