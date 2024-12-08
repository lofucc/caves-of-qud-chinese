using HarmonyLib;
using XRL.CharacterBuilds;
using XRL.CharacterBuilds.Qud;

namespace Lofucc.ChineseTranslation
{
  /// <summary>
  /// XRL.CharacterBuilds.EmbarkBuilderConfiguration 的 Harmony 补丁
  /// </summary>
  [HarmonyPatch(typeof(EmbarkBuilderConfiguration))]
  class EmbarkBuilderConfigurationPatcher
  {
    /// <summary>
    /// Init 方法的 Postfix 补丁
    /// </summary>
    [HarmonyPostfix]
    [HarmonyPatch("Init")]
    static void Postfix()
    {
      foreach (var module in EmbarkBuilderConfiguration.modules.Values)
      {
        foreach (var window in module.windows.Values)
        {
          Dict.Translate(ref window.name, "XML/embarkmodules/module/window/name");
          Dict.Translate(ref window.title, "XML/embarkmodules/module/window/title");
        }

        // XRL.CharacterBuilds.Qud.QudGamemodeModule 模块
        if (module is QudGamemodeModule modes)
        {
          foreach (var mode in modes.GameModes.Values)
          {
            Dict.Translate(ref mode.Title, "XML/embarkmodules/module/Modes/mode/title");
            Dict.Translate(ref mode.Description, "XML/embarkmodules/module/Modes/mode/description");
          }
        }
      }
    }
  }
}

