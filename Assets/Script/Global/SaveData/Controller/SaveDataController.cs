using Agate.MVC.Base;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter.SaveData
{
    public class SaveDataController : DataController<SaveDataController, SaveDataModel>
    {
        public SaveDataController()
        {
            LoadFromStorage();
        }

        public void SaveToStorage()
        {
            string json = JsonUtility.ToJson(new AllDataPlayer(_model.DataPlayer));
            string pathI = "C:/DataSpaceShooter";
            if (!Directory.Exists(pathI)) {
                Directory.CreateDirectory(pathI);
            }

            File.WriteAllText(pathI+ "/DataLeaderBoard.json", json);
        }

        public void LoadFromStorage()
        {
            string pathI = "C:/DataSpaceShooter/DataLeaderBoard.json";
            AllDataPlayer data;
            if (File.Exists(pathI))
            {
                string isi = File.ReadAllText(pathI);
                data = JsonUtility.FromJson<AllDataPlayer>(isi);
            }
            else
            {
                data = new AllDataPlayer(new DataPlayer[0]);
            }

            _model.LoadDataModel(data.DataPlayer);
        }

        public void GetDataPlayer(UnityAction<DataPlayer[]> action) => action(_model.DataPlayer);

        public void CompareScorePlayer(DataPlayer player)
        {
            if (_model.DataPlayer.Length > 0) {
                for (int i = 0; i < _model.DataPlayer.Length; i++)
                {
                    if (_model.DataPlayer[i]._score < player._score)
                    {
                        int currentIdx = 0;
                        DataPlayer down = _model.DataPlayer[i];
                        _model.DataPlayer[i] = player;

                        for (int j = i + 1; j < _model.DataPlayer.Length; j++)
                        {
                            DataPlayer down2 = _model.DataPlayer[j];
                            _model.DataPlayer[j] = down;
                            down = down2;
                            currentIdx = j;
                        }

                        if(currentIdx < 9)
                        {
                            AddPlayerToLast(down);
                        }

                        break;
                    }

                    if (i == _model.DataPlayer.Length - 1 && _model.DataPlayer.Length < 9)
                    {
                        AddPlayerToLast(player);
                        break;
                    }
                }
            }
            else
            {
                AddPlayerToLast(player);
            }
        }

        private void AddPlayerToLast(DataPlayer player)
        {
            DataPlayer[] expand = new DataPlayer[_model.DataPlayer.Length + 1];

            for (int i=0; i<_model.DataPlayer.Length; i++)
            {
                expand[i] = _model.DataPlayer[i];
            }

            expand[expand.Length - 1] = player;

            _model.LoadDataModel(expand);
            SaveToStorage();
        }
    }
}
