using System.Collections.Generic;
using HarmonyLib;
using XRL.CharacterBuilds;
using XRL.CharacterBuilds.Qud;
using static XRL.CharacterBuilds.Qud.QudGamemodeModule;

namespace Lofucc.ChineseTranslation.XML.EmbarkModules
{
  [HarmonyPatch(typeof(AbstractEmbarkBuilderModule), "HandleWindowTitleNode")]
  class AbstractEmbarkBuilderModule__HandleWindowTitleNode
  {
    static void Postfix(EmbarkBuilderModuleWindowDescriptor ___CurrentLoadingWindowDescriptor, object xml)
    {
      Dict.Translate(ref ___CurrentLoadingWindowDescriptor.title, "XML/Embark/Window/Title");
    }
  }

  [HarmonyPatch(typeof(QudGamemodeModule), "Init")]
  class QudGamemodeModule__Init
  {
    static void Postfix(Dictionary<string, GameModeDescriptor> ___GameModes)
    {
      foreach (var mode in ___GameModes.Values)
      {
        Dict.Translate(ref mode.Title, "XML/Embark/Module/Gamemode/Title");
        Dict.Translate(ref mode.Description, "XML/Embark/Module/Gamemode/Description");
      }
    }
  }
}

