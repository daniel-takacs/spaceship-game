using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int checkpointNumber;
    public bool isActiveCheckpoint;

    private Light passLight;
    private RaceController raceController;

    // Use this for initialization
    void Start()
    {
        passLight = GetComponentInChildren<Light>();
        raceController = GetComponentInParent<RaceController>();
    }

    private void Update()
    {
        if (isActiveCheckpoint)
        {
            // Mathf.Sin(Time.time) brings a cool effect of intensity increasing and decreasing
            // Multiplier for Time.time defines the frequency
            // Multiplier for the whole Sin value defines the amount (Sin gets values between -1 and 1)
            passLight.intensity = 4 + Mathf.Sin(Time.time * 2) * 2;
            passLight.color = Color.red;
        }
        else
        {
            passLight.intensity -= 0.1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("is isActiveCheckpoint: " + isActiveCheckpoint);
        Debug.Log("Trigger Entered by: " + other.name);
        // Check if current checkpoint is active, and if the passed object was the player's ship
        if (isActiveCheckpoint && other.name == "Spaceship")
        {
            if (passLight != null)
            {
                passLight.intensity = 8.0f;
                passLight.color = Color.green;
            }
            else
            {
                Debug.LogError("passLight is null");
            }
            // Call a function in the RaceController
            raceController.CheckpointPassed();
            isActiveCheckpoint = false;
        }
    }
}




/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    public int checkpointNumber;
    public bool isActiveCheckpoint;

    private Light passLight;
    private RaceController raceController;

    // Use this for initialization
    void Start () {
        passLight = GetComponentInChildren<Light>();
            if (passLight == null) {
        Debug.LogError("No Light component found on this GameObject or its children.");
    }
        raceController = GetComponentInParent<RaceController>();
    }

private void Update () {
    if (passLight == null) {
        return; // or handle the error appropriately
    }

    if (isActiveCheckpoint) {
        // existing code to modify passLight's properties
    } else {
        passLight.intensity -= 0.1f;
    }
}

private void OnTriggerEnter(Collider other) {
    Debug.Log("Trigger Entered by: " + other.name);

    if (isActiveCheckpoint && other.name == "SpaceShip")  {
        if (passLight != null) {
            passLight.intensity = 8.0f;
            passLight.color = Color.green;
        }

        if (raceController != null) {
            raceController.CheckpointPassed();
        } else {
            // Handle the error if raceController is null
        }

        isActiveCheckpoint = false;
    }
}
} */