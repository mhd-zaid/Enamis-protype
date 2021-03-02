using UnityEngine;
using UnityEngine.SceneManagement;

namespace _enamis_prototype.Scripts.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        public string firstGameScene = "SampleScene";

        public void PlayButton()
        {
            SceneManager.LoadScene(firstGameScene);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
