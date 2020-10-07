using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExAnimator
{
  public List<ExAnimation> AnimList;

  public void addAnim(ExAnimation ea)
  {
    if (GetAnimation(ea.name) != null)
    {
      Debug.LogWarningFormat("ExAnimator:该动画【{0}】已经存在", ea.name);
      return;
    }
    else
      AnimList.Add(ea);
  }

  public ExAnimation GetAnimation(string name)
  {
    foreach (ExAnimation ea in AnimList)
    {
      if (ea.name == name)
      {
        return ea;
      }
    }
    return null;
  }

}

public class ExAnimation
{
  ExAnimation(Animation a, string n)
  {
    this.anim = a;
    this.name = n;
  }
  public Animation anim;
  public string name;
}
