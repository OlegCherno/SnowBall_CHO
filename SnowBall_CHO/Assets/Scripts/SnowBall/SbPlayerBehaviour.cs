using UnityEngine;

public class SbPlayerBehaviour : SbBehaviour
{
    
    [SerializeField] ForceSystem _forceSystem;                 // SO где хранится сила броска
    /*[SerializeField] private Transform _sbContainer_start;     // Исходный контейнер ПУЛА
    [SerializeField] private IndexStorage _indexStorage;       //
    */
        
    private float _flyForce;
    private GameObject _goSB;
    private Rigidbody2D _rb;
    private int _indexSB;
    private bool _sbIsFly;

    public bool SbIsFly { get => _sbIsFly; set => _sbIsFly = value; }

    private void OnEnable()
    {
        PlayerAttack.NotifyPlAttack += SBFly;
    }

    private void OnDisable()
    {
        PlayerAttack.NotifyPlAttack -= SBFly;
    }

    private void FixedUpdate()
    {
        if (SbIsFly && _goSB.transform.position.y < PlayerAttack.PlayerPositionY)   // Если вылетели за пределы координаты Y Игрока назад в пул 
            ReturnSB(_goSB);
    }

    public override void SBFly(GameObject goSB, int index)
    {

        if (goSB != null)
        {
            _flyForce = _forceSystem.ForceThrow * 100;
            _rb = goSB.GetComponent<Rigidbody2D>();
            _rb.gravityScale = 0.55f;                              // ???????????????????????????????????????
            goSB.transform.parent = null;                          // отключаем от родителя
            _rb.AddForce(new Vector2(1f, 0.8f) * _flyForce);
            _goSB = goSB;
            _indexSB = index;
            SbIsFly = true;
        }
    }

    public override void ReturnSB(GameObject _snowBall)
    {
        _rb.gravityScale = 0;
        _snowBall.transform.SetParent(_sbContainer_start);
        _snowBall.transform.localPosition = Vector3.zero;
        _snowBall.SetActive(false);
        _indexStorage.TmpPool.Remove(_indexSB);
        SbIsFly = false;
    }
}
