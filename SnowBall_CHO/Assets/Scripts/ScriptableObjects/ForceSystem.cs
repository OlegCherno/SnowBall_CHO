using UnityEngine;

[CreateAssetMenu(fileName = "ForceSystem", menuName = "ScriptableObjects/NewForceSystem")]
public class ForceSystem : ScriptableObject
{
    [SerializeField] private float _forceThrow;
    [SerializeField] private float _speedIndicate;

    public float ForceThrow
    {
        get
        {
            if (_forceThrow >= 1f)
                return 1f;
            else
                return _forceThrow;
        }
        set
        {
            if (value <= 0)
                _forceThrow = 0;
            else
                _forceThrow = value;
        }
    }

    public float SpeedIndicate 
    { 
        get => _speedIndicate; 
    }
}
