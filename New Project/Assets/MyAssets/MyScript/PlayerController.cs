using UnityEngine;
using UnityEngine.Networking;
using System.Threading;

public class PlayerController : NetworkBehaviour
{

    public Rigidbody rb;

    private float tps = 0;
    public float gap;
    public float moveSpeed;
    public float jumpForce;
    public Camera PlayerCam;
    private Vector3 north;
    private Vector3 south;
    private Vector3 west;
    private Vector3 east;
    private Vector3 north_East;
    private Vector3 north_West;
    private Vector3 south_East;
    private Vector3 south_West;
    Vector3 from1to2 = new Vector3(-300, 0.5f, -140);
    Vector3 from2to1 = new Vector3(0, 0.5f, 60);
    Vector3 from3to1 = new Vector3(0, 0.5f, -60);
    Vector3 from3to2 = new Vector3(-300, 0.5f, -260);
    Vector3 from1to3 = new Vector3(237.5f, 0.5f, -240);
    Vector3 from2to3 = new Vector3(162.5f, 0.5f, -240);
    

    void Start()
    {
        float factor = Mathf.Sqrt(2) / 2;
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveSpeed);
        north = new Vector3(0, rb.velocity.y, moveSpeed);
        south = new Vector3(0, rb.velocity.y, -moveSpeed);
        west = new Vector3(-moveSpeed, rb.velocity.y, 0);
        east = new Vector3(moveSpeed, rb.velocity.y, 0);
        north_East = new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed);
        north_West = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed);
        south_East = new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed);
        south_West = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed);
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            PlayerCam.enabled = false;
            return;
        }

        if (!rb.GetComponent<GameOver>().isOver)
        {
            if (Input.GetKey("d") && Time.time - tps >= gap && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
            {
                if (rb.velocity == north)
                {
                    rb.velocity = east;
                    transform.Rotate(0, 90, 0);
                }
                else if (rb.velocity == east)
                {
                    rb.velocity = south;
                    transform.Rotate(0, 90, 0);
                }
                else if (rb.velocity == south)
                {
                    rb.velocity = west;
                    transform.Rotate(0, 90, 0);
                }
                else if (rb.velocity == west)
                {
                    rb.velocity = north;
                    transform.Rotate(0, 90, 0);
                }
                else if (rb.velocity == north_East)
                {
                    rb.velocity = south_East;
                    transform.Rotate(0, 90, 0);
                }
                else if (rb.velocity == south_East)
                {
                    rb.velocity = south_West;
                    transform.Rotate(0, 90, 0);
                }
                else if (rb.velocity == south_West)
                {
                    rb.velocity = north_West;
                    transform.Rotate(0, 90, 0);
                }
                else if (rb.velocity == north_West)
                {
                    rb.velocity = north_East;
                    transform.Rotate(0, 90, 0);
                }
                tps = Time.time;
            }

            if (Input.GetKey("q") && Time.time - tps >= gap && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
            {
                if (rb.velocity == north)
                {
                    rb.velocity = west;
                    transform.Rotate(0, -90, 0);
                }
                else if (rb.velocity == west)
                {
                    rb.velocity = south;
                    transform.Rotate(0, -90, 0);
                }
                else if (rb.velocity == south)
                {
                    rb.velocity = east;
                    transform.Rotate(0, -90, 0);
                }
                else if (rb.velocity == east)
                {
                    rb.velocity = north;
                    transform.Rotate(0, -90, 0);
                }
                else if (rb.velocity == north_East)
                {
                    rb.velocity = north_West;
                    transform.Rotate(0, -90, 0);
                }
                else if (rb.velocity == north_West)
                {
                    rb.velocity = south_West;
                    transform.Rotate(0, -90, 0);
                }
                else if (rb.velocity == south_West)
                {
                    rb.velocity = south_East;
                    transform.Rotate(0, -90, 0);
                }
                else if (rb.velocity == south_East)
                {
                    rb.velocity = north_East;
                    transform.Rotate(0, -90, 0);
                }
                tps = Time.time;
            }

            if (Input.GetKey("e") && Time.time - tps >= gap && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
            {
                if (rb.velocity == north)
                {
                    rb.velocity = north_East;
                    transform.Rotate(0, 45, 0);
                }
                else if (rb.velocity == north_East)
                {
                    rb.velocity = east;
                    transform.Rotate(0, 45, 0);
                }
                else if (rb.velocity == east)
                {
                    rb.velocity = south_East;
                    transform.Rotate(0, 45, 0);
                }
                else if (rb.velocity == south_East)
                {
                    rb.velocity = south;
                    transform.Rotate(0, 45, 0);
                }
                else if (rb.velocity == south)
                {
                    rb.velocity = south_West;
                    transform.Rotate(0, 45, 0);
                }
                else if (rb.velocity == south_West)
                {
                    rb.velocity = west;
                    transform.Rotate(0, 45, 0);
                }
                else if (rb.velocity == west)
                {
                    rb.velocity = north_West;
                    transform.Rotate(0, 45, 0);
                }
                else if (rb.velocity == north_West)
                {
                    rb.velocity = north;
                    transform.Rotate(0, 45, 0);
                }
                tps = Time.time;
            }

            if (Input.GetKey("a") && Time.time - tps >= gap && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
            {
                if (rb.velocity == north)
                {
                    rb.velocity = north_West;
                    transform.Rotate(0, -45, 0);
                }
                else if (rb.velocity == north_West)
                {
                    rb.velocity = west;
                    transform.Rotate(0, -45, 0);
                }
                else if (rb.velocity == west)
                {
                    rb.velocity = south_West;
                    transform.Rotate(0, -45, 0);
                }
                else if (rb.velocity == south_West)
                {
                    rb.velocity = south;
                    transform.Rotate(0, -45, 0);
                }
                else if (rb.velocity == south)
                {
                    rb.velocity = south_East;
                    transform.Rotate(0, -45, 0);
                }
                else if (rb.velocity == south_East)
                {
                    rb.velocity = east;
                    transform.Rotate(0, -45, 0);
                }
                else if (rb.velocity == east)
                {
                    rb.velocity = north_East;
                    transform.Rotate(0, -45, 0);
                }
                else if (rb.velocity == north_East)
                {
                    rb.velocity = north;
                    transform.Rotate(0, -45, 0);
                }
                tps = Time.time;
            }

            if (Input.GetKey(KeyCode.Space) && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
            {
                rb.AddForce(0, jumpForce, 0);
            }
            

        }

    }
    private void Update()
    {
        if (rb.GetComponent<WallCreater>().enabled == true && ((rb.transform.position.x > -15 && rb.transform.position.x < 15 && rb.transform.position.z > 45) || (rb.transform.position.x > -15 && rb.transform.position.x < 15 && rb.transform.position.z < -45) || (rb.transform.position.x > -315 && rb.transform.position.x < -285 && rb.transform.position.z > -155) || (rb.transform.position.x > -315 && rb.transform.position.x < -285 && rb.transform.position.z <-235) || (rb.transform.position.x < 177.5 && rb.transform.position.x > 147.5 && rb.transform.position.z > -255 ) || (rb.transform.position.x < 252.5 && rb.transform.position.x > 222.5 && rb.transform.position.z > -255)))
        {
            rb.GetComponent<WallCreater>().enabled = false;
        }
        if (!(rb.GetComponent<WallCreater>().enabled == true && ((rb.transform.position.x > -15 && rb.transform.position.x < 15 && rb.transform.position.z > 45) || (rb.transform.position.x > -15 && rb.transform.position.x < 15 && rb.transform.position.z < -45) || (rb.transform.position.x < -315 && rb.transform.position.x > -285 && rb.transform.position.z > -155) || (rb.transform.position.x < -315 && rb.transform.position.x > -285 && rb.transform.position.z < -275) || (rb.transform.position.x > 177.5 && rb.transform.position.x < 147.5 && rb.transform.position.z > -255) || (rb.transform.position.x < 252.5 && rb.transform.position.x > 222.5 && rb.transform.position.z > -255))))
        {
            rb.GetComponent<WallCreater>().enabled = true;
        }
        rb.angularVelocity = new Vector3(0, 0, 0);
        print(" x = " + rb.velocity.x);        
        print(" z = " + rb.velocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "transporter 1 to 2")

        {            
            rb.transform.position = new Vector3(0, 200.5f, 80);            
            rb.velocity = new Vector3(-300, 0, -220);           
        }

        if (collision.gameObject.name == "transporter chemin 1 to 2")

        {
            rb.transform.position = new Vector3(-300, 0.5f, -140);
            rb.velocity = south;
            rb.transform.Rotate(0, 180, 0);            
        }

        if (collision.gameObject.name == "transporter 1 to 3")

        {
            
            rb.transform.position = new Vector3(0, 200.5f, -80);
            rb.velocity = new Vector3(236.3f, 0, -160.545f);           
            
        }
        if (collision.gameObject.name == "transporter chemin 1 to 3")

        {
            rb.transform.position = from1to3;
            rb.velocity = south;            

        }

        if (collision.gameObject.name == "transporter 2 to 1")

        {
            rb.transform.position = new Vector3(-300, 200.5f, -120);
            rb.velocity = new Vector3(297.4f, 0, 184.3f);           
        }
        if (collision.gameObject.name == "transporter chemin 2 to 1")

        {
            rb.transform.position = from2to1;
            rb.velocity = south;
            rb.transform.Rotate(0, 180, 0);
            
        }
        if (collision.gameObject.name == "transporter 2 to 3")

        {
            
            rb.transform.position = new Vector3(-300, 200.5f, -280); 
            rb.velocity = new Vector3(462.5f, 0, 40);
        }
        if (collision.gameObject.name == "transporter chemin 2 to 3")

        {
            rb.transform.position = from2to3;
            rb.velocity = south;

        }
        if (collision.gameObject.name == "transporter 3 to 1")

        {
            rb.transform.position = new Vector3(237.5f, 200.5f, -220);
            rb.velocity = new Vector3(-237.5f , 0, 160);           
        }

        if (collision.gameObject.name == "transporter chemin 3 to 1")

        {
            rb.transform.position = from3to1;
            rb.velocity = north;
            
        }

        if (collision.gameObject.name == "transporter 3 to 2")

        {
            rb.transform.position = new Vector3(162.5f, 200.5f, -220);
            rb.velocity = new Vector3(-462.5f, 0, -40);            
        }

        if (collision.gameObject.name == "transporter chemin 3 to 2")

        {            
            rb.transform.position = from3to2;
            rb.velocity = new Vector3(0, rb.velocity.y, 25);

        }
    }


    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = new Color(0, 0, 255, 255);
        GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
        GetComponent<TrailRenderer>().material.color = new Color(0, 0, 255, 255);
        GetComponent<TrailRenderer>().material.DisableKeyword("_EMISSION");
    }
}
