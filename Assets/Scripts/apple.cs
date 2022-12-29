using UnityEngine;
using System.Collections;


public class apple : MonoBehaviour
{
    void Start()
    {

        //極座標系で向き(direction)と長さ(speed)をランダムに決定
        float direction = Random.Range(0, 359);
        float speed = 2;
        Vector2 v;

        //極座標系を直交座標系に変換
        v.x = Mathf.Cos (Mathf.Deg2Rad * direction) * speed;
        v.y = Mathf.Sin (Mathf.Deg2Rad * direction) * speed;

        //Rigidbody2Dに速度として設定
        RigidBody.velocity = v;

        Count++;

    }

    void Update()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint (Vector2.zero);
        Vector2 max = Camera.main.ViewportToWorldPoint (Vector2.one);

        if (transform.position.x < min.x || max.x < transform.position.x)
        {
            Vector2 v = RigidBody.velocity;
            v.x *= -1;
            RigidBody.velocity = v;
        }
        if (transform.position.y < min.y || max.y < transform.position.y)
        {
            Vector2 v = RigidBody.velocity;
            v.y *= -1;
            RigidBody.velocity = v;
        }
    }

    public void OnMouseDown()
    {
        Add(transform.position);
        Destroy(gameObject);
        Count--;
        PlayerInfo.SetScore(PlayerInfo.GetScore()+1);
    }
 
    public crash Add(Vector3 pos)
    {
        GameObject g = Instantiate (Crash, pos, Quaternion.identity) as GameObject;
        crash obj = g.GetComponent<crash> ();
        return obj;
    }
    GameObject _crash = null;
    public GameObject Crash {
        get { return _crash ?? (_crash = Resources.Load ("Prefabs/crash") as GameObject); }
    }



    // appleオブジェクトに追加したRigidbody2Dコンポーネントへアクセスする
    Rigidbody2D _rigidbody2D = null;
    public Rigidbody2D RigidBody {
        get { return _rigidbody2D ?? (_rigidbody2D = gameObject.GetComponent<Rigidbody2D> ()); }
    }

    //float _width = 0.0f;
    //float _height = 0.0f;

    public static int Count = 0;

}