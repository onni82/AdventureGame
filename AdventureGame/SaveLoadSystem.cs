﻿using Newtonsoft.Json;
using System;
using System.IO;

namespace AdventureGame
{
	public static class SaveLoadSystem
	{
		private static string saveFilePath = "savegame.json";

		// Save the game state to a file, including the story stage
		public static void SaveGame(Entity player, Inventory inventory, string storyStage)
		{
			SaveData saveData = new SaveData(player, inventory, storyStage);
			string jsonData = JsonConvert.SerializeObject(saveData, Formatting.Indented);

			// Write to a file
			File.WriteAllText(saveFilePath, jsonData);
			Console.WriteLine("Game saved successfully.");
		}

		// Load the game state from a file, including the story stage
		public static bool LoadGame(out Entity player, out Inventory inventory, out string storyStage)
		{
			player = null;
			inventory = new Inventory();
			storyStage = string.Empty;

			if (File.Exists(saveFilePath))
			{
				string jsonData = File.ReadAllText(saveFilePath);
				SaveData saveData = JsonConvert.DeserializeObject<SaveData>(jsonData);

				if (saveData != null)
				{
					// Recreate player and inventory from saved data
					player = new Entity
					{
						Name = saveData.PlayerName,
						Health = saveData.PlayerHealth,
						Level = saveData.PlayerLevel,
						Experience = saveData.PlayerExperience
					};

					foreach (var item in saveData.Inventory)
					{
						inventory.AddItem(item.Name, item.Amount);
					}

					// Set story stage
					storyStage = saveData.StoryStage;

					Console.WriteLine("Game loaded successfully.");
					return true;
				}
				else
				{
					Console.WriteLine("Error loading saved game.");
					return false;
				}
			}
			else
			{
				Console.WriteLine("No saved game found.");
				return false;
			}
		}
	}
}
