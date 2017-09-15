using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace XahlicemMod {
    public class XahlicemMod : Mod {

        public XahlicemMod() {

            Properties = new ModProperties() {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        public override void Load() { }

        public override void Unload() { }

        public override void ModifyInterfaceLayers(System.Collections.Generic.List<GameInterfaceLayer> layers) { }

        public override void HandlePacket(System.IO.BinaryReader reader, int whoAmI) { }
    }

    public enum XModMessageType : byte { }
}