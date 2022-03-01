using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraController : MonoBehaviour
{
    [SerializeField] float _horizontalSpeed;
    [SerializeField] float _verticalSpeed;

    private Player _player;
    private PlayerHead _head;

    public void SetPlayer(Player player)
    {
        _player = player;
    }

    public void SetHead(PlayerHead head)
    {
        _head = head;
    }

    public void FixedUpdate()
    {
        ProcessHorizontalRotation();
        ProcessVerticalRotation();
    }

    private void ProcessHorizontalRotation()
    {
        float hInput = Input.GetAxis("Mouse X");
        float prevUpRot = _player.transform.rotation.y;
        float newUpRot = prevUpRot + hInput * Time.fixedDeltaTime * _horizontalSpeed;
        newUpRot = Mathf.Lerp(prevUpRot, newUpRot, Time.fixedDeltaTime);
        Vector3 eulerRot = _player.transform.rotation.eulerAngles;
        Quaternion newRot = Quaternion.Euler(new Vector3(eulerRot.x, newUpRot, eulerRot.z));
        _player.transform.rotation = newRot;
    }

    private void ProcessVerticalRotation()
    {
        float vInput = Input.GetAxis("Mouse Y");
        float newAngle = _head.transform.rotation.x + vInput * Time.fixedDeltaTime * _verticalSpeed;
        newAngle = Mathf.Clamp(newAngle, -180, 180);
        Vector3 curRot = _head.transform.rotation.eulerAngles;
        Quaternion newRot = Quaternion.Euler(new Vector3(newAngle, curRot.y, curRot.z));
        _head.transform.rotation = newRot;
    }
}
