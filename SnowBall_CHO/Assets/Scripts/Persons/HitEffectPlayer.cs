using UnityEngine.Events;
using UnityEngine;

public class HitEffectPlayer : MonoBehaviour
{
    public static UnityAction NotyfyHitPlayer;                                                // Объявляем событие

    [SerializeField] private AnimController _animController;

    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _player.StopMove();
        _animController.AnimWake_UpIdle();
        NotyfyHitPlayer?.Invoke();    // вызов события
    }
}
