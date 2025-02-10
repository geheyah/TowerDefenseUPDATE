using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health = 3;
    public Image heart1;
    public Image heart2;
    public Image heart3;

    // Update is called once per frame
    void Update()
    {
        if (health == 2)
        {
            heart3.enabled = false;
        }
        if (health == 1)
        {
            heart2.enabled = false;
        }

        if (health == 0)
        {
            SceneManager.LoadScene("Fail");
        }
        
    }
}
