using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.tag == "red")
        {

        }else
        {
            base.gameObject.GetComponent<Collider>().enabled = true;
            GameObject gameObject = Instantiate(Resources.Load("splash1")) as GameObject;
            gameObject.transform.parent = target.gameObject.transform;
            Destroy(gameObject, 0.1f);
            target.gameObject.name = "color";
            StartCoroutine(ChangeColor(target.gameObject));
        }
    }

    IEnumerator ChangeColor(GameObject g)
    {
        yield return new WaitForSeconds(0.1f);
        MeshRenderer mesh = g.gameObject.GetComponent<MeshRenderer>();
        mesh.enabled = true;
        mesh.material.color = BallHandler.oneColor;
        Destroy(base.gameObject);
    }
}
