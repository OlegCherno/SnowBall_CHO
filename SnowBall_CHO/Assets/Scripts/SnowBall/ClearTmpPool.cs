using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTmpPool : MonoBehaviour
{
    [SerializeField] IndexStorage _indexStorage;

    void Start()
    {
        _indexStorage.TmpPool.Clear();
    }
       
}
