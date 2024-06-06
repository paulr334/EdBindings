namespace EdBindings.Model
{
    using EdBindings.Model.BindingsRaw.Bindings;

    using Newtonsoft.Json;

    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DeviceMap
    {
        public string Name { get; set; }
        public List<DeviceControlMap> Controls { get; set; }

        public DeviceControlMap FindControlMap(BindingDevice binding)
        {
            if (binding == null)
            {
                return null;
            }

            return this.Controls.FirstOrDefault(c => c.DeviceId.ToUpperInvariant() == binding.Device.ToUpperInvariant() && c.ControlValue.ToUpperInvariant() == binding.Key.ToUpperInvariant());
        }

        public static DeviceMap Open(string path)
        {
            return JsonConvert.DeserializeObject<DeviceMap>(File.ReadAllText(path));
        }
    }
}
