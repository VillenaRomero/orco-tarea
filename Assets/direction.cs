using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class direction : MonoBehaviour
{
    public int speed = 20;
    //public Transform player;
    public GameObject player;
    public Transform punto;
    public Transform referencia;
    public float seekplayer;
    private float destroyrange;
    public int rotationSpeedx = 5;
    public int rotationSpeedy = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 enmyDir = (player.transform.position - transform.position).normalized;
        //print("Dot: " + Vector3.Dot(transform.right, enmyDir));
        float rawAngle = Vector3.Dot(transform.right, enmyDir);
        float radians = Mathf.Acos(rawAngle);
        float angle = radians * Mathf.Rad2Deg;
        print("Angle: " + angle);
        if (Vector3.Distance(player.transform.position, transform.position) < seekplayer && angle <= 60)
        {
            //Vector3 enmyDir = (player.transform.position - transform.position).normalized;



            //Vector3.Dot(transform.right, enmyDir);
            DrawVectors.Instance.Draw(transform.position, transform.position + transform.right, Color.green);
            DrawVectors.Instance.Draw(transform.position, transform.position + enmyDir, Color.cyan);

            //print(Vector3.Distance(transform.position, player.position));
            transform.position += enmyDir * speed * Time.deltaTime;

            if (rawAngle < 0) {
                GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
                //transform.localScale = transform.localScale != ;
                DrawVectors.Instance.Draw(transform.position, transform.position - transform.right, Color.green);

            }
        }
        else {
            Vector3 enmyvolver = (punto.position - transform.position).normalized;
            print(Vector3.Distance(transform.position, punto.position));
            transform.position += enmyvolver * speed * Time.deltaTime;
            DrawVectors.Instance.Draw(transform.position, transform.position + enmyvolver, Color.magenta);
        }
        //Vector3 enmyDir = (player.position - transform.position).normalized;
        //Vector3 enmyDir = (player.transform.position - transform.position).normalized;

        //print(Vector3.Distance(transform.position, player.position));
        //transform.position += enmyDir * speed * Time.deltaTime;
        //DrawVectors.Instance.Draw(transform.position, transform.position + enmyDir, Color.magenta);

        /*if (Vector3.Distance(player.transform.position,transform.position)< destroyrange) {
            Destroy(gameObject);
        }*/
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position,destroyrange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, seekplayer);

    }
    void Rotationenemy() {
        Vector2 enemigoseguir = (player.transform.position - transform.position);


        //  transform.Rotate(player.transform * rotationSpeedy,player.transform *rotationSpeedx,0);
    }
    /*void PlayerRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouseX * rotationSpeed, 0f);
    }*/
}
