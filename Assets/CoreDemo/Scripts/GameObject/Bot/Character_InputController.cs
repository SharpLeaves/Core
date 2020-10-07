/*
 * @Author: vanot313
 * @Date: 2020-09-20 16:59:23
 * @LastEditTime: 2020-10-05 20:29:11
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
		public UnityEngine.KeyCode kInteract = KeyCode.E;
		


		private bool bJumpWasPressed;
		private bool bJump;
		private bool bRunWasPressed;
		private bool bRun;
		private bool bMainHandWasPressed;
		private bool bMainHand;
		private bool bOffHandWasPressed;
		private bool bOffHand;
		private bool bSpecialWasPressed;
		private bool bSpecial;
		private bool bInteractWasPressed;
		private bool bInteract;

		public bool MainHand{
			get{
				return bMainHand;
			}
		}
		public bool MainHandHeld{
			get{
				return bMainHandWasPressed;
			}
		}
		public bool OffHand{
			get{
				return bOffHand;
			}
		}
		public bool OffHandHeld{
			get{
				return bOffHandWasPressed;
			}
		}
		public bool Special{
			get{
				return bSpecial;
			}
		}
		public bool SpecialHeld{
			get{
				return bSpecialWasPressed;
			}
		}
		public bool Interact{
			get{
				return bInteract;
			}
		}
		public bool InteractHeld{
			get{
				return bInteractWasPressed;
			}
		}
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
		public bool MainHandInput{
			get{
				return Input.GetKey(kMainHand);
			}
		}
		public bool OffHandInput{
			get{
				return Input.GetKey(kOffHand);
			}
		}
		public bool SpecialInput{
			get{
				return Input.GetKey(kSpecial);
			}
		}
		public bool InteractInput{
			get{
				return Input.GetKey(kInteract);
			}
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
		private void UpdateOther(){
			bool bMainHandPressed = MainHandInput;
			bool bMainHandJustPressed = bMainHandWasPressed == false && bMainHandPressed;

			bMainHandWasPressed = bMainHandPressed;
			bMainHand = bMainHandJustPressed;

			bool bOffHandPressed = OffHandInput;
			bool bOffHandJustPressed = bOffHandWasPressed == false && bOffHandPressed;

			bOffHandWasPressed = bOffHandPressed;
			bOffHand = bOffHandJustPressed;

			bool bSpecialPressed = SpecialInput;
			bool bSpecialJustPressed = bSpecialWasPressed == false && bSpecialPressed;

			bSpecialWasPressed = bSpecialPressed;
			bSpecial = bSpecialJustPressed;

			bool bInteractPressed = InteractInput;
			bool bInteractJustPressed = bInteractWasPressed == false && bInteractPressed;

			bInteractWasPressed = bInteractPressed;
			bInteract = bInteractJustPressed;
		}


		private void FixedUpdate(){
			UpdateRunInput();
			UpdateJumpInput();
			UpdateOther();
		}
		
	}
}
