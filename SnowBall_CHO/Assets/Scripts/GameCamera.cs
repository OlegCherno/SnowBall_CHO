using UnityEngine;

public class GameCamera : MonoBehaviour
{
    private static float _border = 0;

    public static float Border
    {
        get
        {
            if (_border == 0)
            {
                var cam = Camera.main;
                _border = 2f/cam.aspect * cam.orthographicSize;
            }
            return _border;
        }
    }
}
