using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rb;
   
    [Tooltip("Начальная позиция персонажа")]
    [SerializeField] protected Vector3 _startPos;

    [Tooltip("Скорость персонажа")]
    [Range(0.1f, 10f)]
    [SerializeField] protected float _speed;
}
