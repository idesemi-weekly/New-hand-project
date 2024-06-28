using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReturnTitle : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
