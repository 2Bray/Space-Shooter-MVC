using Agate.MVC.Base;
using SpaceShooter.SaveData;
using System;
using UnityEngine;

namespace SpaceShooter.Scene.MainMenu.LeaderBoard
{
    public class LeaderBoardController : ObjectController<LeaderBoardController, LeaderBoardView>
    {
        public void InitController(LeaderBoardView view)
        {
            SetView(view);
            Publish(new AskSaveDataMessage(ShowLeaderBoard));
            DataPlayer player = new DataPlayer("Player2", 100);
            Publish(new ComparePlayerMessage(player));
        }

        private void ShowLeaderBoard(DataPlayer[] data)
        {
            string send = "";
            if (data.Length == 0)
            {
                send = "No Data";
            }
            else
            {
                send = "Name\tScore\n";
                foreach (DataPlayer player in data)
                {
                    send = send + player._name + "\t" + player._score + "\n";
                }
            }

            _view.UpdateLeaderBoard(send);
        }

    
    }
}
