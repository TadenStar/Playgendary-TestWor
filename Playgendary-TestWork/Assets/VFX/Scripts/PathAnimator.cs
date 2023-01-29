using UnityEngine;

public class PathAnimator : MonoBehaviour
{
    public Transform[] path;
    public float speed = 1f;
    public bool rotateToPath = true;

    private int currentPoint = 0;

    void Update()
    {
        if (currentPoint < path.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, path[currentPoint].position, Time.deltaTime * speed);

            if (rotateToPath)
            {
                Quaternion targetRotation = Quaternion.LookRotation(path[currentPoint].position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
            }

            if (Vector3.Distance(transform.position, path[currentPoint].position) < 0.1f)
            {
                currentPoint++;
            }
        }
    }
}
