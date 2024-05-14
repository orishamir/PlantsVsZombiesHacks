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

        bool freePlants = false;
        bool instantRecharge = false;
        
        protected override void Render()
        {
            ImGui.Begin("PlantsVsZombies hacks");
            ImGui.SetWindowSize(new Vector2(520, 280));
            
            ImGui.SetWindowFontScale((float)1.8);
            if (ImGui.Checkbox("Free plants!", ref freePlants))
            {
                freePlantsChanged();
            }

            if (ImGui.Checkbox("Instant Recharge!", ref instantRecharge))
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
            if (freePlants)
                this.cheats.freePlantsCheat.SetFreePlants();
            else
                this.cheats.freePlantsCheat.RemoveFreePlants();
        }

        private void instantRechargeChanged()
        {
            if (instantRecharge)
                this.cheats.instantRechargeCheat.SetInstantRecharge();
            else
                this.cheats.instantRechargeCheat.RemoveInstantRecharge();
        }
    }
}