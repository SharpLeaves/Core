using UnityEngine;
using Core.StateController;
using Core.Timer;

namespace Core.Test{
    public abstract class NpcState : IState{
        protected Npc_MainController main {get; set;}
    }

    public class smallState : NpcState{
        public smallState(Npc_MainController mainController){
            this.main = mainController;
        }
        public override string getName(){
            return "small";
        }
        public override void update(){

        }
        public override void onEnter(){
            main.animationController.play = "SmallSheep";
            main.animationController.speed = 1.0f;
        }
        public override void onExit(){

        }
    }

    public class eatState : NpcState{
        public eatState(Npc_MainController mainController){
            this.main = mainController;
        }

        public override string getName(){
            return "eat";
        }
        public override void update(){
            AnimatorStateInfo info =main.animationController.animator.GetCurrentAnimatorStateInfo(0);    

            if (info.normalizedTime >= 1.0f)  {
                stateMachine.switchState("big");
            }   
        }
        public override void onEnter(){
            main.animationController.play = "SmallSheepEat";
            main.animationController.speed = 1.0f;
        }
        public override void onExit(){

        }


        
    }

    public class bigState : NpcState{
        public bigState(Npc_MainController mainController){
            this.main = mainController;
        }
        public override string getName(){
            return "big";
        }
        public override void update(){
            TimerManager.instance.addTask(new Task(5.0f, ()=>{
                stateMachine.switchState("small");
            }));
        }
        public override void onEnter(){
            main.animationController.play = "Sheep";
            main.animationController.speed = 1.0f;
        }
        public override void onExit(){

        }
    }
}