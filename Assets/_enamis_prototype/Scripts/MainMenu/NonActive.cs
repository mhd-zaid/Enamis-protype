using UnityEngine;

namespace _enamis_prototype.Scripts.MainMenu
{
    public class NonActive : MonoBehaviour
    {
        public GameObject gameobjet;
        void Start()
        {
            //optionMenu = GameObject.Find("OptionMenu");
            gameobjet.SetActive(false);
        }
    }
}
