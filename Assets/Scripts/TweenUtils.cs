using UnityEngine;

public static class TweenUtils
{
    public static float EaseIn(float t)
    {
        return t * t;
    }
   
    public static float EaseOut(float t)
    {
        return 1 - (1 -t) * (1- t) ;
    }
    
    //new  tweens


    public static float LoopingEase(float t)
    {
        t = Mathf.PingPong(t, 1);

        const float c4 = (2 * Mathf.PI) / 3;

        if (t == 0)
        {
            return 0;
        }
        else if (t == 1)
        {
            return 1;
        }
        else
        {
            return -Mathf.Pow(2, 10 * t - 10) * Mathf.Sin((t * 10 - 10.75f) * c4) + 1;
        }
    }

    public static float EaseInElastic(float t)
    {
        const float c4 = (2 * Mathf.PI) / 3;

        if (t == 0)
        {
            return 0;
        }
        else if (t == 1)
        {
            return 1;
        }
        else
        {
            return -Mathf.Pow(2, 10 * t - 10) * Mathf.Sin((t * 10 - 10.75f) * c4);
        }
    }

    public static float EaseOutElastic(float t)
    {
        const float c4 = (2 * Mathf.PI) / 3;

        if (t == 0)
        {
            return 0;
        }
        else if (t == 1)
        {
            return 1;
        }
        else
        {
            return Mathf.Pow(2, -10 * t) * Mathf.Sin((t * 10 - 0.75f) * c4) + 1;
        }
    }

    public static float EaseOutBounce(float t)
    {
        const float n1 = 7.5625f;
        const float d1 = 2.75f;

        if (t < 1 / d1)
        {
            return n1 * t * t;
        }
        else if (t < 2 / d1)
        {
            return n1 * (t -= 1.5f / d1) * t + 0.75f;
        }
        else if (t < 2.5 / d1)
        {
            return n1 * (t -= 2.25f / d1) * t + 0.9375f;
        }
        else
        {
            return n1 * (t -= 2.625f / d1) * t + 0.984375f;
        }
    }
}