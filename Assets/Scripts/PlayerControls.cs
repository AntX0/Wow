using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float _controlSpeed;
    [SerializeField] private float _xRange;
    [SerializeField] private float _yRange;
    [SerializeField] private float _pitchFactor;
    [SerializeField] private float _controlPitchFactor;
    [SerializeField] private float _positionYawFactor;
    [SerializeField] private float _controlRollFactor;

    float yThrow;
    float xThrow;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * _controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -_xRange, _xRange);

        float yOffset = yThrow * Time.deltaTime * _controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -_yRange, _yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * -_pitchFactor;
        float pitchDueToControl = yThrow * -_controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControl;
        float yaw = transform.localPosition.x * _positionYawFactor;
        float roll = transform.localRotation.z + xThrow * -_controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
