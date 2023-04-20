using MvvmCross.Binding;
using UnityEngine.UI;

namespace MvxFramework.UnityEngine.Binding.Target
{
    public class MvxUGUIInputFieldTargetBinding : MvxUnityEventTargetBinding<InputField, string>
    {
        public MvxUGUIInputFieldTargetBinding(InputField control, string controlEvent) : base(control, controlEvent)
        {
        }

        protected override void AddHandler(InputField control)
        {
            switch (_controlEvent)
            {
                case MvxUGUIPropertyBinding.InputField_onEndEdit:
                    control.onEndEdit.AddListener(ControlEvent);
                    break;
                case MvxUGUIPropertyBinding.InputField_onValueChanged:
                    control.onValueChanged.AddListener(ControlEvent);
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
                case MvxUGUIPropertyBinding.InputField_onEndEdit:
                    Control.onEndEdit.RemoveListener(ControlEvent);
                    break;
                case MvxUGUIPropertyBinding.InputField_onValueChanged:
                    Control.onValueChanged.RemoveListener(ControlEvent);
                    break;
                default:
                    MvxBindingLog.Error("Error - Invalid controlEvent in MvxUGUIPropertyBinding");
                    break;
            }
        }
    }
}