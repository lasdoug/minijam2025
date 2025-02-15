using UnityEngine;

public class LogicScript : MonoBehaviour
{
    public float counter = 0;
    private bool cntStarted = false;
    private bool cntEnd = false;
    
    public void StartCounter(){
        cntStarted = true;
    }
    public void StopCounter(){
        cntEnd = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(cntEnd){
            return;
        }
        if(cntStarted){
            counter += Time.deltaTime;
        }

    }
}
