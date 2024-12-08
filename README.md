# 卡德洞窟（Caves of Qud）汉化

## 安装

将 `ChineseTranslation` 目录复制到 Mods 路径并启用，未来发布到 Steam 创意工坊可直接安装

## 开发

1. 进入模组工具箱（Modding Toolkit）点击 "Write Mods.csproj File" 选项
2. 将生成的 `Mods.csproj` 加入项目根目录
3. 编辑 `Mods.csproj` 在 `Project` -> `ItemGroup` 中加入 `<Reference Include="$(QudLibPath)/Unity.TextMeshPro.dll" />`
4. 使用 Visual Studio Code 打开项目进行开发

## 文件描述

* `manifest.json`：模组信息
* `font.ab`：中文字体的 AssetBundle
* `*.json` 文件：词典文件，按序号加载并合并，对于同一文本后加载的翻译会覆盖之前的翻译
* `*.cs` 文件：模组代码，由游戏编译和执行
