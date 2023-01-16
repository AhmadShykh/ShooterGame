using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collisionDetector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float delayTime = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void OnTriggerEnter(Collider other)
	{
        restartLevel();
	}
	void OnCollisionEnter(Collision collision)
	{
        restartLevel();
    }
    void restartLevel()
	{
        GetComponent<playerScript>().enabled = false;
        Invoke("ReloadLevel",delayTime);
	}

    void ReloadLevel()
	{
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

	}
}
