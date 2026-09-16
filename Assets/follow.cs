using UnityEngine;

public class follow : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        if (player != null)
        transform.position = new Vector3(
            player.position.x,
            player.position.y,
            transform.position.z
        );
        else
            return;

        transform.rotation = Quaternion.identity;
    }
}
