using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HabilityPj : MonoBehaviour
{
    public static HabilityPj instance {  get; private set; }
    private enum HabilityType
    {
        skillshot,
        autoaim
    }
    private enum HabilityEffect
    {
        nothing,
        stun
    }
    private enum HabilityKey
    {
        Q,
        W,
        E,
        R
    }
    [SerializeField] private HabilityKey key;
    [SerializeField] private HabilityType type;
    [SerializeField] private HabilityEffect effect;
    [SerializeField] private float coolDownSegs;
    [SerializeField] private GameObject hability;
    [SerializeField] private Image imageHability;
    [SerializeField] private TextMeshProUGUI textHability;
    private bool enabledHability;
    private float time;

    private void Start()
    {
        enabledHability = true;
        time = coolDownSegs;
    }

    public string Key { get { return key.ToString(); } }

    public bool EnabledHability { get { return enabledHability; } }

    public void activateHability()
    {
        if (enabledHability)
        {
            GameObject habilityInstantiate;
            if (HabilityType.autoaim == type)
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
                {
                    if (hit.transform.gameObject.tag == "Enemy")
                    {
                        habilityInstantiate = Instantiate(hability, new Vector3(transform.position.x, 5f, transform.position.z), Quaternion.identity);
                        AutoAim autoAim = habilityInstantiate.GetComponent<AutoAim>();
                        if(autoAim != null) { 
                            autoAim.positionEn = hit.transform;
                        }
                        habilityInstantiate.gameObject.SetActive(true);
                        enabledHability = false;
                    }
                }
            } else
            {
                habilityInstantiate = Instantiate(hability, new Vector3(transform.position.x, 5f, transform.position.z), Quaternion.identity);
                habilityInstantiate.gameObject.SetActive(true);
                enabledHability = false;
            }
        }
    }

    private void Update()
    {
        if (!enabledHability) 
        {
            imageHability.color = Color.gray;
            textHability.text = Mathf.FloorToInt(time).ToString();
            textHability.fontSize = 26;
            textHability.color = Color.red;
            time -= Time.deltaTime;
            if(time <= 0 ) 
            {
                enabledHability = true;
                imageHability.color = Color.white;
                textHability.color = Color.black;
                textHability.text = key.ToString();
                textHability.fontSize = 36;
                time = coolDownSegs;
            }
        }
    }
}
