using UnityEngine;

/// <summary>
/// 1. 보스등장
/// - 일정시간이 지난 후 등장
/// - 적이 모두 제거된 후 등장
/// 2. 보스 총알 패턴
/// - 플레이어를 추적하는 총알 발사
/// - 회전총알 발사
/// </summary>
public class Boss : MonoBehaviour
{
    public GameObject bulletFactory;    // 총알 공장
    public Transform target;            // 플레이어 위치
    public float fireTime = 1f;         // 총알 발사 간격
    float timer = 0f;                   // 타이머
    public int bulletMax = 10;          // 총알 최대 개수

    // Update is called once per frame
    void Update()
    {
        AutoFire2();
    }

    void AutoFire1()
    {
        // 타겟이 없을 때 총알 발사 금지
        if(target != null)
        {
            timer += Time.deltaTime;
            if (timer >= fireTime)
            {
                timer = 0f;


                // 총알 공장에서 총알 생성
                GameObject bullet = Instantiate(bulletFactory);

                // 총알 위치를 보스 위치로 변경
                bullet.transform.position = transform.position;

                // 총알 방향을 타겟 방향으로 변경
                Vector3 dir = target.position - transform.position;
                dir.Normalize();

            }
        }
    }

    void AutoFire2()
    {
        // 타겟이 없을 때 총알 발사 금지
        if (target != null)
        {
            timer += Time.deltaTime;
            if (timer >= fireTime)
            {
                timer = 0f;

                for (int i = 0; i < bulletMax; i++)
                {

                    // 총알 공장에서 총알 생성
                    GameObject bullet = Instantiate(bulletFactory);

                    // 총알 위치를 보스 위치로 변경
                    bullet.transform.position = transform.position;

                    // 총알 방향을 타겟 방향으로 변경
                    Vector3 dir = target.position - transform.position;
                    dir.Normalize();

                    // 회전 각도 계산
                    float angle = 360 / bulletMax;

                    bullet.transform.eulerAngles = new Vector3(0, 0, i * angle);
                }
            }
        }
    }
}
