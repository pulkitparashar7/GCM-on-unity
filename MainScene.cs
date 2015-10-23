using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class MainScene : MonoBehaviour {
	
	private string[] SENDER_IDS = {"xxxxxxxx"};// enter your GCMid here
	
	private string text1 = "(null)";
	
	
	void Start () {
		
		// Create receiver game object
		GCM.Initialize ();
		
		GCM.SetErrorCallback ((string errorId) => {
			GCM.ShowToast ("Error!!!");
			text1 = "Error: " + errorId;
		});
		
		GCM.SetMessageCallback ((Dictionary<string, object> table) => {
			GCM.ShowToast (" New Message!!!");
			text1 = "Message: " + System.Environment.NewLine;
			foreach (var key in  table.Keys) {
				text1 += key + "=" + table[key] + System.Environment.NewLine;
			}
		});
		
		GCM.SetRegisteredCallback ((string registrationId) => {
			GCM.ShowToast ("Registered!!!");
			text1 = "Register: " + registrationId; 
		});
		
		GCM.SetUnregisteredCallback ((string registrationId) => {
			GCM.ShowToast ("Unregistered!!!");
			text1 = "Unregister: " + registrationId;
		});
		
		GCM.SetDeleteMessagesCallback ((int total) => {
			GCM.ShowToast ("Delete Messaged!!!");
			text1 = "DeleteMessages: " + total;
		});
	}
	
	void Update () {
	
	}
	
	void OnGUI () {
		float x = 50.0f;
		float y = 50.0f;
		float width = Screen.width / 2 - x - 25.0f;
		float height = 100.0f;
		float margin = 25.0f;
		
		if (GUI.Button (new Rect(x, y, width, height), "Register")) {
			GCM.Register (SENDER_IDS);
		}
		
		x += width + margin * 2;
		
		if (GUI.Button (new Rect(x, y, width, height), "Unregister")) {
			GCM.Unregister ();
		}
		
		x -= width + margin * 2;
		y += height + margin;
		
		if (GUI.Button (new Rect(x, y, width, height), "IsRegistered")) {
			text1 = "IsRegistered = " + GCM.IsRegistered ();
		}
		
		x += width + margin * 2;
		
		if (GUI.Button (new Rect(x, y, width, height), "GetRegisterationId")) {
			text1 = "GetRegistrationId = " + GCM.GetRegistrationId ();
		}
		
		x -= width + margin * 2;
		y += height + margin;
		
		if (GUI.Button (new Rect(x, y, width, height), "IsRegisteredOnServer")) {
			text1 = "IsRegisteredOnServer = " + GCM.IsRegisteredOnServer ();
		}
		
		x += width + margin * 2;
		
		if (GUI.Button (new Rect(x, y, width, height), "SetRegisteredOnServer")) {
			GCM.SetRegisteredOnServer (true);
			text1 = "SetRegisteredOnServer";
		}
		
		x -= width + margin * 2;
		y += height + margin;
		
		if (GUI.Button (new Rect(x, y, width, height), "GetRegisterOnServerLifespan")) {
			text1 = "GetRegisterOnServerLifespan = " + GCM.GetRegisterOnServerLifespan ();
		}
		
		x += width + margin * 2;
		
		if (GUI.Button (new Rect(x, y, width, height), "SetRegisterOnServerLifespan")) {
			GCM.SetRegisterOnServerLifespan (30 * 1000);	
			text1 = "SetRegisterOnServerLifespan";
		}
		
		x -= width + margin * 2;
		y += height + margin;
		
		GUI.TextArea (new Rect(x, y, width * 2 + margin * 2, height), text1);
		
		y += height + margin;
		
		}
}
