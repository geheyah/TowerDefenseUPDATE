using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    //buttons
    public Button button1;
    public Button button2;
    public Button button3;
    public TMP_Text info;
    
    public RectTransform transform1;
    public RectTransform transform2;
    public RectTransform transform3;
    
    //things that get affected
    public Gold goldgold;
    public Health health;
    
    public GameObject turret;
    public TurretScript[] turrets;

    void Start()
    {
        info.enabled = false;

        turrets = turret.GetComponentsInChildren<TurretScript>();
        goldgold = GameObject.FindWithTag("Gold").GetComponent<Gold>();
        health = GameObject.FindWithTag("Health").GetComponent<Health>();

    }

    void Update()
    {
        
        
        if (goldgold.gold >= 5)
        {
            Debug.Log("upgrade1 available");
            info.enabled = true;
            transform1.anchoredPosition =Vector3.Lerp(transform1.anchoredPosition, new Vector3(-200,300,0), TweenUtils.EaseIn(0.1f));
        }
        else
        {
            transform1.anchoredPosition =Vector3.Lerp(transform1.anchoredPosition, new Vector3(0,300,0), TweenUtils.EaseOut(0.1f));
        }
        
        if (goldgold.gold >= 10)
        {
            Debug.Log("upgrade2 available");
            transform2.anchoredPosition = Vector3.Lerp(transform2.anchoredPosition, new Vector3(-200,250,0), TweenUtils.EaseIn(0.1f));

        }
        else
        {
            transform2.anchoredPosition = Vector3.Lerp(transform2.anchoredPosition, new Vector3(0,250,0), TweenUtils.EaseOut(0.1f));
        }
        
        
        if (goldgold.gold >= 15)
        {
            Debug.Log("upgrade3 available");
            transform3.anchoredPosition = Vector3.Lerp(transform3.anchoredPosition, new Vector3(-200,200,0), TweenUtils.EaseOut(0.1f));

        }
        else
        {
            transform3.anchoredPosition = Vector3.Lerp(transform3.anchoredPosition, new Vector3(0,200,0), TweenUtils.EaseIn(0.1f));
        }
    }
    
    public void RangeUp()
    {
        Debug.Log("rangeUp");
        goldgold.gold -= 5;
        
        foreach (var turret in turrets)
        {
            turret.range += 1f;
        }
    }

    public void CoolDown()
    {
        Debug.Log("cooldown");
        goldgold.gold -= 10;
        
        foreach (var turret in turrets)
        {
            turret.cooldown -= 0.5f;
        }
    }

    public void HealthUp()
    {
        Debug.Log("healthUp");
        goldgold.gold -= 15;
        health.health += 2;
    }
    
    
}
