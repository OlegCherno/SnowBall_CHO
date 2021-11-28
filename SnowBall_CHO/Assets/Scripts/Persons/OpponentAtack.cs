using UnityEngine;

public class OpponentAtack : MonoBehaviour
{
    [SerializeField] MakeSbOpponent _makeSbOpponent;
    [SerializeField] SbOpBehaviour _sbOpBehaviour;
   
    private GameObject _goSB;
    private int _indexSB;

    public void SaveSB(GameObject goSB, int index)
    {
        this._goSB = goSB;
        this._indexSB = index;
    }

    public void OpAttack()
    {
        if (!_sbOpBehaviour.SbIsFly )                                
        {
            _makeSbOpponent.CreateSB(null, _indexSB);
            _sbOpBehaviour.SBFly(_goSB, _indexSB);
        }
    }
}
