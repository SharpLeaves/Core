using Core;
using UnityEngine;

namespace Site
{
  public abstract class IronBlock_State : IState
  {
    protected IronBlock main { get; set; }
  }
  public class IronBlock_Normal : IronBlock_State
  {
    public IronBlock_Normal(IronBlock main)
    {
      this.main = main;
    }
    public override string getName()
    {
      return "normal";
    }
    public override void update()
    {

    }
    public override void onEnter()
    {
    }
    public override void onExit()
    {
    }
  }
}