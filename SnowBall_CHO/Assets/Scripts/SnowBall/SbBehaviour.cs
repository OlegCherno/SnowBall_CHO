using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SbBehaviour : MonoBehaviour
{
    [SerializeField] protected Transform _sbContainer_start;     // Исходный контейнер ПУЛА
    [SerializeField] protected IndexStorage _indexStorage;       

    public abstract void SBFly(GameObject go, int index);
    public abstract void ReturnSB(GameObject go);
}
