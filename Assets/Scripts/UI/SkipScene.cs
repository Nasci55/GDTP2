using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SkipScenes());
    }

    private IEnumerator SkipScenes()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(1);
        }

        else
        {
            yield return new WaitForSeconds(4f);
            SceneManager.LoadScene(0);
        }
    }
}
