using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerRotation : MonoBehaviour
{
    public static PlayerRotation Instance { get; private set; }
    bool rotate;
    public bool rotateClockwise;

    public float rotateSpeed;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 clockwiseRot = new Vector3(0, 0, -360);
        Vector3 reverseRot = new Vector3(0, 0, 360);

        if (Input.GetMouseButtonDown(0))
        {
            rotate = !rotate;
            if (rotate)
            {
                rotateClockwise = true;
            }
            else
            {
                rotateClockwise = false;
            }
        }
        if (rotateClockwise)
        {
            transform.Rotate(0, 0, rotateSpeed* Time.deltaTime);
            //transform.DOLocalRotate(clockwiseRot, rotateSpeed, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear);
        }
        else
        {
            transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
            //transform.DOLocalRotate(reverseRot, rotateSpeed, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear);
        }


    }

    public void StopRotation()
    {
        rotateSpeed = 0;
    }
    

}
