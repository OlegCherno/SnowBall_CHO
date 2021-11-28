using UnityEngine;

public class MakeSbOpponent : MakeSnowBall
{
    [SerializeField] OpponentAtack _opponentAtack;
  
    private void Awake()
    {
        _sbPool = _snowBallSystem.GetComponent<SbPool>();
    }
    private void Start()
    {
        CreateSB(null, 0);
    }

    protected override void DeclareNotify(GameObject _gameObject, int _index)
    {
        _opponentAtack.SaveSB(_gameObject, _index);
    }
}
