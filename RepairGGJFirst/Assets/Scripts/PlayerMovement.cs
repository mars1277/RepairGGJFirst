using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerMovement : MonoBehaviour
{
    public enum Directions
    {
        UP, DOWN, LEFT,RIGHT,UP_LEFT,UP_RIGHT,DOWN_LEFT,DOWN_RIGHT
    }

    public float speed = 10.0f;
    private float sqrtTwo = 0.70710678f;
    public float maximumInteractionDistance = 2;
    public static PlayerMovement Instance;
    public Transform holder;

    public void Awake()
    {
        Instance = this;
    }

    void Start()
    {

    }

    void Update()
    {
        bool usingTwoKeyToMove = false;
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
        {
            usingTwoKeyToMove = true;
            transform.position += new Vector3(speed * Time.deltaTime * sqrtTwo, 0, speed * Time.deltaTime * sqrtTwo);
            Roadhouse.Instance.direction = Directions.UP_RIGHT;
            Roadhouse.Instance.UpdateCapsule();
        }
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
        {
            usingTwoKeyToMove = true;
            transform.position += new Vector3(speed * Time.deltaTime * sqrtTwo, 0, -speed * Time.deltaTime * sqrtTwo);
            Roadhouse.Instance.direction = Directions.DOWN_RIGHT;
            Roadhouse.Instance.UpdateCapsule();
        }
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
        {
            usingTwoKeyToMove = true;
            transform.position += new Vector3(-speed * Time.deltaTime * sqrtTwo, 0, speed * Time.deltaTime * sqrtTwo);
            Roadhouse.Instance.direction = Directions.UP_LEFT;
            Roadhouse.Instance.UpdateCapsule();
        }
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
        {
            usingTwoKeyToMove = true;
            transform.position += new Vector3(-speed * Time.deltaTime * sqrtTwo, 0, -speed * Time.deltaTime * sqrtTwo);
            Roadhouse.Instance.direction = Directions.DOWN_LEFT;
            Roadhouse.Instance.UpdateCapsule();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractableObject target = InteractableObject.Instances.Where(x => Vector3.Distance(transform.position, x.transform.position) < maximumInteractionDistance).OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).FirstOrDefault();
            if (target == null)
            {
                Debug.Log("no target");
            }
            else
            {
                Debug.LogFormat("interact with {0}", target.gameObject.name);
            }
            target?.Interact();
        }

        if (!usingTwoKeyToMove)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                Roadhouse.Instance.direction = Directions.RIGHT;
                Roadhouse.Instance.UpdateCapsule();
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
                Roadhouse.Instance.direction = Directions.LEFT;
                Roadhouse.Instance.UpdateCapsule();
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, 0, speed * Time.deltaTime);
                Roadhouse.Instance.direction = Directions.UP;
                Roadhouse.Instance.UpdateCapsule();
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
                Roadhouse.Instance.direction = Directions.DOWN;
                Roadhouse.Instance.UpdateCapsule();
            }
        }
    }
}
