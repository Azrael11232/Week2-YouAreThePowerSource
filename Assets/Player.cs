using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D self;
    public float speed;
    public int energy;
    public int cost;
    public GameObject beam;

    public float fireRate = 0.2f;
    private float fireTimer;

    private Vector2 moveInput;

    void Update()
    {
        die();
        attack();
        aim();
    }

    void FixedUpdate()
    {
        movement();
    }

    void movement()
    {
        moveInput = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
            moveInput += Vector2.up;

        if (Input.GetKey(KeyCode.S))
            moveInput += Vector2.down;

        if (Input.GetKey(KeyCode.A))
            moveInput += Vector2.left;

        if (Input.GetKey(KeyCode.D))
            moveInput += Vector2.right;

        moveInput = moveInput.normalized;

        Vector2 newPosition = self.position + moveInput * speed * Time.fixedDeltaTime;
        self.MovePosition(newPosition);
    }


    void attack()
    {
        if (Input.GetMouseButton(0) && fireTimer <= 0)
        {   
            energy -= cost;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 direction = mousePosition - transform.position;
            direction.Normalize();

            Vector3 spawnPosition = transform.position + (Vector3)(direction * 1f);

            GameObject newBeam = Instantiate(beam, spawnPosition, transform.rotation);

            Rigidbody2D beamRB = newBeam.GetComponent<Rigidbody2D>();
            beamRB.linearVelocity = direction * 10f;

            fireTimer = fireRate;
        }

        fireTimer -= Time.deltaTime;
    }

    void die()
    {
        if (energy <= 0)
            Destroy(gameObject);
    }

    void aim()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePosition - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
}