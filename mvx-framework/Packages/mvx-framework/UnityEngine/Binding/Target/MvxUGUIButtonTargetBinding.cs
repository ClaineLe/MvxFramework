using MvvmCross.Binding;
using UnityEngine.UI;

namespace MvxFramework.UnityEngine.Binding.Target
{
    public class MvxUGUIButtonTargetBinding : MvxUnityEventTargetBinding<Button>
    {
        public MvxUGUIButtonTargetBinding(Button control, string controlEvent) : base(control, controlEvent)
        {
        }

        protected override void AddHandler(Button control)
        {
            switch (_controlEvent)
            {
                case MvxUGUIPropertyBinding.Button_onClick:
                    control.onClick.AddListener(ControlEvent);
                    break;
                default:
                    MvxBindingLog.Error("Error - Invalid controlEvent in MvxUGUIPropertyBinding");
                    break;
            }
        }

        protected override void RemoveHandler()
        {
            switch (_controlEvent)
            {
                case MvxUGUIPropertyBinding.Button_onClick:
                    Control.onClick.RemoveListener(ControlEvent);
                    break;
                default:
                    MvxBindingLog.Error("Error - Invalid controlEvent in MvxUGUIPropertyBinding");
                    break;
            }
        }
    }
}