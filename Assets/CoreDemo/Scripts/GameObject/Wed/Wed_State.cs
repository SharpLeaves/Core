using UnityEngine;

namespace Core.Character{
    public abstract class Wed_State : IState{
        protected Wed main {get; set;}
    }

    public abstract class Wed_Ground : Wed_State{
        public override void onEnter(){
            if(Mathf.Abs(main.rigidbodyComponent.velocity.x) > main.runMinSpeed){
                main.animationController.play = "run";
                main.animationController.speed = 1.0f;
            }
            else if(Mathf.Abs(main.rigidbodyComponent.velocity.x) > main.walkMinSpeed){
                main.animationController.play = "walk";
                main.animationController.speed = 1.0f;
            }
            else{
                main.animationController.play = "stand";
                main.animationController.speed = 1.0f;
            }
            
        }
        public override void update(){
            // if(Mathf.Abs(main.rigidbodyComponent.velocity.x) > main.runMinSpeed){
            //     main.animationController.play = "run";
            //     main.animationController.speed = 1.0f;
            // }
            // else if(Mathf.Abs(main.rigidbodyComponent.velocity.x) > main.walkMinSpeed){
            //     main.animationController.play = "walk";
            //     main.animationController.speed = 1.0f;
            // }
            // else{
            //     main.animationController.play = "stand";
            //     main.animationController.speed = 1.0f;
            // }

            if(main.inputController.Vertical > 0){
                this.Container.switchState("lookup");
            }
            if(main.inputController.Vertical < 0){
                this.Container.switchState("crouch");
            }

            if(main.inputController.Jump){
                main.physicsController.addPosition(0, 0.05f);
                main.physicsController.addVelocity(0, main.jump);
            }

            // if(main.inputController.Horizontal != 0){
            //     if(main.inputController.RunHeld){
            //         main.physicsController.addVelocity(main.runMinSpeed * main.inputController.Horizontal, 0);
            //     }
            //     else{
            //         main.physicsController.addVelocity(main.walkMinSpeed * main.inputController.Horizontal, 0);
            //     }
            // }

            if(main.inputController.Horizontal != 0){
                if(main.inputController.RunHeld){
                    main.physicsController.addForce(main.runForce * main.inputController.Horizontal, 0);
                }
                else{
                    main.physicsController.addForce(main.walkForce * main.inputController.Horizontal, 0);
                }
            }

            if(main.groundedTester.IsGrounded == false)
                this.Container.switchState("air");
        }
    }

    public class Wed_Idle : Wed_Ground{
        public Wed_Idle(Wed mainController){
            main = mainController;
        }

        public override string getName(){
            return "idle";
        }
        public override void onEnter(){
            base.onEnter();
        }
        public override void update(){
            base.update();
            if(Mathf.Abs(main.rigidbodyComponent.velocity.x) > main.walkMinSpeed)
                this.Container.switchState("walk");
        }
        public override void onExit(){

        }
    }

    public class Wed_Walk : Wed_Ground{
        public Wed_Walk(Wed mainController){
            main = mainController;
        }

        public override string getName(){
            return "walk";
        }
        public override void onEnter(){
            base.onEnter();

        }
        public override void update(){
            base.update();

            if(Mathf.Abs(main.rigidbodyComponent.velocity.x) <= main.walkMinSpeed)
                this.Container.switchState("idle");
            if(Mathf.Abs(main.rigidbodyComponent.velocity.x) >= main.runMinSpeed)
                this.Container.switchState("run");
        }
        public override void onExit(){

        }
    }

    public class Wed_Run : Wed_Ground{
        public Wed_Run(Wed mainController){
            main = mainController;
        }
        public override string getName(){
            return "run";
        }
        public override void onEnter(){
            base.onEnter();

        }
        public override void update(){
            base.update();

            if(Mathf.Abs(main.rigidbodyComponent.velocity.x) <= main.runMinSpeed)
                this.Container.switchState("walk");
        }
        public override void onExit(){

        }
    }

    public class Wed_Air : Wed_State{
        public Wed_Air(Wed mainController){
            main = mainController;
        }
        public override string getName(){
            return "air";
        }

        public override void onEnter(){
            main.animationController.play = "jump_up";
            main.animationController.speed = 1.0f;
        }

        public override void update(){
            if(main.rigidbodyComponent.velocity.y >= 0){
                main.animationController.play = "jump_up";
            }
            else{
                main.animationController.play = "jump_down";
            }
            if(main.groundedTester.IsGrounded)
                this.Container.switchState("idle");

            
                
 

            if(main.inputController.Horizontal != 0){
                main.physicsController.addForce(main.airForce * main.inputController.Horizontal, 0);
            }
            if(main.inputController.JumpHeld){
                main.physicsController.gravityScale = main.jumpGravityScale;
            }
        }

        public override void onExit(){

        }
    }

    public class Wed_Crouch : Wed_State{
        public Wed_Crouch(Wed mainController){
            main = mainController;
        }
        public override string getName(){
            return "crouch";
        }

        public override void onEnter(){
            main.physicsController.setHorizontalBrake(true);
            main.animationController.play = "crouch";
            main.animationController.speed = 1.0f;
        }

        public override void update(){
            if(main.inputController.Vertical == 0){
                this.Container.switchState("idle");
            }

            main.lookController.VerticalOffset = -0.5f;
        }

        public override void onExit(){

        }
    }

    public class Wed_LookUp : Wed_State{
        public Wed_LookUp(Wed mainController){
            main = mainController;
        }
        public override string getName(){
            return "lookup";
        }

        public override void onEnter(){
            main.physicsController.setHorizontalBrake(true);
            main.animationController.play = "lookup";
            main.animationController.speed = 1.0f;
        }

        public override void update(){
            if(main.inputController.Vertical == 0){
                this.Container.switchState("idle");
            }

            main.lookController.VerticalOffset = 0.5f;
        }

        public override void onExit(){

        }
    }

    
}