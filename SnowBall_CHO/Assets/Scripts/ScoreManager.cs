using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static UnityAction<char> NotyfyVictory;

    [SerializeField] private Text _scoreTextOpponent;
    [SerializeField] private Text _scoreTextPlayer;

    private int _scoreOpponet;                                    //  счет Соперников
    private int _scorePlayer;                                     //  счет Игрока

    private void OnEnable()
    {
        HitEffectPlayer.NotyfyHitPlayer += UpdateScoreOpponent;             // за попадание по игроку очки идут СОПЕРНИКУ
        HitEffectOpponent.NotyfyHitOpponent += UpdateScorePlayer;           // за попадание по сопернику очки идут ИГРОКУ
    }

    private void OnDisable()
    {
        HitEffectPlayer.NotyfyHitPlayer -= UpdateScoreOpponent;
        HitEffectOpponent.NotyfyHitOpponent -= UpdateScorePlayer;
    }

    private void UpdateScoreOpponent()                                // за попадание в игрока
    {
        _scoreOpponet ++;                                             // Наращивание счета
        _scoreTextOpponent.text = _scoreOpponet.ToString();
        if (_scoreOpponet >= 3)                                       // Наращивание счета
            NotyfyVictory?.Invoke('O');

    }

    private void UpdateScorePlayer(int _strickenVavue)                             // За попадание в Соперников
    {
        _scorePlayer += _strickenVavue;                                                // Наращивание счетаы
        _scoreTextPlayer.text = _scorePlayer.ToString();
        if (_scorePlayer >= 10)                                       // Наращивание счета
            NotyfyVictory?.Invoke('P');

    }
}
