using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class vectordemovimiento : MonoBehaviour
{
    public int speed = 20;
    public Transform enemy;
    private void Start()
    {
    }
    private void Update()
    {
        
        if (Input.GetKey(KeyCode.Space)) {
            EnemyDir();
        }
        Movement();
    }
    public void EnemyDir()
    {
        Vector3 enmyDir = (enemy.position - transform.position).normalized;
        print(Vector3.Distance(transform.position, enemy.position));
        transform.position += enmyDir * speed * Time.deltaTime;
        DrawVectors.Instance.Draw(transform.position, transform.position + enmyDir, Color.magenta);
    }
    public void Movement() {
        
        if (Input.GetKey(KeyCode.A)) {
            /*Vector3 left = new Vector3(-1,0,0);
            transform.position += left* speed * Time.deltaTime; */

            transform.position += Vector3.left * speed * Time.deltaTime;
            DrawVectors.Instance.Draw(transform.position, transform.position+ Vector3.left, Color.blue);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            DrawVectors.Instance.Draw(transform.position, transform.position + Vector3.right, Color.yellow);
        }
        if (Input.GetKey(KeyCode.W)) {
            transform.position += Vector3.up * speed * Time.deltaTime;
            DrawVectors.Instance.Draw(transform.position, transform.position + Vector3.up, Color.red);
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.position += Vector3.down * speed * Time.deltaTime;
            DrawVectors.Instance.Draw(transform.position, transform.position + Vector3.down, Color.green);
        } }


}
