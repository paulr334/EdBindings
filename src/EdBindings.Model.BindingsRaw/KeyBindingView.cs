namespace EdBindings.Model
{
    using EdBindings.Model.BindingsRaw.Bindings;

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    [DebuggerDisplay("{Name} {PrimaryDevice}/{PrimaryKey}; {SecondaryDevice}/{SecondaryKey}")]
    public class KeyBindingView
    {
        public string Area { get; set; }
        public string Category { get; set; }
        public string Action { get; set; }
        public string PrimaryDevice { get; set; }
        public string PrimaryKey { get; set; }
        public string SecondaryDevice { get; set; }
        public string SecondaryKey { get; set; }
        public string BindEdVariable { get; set; }
        
        public static KeyBindingView MakeKeyBindingView(BindingGroup group, DeviceMap deviceMap, List<ActionMapping> actionMappings)
        {
            var view = new KeyBindingView();

            var actionMapping = actionMappings.FirstOrDefault(am => am.Code.Equals(group.Name, StringComparison.OrdinalIgnoreCase));
            view.Area = actionMapping?.Area ?? string.Empty;
            view.Category = actionMapping?.Category ?? string.Empty;
            view.Action = actionMapping?.Action ?? group.Name;

            var primary = (BindingDevice)group.Bindings.First(b => new[] { "Binding", "Primary" }.Contains(b.Name));
            var primaryDeviceMap = deviceMap.FindControlMap(primary);
            var secondary = (BindingDevice)group.Bindings.FirstOrDefault(b => b.Name == "Secondary");
            var secondaryDeviceMap = deviceMap.FindControlMap(secondary);

            view.PrimaryDevice = primaryDeviceMap?.DeviceName ?? primary.Device;
            view.PrimaryKey = primaryDeviceMap?.ControlLabel ?? primary.Key;
            view.SecondaryDevice = secondaryDeviceMap?.DeviceName ?? secondary?.Device;
            view.SecondaryKey = secondaryDeviceMap?.ControlLabel ?? secondary?.Key;
            view.BindEdVariable = $"ed{group.Name}";

            return view;
        }


    }
}
