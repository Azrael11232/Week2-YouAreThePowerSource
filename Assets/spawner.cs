using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform player;
    public GameObject enemy;
    public Vector3 offset;
    public int timer;
    public int cd;
    public int min;
    public int max;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawn();

        int randomX = Random.Range(0, 2) == 0 ? -1 : 1;
        int randomY = Random.Range(0, 2) == 0 ? -1 : 1;

        offset.x = Random.Range(min, max) * randomX;
        offset.y = Random.Range(min, max) * randomY;
    }

    void spawn()
    {

        if (cd <= 0)
        {
            Instantiate(enemy, player.position + offset, transform.rotation);
            if (timer >= 100)
                timer -= 5;
            cd = timer;
        }
        else
            cd -= 1;
    }
}
