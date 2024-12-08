using HarmonyLib;
using TMPro;

namespace Lofucc.ChineseTranslation
{
  /// <summary>
  /// TMPro.TMP_Text 的 Harmony 补丁
  /// </summary>
  [HarmonyPatch(typeof(TMP_Text))]
  class TMP_TextPatcher
  {
    /// <summary>
    /// text 字段 setter 的 Prefix 补丁
    /// </summary>
    /// <param name="value">setter 值的引用</param>
    [HarmonyPrefix]
    [HarmonyPatch("text", MethodType.Setter)]
    static void Prefix(ref string value)
    {
      Dict.Translate(ref value, "TMP_Text");
    }
  }
}
