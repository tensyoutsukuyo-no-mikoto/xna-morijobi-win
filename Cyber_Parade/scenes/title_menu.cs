using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace xna_morijobi_win.cyber_parade.scenes
{
    public class title_menu
        :scene.scene
    {
        protected TimeSpan elapsed_time = TimeSpan.Zero;

        protected SpriteBatch sprite_batch { get; set; }
        protected SpriteFont font { get; set; }
        protected Texture2D image;

        protected Song bgm;
        protected SoundEffect se_enter;

        public title_menu(Game g) : base(g) { }

        public override void Initialize()
        {
            sprite_batch = new SpriteBatch(Game.GraphicsDevice);
            font = Game.Content.Load<SpriteFont>(@"fonts\default");
            image = Game.Content.Load<Texture2D>(@"title\title_2");
            base.Initialize();
        }

        public override void resume()
        {
            base.resume();
            elapsed_time = TimeSpan.Zero;
            MediaPlayer.IsRepeating = true;
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            sprite_batch.Begin();
            sprite_batch.Draw(image, new Rectangle(0, 0, Game.GraphicsDevice.Viewport.Width, Game.GraphicsDevice.Viewport.Height), Color.White);
            sprite_batch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            elapsed_time += gameTime.ElapsedGameTime;

            if (input_manager.is_key_down_begin(Keys.Z))
            {
                scene_manager.push(new free_play.free_play(Game));
            }
        }
    }
}
