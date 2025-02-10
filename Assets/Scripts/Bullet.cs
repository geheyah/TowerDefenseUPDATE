using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public float velocity = 10f;
    public GameObject enemy;
    
    public Gold goldgold;
    public GameObject coin;
    
    public GameObject[] enemies;

    public float distance = 1f;
    public float bulletDuration = 5f;
    public float elapsedTime;


    private void Start()
    {
        goldgold = GameObject.FindWithTag("Gold").GetComponent<Gold>();
    }
   
    private void Update()
    {
        transform.position += transform.TransformDirection(Vector3.up) * (velocity * Time.deltaTime);
        
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            var enemyTransform = enemy.transform;
            
		    //Hit enemy
            if ((transform.position - enemyTransform.position).magnitude <= distance)
            {
                goldgold.gold += 5;
                goldgold.enemieskilled++;
                GameObject coinInst = Instantiate(coin, enemyTransform.position,transform.rotation);
                Destroy(enemy);
                Destroy(this.gameObject);
            }
        }
        
        elapsedTime += Time.deltaTime;
        float travel = elapsedTime / bulletDuration;

        if (elapsedTime >= bulletDuration)
        {
            Destroy(this.gameObject);
        }
    }
}

