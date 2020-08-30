using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets i;

    private void Awake()
    {
        i = this;
    }

    public Sprite snakeHeadSprite;
    public Sprite snakeBodySprite;
    // public Sprite foodSprite;
    public GameObject GummyBear;
    public GameObject JellyThingie;
    public GameObject Marshmellow;
    public GameObject BearHead;
    public GameObject Spaghetti;
}
