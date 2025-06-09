using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class direction : MonoBehaviour
{
    //1 (public Transform player;)
    //public Transform referencia;
    //private float destroyrange;
    public int speed = 20;
    public GameObject player;
    public Transform punto;
    public float seekplayer = 10f;
    private float destroyrange = 1f;
    public float rotationSpeed = 200f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer < seekplayer)
        {
            float targetAngle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

            Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            transform.position += (Vector3)directionToPlayer * speed * Time.deltaTime;

            DrawVectors.Instance.Draw(transform.position, transform.position + (Vector3)directionToPlayer, Color.green);
        }
        else
        {
            Vector2 returnDirection = (punto.position - transform.position).normalized;
            float returnAngle = Mathf.Atan2(returnDirection.y, returnDirection.x) * Mathf.Rad2Deg;
            Quaternion returnRotation = Quaternion.Euler(0, 0, returnAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, returnRotation, rotationSpeed * Time.deltaTime);

            transform.position += (Vector3)returnDirection * speed * Time.deltaTime;

            DrawVectors.Instance.Draw(transform.position, transform.position + (Vector3)returnDirection, Color.magenta);
        }

        //1(print("Dot: " + Vector3.Dot(transform.right, enmyDir));)
        // print("Angle: " + angle);
        /*if (Vector3.Distance(player.transform.position, transform.position) < seekplayer && angle <= 60)
        {
            //1(Vector3 enmyDir = (player.transform.position - transform.position).normalized;)



            //1(Vector3.Dot(transform.right, enmyDir),)
            DrawVectors.Instance.Draw(transform.position, transform.position + transform.right, Color.green);
            DrawVectors.Instance.Draw(transform.position, transform.position + enmyDir, Color.cyan);

            //1(print(Vector3.Distance(transform.position, player.position));)
            transform.position += enmyDir * speed * Time.deltaTime;

            if (rawAngle < 0) {
                GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
                //1(transform.localScale = transform.localScale != ;)
                DrawVectors.Instance.Draw(transform.position, transform.position - transform.right, Color.green);

            }
        }
        else {
            Vector3 enmyvolver = (punto.position - transform.position).normalized;
            print(Vector3.Distance(transform.position, punto.position));
            transform.position += enmyvolver * speed * Time.deltaTime;
            DrawVectors.Instance.Draw(transform.position, transform.position + enmyvolver, Color.magenta);
        }
        //1(Vector3 enmyDir = (player.position - transform.position).normalized;)
        //1(Vector3 enmyDir = (player.transform.position - transform.position).normalized;)

        //1(print(Vector3.Distance(transform.position, player.position));)
        //1(transform.position += enmyDir * speed * Time.deltaTime;)
        //1(DrawVectors.Instance.Draw(transform.position, transform.position + enmyDir, Color.magenta);

        /*2(if (Vector3.Distance(player.transform.position,transform.position)< destroyrange) {
            Destroy(gameObject);))}*/
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, destroyrange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, seekplayer);
    }
}
