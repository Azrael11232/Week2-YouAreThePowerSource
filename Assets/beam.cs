using UnityEngine;

public class beam : MonoBehaviour
{
    public int timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if (timer <= 0)
            Destroy(gameObject);
        else
            timer -= 1;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
