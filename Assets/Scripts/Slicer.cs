using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BzKovSoft.ObjectSlicer;
using BzKovSoft.ObjectSlicerSamples;

public class Slicer : MonoBehaviour
{
    [SerializeField] private GameObject _blade;
    [SerializeField] private float _duration;
    [SerializeField] private float _offsetY;

    private BzKnife _knife;

    private Vector3 _knifeStartPosition;
    private bool _isKnifeInTheStartPosition;

    private void Start()
    {
        _knife = _blade.GetComponentInChildren<BzKnife>();

        _knifeStartPosition = _blade.transform.position;
        _isKnifeInTheStartPosition = true;
    }

    private void Update()
    {
        _isKnifeInTheStartPosition = _knifeStartPosition == _blade.transform.position;

        if(Input.GetMouseButtonDown(0) && _isKnifeInTheStartPosition)
        {
            _knife.BeginNewSlice();

            _blade.transform.DOMoveY(_blade.transform.position.y - _offsetY, _duration).SetLoops(2, LoopType.Yoyo);
        }
    }


}
