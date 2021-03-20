using UnityEngine;
using UnityEngine.UI;


public class PlayerMovementLab  : MonoBehaviour
{
	AndroidButonLab ab;



	public Rigidbody rb;

	public float ForwardForce = 2000f;
	public float SidewaysForce = 30f;
	public float JumpForce;

	void Start()
	{

		ab = GameObject.FindGameObjectWithTag("Canvas").GetComponent<AndroidButonLab>();

	}
	void FixedUpdate()
	{


		Android();


		rb.AddForce(0, 0, ForwardForce * Time.deltaTime);

		if (Input.GetKey("d"))
		{
			rb.AddForce(SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); //bu sag içim 
		}
		if (Input.GetKey("a"))
		{
			rb.AddForce(-SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); // buda sol 
		}
		if (Input.GetKey("w"))
		{
			rb.AddForce(1, 1, ForwardForce * Time.deltaTime);
		}


		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (isGrounded)
			{
				GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce);
				isGrounded = false;
			}

		}

		if (Input.GetKey("w"))
		{

			rb.AddForce(0, 0, ForwardForce * Time.deltaTime, ForceMode.VelocityChange);
		}

		if (Input.GetKey("s"))
		{

			rb.AddForce(0, 0, -ForwardForce * Time.deltaTime, ForceMode.VelocityChange);
		}
		

	}

	public void Jump()
	{
		if (isGrounded)
		{
			GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce);
			isGrounded = false;
		}


	}

	void Android()
	{

		if (ab.sag)
		{

			rb.AddForce(SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

		}

		if (ab.sol)
		{

			rb.AddForce(-SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

		}

		if (ab.yukarı)
		{

			rb.AddForce(0, 0, ForwardForce * Time.deltaTime, ForceMode.VelocityChange);

		}

		if (ab.asagı)
		{

			rb.AddForce(0, 0, -ForwardForce * Time.deltaTime, ForceMode.VelocityChange);

		}
	}
	public bool isGrounded;
	public RaycastHit hit;
	public float RayDistance = 2;
	public LayerMask Groundmask;
	public void Update()
	{
		Ray x = new Ray(transform.position, Vector3.down);
		Debug.DrawRay(x.origin, x.direction * RayDistance, Color.blue);
		if (Physics.Raycast(x, out hit, RayDistance, Groundmask))
		{
			isGrounded = true;
		}
		else
			isGrounded = false;
	}
	

}