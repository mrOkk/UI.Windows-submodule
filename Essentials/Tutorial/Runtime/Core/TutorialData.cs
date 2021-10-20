using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.UI.Windows.Essentials.Tutorial {

    public enum ConditionResult {

        Success,
        Failed,

    }

    public interface IConditionRuntime {

        string runtimeText { get; }

    }
    
    public interface ICondition {

        string text { get; }

        ConditionResult IsValid(in Context context);

    }

    public interface IAction {

        string text { get; }

        void Execute(in Context context);

    }

    public enum ConditionValue {

        EqualsTo,
        NotEqualsTo,
        LessThan,
        GreaterThan,
        LessOrEqualsThan,
        GreaterOrEqualsThan,

    }

    public struct ConditionValueChecker {

        private ConditionValue conditionValue;
        private int checkValue;
        private int value;

        public ConditionValueChecker(ConditionValue conditionValue, int value, int checkValue) {
            
            this.conditionValue = conditionValue;
            this.checkValue = checkValue;
            this.value = value;
            
        }

        public bool GetResult() {

            if (this.conditionValue == ConditionValue.EqualsTo) {
                
                return this.value == this.checkValue;

            } else if (this.conditionValue == ConditionValue.NotEqualsTo) {
                
                return this.value != this.checkValue;

            } else if (this.conditionValue == ConditionValue.LessThan) {
                
                return this.checkValue < this.value;

            } else if (this.conditionValue == ConditionValue.GreaterThan) {
                
                return this.checkValue > this.value;

            } else if (this.conditionValue == ConditionValue.LessOrEqualsThan) {
                
                return this.checkValue <= this.value;

            } else if (this.conditionValue == ConditionValue.GreaterOrEqualsThan) {
                
                return this.checkValue >= this.value;

            }
            
            return false;
            
        }

    }
    
    [System.Serializable]
    public struct WindowType {

        public string guid;
        public string type;

    }
    
    [System.Serializable]
    public struct Conditions {
        
        [SerializeReference]
        public ICondition[] items;
        
    }

    [System.Serializable]
    public struct Actions {
        
        [SerializeReference]
        public IAction[] items;
        
    }

    [CreateAssetMenu(menuName = "UI.Windows/Tutorial/Data")]
    public class TutorialData : ScriptableObject {

        public WindowType forWindowType;
        public TutorialWindowEvent startEvent;
        
        public Conditions conditions;
        public Actions actions;

        public bool IsValid(WindowBase window, in Context context) {

            var type = window.GetType().FullName;
            if (this.forWindowType.type == type) {

                for (int i = 0; i < this.conditions.items.Length; ++i) {

                    if (this.conditions.items[i].IsValid(in context) == ConditionResult.Failed) return false;

                }

                return true;

            }

            return false;

        }

        public void OnStart(in Context context) {

            for (int i = 0; i < this.actions.items.Length; ++i) {

                this.actions.items[i].Execute(in context);

            }
            
        }

    }

}