using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RollDontFall.TrackModule;

public class HorizontalArcChank : Chank
{
    public HorizontalArcChank(GameObject gameObject, int difficultLevel, Vector3 firstPosition, float length, Material material) : base(gameObject, difficultLevel, firstPosition, material)
    {
        Debug.Log("Я поворотный чанк");
    }

    public HorizontalArcChank(GameObject gameObject, int difficultLevel, Vector3 firstPosition, Material material) : base(gameObject, difficultLevel, firstPosition, material)
    {
        Debug.Log("Я повортоный чанк");
    }

    public override void GenerateChank()
    {
        float arcCoef = 50f;
        float arcDistance = Random.Range(-arcCoef * this.DifficultLevel, arcCoef * this.DifficultLevel);

        Vector3 secondPosition = new Vector3(this.FirstPosition.x, this.FirstPosition.y, this.FirstPosition.z + this.Length / 4);
        Vector3 thirdPosition = new Vector3(this.FirstPosition.x + arcDistance, this.FirstPosition.y, secondPosition.z + this.Length / 4);
        Vector3 fourthPosition = new Vector3(this.FirstPosition.x, this.FirstPosition.y, thirdPosition.z + this.Length / 4);

        TrackChankFiller track = new TrackChankFiller(new Vector3[] { this.FirstPosition, secondPosition, thirdPosition, fourthPosition });
        track.FormChank();
        AddBezierLine(track);
        SetLastPos(fourthPosition);
    }
}
