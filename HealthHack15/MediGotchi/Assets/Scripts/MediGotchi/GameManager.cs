using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Transform ProgressBar;
    
    int mStepCounter;

    int BAR_MAX = 25;
    public float BAR_LEFT = -0.5f;
    Vector3 mBarCenter;

    void Start()
    {
        mBarCenter = Camera.main.WorldToScreenPoint(ProgressBar.position);
        SetProgressBarLength(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            trigger();
        }
    }
    
    public void trigger(){
    
        IncreaseStep();

		SetProgressBarLength(Mathf.Min((float)mStepCounter / BAR_MAX, 1f));
    }
    
    public void Set(int newMax){
    
		SetProgressBarLength(0);
    	
    	BAR_MAX = newMax;
    }

    void IncreaseStep()
    {
        mStepCounter++;
    }

    void SetProgressBarLength(float progress)
    {
        var barScale = ProgressBar.localScale;
        ProgressBar.localScale = new Vector3(progress, barScale.y, barScale.z);

        var barPos = ProgressBar.localPosition;
        ProgressBar.localPosition = new Vector3(BAR_LEFT * (progress - 1), barPos.y, barPos.z);
    }
}
