using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleRotator : MonoBehaviour
{
    [SerializeField] float _animDuration;
    private void Start()
    {
        transform.DORotate(new Vector3(0, 360, 0), _animDuration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
    }
}
