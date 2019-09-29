using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Flashing_Text_Script : MonoBehaviour
{

    public Image Flashing_Image;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BlinkText());
    }

    public IEnumerator BlinkText()
    {
        while(true)
        {
            Flashing_Image.enabled = false;
            yield return new WaitForSeconds(.5f);
            Flashing_Image.enabled = true;
            yield return new WaitForSeconds(.5f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }
    }
}
