using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AdventureGame
{
	public class SaveData
	{
		public string PlayerName { get; set; }
		public int PlayerHealth { get; set; }
		public int PlayerLevel { get; set; }
		public int PlayerExperience { get; set; }
		public List<Item> Inventory { get; set; }
		public int StoryStage { get; set; } // Added StoryStage to track progress

		// Constructor
		public SaveData(Entity player, Inventory inventory, int storyStage)
		{
			PlayerName = player.Name;
			PlayerHealth = player.Health;
			PlayerLevel = player.Level;
			PlayerExperience = player.Experience;
			Inventory = new List<Item>(inventory); // Make a copy of the inventory
			StoryStage = storyStage;
		}

		public SaveData() { } // Empty constructor for deserialization
	}
}
