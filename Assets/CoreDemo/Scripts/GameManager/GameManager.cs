using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
  [Header("当前场景编号")]
  /* 当前场景编号 */
  public int CurSceneIndex;
  [Header("场景出生点")]
  public Transform FirstSpwanPoint;
  /* 游戏UI动画控制器 */
  public AnimatorController AnimCTL;
  /* WED */
  public Core.Character.Wed wed;
  private void Awake()
  {
    GameManagerData.GetInstance().GameManagerInit(this);

  }
  // Start is called before the first frame update
  void Start()
  {
    GameManagerData.GetInstance().statemachineInit();
    GameInit();
  }

  // Update is called once per frame
  void Update()
  {
    GameManagerData.GetInstance().stateMachine.update();
  }


  public void IsPlayerDead()
  {
    if (wed.IsDead)
    {
      GameManagerData.GetInstance().stateMachine.switchState("dead");
    }
  }

  void GameInit()
  {

  }

  public void ReLoadScene()
  {
    SceneManager.LoadScene(CurSceneIndex);
  }

  public void SwitchScene(int Scene)
  {
    SceneManager.LoadScene(Scene);
    GameManagerData.GetInstance().IsSetSpwanPoint = false;
  }


}
