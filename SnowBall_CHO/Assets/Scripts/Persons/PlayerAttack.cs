using UnityEngine.Events;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static event UnityAction<GameObject, int> NotifyPlAttack;

    // [SerializeField] private IndexStorage _indexStorage;                // SO сохранение последнего использованного "Индекса Снежка"
    [SerializeField] private float _attackRate;
    [SerializeField] SbPlayerBehaviour _sbPlayerBehaviour;

    private float _nextAttack;
    private GameObject _goSB;
    private int _indexSB;

    private static float _playerPositionY;

    private Player _player;

    public static float PlayerPositionY { get => _playerPositionY; }

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        MakeSbPlayer.NotifySbPlayerRedy += SaveSB;
    }

    private void OnDisable()
    {
        MakeSbPlayer.NotifySbPlayerRedy -= SaveSB;
    }

    public void SaveSB(GameObject goSB, int index)
    {
        this._goSB = goSB;
        this._indexSB = index;
    }

    public void PlAttack()
    {
        if (Time.time > _nextAttack)
        {
            _nextAttack = Time.time + _attackRate;
            _player.StopMove();
            _playerPositionY = _player.transform.position.y;  // координата Y игрока
            if (!_sbPlayerBehaviour.SbIsFly)
                NotifyPlAttack?.Invoke(_goSB, _indexSB);
        }
    }
}
