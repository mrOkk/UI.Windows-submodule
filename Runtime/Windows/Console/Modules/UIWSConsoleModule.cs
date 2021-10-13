﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.UI.Windows.Runtime.Windows {

    [UnityEngine.Scripting.PreserveAttribute]
    [Help("UI.Windows Console Module")]
    [Alias("uiws")]
    public class UIWSConsoleModule : ConsoleModule {

        [UnityEngine.Scripting.PreserveAttribute]
        [Help("Destroy UIWS with all submodules")]
        public void Destroy() {

            var instance = WindowSystem.instance;
            GameObject.Destroy(instance.gameObject);

        }

        [UnityEngine.Scripting.PreserveAttribute]
        [Help("Prints all currently opened windows")]
        public void List() {

            var opened = WindowSystem.GetCurrentOpened();
            foreach (var item in opened) {

                Debug.Log($"Source: {item.prefab.name}, Window: {item.instance.name}");

            }

        }

        [UnityEngine.Scripting.PreserveAttribute]
        [Help("Hides all windows")]
        public void HideAll() {
            
            WindowSystem.HideAll();
            
        }

        [UnityEngine.Scripting.PreserveAttribute]
        [Help("Show root window")]
        public void Root() {
            
            WindowSystem.ShowRoot();
            
        }

    }

}