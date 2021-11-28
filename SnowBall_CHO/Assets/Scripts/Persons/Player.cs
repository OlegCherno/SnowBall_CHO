using UnityEngine.Events;
using UnityEngine;

public class Player : Person
{
    public static UnityAction NotyfyPlMove;                                                // ќбъ€вл€ем событие
    public static UnityAction NotyfyPlStop;                                                // ќбъ€вл€ем событие

    private int _direction;

    private void Start()
    {
        transform.position = _startPos;
    }

    private void FixedUpdate()
    {
        if (_direction == 1 && transform.position.y < GameCamera.Border - 2)
             transform.Translate(Vector3.up * _speed * Time.fixedDeltaTime);
            
        else if (_direction == -1 && transform.position.y > -GameCamera.Border + 1)
            transform.Translate(Vector3.down * _speed * Time.fixedDeltaTime);
    }

    public void UpMove()
    {
        _direction = 1;
        NotyfyPlMove?.Invoke();
    }

    public void DownMove()
    {
        _direction = -1;
        NotyfyPlMove?.Invoke();
    }

    public void StopMove()
    {
        _direction = 0;
        NotyfyPlStop?.Invoke();
    }
}
