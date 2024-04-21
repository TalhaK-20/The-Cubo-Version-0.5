using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool tkgames = false;
    public void EndGame(){

        if(tkgames == false){
            tkgames = true;
            Invoke("restart", 3f);
        }
    
    }

    void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}