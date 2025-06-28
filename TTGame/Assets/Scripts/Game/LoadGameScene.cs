using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NetworkManager.Singleton.Shutdown();
        List<GameObject> netObjects = FindObjectOfType<NetworkObject>().Select(obj:NetworkObject => obj.transform.gameObject).ToList();

        foreach (var obj:GameObject in netObjects){
            Destroy(obj);
        }

        Destroy(FindObjectOfType<NetworkManager>().transform.gameObject);
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }


}
