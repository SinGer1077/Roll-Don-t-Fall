using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RollDontFall.TrackModule;

public class StraightChank : Chank
{  
    public StraightChank(GameObject gameObject, int difficultLevel, Vector3 firstPosition, float length, Material material) : base(gameObject, difficultLevel, firstPosition, material)
    {
        this.Length = length;
        Debug.Log("Я прямой чанк");
    }

    public StraightChank(GameObject gameObject, int difficultLevel, Vector3 firstPosition, Material material) : base(gameObject, difficultLevel, firstPosition, material)
    {        
        Debug.Log("Я прямой чанк");
    }

    public override void GenerateChank()
    {
        Vector3 secondPosition = new Vector3(this.FirstPosition.x, this.FirstPosition.y, this.FirstPosition.z + this.Length / 4);
        Vector3 thirdPosition = new Vector3(this.FirstPosition.x, this.FirstPosition.y, secondPosition.z + this.Length / 4);
        Vector3 fourthPosition = new Vector3(this.FirstPosition.x, this.FirstPosition.y, thirdPosition.z + this.Length / 4);

        TrackChank track = new TrackChank(new Vector3[] { this.FirstPosition, secondPosition, thirdPosition, fourthPosition });
        track.FormChank();
        AddBezierLine(track);
        SetLastPos(fourthPosition);
    }
}
