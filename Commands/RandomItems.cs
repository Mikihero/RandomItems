using System;
using System.Collections.Generic;
using System.Linq;
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

        public string[] Usage => new string[] { "Team", "use <b><u>teams</u></b> to see all teams" };

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if(arguments.Count() != 1)
            {
                response = "Incorrect usage.";
                return false;
            }
            if(arguments.At(0).ToLower() == "teams")
            {
                response = "<b>Possible teams:</b>\n - CDP (ClassDPersonnel)\n - CHI (ChaosInsurgency)\n - MTF (MTF)\n - RSC(Researchers)";
                return false;
            }
            bool parsedCorrectly = Enum.TryParse(arguments.At(0), out Team team);
            if (!parsedCorrectly)
            {
                response = "Couldn't parse team name.";
                return false;
            }
            var teamPlayers = Player.Get(team);
            Log.Info($"Team: {teamPlayers}");
            ItemType[] itemsArray = (ItemType[])Enum.GetValues(typeof(ItemType));
            List<ItemType> itemsList = itemsArray.ToList();
            itemsList.Remove(ItemType.None);
            ItemType item = itemsList.RandomItem();
            Log.Info($"Item: {item}");
            foreach (Player pl in teamPlayers)
            {
                pl.AddItem(item);
            }
            response = "Successfuly added items.";
            return true;
        }
    }
}
