using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public Health health;
    
    public bool hasHit = false;

    public float timeItTakes = 3f;
    public float lerpValue = 0f;
    public float t = 0f;

    public Spawner spawner;


    void Start()
    {
        health = (Health)FindFirstObjectByType(typeof(Health));
        spawner = (Spawner)FindFirstObjectByType(typeof(Spawner));
    }

    // Update is called once per frame
    void Update()
    {
        lerpValue += Time.deltaTime;
        t = Mathf.Clamp01(lerpValue / timeItTakes);

        transform.position = CubicBezier(spawner.spawn.position, new Vector3(0f, -1f, 0),new Vector3(0f, 1f, 0), health.gameObject.transform.position, t);

	    //Death
        if (hasHit) return;
        if ((health.gameObject.transform.position - transform.position).magnitude <= 1f)
        {
            hasHit = true;
            health.health--;
            Destroy(gameObject);
        }
    }
    
    private Vector3 CubicBezier(Vector3 start, Vector3 control1,Vector3 control2, Vector3 end, float t)
    {
        return Mathf.Pow(1-t,3) * start + (1 - t) * control1 * 3 + Mathf.Pow(1-t,2) * control2 * 3 + t * t * t * end;
    }
}
