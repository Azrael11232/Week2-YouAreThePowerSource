using UnityEngine;

public class Energy : MonoBehaviour
{
    public int energyCost = 50;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();

            if (player.energy >= energyCost)
            {
                player.energy -= energyCost;

                Destroy(gameObject);
            }
        }
    }
}