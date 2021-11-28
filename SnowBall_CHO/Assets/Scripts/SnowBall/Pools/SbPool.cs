using System.Collections.Generic;
using UnityEngine;

public class SbPool : MonoBehaviour
{
    [SerializeField] public List<GameObject> _pool;
    [SerializeField] Transform _sbContainer_start;
  
    public Transform SbContainer_start 
    { 
        get => _sbContainer_start; 
    }
   
    private void Start()
    {
        InitPool();
    }

    protected void InitPool()
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            _pool[i].transform.SetParent(SbContainer_start);
            _pool[i].SetActive(false);
        }
    }
}
