using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerScript : MonoBehaviour
{
    //[SerializeField] InputAction movement;
    [Header("Movement Settings")]
    [Tooltip("SpaceShip Speed")] [SerializeField] float speed = 15f;
    [Tooltip("X Range from positive to negative")] [SerializeField] float xRange = 24f;
    [Tooltip("Y Range from positive to negative")] [SerializeField] float yRange = 15f;

    [Header("Array for all lasers")]
    [SerializeField] ParticleSystem[] allLasers;

    [Header("Rotation Parameters")]
    [SerializeField] float pitchPositionFactor = 2f;
    [SerializeField] float pitchThrowFactor = -20f;
    [SerializeField] float rollThrowFactor = -20f;
    [SerializeField] float yawPositionFactor = -1f;


    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
    }

	//private void OnEnable()
	//{
    //    //movement.Enable();
	//}

    //private void OnDisable()
    //{
    //    //movement.Disable();
    //}

    // Update is called once per frame
    void Update()
	{
		processTransformation();
        processRotation();
        processFiring();
	}

    void processFiring()
	{
		if (Input.GetButton("Fire1"))
		{
			ActivateParticles(true);
		}
		else
		{
            ActivateParticles(false);
        }
	}

	void ActivateParticles(bool allowEmit)
	{
		foreach (ParticleSystem eachLaser in allLasers)
		{
            if (allowEmit)
            { 
                if(!eachLaser.isEmitting ) eachLaser.Play(); 
            }
            else
            {
                if (eachLaser.isEmitting) eachLaser.Stop();
            }
        }
	}

	void processRotation()
	{
        float pitch = transform.localPosition.y * pitchPositionFactor + yThrow * pitchThrowFactor;
        float yaw = transform.localPosition.x * yawPositionFactor ;
        float roll = xThrow * rollThrowFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
	}
	void processTransformation()
	{

        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");


        float xMovement = xThrow * Time.deltaTime * speed + transform.localPosition.x;
		float yMovement = yThrow * Time.deltaTime * speed + transform.localPosition.y;

		float refinedX = Mathf.Clamp(xMovement, -xRange, xRange);
		float refinedY = Mathf.Clamp(yMovement, -yRange, yRange);


		transform.localPosition = new Vector3(refinedX, refinedY, transform.localPosition.z);
	}
}
