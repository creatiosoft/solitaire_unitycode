using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class PushScript : MonoBehaviour
{
//		void Start ()
//		{
//				DontDestroyOnLoad (this.gameObject);
//				ResetNotification ();
//		}
//
//
//		/// <summary>
//		/// Pushs the notification.
//		// Settings Notifications for total of 20 times if user is not playing Game.
//		/// </summary>
//		/// <param name="NumOfNotif1">Number of notif1.</param>
//		/// <param name="Notif1Interval">Notif1 interval.</param>
//		/// <param name="NumOfNotif2">Number of notif2.</param>
//		/// <param name="Notif2Interval">Notif2 interval.</param>
//		void PushNotification (int NumOfNotif1, int Notif1Interval, int NumOfNotif2, int Notif2Interval)
//		{
////		Debug.Log ("PushNotification called");
//
//				if (NumOfNotif1 <= 0 || NumOfNotif2 <= 0)
//						return;
//
//				int TimeIntervalForNotif1 = 0;
//				int TimeIntervalForNotif2 = 0;
//		       
//				//	EtceteraBinding.setBadgeCount (-1);
//		 
//				LocalNotification[] notif1 = new LocalNotification[NumOfNotif1];
//				LocalNotification[] notif2 = new LocalNotification[NumOfNotif2];
//
//				for (int i = 0; i < NumOfNotif1; i++) {
//						notif1 [i] = new LocalNotification ();
//				}
//
//				for (int i = 0; i < NumOfNotif2; i++) {
//						notif2 [i] = new LocalNotification ();
//				}
//
//				for (int i = 0; i < NumOfNotif1; i++) {
//
//						if (TimeIntervalForNotif1 == 0)
//								TimeIntervalForNotif1 += Notif1Interval;
//						else
//								TimeIntervalForNotif1 += Notif2Interval;
//
//						notif1 [i].fireDate = System.DateTime.Now.AddSeconds (TimeIntervalForNotif1);
//						notif1 [i].applicationIconBadgeNumber = ((i * 2) + 1);
////			Debug.Log ("Notification Called in " + TimeIntervalForNotif1 + " seconds.");
////			notif1 [i].alertBody = "Notification Called in " + TimeIntervalForNotif1 + " seconds.";
//						notif1 [i].alertBody = "Hi, Let\'s play Solitaire. It\'s time to have some fun with cards.";
//
//						NotificationServices.ScheduleLocalNotification (notif1 [i]);
//
//				}
//
//				for (int j = 0; j < NumOfNotif2; j++) {
//
//						TimeIntervalForNotif2 += Notif2Interval;
//						notif2 [j].fireDate = System.DateTime.Now.AddHours (TimeIntervalForNotif2);
//						notif2 [j].applicationIconBadgeNumber = ((j * 2) + 2);
////			Debug.Log ("Notification Called in " + TimeIntervalForNotif2 + " seconds.");
////			notif2 [j].alertBody = "Notification Called in " + TimeIntervalForNotif2 + " seconds.";
//						notif2 [j].alertBody = "Hey, let\'s play Solitaire and have fun.";
//
//						NotificationServices.ScheduleLocalNotification (notif2 [j]);
//				}
//		}
//
//		/// <summary>
//		/// Resets the notification.
//		/// </summary>
//		void ResetNotification ()
//		{
////		Debug.Log ("ResetNotification called");
//				//EtceteraBinding.setBadgeCount (-1);
//				NotificationServices.ClearLocalNotifications ();
//				NotificationServices.CancelAllLocalNotifications ();
//		}
//
//		/// <summary>
//		/// Raises the application pause event.
//		/// </summary>
//		/// <param name="IsPause">If set to <c>true</c> is pause.</param>
//		void OnApplicationPause (bool IsPause)
//		{
////		Debug.Log ("IsPause : " + IsPause);
//
//				if (IsPause) {	
//						PushNotification (10, 24, 10, 48);
//				} else {
//						ResetNotification ();
//				}
//		}
}
