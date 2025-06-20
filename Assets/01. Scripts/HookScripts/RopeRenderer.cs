using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] Transform startPosition;
    private float line_width = 0.07f;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = line_width;
        lineRenderer.enabled = false;
    }
    public void RenderLine(Vector3 endPosition, bool enableRenderer)
    {
        if (enableRenderer)
        {
            if (!lineRenderer.enabled)
            {
                lineRenderer.enabled = true;
            }
            lineRenderer.positionCount = 2;
        }
        else
        {
            lineRenderer.positionCount = 0;

            if (lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
            }
        }

        if (lineRenderer.enabled)
        {
            Vector3 temp = startPosition.position;
            temp.z = -5f;
            startPosition.position = temp;

            temp = endPosition;
            temp.z = -5f;
            endPosition = temp;

            lineRenderer.SetPosition(0, startPosition.position);
            lineRenderer.SetPosition(1, endPosition);
        }
    }
}
