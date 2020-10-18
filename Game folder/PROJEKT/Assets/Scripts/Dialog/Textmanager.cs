using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textmanager : MonoBehaviour
{
    [System.NonSerialized] public char[] chars = "!#$%&()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[]_`{|}~abcdefghijklmnopqrstuvwxyz ".ToCharArray();
    [SerializeField] Sprite[] charsprite;
    [SerializeField] Dictionary<char, Chardata> chardata;
    [SerializeField] Texture2D charSheet;
    [SerializeField] int spritesize = 80;
    [SerializeField] int spriteheigh = 64;
    [Range(0.0001F,0.01F)]
    [SerializeField] float charlength = 0.1f;
    [SerializeField] public float NewtextPos;
    


    void Start()
    {
        //GetSubSprites();
        GetspriteWidths();
    }

    /*public void GetSubSprites()
    {
        Sprite[] subsprite = Resources.LoadAll<Sprite>(charSheet.name);
        charsprite = subsprite;
    }*/

    public void GetspriteWidths()
    {
        int height = charSheet.height;
        int width = charSheet.width;

        int charIndex = 0;
        chardata = new Dictionary<char,Chardata>();

        for (int texCoordY = height; texCoordY > 0; texCoordY -= spriteheigh) //(i = 0; i < 5; i++) up to down
        {
            for (int texCoordX = 0; texCoordX < width; texCoordX += spritesize) // left to right
            {
                //print(charIndex);
                int x = 0;
                int y = 0;

                int min = 0;
                int max = spritesize;

                //get min width
                while (min == 0 && x < spritesize)
                {
                    for (y = 0; y < spritesize; y++)
                    {
                        if (charSheet.GetPixel(texCoordX + x, texCoordY - y).a != 0)
                        {
                            min = x;
                        }
                    }
                    x++;
                }
                x = spritesize;

                //get maxwidth

                while (max == spritesize && x > 0)
                {
                    for (y = 0; y < spritesize; y++)
                    {
                        if (charSheet.GetPixel(texCoordX + x, texCoordY - y).a != 0)
                        {
                            max = x;
                        }
                    }
                    x--;
                }

                //calculate
                int charwidth = max - min + 1;
                if (charwidth <= spritesize && charIndex < chars.Length)
                {
                    char c = chars[charIndex];
                    Sprite Charsprite = charsprite[charIndex];
                    chardata.Add(c, new Chardata(charwidth, Charsprite));
                }
                ++charIndex;
            }

        }
    }

    public struct Chardata
    {
        public int width;
        public Sprite sprite;

        public Chardata(int width, Sprite sprite)
        {
            this.width = width;
            this.sprite = sprite;
        }
    }

    public float DisplayDialog(char input, Transform textlocation,GameObject letter)
    {
        print("go");
        GameObject newtext;
        NewtextPos = textlocation.position.x;

        newtext = Instantiate(letter);
        newtext.transform.position = new Vector3(textlocation.position.x,textlocation.position.y,textlocation.position.z);
        newtext.GetComponent<SpriteRenderer>().sprite = chardata[input].sprite;
        NewtextPos += (chardata[input].width * charlength);


        return (NewtextPos);
    }
}
