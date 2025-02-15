using UnityEngine;

public class LogicScript : MonoBehaviour
{
    public float counter = 0;
    public bool cntStarted = false;
    public bool cntEnd = false;
    public TMPro.TMP_Text scoreDisplay;
    
    public void StartCounter(){
        cntStarted = true;
    }
    public void StopCounter(){
        cntEnd = true;
    }

    void Start()
    {
        scoreDisplay.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(cntEnd){
            scoreDisplay.text = "Congratulations! Hit play in " + counter.ToString() + "!";
            cntEnd = false; cntStarted = false;
            return;
        }
        if(cntStarted){
            counter += Time.deltaTime;
            scoreDisplay.text = counter.ToString();
        }

    }
}
