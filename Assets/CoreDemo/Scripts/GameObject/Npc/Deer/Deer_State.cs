using UnityEngine;

namespace Core.Deer{
    public abstract class Deer_State : IState{
        protected Deer main {get; set;}
    }

    public class Deer_Small : Deer_State{
        public Deer_Small(Deer main){
            this.main = main;
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

    public class Deer_Eat : Deer_State{
        public Deer_Eat(Deer main){
            this.main = main;
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

    public class Deer_Big : Deer_State{
        public Deer_Big(Deer main){
            this.main = main;
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