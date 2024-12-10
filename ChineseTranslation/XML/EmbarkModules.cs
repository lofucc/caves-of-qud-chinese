using System;
using System.Collections.Generic;
using HarmonyLib;
using XRL.CharacterBuilds;
using XRL.CharacterBuilds.Qud.UI;
using XRL.UI.Framework;

namespace Lofucc.ChineseTranslation.XML.EmbarkModules
{
  [HarmonyPatch(typeof(FrameworkScroller), "BeforeShow", new Type[] { typeof(EmbarkBuilderModuleWindowDescriptor), typeof(IEnumerable<FrameworkDataElement>) })]
  class FrameworkScroller__BeforeShow
  {
    static void Prefix(EmbarkBuilderModuleWindowDescriptor descriptor)
    {
      if (descriptor != null)
      {
        Dict.Translate(ref descriptor.title, "XML/Embark/Window/Title");
      }
    }
  }

  [HarmonyPatch(typeof(QudGamemodeModuleWindow), "BeforeShow")]
  class QudGamemodeModuleWindow__BeforeShow
  {
    static void Prefix(QudGamemodeModuleWindow __instance)
    {
      foreach (var mode in __instance.module.GameModes.Values)
      {
        Dict.Translate(ref mode.Title, "XML/Embark/Module/Gamemode/Title");
        Dict.Translate(ref mode.Description, "XML/Embark/Module/Gamemode/Description");
      }
    }
  }

  [HarmonyPatch(typeof(QudChartypeModuleWindow), "BeforeShow")]
  class QudChartypeModuleWindow__BeforeShow
  {
    static void Prefix(QudChartypeModuleWindow __instance)
    {
      foreach (var type in __instance.module.GameTypes.Values)
      {
        Dict.Translate(ref type.Title, "XML/Embark/Module/Chartype/Title");
      }
    }
  }
}

