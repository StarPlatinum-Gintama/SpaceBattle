using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    [SerializeField] float force = 10f;
    Rigidbody2D rb;
    float horizontal;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        // Movimiento de la nave horizontal
        horizontal = Input.GetAxis("Horizontal");
        rb.AddForce(Vector3.right * horizontal * force);

        //Límite de la pantalla
        float pos = Mathf.Clamp(transform.position.x, -3.7f, 3.7f);

        
    }
}
