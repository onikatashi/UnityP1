using Unity.VisualScripting;
using UnityEngine;

public class PlayerHelper : MonoBehaviour
{
    public Transform target;
    float distance = 1f;
    float speed = 5f;
    float sqrDistance;
    Vector3 dir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        sqrDistance = (transform.position - target.position).sqrMagnitude;
        // -> 오차기 있을 수 있음. 그냥 Magnitude쓰는게 나을지도
        dir = (target.position - transform.position).normalized;

        if (sqrDistance > distance * distance)
        {
            //transform.position = Vector3.Slerp(transform.position, target.position, 0.05f);
            //transform.position = Vector3.Lerp(transform.position, target.position, 0.05f);
            //transform.Translate(dir * 10f * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
