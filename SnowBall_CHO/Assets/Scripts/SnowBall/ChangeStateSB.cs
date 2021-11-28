using UnityEngine;

public class ChangeStateSB : MonoBehaviour
{
    Collider2D _coll;
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        _coll = other.GetComponent<Collider2D>();
        _coll.isTrigger = true;                         // при пересечении средней линии ставим триггер для корректого срататывания OnTriggerEnter на персонажах
    }
}
