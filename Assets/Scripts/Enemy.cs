using UnityEngine;

/// <summary>
/// 1. 똥피하기 느낌으로 위에서 아래로 이동한다.
/// 2. 플레이어를 향해 총알 발사 
/// 3. 플레이어와 충돌하면 폭발 효과와 함께 사라짐 (충돌처리)
/// </summary>

// 자동으로 원하는 컴포넌트를 추가
// 반드시 필요한 컴포넌트를 실수로 삭제하는 것을 방지
[RequireComponent (typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public float speed = 5f;            // 적 비행기 속도
    public GameObject bulletFactory;    // 총알 공장

    public GameObject fxFactory;        // 이펙트 공장

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed *  Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // 폭발 효과
            ShowEffect();
            // 사운드 효과
            // 점수 증가
            // 적 비행기 사라짐
            Destroy(gameObject);
            //Destroy(gameObject, 2f); // 2초 뒤 사라짐

            // 충돌한 오브젝트가 플레이어인 경우 처리
            Destroy(collision.gameObject);

            // 씬 전환 처리
        }
    }

    void ShowEffect()
    {
        //if (fxFactory != null)
        //{
        //    Instantiate(fxFactory, transform.position, Quaternion.identity);
        //}

        GameObject fx = Instantiate(fxFactory);
        fx.transform.position = transform.position;
    }
}
