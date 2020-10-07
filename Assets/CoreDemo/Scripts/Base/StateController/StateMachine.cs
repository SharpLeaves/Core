using System.Collections.Generic;
using UnityEngine;

namespace Core{
    [AddComponentMenu("Core/FSM/StateMachine")]

    public class StateMachine{
        List<IState> stateList;
        public IState curState;
        public StateMachine(){
            stateList = new List<IState>();
        }
        
        public IState getState(string name){
            foreach (IState state in this.stateList){
                if (state.getName() == name){
                   return state;
                }
            }
            return null;
        }

        public void addState(IState state){
            IState tmpState = this.getState(state.getName());
            if(tmpState == null){
                stateList.Add(state);
                state.Container = this;
            }
            else{
                Debug.LogWarningFormat("StateController.StateMachine：This state is already exist!", tmpState.getName());
            }
        }

        public void deleteState(IState state){
            IState tmpState = this.getState(state.getName());
            if(tmpState != null){
                stateList.Remove(tmpState);
            }
            else{
                Debug.LogWarningFormat("StateController.StateMachine：This state is not exist!", tmpState.getName());
            }
        }

        public void switchState(string name){
            IState tmpState = this.getState(name);
            if (this.curState != null){
                this.curState.onExit();
                this.curState = null;
            }
            if(tmpState != null){
                curState = this.getState(name);
                curState.onEnter();
            }
            else{
                Debug.LogWarningFormat("StateController.StateMachine：This state is not exist!", tmpState.getName());
            }
            
        }

        public void clearState(){
            if (this.curState != null){
                this.curState.onExit();
                this.curState = null;
            }
            this.stateList.Clear();
        }

        public void update(){
            this.curState.update();
        }
    }
}