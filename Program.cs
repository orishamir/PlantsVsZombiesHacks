using System.Numerics;
using ImGuiNET;
using ClickableTransparentOverlay;
// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable SuggestVarOrType_SimpleTypes
// ReSharper disable SuggestVarOrType_BuiltInTypes
// ReSharper disable ArrangeThisQualifier
// ReSharper disable RedundantDefaultMemberInitializer
// ReSharper disable ArrangeObjectCreationWhenTypeEvident

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

        readonly CheatClass cheats = new CheatClass();
        int sunsCountValue = 500;

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
                this.cheats.Suns.SetSuns(sunsCountValue);
            }

            if (ImGui.Button("temp"))
            {
                cheats.PlantsCheat.Run();
            }

            ImGui.End();
        }

        private void freePlantsChanged()
        {
            if (freePlantsEnabled)
                this.cheats.FreePlantsToggleCheat.Activate();
            else
                this.cheats.FreePlantsToggleCheat.Deactivate();
        }

        private void instantRechargeChanged()
        {
            if (instantRechargeEnabled)
                this.cheats.InstantRechargeToggleCheat.Activate();
            else
                this.cheats.InstantRechargeToggleCheat.Deactivate();
        }
    }
}