using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wangjianlong.functionality.Tools.Common;

namespace Wangjianlong.functionality.Tools.Tools
{
    public class MutipleClipTool:ITang
    {
        public string Description { get { return ""; } }
        public string Error { get; set; }
        public int Count { get; set; }
        private List<string> _messages { get; set; }
        public string DataBasePath { get; set; }
        public List<string> Layers { get; set; }

        public List<string> ClipLayers { get; set; }
        public string ClipDataBasePath { get; set; }
        
        public string SaveFolder { get; set; }

        private Clip _tool { get; set; }

        public bool Init()
        {
            _messages = new List<string>();
            _tool = new Clip();
            var clipWorkspace = WorkspaceManager.OpenAccessWorkSpace(ClipDataBasePath);
            if (clipWorkspace == null)
            {
                return false;
            }
            var clipLayers = WorkspaceManager.AnalyzeLayers(clipWorkspace);
            foreach(var cliplayer in clipLayers)
            {
                if (ClipLayers.Contains(cliplayer.Name))
                {
                    if (cliplayer is IFeatureLayer)
                    {
                        var featureLayer = cliplayer as IFeatureLayer;
                        if (featureLayer != null)
                        {
                            var featureClass = featureLayer.FeatureClass;
                            if (featureClass != null)
                            {
                                var name = featureClass.AliasName;
                                var saveDataBasePath = System.IO.Path.Combine(SaveFolder, name + ".mdb");
                                if (System.IO.File.Exists(saveDataBasePath))
                                {
                                    System.IO.File.Delete(saveDataBasePath);
                                }
                                if (!ArcGISFileHelper.CreatePersonalDataBase(saveDataBasePath))
                                {
                                    continue;
                                }

                                Program(saveDataBasePath, featureClass);

                            }
                        }
                    }
                }
               
            }
            return _messages.Count == 0;
        }

        private void Program(string saveDataBasePath,IFeatureClass clipFeatureClass)
        {
            foreach (var layer in Layers)
            {
                _tool.in_features = string.Format("{0}\\{1}", DataBasePath, layer);
                _tool.clip_features = clipFeatureClass;
                _tool.out_feature_class = string.Format("{0}\\{1}", saveDataBasePath, layer);
                if (!GPHelper.Excute(_tool))
                {
                    _messages.Add(string.Format("执行{0}发生错误", _tool.out_feature_class));
                }
            }
        }

  

    }
}
