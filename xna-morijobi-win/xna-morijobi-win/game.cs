using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using System.Threading.Tasks;
using xna_morijobi_win.simple3D;

namespace xna_morijobi_win
{
    public class game : Game
    {
        protected readonly GraphicsDeviceManager graphics;
        protected readonly scene.scene_manager scene_manager;
        protected readonly input.input_manager input_manager;

        public game()
        {
            graphics = new GraphicsDeviceManager(this);
            scene_manager = new scene.scene_manager(this);
            input_manager = new input.input_manager(this);
            Content.RootDirectory = "Content";
            reset_game_settings();
        }
        
        protected override void Initialize()
        {
            base.Initialize();
            reset_components();
            initialize_scenes();
        }

        protected void reset_game_settings()
        {
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 480;
            TargetElapsedTime = TimeSpan.FromSeconds(1.0 / 60.0);
        }

        protected void reset_components()
        {
            Components.Clear();
            Components.Add(input_manager);
            Components.Add(scene_manager);
        }

        protected void initialize_scenes()
        {
            scene_manager.push(new scene.scene[] {
                new scenes.title(this),
                new scenes.blanding(this),
            });
        }

        protected override void Update(GameTime gameTime)
        {
            check_exit();
            check_fullscreen();
            base.Update(gameTime);
        }

        protected void check_fullscreen()
        {
            if (input_manager.is_key_down_begin(Keys.F12))
                graphics.ToggleFullScreen();
        }

        protected void check_exit()
        {
            if (input_manager.current_keyboard_state.IsKeyDown(Keys.Escape))
                Exit();
        }
    }
}