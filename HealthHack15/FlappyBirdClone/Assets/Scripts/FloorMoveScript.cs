using UnityEngine;
using System.Collections;

public class FloorMoveScript : MonoBehaviour
{
    public float ScreenWidth;
    void Update()
    {
        if(GameStateManager.GameState == GameState.Dead) return;

        if (transform.localPosition.x < -ScreenWidth)
        {
            transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
        }

        transform.position += Vector3.left * Time.deltaTime;
    }
}
