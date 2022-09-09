#region Assembly MonoGame.Framework, Version=3.5.1.1679, Culture=neutral, PublicKeyToken=null
// C:\Program Files (x86)\MonoGame\v3.0\Assemblies\Windows\MonoGame.Framework.dll
#endregion

using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework
{
    public class Game : IDisposable
    {
        public Game();

        ~Game();

        public GameComponentCollection Components { get; }
        public ContentManager Content { get; set; }
        public GraphicsDevice GraphicsDevice { get; }
        public TimeSpan InactiveSleepTime { get; set; }
        public bool IsActive { get; }
        public bool IsFixedTimeStep { get; set; }
        public bool IsMouseVisible { get; set; }
        public LaunchParameters LaunchParameters { get; }
        //
        // Summary:
        //     The maximum amount of time we will frameskip over and only perform Update calls
        //     with no Draw calls. MonoGame extension.
        public TimeSpan MaxElapsedTime { get; set; }
        public GameServiceContainer Services { get; }
        public TimeSpan TargetElapsedTime { get; set; }
        [CLSCompliant(false)]
        public GameWindow Window { get; }

        public event EventHandler<EventArgs> Activated;
        public event EventHandler<EventArgs> Deactivated;
        public event EventHandler<EventArgs> Disposed;
        public event EventHandler<EventArgs> Exiting;

        public void Dispose();
        public void Exit();
        public void ResetElapsedTime();
        public void Run();
        public void Run(GameRunBehavior runBehavior);
        public void RunOneFrame();
        public void SuppressDraw();
        public void Tick();
        protected virtual bool BeginDraw();
        protected virtual void BeginRun();
        protected virtual void Dispose(bool disposing);
        protected virtual void Draw(GameTime gameTime);
        protected virtual void EndDraw();
        protected virtual void EndRun();
        protected virtual void Initialize();
        protected virtual void LoadContent();
        protected virtual void OnActivated(object sender, EventArgs args);
        protected virtual void OnDeactivated(object sender, EventArgs args);
        protected virtual void OnExiting(object sender, EventArgs args);
        protected virtual void UnloadContent();
        protected virtual void Update(GameTime gameTime);
    }
}