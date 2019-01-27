using UnityEngine;

[System.Serializable]
public class CameraMovementControl : MonoBehaviour
{
	public float cameraSpeed = 5F;
	public float maxZoom = 20;
	public float minZoom = 1;

	Camera mainCamera;

	Transform player;
	Transform cam;

	void Start()
	{
		mainCamera = Camera.main;
		player = GameObject.FindWithTag("Player").GetComponent<Transform>();
		cam = transform;
		mainCamera.orthographicSize = Mathf.Min(minZoom, maxZoom);
	}

	void LateUpdate()
	{

		Vector2 tPos = new Vector2((player.position.x), (player.position.y));

		Vector2 direction = new Vector2(tPos.x - cam.position.x, tPos.y - cam.position.y);

		cam.position = new Vector3(cam.position.x + direction.x * Time.deltaTime * cameraSpeed, cam.position.y + direction.y * Time.deltaTime * cameraSpeed, cam.position.z);

		if (Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			mainCamera.orthographicSize = Mathf.Max(mainCamera.orthographicSize - 1, minZoom);
		}
		if (Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			mainCamera.orthographicSize = Mathf.Min(mainCamera.orthographicSize + 1, maxZoom);
		}
	}
}