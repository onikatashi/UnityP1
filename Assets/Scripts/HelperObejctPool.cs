using System.Collections.Generic;
using UnityEngine;

public class HelperObejctPool : MonoBehaviour
{
    public static HelperObejctPool Instance;

    public GameObject bulletFactory;
    public Queue<GameObject> helperBulletPool;     // 총알 오브젝트 풀링 큐
    int helperPoolSize = 5;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        InitObejctPooling();
    }

    void InitObejctPooling()
    {
        helperBulletPool = new Queue<GameObject>();
        for (int i = 0; i < helperPoolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.SetActive(false);
            helperBulletPool.Enqueue(bullet);
        }
    }

    public void ReloadBullet(GameObject obj)
    {
        obj.SetActive(false);
        helperBulletPool.Enqueue(obj);
    }
}
