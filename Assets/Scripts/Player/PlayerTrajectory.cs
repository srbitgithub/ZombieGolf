using UnityEngine;

public class PlayerTrajectory : MonoBehaviour
{
    Vector2 initialPoint;
    Vector2 currentPoint;
    float currentAngle;
    float currentDistance;
    public GameObject trajectory;
    public Color trajectoryBallOff;
    public Color trajectoryBallOn;
    public int currentVelocityIncrease = 2;

    string lengthTrajectory;
    bool firstTime = true;
    int childNumber;
    float maxPower = 180f;
    int finalPower;
    int numberOfTrajectoryBalls;

    void Start()
    {
        lengthTrajectory = "1X";
        showHideTrajectorySegments(lengthTrajectory);
        trajectory.SetActive(false);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && firstTime)
        {
            trajectory.transform.position = transform.position;
            trajectory.SetActive(true);
            trajectory.gameObject.SetActive(true);
            initialPoint = Input.mousePosition;
            firstTime = false;
        }

        if (Input.GetMouseButton(0))
        {
            currentPoint = Input.mousePosition;
            currentAngle = Mathf.Atan2(currentPoint.y - initialPoint.y, currentPoint.x - initialPoint.x) * 180 / Mathf.PI;
            if (currentAngle < 0) currentAngle += 360;
            trajectory.transform.eulerAngles = new Vector3 (0, 0, currentAngle + 180);

            currentDistance = Vector2.Distance(initialPoint, currentPoint);

            float jumpPower = maxPower / 9f;
            if (currentDistance <= maxPower)
            {
                numberOfTrajectoryBalls = Mathf.RoundToInt(currentDistance / jumpPower);
                shootPower(trajectory.transform.GetChild(0), numberOfTrajectoryBalls);
            }
        }

        if (Input.GetMouseButtonUp(0)){
            firstTime = true;
            trajectory.SetActive(false);
            finalPower = numberOfTrajectoryBalls * currentVelocityIncrease;
            transform.GetComponent<PlayerShoot>().playerShoot(trajectory.transform.eulerAngles, finalPower);
        }
    }

    void showHideSegments(bool segment2X, bool segment4X, bool segmentFull)
    {
        showHideSegment(trajectory.transform.GetChild(1), segment2X);
        showHideSegment(trajectory.transform.GetChild(2), segment4X);
        showHideSegment(trajectory.transform.GetChild(3), segmentFull);
    }

    void showHideTrajectorySegments(string type)
    {
        if (type == "1X") showHideSegments(false, false, false);
        if (type == "2X") showHideSegments(true, false, false);
        if (type == "4X") showHideSegments(true, true, false);
        if (type == "Full") showHideSegments(true, true, true);
    }

    public void showHideSegment(Transform group, bool showHide)
    {
        childNumber = group.childCount;
        for (int l = 0; l < childNumber; l++)
        {
            group.GetChild(l).GetComponent<Renderer>().enabled = showHide;
        }
    }

    public void shootPower(Transform group, int ballsNumberOn)
    {
        for (int i = 0; i < 9; i++)
        {
            if (i < ballsNumberOn) group.transform.GetChild(i).GetComponent<SpriteRenderer>().color = trajectoryBallOn;
            else group.transform.GetChild(i).GetComponent<SpriteRenderer>().color = trajectoryBallOff;
        }
    }
}
