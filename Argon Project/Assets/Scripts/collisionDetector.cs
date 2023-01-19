using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collisionDetector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float delayTime = 3f;
    [SerializeField] ParticleSystem collisionParticle;
    [SerializeField] GameObject colliderObject;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void OnTriggerEnter(Collider other)
	{
        crashSequence();
	}
	void OnCollisionEnter(Collision collision)
	{
        crashSequence();
    }
    void crashSequence()
	{
        GetComponent<MeshRenderer>().enabled = false;
        colliderObject.SetActive(false);
        collisionParticle.Play();
        GetComponent<playerScript>().enabled = false;
        Invoke("ReloadLevel",delayTime);
	}

    void ReloadLevel()
	{
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

	}
}
