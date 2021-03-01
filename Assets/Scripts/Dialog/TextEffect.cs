using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEffect : MonoBehaviour
{
    public enum Effects { None, Wave, chromatic, Red}

    public Effects effect;

    [SerializeField] float WaveFrequency;
    [SerializeField] float WaveAmplitude;

    [SerializeField] SpriteRenderer SpriteRen;
    [SerializeField] float ColorChangeTime;
    [SerializeField] float ColorTimer;
    float timesincechange;

    Transform Originalpos;
    float x;

    void Start()
    {
        //y = sin x
        Originalpos = transform;

    }

    // Update is called once per frame
    void Update()
    {
        switch (effect)
        {
            case Effects.Wave:
                x += WaveFrequency;
                float y = Mathf.Sin(x) * WaveAmplitude;
                transform.position = new Vector3(Originalpos.position.x, Originalpos.position.y + y, Originalpos.position.z);
                break;

            case Effects.chromatic:
                timesincechange += Time.deltaTime;
                if (timesincechange >= ColorTimer)
                {
                    Color newcolor = new Color(
                    Random.value,
                    Random.value,
                    Random.value
                    );

                    SpriteRen.color = Color.Lerp(SpriteRen.color, Random.ColorHSV(0, 1, 1, 1, 1, 1), ColorChangeTime);
                    timesincechange = 0;
                }
                break;
            case Effects.Red:
                SpriteRen.color = Color.red;
                break;

        }

    }
}
