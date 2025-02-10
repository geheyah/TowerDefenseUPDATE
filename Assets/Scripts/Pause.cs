using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public bool paused = false;
    public Button pause; 
    
    public Sprite playicon;
    public Sprite pauseicon;
    
    public TMP_Text text;
    
    void Start()
    {
        pause.onClick.AddListener(PauseGame);
        text.enabled = false;
    }

    void PauseGame()
    {
        if (!paused)
        {
            paused = true;
            pause.GetComponent<Image>().sprite = playicon;
            text.enabled = true;
            
            //flash color slowly using lerp
            text.color = Color.Lerp(Color.black, Color.white, TweenUtils.LoopingEase(0.1f));
            Time.timeScale = 0f;
        }
        else
        {
            paused = false;
            pause.GetComponent<Image>().sprite = pauseicon;
            text.enabled = false;
            Time.timeScale = 1f;
        }
    }
   
}
