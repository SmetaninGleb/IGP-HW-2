using System.Collections;
using UnityEngine;

[RequireComponent(typeof(FPSCameraController))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerHead _head;
    private FPSCameraController _cameraController;

    private void Start()
    {
        _cameraController = GetComponent<FPSCameraController>();
        _cameraController.SetHead(_head);
        _cameraController.SetPlayer(this);
    }
}