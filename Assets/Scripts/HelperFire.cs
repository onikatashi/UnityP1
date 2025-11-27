using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 1. 아이템 먹어서 보조 비행기가 새롭게 생성되는 기능 (on/off)
/// 2. 보조비행기는 일정시간마다 자동으로 총알발사 한다
/// </summary>
public class HelperFire : MonoBehaviour
{
    public Transform helperFirePoint;       // 발사 위치
    public float attackSpeed = 2;           // 공격 속도
    float attackCooldown = 1f;              // 공격 쿨타임

    // 나는 빼고 나눠서 해결했지만
    // 이거는 그냥 더하기만 하고 수가 커지면 발사 하는 식으로 구현
    // 이게 성능적으로 더 좋을 듯
    // fireTime이 공격속도 -> 공격속도가 낮을 수록 빠른 공격속도 -> 스타크래프트 식
    // 내가 구현한건 공속이 높을수록 빠른 공격속도 -> 리그 오브 레전드 식
    public float fireTime = 1f;             // 총알 발사 간격
    float timer = 0f;                       // 시간 누적 변수

    // Update is called once per frame
    void Update()
    {
        attackCooldown -= Time.deltaTime;
        if (gameObject.activeSelf)
        {
            if (attackCooldown <= 0f)
            {
                AutoFire();
                attackCooldown = 1f / attackSpeed;
            }
        }
    }

    void AutoFire()
    {
        if (HelperObejctPool.Instance.helperBulletPool.Count > 0)
        {
            GameObject bullet = HelperObejctPool.Instance.helperBulletPool.Dequeue();
            bullet.SetActive (true);
            bullet.transform.position = helperFirePoint.position;
            bullet.transform.up = helperFirePoint.up;
        }
        else
        {
            GameObject bullet = Instantiate(HelperObejctPool.Instance.bulletFactory);
            bullet.SetActive (false);
            HelperObejctPool.Instance.helperBulletPool.Enqueue (bullet);
        }
    }
}
