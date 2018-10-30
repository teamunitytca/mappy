using UnityEngine.SceneManagement;

public class SceneChanger {

	static public void sceneChange ( string scene ) {
		SceneManager.LoadScene( scene );
	}
}
