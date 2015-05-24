using UnityEngine;
using System.Collections;

public class RewardController : MonoBehaviour
{
    public FlappyScript Flappy;
    public GameObject Booster;

    float mStartSpeed;
    Animator mAnimator;

    void Start()
    {
        mStartSpeed = Flappy.XSpeed;
        mAnimator = Flappy.GetComponent<Animator>();
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            ActivateReward();
        }
    }

    public void ActivateReward()
    {
        Flappy.XSpeed = mStartSpeed * 1.5f;
        mAnimator.SetBool("super", true);
        var booster = Instantiate(Booster, Flappy.transform.position, Quaternion.identity) as GameObject;
        booster.transform.parent = Flappy.transform;
    }
}
