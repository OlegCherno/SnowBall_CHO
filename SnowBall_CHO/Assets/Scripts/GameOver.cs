using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Image _fadePanel;
    [SerializeField] private float _timeFade;
    [SerializeField] private Text _outText;

    private Tween _tween;
    private void OnEnable()
    {
        ScoreManager.NotyfyVictory += GameQuit;
    }

    private void OnDisable()
    {
        ScoreManager.NotyfyVictory -= GameQuit;
        _tween.Kill();
    }
   
    void GameQuit(char who)
    {
        switch (who)
        {
            case 'O':
                _outText.text = "ВЫ ПРОИГРАЛИ.";
                goto case 'Q';
            case 'P':
                _outText.text = "ВЫ ВЫИГРАЛИ.";
                goto case 'Q';
            case 'Q':
                FadePanel(_timeFade);
                break;
        }
    }

    public void FadePanel(float _timeFade)
    {
        _tween = _fadePanel.DOFade(1, _timeFade).OnComplete(() => _quitApp(0));
    }

    void _quitApp(float _time)
    {
        _outText.gameObject.SetActive(true);
        Application.Quit();
        Time.timeScale = _time;
    }
}
