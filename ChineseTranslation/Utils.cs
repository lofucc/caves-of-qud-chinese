using System.Linq;
using XRL;
using XRL.Collections;

namespace Lofucc.ChineseTranslation
{
  /// <summary>
  /// 实用工具
  /// </summary>
  class Utils
  {
    /// <summary>
    /// 获取模组的文件列表
    /// </summary>
    /// <returns>文件列表</returns>
    public static Rack<ModFile> GetFiles()
    {
      var ID = typeof(Dict).Namespace.Replace(".", "_");

      foreach (ModInfo mod in ModManager.ActiveMods)
      {
        if (mod.ID != ID) continue;

        return mod.Files;
      }

      return null;
    }

    /// <summary>
    /// 获取回溯信息
    /// </summary>
    /// <returns>回溯信息数组</returns>
    public static string[] GetBackTrace()
    {
      return new System.Diagnostics.StackTrace(3).GetFrames().Select(frame => $"{frame.GetMethod().DeclaringType}.{frame.GetMethod().Name}").ToArray();
    }
  }
}

