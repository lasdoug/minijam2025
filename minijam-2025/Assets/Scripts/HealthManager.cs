using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int health = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    // Update is called once per frame
    void Update()
    {
        foreach (var img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (var i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;
        }

    }
}
