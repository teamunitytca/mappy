
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger {

	static public void sceneChange ( string scene ) {
		SceneManager.LoadScene( scene );
		//if (scene == "Main") {
		//    SceneManager.LoadScene("Stage",LoadSceneMode.Additive);
		//}
	}
}
