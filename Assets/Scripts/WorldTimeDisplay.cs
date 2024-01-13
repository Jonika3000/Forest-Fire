using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(TMP_Text))]
    public class WorldTimeDisplay: MonoBehaviour
    {
        [SerializeField]
        private WorldTime worldTime;

        private TMP_Text text;

        private void Awake()
        {
            text = GetComponent<TMP_Text>();
            worldTime.WorldTimeChanged += WorldTime_WorldTimeChanged;
        }

        private void OnDestroy()
        {
            worldTime.WorldTimeChanged -= WorldTime_WorldTimeChanged;
        }

        private void WorldTime_WorldTimeChanged(object sender, TimeSpan newTime)
        {
            text.SetText(newTime.ToString(@"hh\:mm"));
        }
    }
}
