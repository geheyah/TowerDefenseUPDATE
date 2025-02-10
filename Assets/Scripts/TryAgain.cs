using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TryAgain : MonoBehaviour
{
    public Button tryagain;    
    void Start()
    {
        tryagain.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        SceneManager.LoadScene("Game");
    }
}
