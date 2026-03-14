using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;
using System;

public class DiscordControl : MonoBehaviour
{

	public Discord.Discord discord;

	// Use this for initialization
	void Start()
	{
		System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
		int cur_time = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;
		discord = new Discord.Discord(877573321028407366, (System.UInt64)Discord.CreateFlags.NoRequireDiscord);
		var activityManager = discord.GetActivityManager();
		var activity = new Discord.Activity
		{
			Details = "In Sandbox",
			State = "Pre-Alpha",
			Timestamps = {
				Start = cur_time
			},
			Assets = {
				LargeText = "Physics Lab",
				LargeImage = "physics_lab"
			}

		};
		activityManager.UpdateActivity(activity, (res) =>
		{
			if (res == Discord.Result.Ok)
			{
				Debug.Log("Everything is fine!");
			}
		});
	}

	// Update is called once per frame
	void Update()
	{
		try
		{
			discord.RunCallbacks();
		}
		catch (Exception e)
		{
			print("DiscordErr: "+e);
		}
		
	}
}