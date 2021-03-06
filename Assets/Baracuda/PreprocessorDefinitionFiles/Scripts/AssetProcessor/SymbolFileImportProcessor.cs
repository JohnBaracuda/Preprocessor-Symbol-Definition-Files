namespace Baracuda.PreprocessorDefinitionFiles.Scripts.AssetProcessor
{
    /// <summary>
    /// AssetPostprocessor responsible to apply and update Preprocessor Defines when an asset has been imported.
    /// </summary>
    internal class SymbolFileImportProcessor : UnityEditor.AssetPostprocessor
    {
#if !PPSDF
        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            UnityEditor.AssetDatabase.importPackageCompleted -= OnPackageImportCompleted;
            UnityEditor.AssetDatabase.importPackageCompleted += OnPackageImportCompleted;
        }
        
        private static void OnPackageImportCompleted(string name)
        {
            Initialize();
        }
        
        [UnityEditor.InitializeOnLoadMethod]
        private static void Initialize()
        {
            Baracuda.PreprocessorDefinitionFiles.Scripts.PreprocessorSymbolDefinitionSettings.FindAllPreprocessorSymbolDefinitionFiles();            
            Baracuda.PreprocessorDefinitionFiles.Scripts.Utilities.PreprocessorDefineUtilities.ApplyAndUpdateAllDefinitionFiles();
        }
#endif
    }
}
