using UnityEngine;

public class Enemy : MonoBehaviour
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

        transform.position = QuadraticBezier(spawner.spawn.position, new Vector3(0f, 1f, 0), health.gameObject.transform.position, t);
	    //Enemy Death
        if (hasHit) return;
        if ((health.gameObject.transform.position - transform.position).magnitude <= 1f)
        {
            hasHit = true;
            health.health--;
            Destroy(gameObject);
        }
       
    }
    
    //Quadratic
    private Vector3 QuadraticBezier(Vector3 start, Vector3 control,Vector3 end, float t)
    {
        return Mathf.Pow(1-t,2) * start + (1 - t) * control * 2 + t * t * end;
    }
}
