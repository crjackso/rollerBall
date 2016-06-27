using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public Rigidbody rb;
	public float speed;
	private int count;
	public Text countText;
	public Text winText;

	void Start() {
		rb = GetComponent<Rigidbody> ();	
		count = 0;
		UpdateCountText ();
		winText.text = "";
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		var movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed); 
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive (false);
			count++;
			UpdateCountText ();
		}
	}

	void UpdateCountText() {
		countText.text = string.Format ("{0} items", count);
		if (count >= 11) {
			winText.text = "You Win!";
		}
	}
}
