using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToScene : MonoBehaviour {
	[SerializeField]
	public string sceneToJump;

	private Button button;

	void Awake() {
		button = gameObject.GetComponent<Button>();
		button.onClick.AddListener(GoToScene);
	}

	public void GoToScene() {
		SceneManager.LoadScene(sceneToJump);
	}
}
