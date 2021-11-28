using UnityEngine;

public class SbOpBehaviour : SbBehaviour
{
    [SerializeField] private float _speedFly;

    private float _correntSpeedFly = 0;
    private bool _sbIsFly;
    private GameObject _goSB;
    private int _indexSB;

    public bool SbIsFly { get => _sbIsFly; set => _sbIsFly = value; }

    void Update()
    {
        if (SbIsFly && _goSB.transform.position.x > -10)
            _goSB.transform.Translate(Vector2.left * _correntSpeedFly * Time.deltaTime);
        else if (SbIsFly && _goSB.transform.position.x < -10)
            ReturnSB(_goSB);
    }

    public override  void SBFly(GameObject goSB,  int index)
    {
        if (goSB != null)
        {
            goSB.transform.parent = null;                          // отключаем от родителя
            _correntSpeedFly = _speedFly;
            _goSB = goSB;
            _indexSB = index;
            SbIsFly = true;
        }
    }

   public override  void ReturnSB(GameObject _snowBall)
    {
        _snowBall.transform.SetParent(_sbContainer_start);
        _snowBall.transform.localPosition = Vector3.zero;
        _snowBall.SetActive(false);
        _indexStorage.TmpPool.Remove(_indexSB);
        SbIsFly = false;
    }
}
