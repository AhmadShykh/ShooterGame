using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    [SerializeField] GameObject destroyEffect;
    [SerializeField] Transform parent;
    [SerializeField] int enemyScore = 15;
    [SerializeField] float health = 10f;
    scoreBoard ScoreBoard;
    MeshRenderer newMesh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreBoard = FindObjectOfType<scoreBoard>();
    }

	void OnParticleCollision(GameObject other)
	{
        if(health != 0)
		{
            if (health - 3 > 0)
            {
                health -= 3;
                StartCoroutine(flashRed());
            }
            else
            {
                health = 0;
                GameObject vfx = Instantiate(destroyEffect, transform.position, Quaternion.identity);
                vfx.transform.parent = parent;
                Destroy(gameObject);
                ScoreBoard.increaseScore(enemyScore);
            }
        }
        
        

    }

    public IEnumerator flashRed()
	{
        newMesh.material.color = Color.red;
        yield return new WaitForSeconds(1f);
        newMesh.material.color = Color.white;
    }
}
