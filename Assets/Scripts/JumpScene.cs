using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpScene : MonoBehaviour {
	public void GoToScene(string sceneToJump) {
		SceneManager.LoadScene(sceneToJump);
	}
}
