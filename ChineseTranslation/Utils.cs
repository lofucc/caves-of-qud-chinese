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
  }
}

