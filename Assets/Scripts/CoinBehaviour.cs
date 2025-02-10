using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    public Transform coinPos;
    public Transform counterPos;
    
    public float duration = 2f;
    public float elapsedTime = 0f;

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counterPos = GameObject.Find("GoldCounter").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        float travel = elapsedTime / duration;
        
        this.transform.position = Vector3.Lerp(coinPos.position, counterPos.position, TweenUtils.EaseIn(travel));

        if (elapsedTime >= duration)
        {
            Destroy(this.gameObject);
        }
        
    }
}
