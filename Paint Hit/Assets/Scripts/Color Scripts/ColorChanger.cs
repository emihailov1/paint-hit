using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.tag == "red")
        {
            base.gameObject.GetComponent<Collider>().enabled = false;
            MeshRenderer mesh = target.gameObject.GetComponent<MeshRenderer>();
            mesh.enabled = true;
            mesh.material.color = Color.red;
            base.GetComponent<Rigidbody>().AddForce(Vector3.down * 50, ForceMode.Impulse);
            Destroy(base.gameObject, 0.5f);
        }
        else
        {
            base.gameObject.GetComponent<Collider>().enabled = false;
            GameObject gameObject = Instantiate(Resources.Load("splash1")) as GameObject;
            gameObject.transform.parent = target.gameObject.transform;
            Destroy(gameObject, 0.1f);
            target.gameObject.name = "color";
            target.gameObject.tag = "red";
            StartCoroutine(ChangeColor(target.gameObject));
        }
    }

    IEnumerator ChangeColor(GameObject g)
    {
        yield return new WaitForSeconds(0.1f);
        MeshRenderer mesh = g.gameObject.GetComponent<MeshRenderer>();
        mesh.enabled = true;
        mesh.material.color = BallHandler.oneColor;
        Destroy(base.gameObject, 0.5f);
    }
}
