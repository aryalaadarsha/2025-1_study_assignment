using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class GameManager : MonoBehaviour
{
    public UIManager MyUIManager;

    public GameObject Character;
    public GameObject CamObj;
    
    const float CharacterSpeed = 3f;

    public int NowScore = 0;

    void Awake()
    {
        MyUIManager.DisplayScore(NowScore);
        MyUIManager.DisplayMessage("", 0);
    }
    
    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
    }

    // For smooth cam moving, it's good to use LateUpdate.
    void LateUpdate()
    {
        MoveCam();
    }

    void MoveCam()
    {
        // CamObj는 Character의 x, y position을 따라간다.
        // ---------- TODO ---------- 
        if (Character.gameObject) CamObj.transform.position = Character.transform.position + new Vector3(0, 0, -1);
        // -------------------- 
    }

    void MoveCharacter()
    {
        // Character는 초당 CharacterSpeed의 속도로 우측으로 움직인다.
        // ---------- TODO ---------- 
        if (Character.gameObject) Character.transform.position += new Vector3(CharacterSpeed * Time.deltaTime, 0);
        // -------------------- 
    }

    public void GameOver()
    {
        // Character를 삭제하고, "Game Over!"라는 메시지를 3초간 띄우고, RestartButton을 활성화한다.
        // ---------- TODO ---------- 
        MyUIManager.DisplayMessage("Game Over!", 3f);
        Destroy(Character);
        MyUIManager.RestartButton.SetActive(true);

        // -------------------- 
    }

    public void GetPoint(int point)
    {
        // point만큼 점수를 증가시키고 UI에 표시한다.
        // ---------- TODO ---------- 
        NowScore += point;
        MyUIManager.DisplayScore(NowScore);
        // -------------------- 
    }

    // Restart the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
