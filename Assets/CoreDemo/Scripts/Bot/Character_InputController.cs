/*
 * @Author: vanot313
 * @Date: 2020-09-20 16:59:23
 * @LastEditTime: 2020-09-30 20:54:50
 * @LastEditors: Please set LastEditors
 * @Description: Main player input component.
 * @FilePath: \Core\Assets\Scripts\Bot\Character_Input.cs
 */

using UnityEngine;
using System.Collections;


namespace Core.Character
{
	[AddComponentMenu("Core/Character/InputController")]

	/**
	* @description: 角色输入控制器
	*/
	public class Character_InputController : MonoBehaviour 
	{
		public UnityEngine.KeyCode kLeft = KeyCode.LeftArrow;
		public UnityEngine.KeyCode kUp = KeyCode.UpArrow;
		public UnityEngine.KeyCode kRight = KeyCode.RightArrow;
		public UnityEngine.KeyCode kDown = KeyCode.DownArrow;
		public UnityEngine.KeyCode kRun = KeyCode.LeftShift;
		public UnityEngine.KeyCode kJump = KeyCode.Space;
		public UnityEngine.KeyCode kMainHand = KeyCode.Z;
		public UnityEngine.KeyCode kOffHand = KeyCode.X;
		public UnityEngine.KeyCode kSpecial = KeyCode.C;


		private bool bJumpWasPressed;
		private bool bJump;
		private bool bRunWasPressed;
		private bool bRun;
		
		public bool Run{
			get{
				return bRun;
			}
		}

		public bool RunHeld{
			get{
				return bRunWasPressed;
			}
		}
		
		public bool Jump{
			get{
				return bJump;
			}
		}
		
		public bool JumpHeld{
			get{
				return bJumpWasPressed;
			}
		}
		/**
		* @description: 获取水平移动输入
		* @param {} 
		* @return {float} 
		*/
		public float Horizontal{
			get{
				float fValue = 0.0f;
				if(Input.GetKey(kLeft)){
					fValue -= 1.0f;
				}
				if(Input.GetKey(kRight)){
					fValue += 1.0f;
				}
				return fValue;
			}
		}
		/**
		* @description:获取垂直移动输入
		* @param {} 
		* @return {float} 
		*/
		public float Vertical{
			get{
				float fValue = 0.0f;
				if(Input.GetKey(kDown)){
					fValue -= 1.0f;
				}
				if(Input.GetKey(kUp)){
					fValue += 1.0f;
				}
				return fValue;
			}
		}
		
		public bool JumpInput{
			get{
				return Input.GetKey(kJump);
			}
		}
		
		public bool RunInput{
			get{
				return Input.GetKey(kRun);
			}
		}
		/**
		* @description:更新角色输入状态 
		* @param {}
		* @return {} 
		*/
		private void FixedUpdate()
		{
			UpdateRunInput();
			UpdateJumpInput();
			// KeyCode currentKey = KeyCode.Space;
			// if (Input.anyKeyDown)
			// {
			// 	Debug.Log("Press");
				// Event e = Event.current;
				// if (e.isKey)
				// {
				// 	currentKey = e.keyCode;
				// 	Debug.Log("Current Key is : " + currentKey.ToString());
				// }
			// }
		}
		
		private void UpdateJumpInput(){
			bool bJumpPressed = JumpInput;
			bool bJumpJustPressed = bJumpWasPressed == false && bJumpPressed;

			bJumpWasPressed = bJumpPressed;
			bJump = bJumpJustPressed;
		}
		
		private void UpdateRunInput(){
			bool bRunPressed = RunInput;
			bool bRunJustPressed = bRunWasPressed == false && bRunPressed;

			bRunWasPressed = bRunPressed;
			bRun = bRunJustPressed;
		}
	}
}
