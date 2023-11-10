using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Networking;
using UnityEngine.Networking;

public class AgentController : MonoBehaviour
{

    Animator animator;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        StartCoroutine(fun());
    }
    

    IEnumerator fun()
    {
        // List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        // formData.Add(new MultipartFormDataSection("field1=foo&field2=bar"));
        // formData.Add(new MultipartFormFileSection("my file data", "myfile.txt"));
        // UnityWebRequest www = UnityWebRequest.Post("https://www.my-server.com/myform", formData);

        string url = "http://localhost:5000/test";


        // List<IMultipartFormSection> formSections = new List<IMultipartFormSection>();
        // formSections.Add( new MultipartFormDataSection("field1=foo&field2=bar") );
        // UnityWebRequest www = UnityWebRequest.Post(url, formSections);

        
        while(true)
        {
            UnityWebRequest www = UnityWebRequest.Get(url);
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Debug.Log("Form upload complete!");
                // Debug.Log(www);
                // Debug.Log(www.result);
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text == "dance")
                {
                    animator.SetBool("IsDancing", true);
                    animator.SetBool("IsIdling", false);
                } else if (www.downloadHandler.text == "idle")
                {
                    animator.SetBool("IsDancing", false);
                    animator.SetBool("IsIdling", true);
                }
            }
        }
    }





    // void Start()
    // {
    //     StartCoroutine(Upload());
    // }

    // IEnumerator Upload()
    // {
    //     List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
    //     formData.Add(new MultipartFormDataSection("field1=foo&field2=bar"));
    //     // formData.Add(new MultipartFormFileSection("my file data", "myfile.txt"));

    //     UnityWebRequest www = UnityWebRequest.Post("http://localhost:5000/test", formData);
    //     yield return www.SendWebRequest();

    //     if (www.result != UnityWebRequest.Result.Success)
    //     {
    //         Debug.Log(www.error);
    //     }
    //     else
    //     {
    //         Debug.Log("Form upload complete!");
    //     }
    // }
}
