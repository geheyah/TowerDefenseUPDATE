using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Gold : MonoBehaviour
{
    public int gold = 0;
    public TMP_Text counter;
    
    public int wave;
    public int enemieskilled;
    public TMP_Text wavecounter;
    
    void Update()
    {
        counter.text = "$=" + gold.ToString();
        //Wave System
        
        wavecounter.text = "Wave#" + wave.ToString();
        
        Debug.Log("enemies killed:" + enemieskilled);
        
        if (enemieskilled == 6)
        {
            wave = 1;
        }
        if (enemieskilled == 12)
        {
            wave = 2 ;
        }
        if (enemieskilled == 20)
        {
            wave = 3;
        }
        
        if (enemieskilled == 30)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
