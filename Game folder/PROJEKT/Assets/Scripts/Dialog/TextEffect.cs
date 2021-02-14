using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEffect : MonoBehaviour
{
    public enum Effects { None, Wave, chromatic }

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
        if (effect == Effects.Wave)
        {
            x += WaveFrequency;
            float y = Mathf.Sin(x) * WaveAmplitude;
            transform.position = new Vector3(Originalpos.position.x, Originalpos.position.y + y, Originalpos.position.z);
        }
        else if (effect == Effects.chromatic)
        {
            timesincechange += Time.deltaTime;
            if (timesincechange>= ColorTimer)
            {
                Color newcolor = new Color(
                Random.value,
                Random.value,
                Random.value
                );

                SpriteRen.color = Color.Lerp(SpriteRen.color, Random.ColorHSV(0,1,1,1,1,1), ColorChangeTime);
                timesincechange = 0;
            }


        }
    }
}
