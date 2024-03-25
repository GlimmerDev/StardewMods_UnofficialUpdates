using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using System;

namespace Level_Up_Notifications
{
  public class ModEntry : Mod
  {
    private bool loadedBool;

    public override void Entry(IModHelper helper)
    {
      helper.Events.Player.LevelChanged += onLevelChanged;
      helper.Events.GameLoop.SaveLoaded += loadedFunc;
    }

    private void onLevelChanged(object sender, LevelChangedEventArgs e)
    {
      if (e.IsLocalPlayer) NotifyLevelUp(e.NewLevel, e.Skill);
    }

    private void loadedFunc(object sender, EventArgs args)
    {
      this.Monitor.Log("Level Up Notifications by kd8lvt is ready!", (LogLevel) 2);
      this.loadedBool = true;
    }

    private void NotifyLevelUp(int newLevel, StardewModdingAPI.Enums.SkillType skill)
    {
      string skillStr = "";
      if (!this.loadedBool)
        return;
      switch (skill)
        {
            case StardewModdingAPI.Enums.SkillType.Combat: skillStr = "Combat"; break;
            case StardewModdingAPI.Enums.SkillType.Farming: skillStr = "Farming"; break;
            case StardewModdingAPI.Enums.SkillType.Fishing: skillStr = "Fishing"; break;
            case StardewModdingAPI.Enums.SkillType.Foraging: skillStr = "Foraging"; break;
            case StardewModdingAPI.Enums.SkillType.Mining: skillStr = "Mining"; break;
        }
      Game1.drawDialogueNoTyping("You leveled up to level " + newLevel + " in " + skillStr + "!");
    }

    public ModEntry()
    {
    }
  }
}
