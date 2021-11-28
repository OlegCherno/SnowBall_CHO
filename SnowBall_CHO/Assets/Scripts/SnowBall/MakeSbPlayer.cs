using UnityEngine.Events;
using UnityEngine;

public class MakeSbPlayer : MakeSnowBall
{
    public static event UnityAction<GameObject, int> NotifySbPlayerRedy;

    private void Awake()
    {
        _sbPool = _snowBallSystem.GetComponent<SbPool>();
    }

    private void Start()
    {
        CreateSB(null, 0);
    }

    private void OnEnable()
    {
        PlayerAttack.NotifyPlAttack += CreateSB;
    }

    private void OnDisable()
    {
        PlayerAttack.NotifyPlAttack -= CreateSB;
    }

    protected override void DeclareNotify(GameObject _gameObject, int _index)
    {
        NotifySbPlayerRedy?.Invoke(_gameObject, _index);                    // объявить событие о готовности снежка
    }
}
