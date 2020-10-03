using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    [SerializeField] GameObject door_segment;
    [SerializeField] GameObject door;

    public Vector3 doorStart_phase1, doorEnd_phase1, doorStart_phase2, doorEnd_phase2;

    public float animSpeed = 5f;

    bool doorMoving = false;
    bool isDoorOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            doorMoving = true;
        }
        if(doorMoving)
        {
            if (isDoorOpen)
                CloseDoor();
            else
                OpenDoor();
        }
    }
    void OpenDoor()
    {
        if(OpenDoor_Phase1())
        {
            if(OpenDoor_Phase2())
            {
                doorMoving = false;
                isDoorOpen = true;
            }
        }
    }
    bool OpenDoor_Phase1()
    {
        door.transform.localPosition = Vector3.Lerp(doorStart_phase1, doorEnd_phase1, Time.deltaTime*animSpeed);
        return (door.transform.localPosition == doorEnd_phase1);
    }

    bool OpenDoor_Phase2()
    {
        door.transform.localPosition = Vector3.Lerp(doorStart_phase2, doorEnd_phase2, Time.deltaTime * animSpeed);
        return (door.transform.localPosition == doorEnd_phase2);
    }

    void CloseDoor()
    {
        if (CloseDoor_Phase1())
        {
            if (CloseDoor_Phase2())
            {
                doorMoving = false;
                isDoorOpen = false;
            }
        }
    }
    bool CloseDoor_Phase1()
    {
        door.transform.localPosition = Vector3.Lerp(doorEnd_phase2, doorStart_phase2, Time.deltaTime * animSpeed);
        return (door.transform.localPosition == doorStart_phase2);
        
    }

    bool CloseDoor_Phase2()
    {
        door.transform.localPosition = Vector3.Lerp(doorEnd_phase1, doorStart_phase1, Time.deltaTime * animSpeed);
        return (door.transform.localPosition == doorStart_phase1);
    }
}
