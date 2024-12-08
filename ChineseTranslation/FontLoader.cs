using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;
using XRL;

namespace Lofucc.ChineseTranslation
{
  /// <summary>
  /// 字体加载器
  /// </summary>
  [HasModSensitiveStaticCache]
  class FontLoader
  {
    /// <summary>
    /// 在模组初始化时加载字体
    /// </summary>
    [ModSensitiveCacheInit]
    public static void LoadFont()
    {
      // 筛选出字体的 AssetBundle
      var file = Utils.GetFiles().First(file => file.Name == "font" && file.Extension == ".ab");

      // 加载 AssetBundle 并筛选出加载好的 font.ab，注意 AssetBundle.LoadFromFile 在第二次调用时会返回 null，所以需要筛选已加载的 AssetBundle
      AssetBundle.LoadFromFile(file.OriginalName);
      var assetBundle = AssetBundle.GetAllLoadedAssetBundles().First(ab => ab.name == "font.ab");

      // 加载字体 asset 并修复 shader
      var font = assetBundle.LoadAsset<TMP_FontAsset>("assets/font.asset");
      font.material.shader = TMP_Settings.defaultFontAsset.material.shader;

      // 使用反射设置 TextMeshPro 的默认字体
      var type = typeof(TMP_Settings);
      var field = type.GetField("m_defaultFontAsset", BindingFlags.Instance | BindingFlags.NonPublic);
      field.SetValue(TMP_Settings.instance, font);

      // 替换已载入场景的 TextMeshProUGUI 对象中的字体
      foreach (var text in GameObject.FindObjectsOfType<TextMeshProUGUI>())
      {
        text.font = font;
      }
    }
  }
}


