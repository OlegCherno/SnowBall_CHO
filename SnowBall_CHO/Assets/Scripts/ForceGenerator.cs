using UnityEngine.UI;
using UnityEngine;

public class ForceGenerator : MonoBehaviour
{
    [SerializeField] ForceSystem _forceSystem;
    
    [Header("Индикатор силы броска")]
    public Image _imageScale;

    
    void Start()
    {
        _forceSystem.ForceThrow = 0;
    }

    private void FixedUpdate()
    {
        _forceSystem.ForceThrow += Time.deltaTime * _forceSystem.SpeedIndicate;
        _imageScale.fillAmount = _forceSystem.ForceThrow;
        if (_forceSystem.ForceThrow >= 1)
            _forceSystem.ForceThrow = 0;
    }
}
