using UnityEditor;
using UnityEngine;

namespace io.github.kiriumestand.ksassetscloner.editor
{
    [InitializeOnLoad]
    public static class MigrationNotifier
    {
        private const string OldPackageName = "com.github.kiriumestand.ksassetscloner";
        private const string OldPackageDisplayName = "KS Assets Cloner";
        private const string NewPackageName = "com.github.k-stand.ksassetscloner";
        private const string NewPackageDisplayName = "KS Assets Cloner";

        static MigrationNotifier()
        {
            // 新パッケージがまだ入っていない場合だけ警告
            if (!IsNewPackageInstalled())
            {
                EditorApplication.delayCall += ShowMigrationDialog;
            }
        }

        private static bool IsNewPackageInstalled()
        {
            // Packages/{NewPackageName} が存在するか確認
            return System.IO.Directory.Exists(
                $"Packages/{NewPackageName}");
        }

        private static void ShowMigrationDialog()
        {
            bool result = EditorUtility.DisplayDialog(
                "新パッケージ移行のお知らせ",
                $"「{OldPackageDisplayName}({OldPackageName})」は新しい「{NewPackageDisplayName}({NewPackageName})」に移行しました。\n" +
                "VCCから新パッケージをインストールしてください。",
                "VCCを開く", "後で");

            if (result)
            {
                // VCCのディープリンクで直接パッケージページを開くことも可能
                Application.OpenURL("vcc://vpm/addRepo?url=https://k-stand.github.io/vpm-repos/index.json");
            }
        }
    }
}