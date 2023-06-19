using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singletonPattern : MonoBehaviour
{
	// Start is called before the first frame update
	void Awake()
	{
		int num = FindObjectsOfType<singletonPattern>().Length;	
		if(num > 1)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}
}
