// using UnityEngine;
// using System.Collections;

// namespace Core.Character
// {
// 	[AddComponentMenu("Core/Character/FeetSoundPlayer")]
// 	public class Character_FeetSoundPlayer : MonoBehaviour 
// 	{	
// 		[System.Serializable]
// 		public class Sound
// 		{
// 			public AudioClip clip;
// 			public float volume = 1.0f;
// 		}
		
// 		public Character_PhysicsController physicsController;
		
// 		public AudioSource audioSource;
		
// 		public Sound leftFootWalkSound;
// 		public Sound rightFootWalkSound;
		
// 		public Sound leftFootRunSound;
// 		public Sound rightFootRunSound;
		
// 		public Sound jumpSound;
		
// 		public void LeftFeetWalkSound()
// 		{
// 			PlaySound(leftFootWalkSound);
// 		}
		
// 		public void RightFeetWalkSound()
// 		{
// 			PlaySound(rightFootWalkSound);
// 		}
		
// 		public void LeftFeetRunSound()
// 		{
// 			PlaySound(leftFootRunSound);
// 		}
		
// 		public void RightFeetRunSound()
// 		{
// 			PlaySound(rightFootRunSound);
// 		}
		
// 		public void JumpSound()
// 		{
// 			PlaySound(jumpSound);
// 		}
		
// 		private void Awake()
// 		{
// 			if(physicsController != null)
// 			{
// 				physicsController.onJump += OnJump;
// 			}
// 		}
		
// 		private void OnDestroy()
// 		{
// 			if(physicsController != null)
// 			{
// 				physicsController.onJump -= OnJump;
// 			}
// 		}
		
// 		private void PlaySound(Sound a_rSound)
// 		{
// 			audioSource.PlayOneShot(a_rSound.clip, a_rSound.volume);
// 		}
		
// 		private void OnJump()
// 		{
// 			JumpSound();
// 		}
// 	}
// }
