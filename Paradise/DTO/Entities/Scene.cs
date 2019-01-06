using System.Collections.Generic;

namespace DTO.Entities
{
    public class Scene
    {
        public int SceneId { get; set; }

        public List<Dialogue> Dialogues { get; set; }
    }
}
