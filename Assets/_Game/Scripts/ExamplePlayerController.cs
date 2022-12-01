using UnityEngine;

public class ExamplePlayerController : MonoBehaviour
{
	[SerializeField] public CirclesData circlesData = null;
	//public Color materialColor;
	private Rigidbody m_rigidbody;

	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";
	public string jumpButton = "Jump";

	private float inputHorizontal;
	private float inputVertical;
	//private int direction = -1;

	void Awake()
	{
		m_rigidbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		inputHorizontal = SimpleInput.GetAxis( horizontalAxis );
		inputVertical = SimpleInput.GetAxis( verticalAxis );

		transform.Rotate( 0f, circlesData.direction*inputHorizontal * 2f, 0f, Space.World );

		if( SimpleInput.GetButtonDown( jumpButton ) && IsGrounded() )
			m_rigidbody.AddForce( 0f, 2f, 0f, ForceMode.Impulse );
	}

	void FixedUpdate()
	{
		m_rigidbody.AddRelativeForce( new Vector3( 0f, 0f, -inputVertical ) * 20f );
	}

	void OnCollisionEnter( Collision collision )
	{
		if( collision.gameObject.CompareTag( "Player" ) )
			m_rigidbody.AddForce( collision.contacts[0].normal * 10f, ForceMode.Impulse );
	}

	bool IsGrounded()
	{
		return Physics.Raycast( transform.position, Vector3.down, 1.75f );
	}
}