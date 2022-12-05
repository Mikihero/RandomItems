using System;
using CommandSystem;
using Exiled.API.Enums;
using Exiled.API.Features;

namespace RandomItems.Commands
{
    class RandomItems : ICommand, IUsageProvider
    {
        public string Command => "randomitems";

        public string[] Aliases => new string[] { "" };

        public string Description => "Gives a random item to the specified team.";

        public string[] Usage => new string[] { "" };

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            bool parsedCorrectly = Enum.TryParse(arguments.At(0), out Team team);
            if(parsedCorrectly)
            {
                var teamPlayers = Player.Get(team);
                Log.Info($"Team: {teamPlayers}");
                ItemType[] itemsArray = Enum.GetValues(typeof(ItemType)).ToArray<ItemType>();
                for(int i = 0; i < itemsArray.Length; i++)
                {
                    if(itemsArray. == ItemType.None)
                    {

                    }
                }
                ItemType item = itemsArray.SetValue itemsArray.IndexOf(ItemType.None)] [UnityEngine.Random.Range(0, Enum.GetValues(typeof(ItemType)).Length)];
                Log.Info($"Item: {item}");
                foreach(Player pl in teamPlayers)
                {
                    pl.AddItem(item);
                }
                response = "Successfuly added items.";
                return true;
            }
            response = "Couldn't parse team name.";
            return false;
        }
    }
}
