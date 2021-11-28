using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceOpponents : MonoBehaviour
{
    [SerializeField] private AnimController _animController;

    private Opponent _opponent;

    private void Awake()
    {
        _opponent = GetComponent<Opponent>();
    }

    private void OnEnable()
    {
        HitEffectOpponent.NotyfyReserve += OutReserve;
    }
    private void OnDisable()
    {
        HitEffectOpponent.NotyfyReserve -= OutReserve;
    }

    public void InReserve()
    {
        StopAllCoroutines();
        _animController.AnimIdle();
        _opponent.IsReserve = true;
        _opponent.Direction = 0;
    }

    public void OutReserve(Transform _targetPoint)
    {
        if (_opponent.IsReserve)
        {
            StartCoroutine(_opponent.ChangeDirection());
            gameObject.transform.position = new Vector2(_targetPoint.transform.position.x, GameCamera.Border);
            _opponent.IsReserve = false;
            _opponent.IsStricken = false;
            _opponent.Direction = 0;
        }
    }
}
