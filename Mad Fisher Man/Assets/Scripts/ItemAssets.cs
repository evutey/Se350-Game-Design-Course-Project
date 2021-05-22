using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour {

    public static ItemAssets Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }
    public Transform pfItemWorld;
    public Sprite fish1;
    public Sprite fish2;
    public Sprite fish3;
    public Sprite fish4;
    public Sprite fish5;
    public Sprite fish6;
    public Sprite fish7;
    public Sprite fish8;
}
