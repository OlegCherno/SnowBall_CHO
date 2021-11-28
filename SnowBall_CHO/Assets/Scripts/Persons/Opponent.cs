using System.Collections;
using UnityEngine.Events;
using UnityEngine;

public class Opponent : Person
{
    [SerializeField] AnimController _animController;
    [SerializeField] OpponentAtack _opponentAtack;
    [SerializeField] private int _strickenValue;

    private int _direction;
    private float _delay = 5f;
    private bool _isStricken;
    private float _currentSpeed;
    private bool _isReserve;


    public bool IsStricken { get => _isStricken; set => _isStricken = value; }
    public int Direction { get => _direction; set => _direction = value; }
    public float CurrentSpeed { get => _currentSpeed; set => _currentSpeed = value; }
    public bool IsReserve { get => _isReserve; set => _isReserve = value; }
    public int StrickenValue { get => _strickenValue; }

    private ReplaceOpponents _replaceOpponents;

    private void Awake()
    {
        _replaceOpponents = GetComponent<ReplaceOpponents>();
    }
    void Start()
    {
        if (transform.position.y < -GameCamera.Border - 2)
            _replaceOpponents.InReserve();
        CurrentSpeed = _speed;
        transform.position = _startPos;
        SetDirection();
        StartCoroutine(ChangeDirection());
    }

    private void FixedUpdate()
    {
        if (Direction == 1 && transform.position.y < GameCamera.Border - 2 && !IsStricken)
            transform.Translate(Vector3.up * CurrentSpeed * Time.fixedDeltaTime);
        else if (Direction == -1 && transform.position.y > -GameCamera.Border + 1 && !IsStricken)
            transform.Translate(Vector3.down * CurrentSpeed * Time.fixedDeltaTime);
        else Direction *= -1;
        if (IsStricken && transform.position.y > -GameCamera.Border - 3)
            transform.Translate(Vector3.down * CurrentSpeed * Time.fixedDeltaTime);
        if (transform.position.y < -GameCamera.Border - 2)
        {
            _replaceOpponents.InReserve();
        }
    }


    private void SetDirection()
    {
        Direction = Random.Range(0, 2);  // случайное направление -1 или 1
        if (Direction == 0)
            Direction = -1;
        _animController.AnimRun();
    }

    public IEnumerator ChangeDirection()
    {
        while (true)
        {
            SetDirection();
            int _changeDirection = Random.Range(2, 8);
            yield return new WaitForSeconds(_changeDirection);
            StopMove();
            yield return new WaitForSeconds(_delay);

        }
    }

    public void StopMove()
    {
        Direction = 0;
        _opponentAtack.OpAttack();
        _animController.AnimIdle();
    }

}
