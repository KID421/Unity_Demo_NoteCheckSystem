using UnityEngine;

public class Note : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}
