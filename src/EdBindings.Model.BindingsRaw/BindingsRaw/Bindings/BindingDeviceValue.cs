namespace EdBindings.Model.BindingsRaw.Bindings
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public record BindingDevice(string Name, string Device, string Key) : Binding(Name)
    {
        public static Binding MakeBindingDevice(XElement element)
        {
            if (!element.Attributes().Any(attribute => attribute.Name == "Device"))
            {
                return null;
            }

            return new BindingDevice(
               Name: element.Name.LocalName,
               Device: element.Attribute("Device").Value,
               //Key: element.Attribute("Key").Value);
               Key: CreateKeyString(element));
        }

        private static string CreateKeyString(XElement element)
        {
            var key = element.Attribute("Key").Value;

            if (element == null || !element.HasElements)
                return key;

            var modifiers = element.Elements("Modifier");
            // Modifiers not displaying correctly in list - they should read names from the device mapping json but don't
            return modifiers.Any() ? modifiers.Aggregate(key, (aggregate, mod) => aggregate + " + " + mod.Attribute("Key")?.Value) : key;

        }
    }
}
