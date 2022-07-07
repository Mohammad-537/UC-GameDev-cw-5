using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    //[SerializeField] private Material winningMeterial;
    //[SerializeField] private GameObject winningUI;
    public int next = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator WInningRoutine()
    {

        //GetComponent<MeshRenderer>();
        //winningUI.SetActive(true);

        Time.timeScale = 0.25f;

        yield return new WaitForSeconds(1f);

        Time.timeScale = 1f;

        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(next);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(WInningRoutine());


        }
    }

}
