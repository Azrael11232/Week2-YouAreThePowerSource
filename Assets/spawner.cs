using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform player;
    public GameObject enemy;
    public Vector3 offset;
    public float timer;
    public float cd;
    public int min;
    public int max;
    public int amount = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cd <= 0)
        {
            for (int i = 0; i < amount; i++)
            {
                spawn();
            }
            if (timer >= .2f)
                timer -= .1f;
            else
            {
                cd = 2f;
                timer = 3f;
                amount += 1;
            }

            cd -= .1f;
            cd = timer;
        }


        else
            cd -= Time.deltaTime;
        
    }

    void spawn()
    {
        if (player != null)
        {
            int randomX = Random.Range(0, 2) == 0 ? -1 : 1;
            int randomY = Random.Range(0, 2) == 0 ? -1 : 1;

            offset.x = Random.Range(min, max) * randomX;
            offset.y = Random.Range(min, max) * randomY;

            Instantiate(enemy, player.position + offset, transform.rotation);
        }

        else
            return;
    }
}
