using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanHealth : MonoBehaviour
{
    public float hp;
    public GameObject healthBar;
    public Text textBox;
    public float delaySeconds;
    public float changeSize;
    
    void OnCollisionEnter2D(Collision2D col) {
        if (col.relativeVelocity.magnitude > 35){
            hp -= Mathf.Round(col.relativeVelocity.magnitude/10.5f * 100f) / 100f;
        }
    }

    IEnumerator animateSize(float target){
        target *= 2;
        //float nextPoint = 200;
        //float vectorAdd = 0.001f;
        while (healthBar.GetComponent<RectTransform>().sizeDelta.x > target) {
            //nextPoint -= 0.01f;
            //Debug.Log(nextPoint);
            //Debug.Log(healthBar.GetComponent<RectTransform>().sizeDelta.x);
            healthBar.GetComponent<RectTransform>().sizeDelta -= new Vector2(changeSize, 0);
            /*
            if(healthBar.GetComponent<RectTransform>().sizeDelta.x - 0.5f <= target){
                vectorAdd -= 0.001f;
                healthBar.GetComponent<RectTransform>().sizeDelta -= new Vector2(vectorAdd, 0);
            }else{
                vectorAdd += 0.001f;
                healthBar.GetComponent<RectTransform>().sizeDelta -= new Vector2(vectorAdd, 0);
            }
            */
            yield return new WaitForSeconds(delaySeconds);
        }
    }

    void Update(){
        hp = (float)(System.Math.Round((double)hp, 2));
        //healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(50, 20);
        textBox.text = $"{hp}hp";
        StartCoroutine(animateSize(hp));
        //animateSize(healthBar.transform.position, new Vector3(hp * 2, healthBar.transform.position.y, healthBar.transform.position.z));
    }
}
