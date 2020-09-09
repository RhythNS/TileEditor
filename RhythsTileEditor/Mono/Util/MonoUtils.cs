using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;

namespace RhyTiles.Mono.Util
{
    public class MonoUtils
    {
        public static bool TryLoadTextureFromAbsolutePath(GraphicsDevice graphics, string loc, out Texture2D texture)
        {
            texture = null;
            if (File.Exists(loc) == false)
                return false;

            try
            {
                Stream read = new FileStream(loc, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                texture = Texture2D.FromStream(graphics, read);
                read.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
