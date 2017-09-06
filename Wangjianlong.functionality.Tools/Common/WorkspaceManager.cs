using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wangjianlong.functionality.Tools.Common
{
    public static class WorkspaceManager
    {

        public static IFeatureClass GetFeatureClass(this IWorkspace workspcae, string featureClassName)
        {
            if (workspcae == null)
            {
                Console.WriteLine("workspace为null,无法获取要素类.........");
                return null;
            }
            IFeatureWorkspace featureWorkspace = workspcae as IFeatureWorkspace;
            IFeatureClass featureClass = null;
            try
            {
                featureClass = featureWorkspace.OpenFeatureClass(featureClassName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("获取要素类：{0}发成错误，错误信息:{1}", featureClassName, ex.Message));
                return null;
            }
            return featureClass;
        }
        /// <summary>
        /// 作用：打开CAD文件Workspace
        /// 作者：汪建龙
        /// 编写时间：2016年11月22日12:54:02
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public static IWorkspace OpenCADWorkSpace(string directory)
        {
            IWorkspaceFactory workspaceFactory = new CadWorkspaceFactory();
            IWorkspace workspace = workspaceFactory.OpenFromFile(directory, 0);
            return workspace;
        }
        /// <summary>
        /// 作用：获取CAD文件单独某一个类型的要素类
        /// 作者：汪建龙
        /// 编写时间：2016年11月22日12:57:12
        /// </summary>
        /// <param name="workspace"></param>
        /// <param name="fileName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IFeatureClass GetCADFeatureClass(this IWorkspace workspace,string fileName,string type)
        {
            IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;
            if (featureWorkspace != null)
            {
                IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(string.Format("{0}:{1}", fileName, type));
                return featureClass;
            }
            return null;
        }

        public static IWorkspace OpenAccessWorkSpace(string accessFilePath)
        {
            IWorkspaceFactory workspaceFactory = new AccessWorkspaceFactory();
            IWorkspace workspace = workspaceFactory.OpenFromFile(accessFilePath, 0);
            return workspace;
        }

        public static List<ILayer> AnalyzeLayers(IWorkspace workspace)
        {
            var list = new List<ILayer>();
            IEnumDataset enumDataset = workspace.get_Datasets(esriDatasetType.esriDTAny);
            enumDataset.Reset();
            IDataset dataset = enumDataset.Next();
            while (dataset != null)
            {
                if(dataset is IFeatureDataset)
                {
                    IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;
                    IFeatureDataset featureDataset = featureWorkspace.OpenFeatureDataset(dataset.Name);
                    IEnumDataset enumdataset1 = featureDataset.Subsets;
                    enumdataset1.Reset();
                    IGroupLayer groupLayer = new GroupLayerClass();
                    groupLayer.Name = featureDataset.Name;
                    IDataset dataset1 = enumdataset1.Next();
                    while (dataset1 != null)
                    {
                        if(dataset1 is IFeatureClass)
                        {
                            IFeatureLayer featureLayer = new FeatureLayerClass();
                            featureLayer.FeatureClass = featureWorkspace.OpenFeatureClass(dataset1.Name);
                            if (featureLayer.FeatureClass != null)
                            {
                                featureLayer.Name = featureLayer.FeatureClass.AliasName;
                                list.Add(featureLayer);
                                groupLayer.Add(featureLayer);
                            }
                        }
                        dataset1 = enumdataset1.Next();
                    }
                    //list.Add(groupLayer);

                }else if(dataset is IFeatureClass)
                {
                    IFeatureWorkspace featureworkSpace = workspace as IFeatureWorkspace;
                    IFeatureLayer featurelayer = new FeatureLayerClass();
                    featurelayer.FeatureClass = featureworkSpace.OpenFeatureClass(dataset.Name);
                    featurelayer.Name = featurelayer.FeatureClass.AliasName;
                    list.Add(featurelayer);
                }else if(dataset is IRasterDataset)
                {
                    IRasterWorkspaceEx rasterWorkspace = workspace as IRasterWorkspaceEx;
                    IRasterDataset rasterDataset = rasterWorkspace.OpenRasterDataset(dataset.Name);
                    IRasterPyramid3 rasterPyramid = rasterDataset as IRasterPyramid3;
                    if (rasterPyramid != null)
                    {
                        if (!(rasterPyramid.Present))
                        {
                            rasterPyramid.Create();
                        }
                    }

                    IRasterLayer rasterLayer = new RasterLayerClass();
                    rasterLayer.CreateFromDataset(rasterDataset);
                    ILayer layer = rasterLayer as ILayer;
                    list.Add(layer);

                }

                dataset = enumDataset.Next();
            }

            return list;

        }
    }
}
