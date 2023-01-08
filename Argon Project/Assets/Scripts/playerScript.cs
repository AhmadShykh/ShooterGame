using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class playerScript : MonoBehaviour
{
    [SerializeField] InputAction movement;
    // Start is called before the first frame update
    void Start()
    {
    }

	private void OnEnable()
	{
        movement.Enable();
	}

    private void OnDisable()
    {
        movement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = movement.ReadValue<Vector2>().x;
        float verticalMovement = movement.ReadValue<Vector2>().y;
        //float xAxis = Input.GetAxis("Horizontal");
        //float yAxis = Input.GetAxis("Vertical");
    }
}
