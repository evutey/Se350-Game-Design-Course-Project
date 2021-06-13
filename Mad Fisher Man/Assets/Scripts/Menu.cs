using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
  public void playButton()
  {
    SceneManager.LoadScene(1);
  }
}
