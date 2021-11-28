using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IndexStorage", menuName = "ScriptableObjects/NewIndexStorage")]

public class IndexStorage : ScriptableObject
{
    [SerializeField] private List<int> _TmpPool = new List<int>();

    public List<int> TmpPool { get => _TmpPool; set => _TmpPool = value; }
}
