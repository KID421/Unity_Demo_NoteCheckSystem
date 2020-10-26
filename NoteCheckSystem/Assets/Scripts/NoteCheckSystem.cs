using UnityEngine;
using UnityEngine.UI;

public class NoteCheckSystem : MonoBehaviour
{
    public float rangePerfect;
    public float rangeGood;
    public float rangeBad;

    public Transform target = null;

    public Text textTip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "音符" && target == null) target = collision.transform;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "音符" && target != null) target = null;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "音符" && target == null) target = collision.transform;
    }

    private void Update()
    {
        if (target != null && Input.GetKeyDown(KeyCode.Mouse0)) CheckDistance();
    }

    /// <summary>
    /// 檢查距離
    /// </summary>
    private void CheckDistance()
    {
        float dis = Vector3.Distance(transform.position, target.position);

        if (dis <=  rangePerfect)
        {
            print("PERFECT!!!");
            Destroy(target.gameObject);
            textTip.text = "Perfect!!!";
        }
        else if (dis <= rangeGood)
        {
            print("GOOD!!!");
            Destroy(target.gameObject);
            textTip.text = "Good!!!";
        }
        else if (dis <= rangeBad)
        {
            print("BAD!!!");
            Destroy(target.gameObject);
            textTip.text = "Bad!!!";
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rangePerfect);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangeGood);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeBad);
    }
}
