using Spine.Unity;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation _skeletonAnim;

    protected const string _Idle = "Idle";
    protected const string _Run = "run";
    protected const string _Joy = "joy";
    protected const string _Wake_Up = "wake_up";

    public void AnimIdle()
    {
        _skeletonAnim.state.SetAnimation(0, _Idle, true);
    }

    public void AnimRun()
    {
        _skeletonAnim.state.SetAnimation(0, _Run, true);
    }
    public void AnimJoy()
    {
        _skeletonAnim.state.SetAnimation(0, _Joy, false);
    }

    public void AnimWake_UP()
    {
        _skeletonAnim.state.SetAnimation(0, _Wake_Up, false);
    }
    
    public void AnimWake_UpIdle()
    {
        _skeletonAnim.state.SetAnimation(0, _Wake_Up, false);
        _skeletonAnim.state.AddAnimation(0, _Idle, true, 0);
    }

    public void AnimRemove()
    {
        _skeletonAnim.state.SetAnimation(0, _Wake_Up, false);
        _skeletonAnim.state.AddAnimation(0, _Run, true, 0);
    }
}
