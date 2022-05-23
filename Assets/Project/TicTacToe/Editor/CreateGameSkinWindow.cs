using UnityEditor;
using UnityEngine;

namespace Project.TicTacToe.Editor
{
    public class CreateGameSkinWindow : EditorWindow
    {
        private string bundleName = "";
        private Sprite xSymbol;
        private Sprite oSymbol;
        private Sprite background;
        
        [MenuItem("Window/TicTacToe/Create Game Skin")]
        public static void Open()
        {
            GetWindow<CreateGameSkinWindow>("Create Game Skin");
        }

        private void OnGUI()
        {
            GUILayout.Label("Bundle Name", EditorStyles.boldLabel);
            bundleName = EditorGUILayout.TextField("Bundle Name", bundleName);
            xSymbol = CreateSpritePicker("X Symbol", xSymbol);
            oSymbol = CreateSpritePicker("Y Symbol", oSymbol);
            background = CreateSpritePicker("Background", background);
            if (GUILayout.Button("Create"))
            {
                BuildBundle(bundleName, xSymbol, oSymbol, background);
            }
        }

        private void BuildBundle(string name, Sprite xSprite, Sprite oSprite, Sprite backgroundSprite)
        {
            AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(xSprite)).SetAssetBundleNameAndVariant(name, "xSprite");
            AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(oSprite)).SetAssetBundleNameAndVariant(name, "oSprite");
            AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(backgroundSprite)).SetAssetBundleNameAndVariant(name, "backgroundSprite");
            // BuildPipeline ??
        }

        private Sprite CreateSpritePicker(string labelText, Sprite currentValue)
        {
            return (Sprite) EditorGUILayout.ObjectField(labelText, currentValue, typeof(Sprite), false);
        }
    }
}