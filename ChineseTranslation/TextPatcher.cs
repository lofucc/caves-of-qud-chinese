using HarmonyLib;
using UnityEngine.UI;

namespace Lofucc.ChineseTranslation
{
  /// <summary>
  /// UnityEngine.UI.Text 的 Harmony 补丁
  /// </summary>
  [HarmonyPatch(typeof(Text))]
  class TextPatcher
  {
    /// <summary>
    /// text 字段 setter 的 Prefix 补丁
    /// </summary>
    /// <param name="value">setter 值的引用</param>
    [HarmonyPrefix]
    [HarmonyPatch("text", MethodType.Setter)]
    static void Prefix(ref string value)
    {
      Dict.Translate(ref value, "Text");
    }
  }
}
