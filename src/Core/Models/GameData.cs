﻿using Newtonsoft.Json;
using System.IO;

namespace Game.Core.Models
{
    /// <summary>
    /// The game's data
    /// </summary>
    public class GameData
    {
        /// <summary>
        /// Game name
        /// </summary>
        public static string GameName { get; set; } = "Retro Fantasy RPG";

        /// <summary>
        /// Subtitle of the game name
        /// </summary>
        public static string GameSubtitle { get; set; } = "The Test Of Data";

        /// <summary>
        /// The filename of the save game that stores the game data
        /// </summary>
        public static string SavegameFilename { get; } = "retro-fantasy-test-of-data.json";

        /// <summary>
        /// Creates a new game data instance
        /// </summary>
        /// <returns>game data instance</returns>
        public static GameData Create()
        {
            return new GameData
            {
            };
        }

        /// <summary>
        /// Saves game data to the stream
        /// </summary>
        /// <param name="stream">stream to save game to</param>
        public void Save(Stream stream)
        {
            string json = JsonConvert.SerializeObject(this);

            using (var writer = new StreamWriter(stream))
            {
                writer.Write(json);
            }
        }

        /// <summary>
        /// Loads game data from given stream
        /// </summary>
        /// <param name="stream">stream to load game data from</param>
        /// <returns>loaded game data</returns>
        public static GameData Load(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<GameData>(json);
            }
        }
    }
}
