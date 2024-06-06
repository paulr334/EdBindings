using Newtonsoft.Json;

using System.Collections.Generic;
using System.IO;

namespace EdBindings.Model
{
    public record ActionMapping
    {
        public string Code { get; set; }
        public string Area { get; set; }
        public string Category { get; set; }
        public string Action { get; set; }
        
        public static List<ActionMapping> Open(string path)
        {
            return JsonConvert.DeserializeObject<List<ActionMapping>>(File.ReadAllText(path));
        }
    }
}
