using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyEffect;
    GameObject newParent;
    [SerializeField] int enemyScore = 15;
    [SerializeField] float health = 10f;
    scoreBoard ScoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        newParent = GameObject.FindGameObjectWithTag("runtime") ;
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreBoard = FindObjectOfType<scoreBoard>();
    }

	void OnParticleCollision(GameObject other)
	{
        if(health != 0)
        processHit();	
        if(health < 1)
		    vanishObject();
    }

	private void vanishObject()
	{
		health = 0;
		GameObject vfx = Instantiate(destroyEffect, transform.position, Quaternion.identity);
		vfx.transform.parent = newParent.transform;
		Destroy(gameObject);
        ScoreBoard.increaseScore(enemyScore);

    }

	private void processHit()
	{
		health -= 3;
        StartCoroutine(flashRed());
	}

	public IEnumerator flashRed()
	{
        
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        GetComponent<Renderer>().material.color = Color.white;
    }
}
