using OnixRuntime.Api;
using OnixRuntime.Plugin;
using OnixRuntime.Api.Rendering;
using OnixRuntime.Api.Inputs;
using OnixRuntime.Api.UI;

namespace ThreeBody {
    public class ThreeBody : OnixPluginBase {
        public static ThreeBody Instance { get; private set; } = null!;
        public static ThreeBodyConfig Config { get; private set; } = null!;

        public ThreeBody(OnixPluginInitInfo initInfo) : base(initInfo) {
            Instance = this;
            // If you can clean up what the plugin leaves behind manually, please do not unload the plugin when disabling.
            base.DisablingShouldUnloadPlugin = false;
#if DEBUG
           // base.WaitForDebuggerToBeAttached();
#endif
        }

        protected override void OnLoaded() {
            Console.WriteLine($"Plugin {CurrentPluginManifest.Name} loaded!");
            Config = new ThreeBodyConfig(PluginDisplayModule);
            Onix.Events.Common.Tick += OnTick;
            Onix.Events.Common.HudRender += OnHudRender;
            Onix.Events.Common.HudRenderGame += OnHudRenderGame;
            Onix.Events.Common.WorldRender += OnWorldRender;
            Onix.Events.Common.HudRenderDirect2D += OnHudRenderDirect2D;
            Onix.Events.Common.HudInput += OnHudInput;
            Onix.Events.Common.ChatMessage += OnChatMessage;
        }

        protected override void OnEnabled() {

        }

        protected override void OnDisabled() {

        }

        protected override void OnUnloaded() {
            // Ensure every task or thread is stopped when this function returns.
            // You can give them base.PluginEjectionCancellationToken which will be cancelled when this function returns. 
            Console.WriteLine($"Plugin {CurrentPluginManifest.Name} unloaded!");
            Onix.Events.Common.Tick -= OnTick;
            Onix.Events.Common.HudRender -= OnHudRender;
            Onix.Events.Common.HudRenderGame -= OnHudRenderGame;
            Onix.Events.Common.WorldRender -= OnWorldRender;
            Onix.Events.Common.HudRenderDirect2D -= OnHudRenderDirect2D;
            Onix.Events.Common.HudInput -= OnHudInput;
            Onix.Events.Common.ChatMessage -= OnChatMessage;
        }

        private void OnTick() {
        }

        private void OnHudRender(RendererCommon2D gfx, float delta) {
        }

        private void OnHudRenderGame(RendererGame gfx, float delta) {
        }

        private void OnWorldRender(RendererWorld gfx, float delta) {
        }

        private void OnHudRenderDirect2D(RendererDirect2D gfx, float delta) {
        }

        private bool OnHudInput(InputKey key, bool isDown) {
            return false;
        }

        private bool OnChatMessage(string message, string username, string xuid, ChatMessageType type) {
            return false;
        }
    }
}