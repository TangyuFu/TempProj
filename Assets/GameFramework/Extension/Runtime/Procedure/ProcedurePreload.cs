using GameFramework;
using GameFramework.Event;
using GameFramework.Resource;
using System.Collections.Generic;
using TempProj;
using TMPro;
using UnityEngine;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 预加载流程，进入主流程之前预先初始化必要内容。
    /// </summary>
    public class ProcedurePreload : ProcedureBase
    {
        public static readonly string[] DataTableNames = new string[]
        {
            "UIForm",
            "UIFormGroup",
            "Entity",
            "EntityGroup",
            "SoundGroup",
            "Sound",
            "UISound",
            "Music",
            "PropGroup",
            "Prop",
            "PropResource",
            "PropEquipment",
            "PropActivity",
        };

        private Dictionary<string, bool> m_LoadedFlag = new Dictionary<string, bool>();

        public override bool UseNativeDialog => true;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            Entry.Event.Subscribe(LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSuccess);
            Entry.Event.Subscribe(LoadDataTableFailureEventArgs.EventId, OnLoadDataTableFailure);
            Entry.Event.Subscribe(LoadDictionarySuccessEventArgs.EventId, OnLoadDictionarySuccess);
            Entry.Event.Subscribe(LoadDictionaryFailureEventArgs.EventId, OnLoadDictionaryFailure);

            m_LoadedFlag.Clear();

            PreloadResources();
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            Entry.Event.Unsubscribe(LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSuccess);
            Entry.Event.Unsubscribe(LoadDataTableFailureEventArgs.EventId, OnLoadDataTableFailure);
            Entry.Event.Unsubscribe(LoadDictionarySuccessEventArgs.EventId, OnLoadDictionarySuccess);
            Entry.Event.Unsubscribe(LoadDictionaryFailureEventArgs.EventId, OnLoadDictionaryFailure);

            base.OnLeave(procedureOwner, isShutdown);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            foreach (KeyValuePair<string, bool> loadedFlag in m_LoadedFlag)
            {
                if (!loadedFlag.Value)
                {
                    return;
                }
            }

            ChangeState<ProcedureMain>(procedureOwner);
        }

        private void PreloadResources()
        {
            // Preload data tables
            foreach (string dataTableName in DataTableNames)
            {
                LoadDataTable(dataTableName);
            }

            // Remove preset language
            Entry.Localization.RemoveAllRawStrings();
            
            // Preload dictionaries
            LoadDictionary("Language");

            // Preload fonts
            LoadFont("DefaultFont");
        }

        private void LoadDataTable(string dataTableName)
        {
            string dataTableAssetName = UUtility.Asset.GetTableClientDataPath(dataTableName);
            m_LoadedFlag.Add(dataTableAssetName, false);
            Entry.DataTable.LoadDataTable(dataTableName, dataTableAssetName, this);
        }

        private void LoadDictionary(string dictionaryName)
        {
            string dictionaryAssetName = UUtility.Asset.GetTableLanguagePath(dictionaryName);
            // 字体变体
            dictionaryAssetName =
                LocalizationExtension.GetVariantPath(dictionaryAssetName, Entry.Localization.Language);
            m_LoadedFlag.Add(dictionaryAssetName, false);
            Entry.Localization.ReadData(dictionaryAssetName, this);
        }

        private void LoadFont(string fontName)
        {
            m_LoadedFlag.Add(Utility.Text.Format("Font.{0}", fontName), false);
            string fontAssetName = UUtility.Asset.GetUIFontPath(fontName);
            fontAssetName = LocalizationExtension.GetVariantPath(fontAssetName, Entry.Localization.Language);
            Entry.Resource.LoadAsset(fontAssetName, Constant.AssetPriority.FontAsset,
                new LoadAssetCallbacks(
                    (assetName, asset, duration, userData) =>
                    {
                        m_LoadedFlag[Utility.Text.Format("Font.{0}", fontName)] = true;
                        UIExtension.SetFont((TMP_FontAsset) asset);
                        Log.Info("Load font '{0}' OK.", fontName);
                    },
                    (assetName, status, errorMessage, userData) =>
                    {
                        Log.Error("Can not load font '{0}' from '{1}' with error message '{2}'.", fontName, assetName,
                            errorMessage);
                    }));
        }

        private void OnLoadDataTableSuccess(object sender, GameEventArgs e)
        {
            LoadDataTableSuccessEventArgs ne = (LoadDataTableSuccessEventArgs) e;
            if (ne.UserData != this)
            {
                return;
            }

            m_LoadedFlag[ne.DataTableAssetName] = true;
            Log.Info("Load data table '{0}' OK.", ne.DataTableAssetName);
        }

        private void OnLoadDataTableFailure(object sender, GameEventArgs e)
        {
            LoadDataTableFailureEventArgs ne = (LoadDataTableFailureEventArgs) e;
            if (ne.UserData != this)
            {
                return;
            }

            Log.Error("Can not load data table '{0}' from '{1}' with error message '{2}'.", ne.DataTableAssetName,
                ne.DataTableAssetName, ne.ErrorMessage);
        }

        private void OnLoadDictionarySuccess(object sender, GameEventArgs e)
        {
            LoadDictionarySuccessEventArgs ne = (LoadDictionarySuccessEventArgs) e;
            if (ne.UserData != this)
            {
                return;
            }

            m_LoadedFlag[ne.DictionaryAssetName] = true;
            Log.Info("Load dictionary '{0}' OK.", ne.DictionaryAssetName);
        }

        private void OnLoadDictionaryFailure(object sender, GameEventArgs e)
        {
            LoadDictionaryFailureEventArgs ne = (LoadDictionaryFailureEventArgs) e;
            if (ne.UserData != this)
            {
                return;
            }

            Log.Error("Can not load dictionary '{0}' from '{1}' with error message '{2}'.", ne.DictionaryAssetName,
                ne.DictionaryAssetName, ne.ErrorMessage);
        }
    }
}