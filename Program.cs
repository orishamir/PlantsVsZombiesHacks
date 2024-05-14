using System.Numerics;
using ImGuiNET;
using ClickableTransparentOverlay;
// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable SuggestVarOrType_SimpleTypes
// ReSharper disable SuggestVarOrType_BuiltInTypes

namespace PlantsVsZombiesHacks
{
    public class Program : Overlay
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting up");
            Program program = new Program();
            program.Start().Wait();
        }

        CheatClass cheats = new CheatClass();
        int sunsCountValue;

        bool freePlantsEnabled = false;
        bool instantRechargeEnabled = false;
        
        protected override void Render()
        {
            ImGui.Begin("PlantsVsZombies hacks");
            ImGui.SetWindowSize(new Vector2(520, 280));
            
            ImGui.SetWindowFontScale((float)1.8);
            if (ImGui.Checkbox("Free plants!", ref freePlantsEnabled))
            {
                freePlantsChanged();
            }

            if (ImGui.Checkbox("Instant Recharge!", ref instantRechargeEnabled))
            {
                instantRechargeChanged();
            }
            
            ImGui.InputInt("Suns Count", ref sunsCountValue, 50, 100);
            if (ImGui.Button("Set"))
            {
                this.cheats.suns.SetSuns(sunsCountValue);
            }
            
            ImGui.End();
        }

        private void freePlantsChanged()
        {
            if (freePlantsEnabled)
                this.cheats.freePlantsCheat.Activate();
            else
                this.cheats.freePlantsCheat.Deactivate();
        }

        private void instantRechargeChanged()
        {
            if (instantRechargeEnabled)
                this.cheats.instantRechargeCheat.Activate();
            else
                this.cheats.instantRechargeCheat.Deactivate();
        }
    }
}