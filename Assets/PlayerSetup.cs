
using UnityEngine;
using UnityEngine.Networking;
public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] ComponentsToDisable;
    Camera sceneCamera;
    void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < ComponentsToDisable.Length; i++)
            {
                ComponentsToDisable[i].enabled = false;
            }
        }
        else
        {
            sceneCamera = Camera.main;
            if (sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(false);
            }
        }

    }
    void OnDisable()
    {
        if (sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }
}



