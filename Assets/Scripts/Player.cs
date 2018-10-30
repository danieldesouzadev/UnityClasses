using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private GameManager _gameManager;

    [SerializeField]
    private GameObject _ground;

    [SerializeField]
    private GameObject _cube;

    private float _moveSpeed;
	private float _rotationSpeed;

    [SerializeField]
	private ParticleSystem particles;

	Rigidbody _rb;
	public Vector3 _jump;
	public float _jumpForce;
	public bool _isGrounded;    

	void Start () {

		_moveSpeed = 35;
		_rotationSpeed = 90.0f;

        _jumpForce = 6.0f;
		_rb = GetComponent<Rigidbody>();
    	_jump = new Vector3(0.0f, 2.0f, 0.0f);

        particles.Stop();
	}
	
	void Update () {

        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
		
        //  Move

        transform.Translate(Vector3.forward * Time.deltaTime * _moveSpeed * verticalAxis);
        transform.Translate(Vector3.right * Time.deltaTime * _moveSpeed * horizontalAxis);

        //  Rotate

		float rotateX = Input.GetAxis("Mouse X") * _rotationSpeed * Mathf.Deg2Rad;
		transform.Rotate(Vector3.up, rotateX);
		
        //  Jump

		if (Input.GetKeyDown(KeyCode.Space) && _isGrounded) {

			_rb.AddForce(_jump * _jumpForce, ForceMode.Impulse);
			_isGrounded = false;
		}
	}

 	void OnCollisionStay() {

		_isGrounded = true;
	}

	void OnCollisionEnter(Collision collision) {

		if (collision.gameObject.tag == "TagObstacle") {

			particles.Play();

			Invoke("DisableParticles", 1);

            Destroy(collision.gameObject);

            _gameManager.UpdateScore();

            CreateCube();
        }
    }

	void DisableParticles() {

        particles.Stop();
	}

    void CreateCube() {

        float x = Random.Range(-100, 100);
        float y = 1;
        float z = Random.Range(-100, 100);
        Vector3 pos = new Vector3(x, y, z);

        Instantiate(_cube, pos, Quaternion.identity);
    }
}