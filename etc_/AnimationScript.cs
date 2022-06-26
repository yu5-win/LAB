using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {

    public bool isAnimated = false;

    public bool isFloating = false;

    
    public float rotationSpeed;

    public float y_dis;//y축 이동거리
    private bool goingUp = true;
    public float floatRate;
    private float floatTimer;
   
    public Vector3 startScale;
    public Vector3 endScale;

    public float scaleSpeed;
    public float scaleRate;

	void Update () {
        if(isAnimated)
        {
            if(isFloating)
            {
                floatTimer += Time.deltaTime;
                Vector3 moveDir = new Vector3(0.0f, y_dis, 0.0f);
                transform.Translate(moveDir);

                if (goingUp && floatTimer >= floatRate)
                {
                    goingUp = false;
                    floatTimer = 0;
                    y_dis = -y_dis;
                }

                else if(!goingUp && floatTimer >= floatRate)
                {
                    goingUp = true;
                    floatTimer = 0;
                    y_dis = +y_dis;
                }
            }

        }
	}
}
