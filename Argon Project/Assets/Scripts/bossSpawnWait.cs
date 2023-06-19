using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSpawnWait : MonoBehaviour
{
    [SerializeField] GameObject bossShip;
    void Start()
    {
        Invoke("callInstan", 31);
    }

    void callInstan()
	{
        bossShip.SetActive(true);
	}
}
