using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using XRL;

namespace Lofucc.ChineseTranslation
{
  [HasModSensitiveStaticCache]
  class Dict
  {
    /// <summary>
    /// 汉化词典
    /// </summary>
    static readonly Dictionary<string, string> dict = new();

    /// <summary>
    /// 已翻译文本的集合
    /// </summary>
    static readonly HashSet<string> translatedText = new();
    /// <summary>
    /// 未翻译的文本和它的上下文
    /// </summary>
    static readonly Dictionary<string, string> untranslatedText = new();

    /// <summary>
    /// 在模组初始化时加载词典
    /// </summary>
    [ModSensitiveCacheInit]
    public static void LoadDict()
    {
      foreach (ModFile file in Utils.GetFiles().Where(file => file.Extension == ".json"))
      {
        foreach (var item in JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(file.OriginalName)))
        {
          dict.Set(item.Key, item.Value);
        }
      }
    }

    /// <summary>
    /// 对字符串引用尝试翻译，对未翻译的文本记录其对应的上下文
    /// </summary>
    /// <param name="text">待翻译文本的字符串引用</param>
    /// <param name="context">上下文</param>
    public static void Translate(ref string text, string context)
    {
      if (text == null) return;

      string value = dict.GetValue(text);
      if (value != null)
      {
        translatedText.Add(value); // avoid logging translated text
        text = value;
        return;
      }

      if (!translatedText.Contains(text) && !untranslatedText.ContainsKey(text))
      {
        untranslatedText.Set(text, context);
        File.WriteAllText(Path.Join(Path.GetTempPath(), "untranslated.json"), JsonConvert.SerializeObject(untranslatedText));
      }
    }
  }
}
