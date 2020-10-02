using System.Collections.Generic;
using UnityEngine;

namespace Core.Timer{
    public class TimerManager : MonoBehaviour{
        public static TimerManager instance;

        private void Awake(){
            instance = this;
        }

        private List<Task> tasks = new List<Task>();

        public void addTask(Task task){
            tasks.Add(task);
        }

        private void Update(){
            foreach (var task in tasks){
                task.cd -= Time.deltaTime;
                if (task.cd < 0f){
                    task.function();
                }
            }

            tasks.RemoveAll(task => task.cd < 0f);
        }
    }
}

