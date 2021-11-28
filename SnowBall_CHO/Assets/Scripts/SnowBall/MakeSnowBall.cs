using System.Collections;
using UnityEngine;

public class MakeSnowBall : MonoBehaviour
{
    [SerializeField] protected IndexStorage _indexStorage;                // хранилище использованных снежков
    [SerializeField] protected Transform _sbContainer_ready;              // контейнер для меремещения снежков из пула "Рука"
    [SerializeField] protected GameObject _snowBallSystem;                // ссылка на систему снежков. Пул< поведение очистка пула
    [SerializeField] protected float _timeOutCreateSB;                    // время создания снежка

    protected SbPool _sbPool;
    protected int _indexSB;
    private Collider2D _coll;

    public void CreateSB(GameObject goSB, int indexSB)           // создаем  снежок путем активации в пуле
    {
        StartCoroutine(WaitNsec(_timeOutCreateSB));
    }

    IEnumerator WaitNsec(float n)
    {

        yield return new WaitForSeconds(n);
        if (_sbContainer_ready.childCount == 0)           // если в руке нет снежка то создаем
        {
            for (int i = 0; i < _sbPool._pool.Count; i++)  // проверяем содержится ли индекс снежка во временном пуле(т. е. занят ли он)
                if (!_indexStorage.TmpPool.Contains(i))
                    _indexSB = i;                          // если нет то берем его

            if (_indexSB >= _sbPool._pool.Count)           // Контроль выхода индекса за пределы пула
                _indexSB = 0;
            var _go = _sbPool._pool[_indexSB];             // Взять снежок из пула 
            _coll = _go.GetComponent<Collider2D>();
            _coll.isTrigger = false;                       // снять триггер установленный при пересечении средней линии 
            _indexStorage.TmpPool.Add(_indexSB);           // заносим индекс в TMP_Pool чтоб отметить как занятый
            _go.SetActive(true);
            _go.transform.SetParent(_sbContainer_ready);
            _go.transform.localPosition = Vector3.zero;
            DeclareNotify(_go, _indexSB);                    // объявить событие о готовности снежка
        }

    }

    protected virtual void DeclareNotify(GameObject go, int index) { }
}
