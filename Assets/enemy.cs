using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject Power;
    Transform player;

    public int speed;
    public int damage;
    public int cd;
    public int chance;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }


    void FixedUpdate()
    {
        MoveTowards(player);
    }

    void MoveTowards(Transform target)
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.fixedDeltaTime
        );
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("beam"))
        {
            Debug.Log("hit");
            Destroy(gameObject);

            if (Random.Range(1, 100) <= chance)
            {
                Instantiate(Power, transform.position, Quaternion.identity);
            }
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (cd != 0)
                cd -= 1;
            else
            {
                Player player = other.gameObject.GetComponent<Player>();
                player.energy -= damage;
                cd = 10;
            }
        }
    }
}
