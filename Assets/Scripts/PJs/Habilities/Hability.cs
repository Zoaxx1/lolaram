using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hability : MonoBehaviour
{
    public enum HabilityType
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
    public HabilityType type;
    [SerializeField] private HabilityEffect effect;
    [SerializeField] private float coolDownSegs;
    public GameObject hability;
    [SerializeField] private Image imageHability;
    [SerializeField] private TextMeshProUGUI textHability;
    public bool isHabilityEnable = true;
    private float instantiateY = 5f;
    private float time;

    private void Start()
    {
        time = coolDownSegs;
    }

    public virtual void activateHability()
    {
        if (isHabilityEnable)
        {
            GameObject habilityInstantiate = Instantiate(hability, new Vector3(transform.position.x, instantiateY, transform.position.z), Quaternion.identity);
            if (HabilityType.autoaim == type)
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
                {
                    if (hit.transform.gameObject.tag == "Enemy")
                    {
                        
                        AutoAim autoAim = habilityInstantiate.GetComponent<AutoAim>();
                        if(autoAim != null) { 
                            autoAim.positionEn = hit.transform;
                        }
                    }
                }
            }
            habilityInstantiate.gameObject.SetActive(true);
            isHabilityEnable = false;
        }
    }

    public void disableHability()
    {
        imageHability.color = Color.gray;
        textHability.color = Color.red;
        textHability.text = Mathf.FloorToInt(time).ToString();
        textHability.fontSize = 26;
        time -= Time.deltaTime;
    }

    public void enableHability()
    {
        isHabilityEnable = true;
        imageHability.color = Color.white;
        textHability.color = Color.black;
        textHability.text = key.ToString();
        textHability.fontSize = 36;
        time = coolDownSegs;
    }

    private void Update()
    {
        if (!isHabilityEnable) 
        {
            disableHability();
            if(time <= 0 ) 
            {
                enableHability();
            }
        }
    }
}
