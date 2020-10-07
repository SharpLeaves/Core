using UnityEngine;
using Core;

namespace Core.Dog{
    public abstract class DiskTop_State : IState{
        protected DiskTop main {get; set;}
    }

    public class DiskTop_Normal : DiskTop_State{
        public DiskTop_Normal(DiskTop main){
            this.main = main;
        }
        public override string getName(){
            return "normal";
        }

        public override void onEnter(){

        }

        public override void onExit(){

        }

        public override void update(){

        }
    }

    public class DiskTop_Active : DiskTop_State{
        public DiskTop_Active(DiskTop main){
            this.main = main;
        }
        public override string getName(){
            return "active";
        }

        public override void onEnter(){

        }

        public override void onExit(){

        }

        public override void update(){
            
        }
    }

    public class DiskTop_Moving : DiskTop_State{
        public DiskTop_Moving(DiskTop main){
            this.main = main;
        }
        public override string getName(){
            return "moving";
        }

        public override void onEnter(){

        }

        public override void onExit(){

        }

        public override void update(){
            
        }
    }
}