using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WheelOfFortuneManager : MonoBehaviour
{
    public static WheelOfFortuneManager Instance { get; private set; }

    #region Serialized Fields

    [SerializeField] private InputManager InputManagerRef;

    [SerializeField] private GameObject panelWheel;

    [Header("Size and items of array")]
    [SerializeField] private string[] items;

    [Header("References")]
    [SerializeField] private Button spinButton;
    [SerializeField] private GenericButtonTween spinButtonTween;
    [SerializeField] private TextMeshProUGUI wonText;
    [SerializeField] private GameObject wheel;

    [Header("Time to spin")]
    [SerializeField] private float rotateDuration;

    #endregion

    #region Private Fields

    private Vector3 rotateZ = Vector3.forward;

    private WaitForSeconds delay;

    private float degree;

    private int additionalRotation;
    private int randomDegree;

    private bool isRotate;
    private bool isCall;

    #endregion

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);
    }

    private void OnEnable()
    {
        isCall = false;

        spinButton.onClick.AddListener(() => { OnClickRotate(); });
    }

    private void OnClickRotate()
    {
        if (!isRotate) return;

        isRotate = false;

        additionalRotation = 360 * Random.Range(1, 4);
        randomDegree = Random.Range(0, items.Length) * (360 / items.Length);

        degree = additionalRotation + randomDegree;

        LeanTween.rotateAround(wheel, rotateZ, degree, rotateDuration).setEaseInOutBack().setOnStart(OnWheelStart).setOnComplete(OnWheelComplete);
    }

    private void OnWheelStart()
    {
        spinButtonTween.enabled = false;
    }

    private void OnWheelComplete()
    {
        wonText.text = items[
            (int)(randomDegree / (360 / (items.Length - 1)))
                            ];

        StartCoroutine(DisablePanel());
    }

    public void EnablePanel()
    {
        if (isCall) return;

        InputManagerRef.enabled = false;

        isCall = true;
        isRotate = true;

        panelWheel.SetActive(true);

        wonText.text = string.Empty;
        wheel.gameObject.transform.rotation = Quaternion.identity;
    }

    public IEnumerator DisablePanel()
    {
        isCall = false;

        yield return new WaitForSeconds(3);

        InputManagerRef.enabled = true;

        panelWheel.SetActive(false);
    }

    private void OnDisable()
    {
        spinButton.onClick.RemoveAllListeners();
    }
}
