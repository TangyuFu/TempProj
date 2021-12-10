using UnityEngine;
using UnityEngine.UI;

public class FuTest : MonoBehaviour
{
    public RectTransform RectTransform;

    public Camera WorldCamera;

    public Camera Camera;

    public Transform Transform;

    public Image Image;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    [ContextMenu("Debug")]
    private void D()
    {
        var localPosition = Transform.position;
        var screenPosition = WorldCamera.WorldToScreenPoint(localPosition);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(RectTransform, screenPosition, Camera, out var l);
        Image.transform.localPosition = l;
    }
}