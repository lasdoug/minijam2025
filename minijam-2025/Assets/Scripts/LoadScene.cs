using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;
    private float timer = 0;
    public float threshold;
    void Update()
    {
        if (timer < threshold)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }

    }
    
}
