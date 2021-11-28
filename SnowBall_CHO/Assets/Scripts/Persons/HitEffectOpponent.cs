using System.Collections;
using UnityEngine.Events;
using UnityEngine;

public class HitEffectOpponent : MonoBehaviour
{
    public static UnityAction<int> NotyfyHitOpponent;                                                   // Объявляем событие
    public static UnityAction<Transform> NotyfyReserve;                                                  // Объявляем событие

    [SerializeField] private AnimController _animController;
    [SerializeField] private SbPlayerBehaviour _sbPlayerBehaviour;

    private Opponent _opponent;
    private Transform _targetPoint;
    
    private void Awake()
    {
        _opponent = GetComponent<Opponent>();
        _targetPoint = GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject _other = collision.gameObject;
        _sbPlayerBehaviour.ReturnSB(_other);
        _targetPoint.position = transform.position;
        StartCoroutine(WaitNsec(1.5f));
        NotyfyHitOpponent?.Invoke(_opponent.StrickenValue);    // вызoв события
    }
   
    IEnumerator WaitNsec(float n)
    {
        var _tmpSpeed = _opponent.CurrentSpeed;
        _opponent.CurrentSpeed=0;
        _opponent.IsStricken = true;
        _animController.AnimWake_UpIdle();
        yield return new WaitForSeconds(n);
        _opponent.CurrentSpeed = _tmpSpeed;
        NotyfyReserve?.Invoke(_targetPoint);
        _animController.AnimRun();
       
    }
}
