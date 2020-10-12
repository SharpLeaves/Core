using System.Collections.Generic;
using UnityEngine;

namespace Core{
    public class TimerManager : MonoBehaviour{
        public static TimerManager instance;

        private void Awake(){
            instance = this;
        }

        private List<Task> tasks = new List<Task>();
        private List<Task> sustainTasks = new List<Task>();

        public void addTask(Task task){
            tasks.Add(task);
        }

        public void addSustainTask(Task task){
            sustainTasks.Add(task);
        }

        private void Update(){
            foreach (var task in tasks){
                task.cd -= Time.deltaTime;
                if (task.cd < 0f){
                    task.function();
                }
            }
            foreach (var task in sustainTasks){
                task.cd -= Time.deltaTime;
                if(task.cd > 0f){
                    task.function();
                }
            }
            tasks.RemoveAll(task => task.cd < 0f);
            sustainTasks.RemoveAll(task => task.cd < 0f);
        }
    }
}

