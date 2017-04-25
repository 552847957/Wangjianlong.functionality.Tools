using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wangjianlong.functionality.Tools.Models;

namespace Wangjianlong.functionality.Tools.Common
{
    public static class FeatureClassManager
    {
        /// <summary>
        /// 作用：创建要素类
        /// 作者：汪建龙
        /// 编写时间：2016年12月27日10:50:16
        /// </summary>
        /// <param name="saveFilePath"></param>
        /// <param name="spatialReference"></param>
        /// <param name="esriGeometryType"></param>
        /// <returns></returns>
        public static IFeatureClass CreateFeatrueClass(string saveFilePath, ISpatialReference spatialReference, esriGeometryType esriGeometryType)
        {
            IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();
            var directory = System.IO.Path.GetDirectoryName(saveFilePath);
            var parent = System.IO.Path.GetDirectoryName(directory);
            var fileName = System.IO.Path.GetFileName(directory);
            IWorkspaceName workspaceName = workspaceFactory.Create(parent,fileName , null, 0);

            IName name = workspaceName as IName;
            IWorkspace workspace = name.Open() as IWorkspace;
            IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;
            IFields fields = new FieldsClass();
            IFieldsEdit fieldsEdit = fields as IFieldsEdit;
            IFieldEdit fieldEdit = new FieldClass();
            fieldEdit.Name_2 = "OID";
            fieldEdit.AliasName_2 = "序号";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeOID;
            fieldsEdit.AddField(fieldEdit as IField);

            fieldEdit = new FieldClass();
            fieldEdit.Name_2 = "TCMC";
            fieldEdit.AliasName_2 = "图层名称";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
            fieldsEdit.AddField(fieldEdit as IField);

            IGeometryDefEdit geometryDefEdit = new GeometryDefClass();
            geometryDefEdit.SpatialReference_2 = spatialReference;
            geometryDefEdit.GeometryType_2 = esriGeometryType;

            fieldEdit = new FieldClass();
            fieldEdit.Name_2 = "Shape";
            fieldEdit.AliasName_2 = "形状";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
            fieldEdit.GeometryDef_2 = geometryDefEdit;
            fieldsEdit.AddField(fieldEdit as IField);
            return featureWorkspace.CreateFeatureClass(System.IO.Path.GetFileNameWithoutExtension(saveFilePath), fields, null, null, esriFeatureType.esriFTSimple, "shape", "");

        }

        public static List<TangField> GainFieldInformation(this IFeatureClass featureClass)
        {
            var list = new List<TangField>();
            var fields = featureClass.Fields;
            for(var i = 0; i < fields.FieldCount; i++)
            {
                var field = fields.get_Field(i);
                if (field.Name.ToUpper().Contains("SHAPE") || field.Name.ToUpper() == "FID")
                {
                    continue;
                }
                list.Add(new TangField() { Name = field.Name, Alias = field.AliasName, Type = field.Type, Index = i });
            }
            return list;
        }

        public static void AddField(this IFeatureClass featureClass,IField addField)
        {
            IClass pClass = featureClass as IClass;
            IFieldsEdit fieldsEdit = featureClass.Fields as IFieldsEdit;
            //IField field = new FieldClass();
            //IFieldEdit2 fieldEdit = field as IFieldEdit2;
            //fieldEdit.Type_2 = addField.Type;
            //fieldEdit.Name_2 = addField.Name;
            //fieldEdit.AliasName_2 = addField.AliasName;
            pClass.AddField(addField);
        }

        /// <summary>
        /// 作用：获取要素类中某个字段的唯一值
        /// 作者：汪建龙
        /// 编写时间：2016年11月22日13:08:16
        /// </summary>
        /// <param name="featureClass"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static List<string> GetUniqueValue(this IFeatureClass featureClass,string fieldName)
        {
            var list = new List<string>();
            //var dataset = featureClass as IDataset;
            //var queryDef = (dataset.Workspace as IFeatureWorkspace).CreateQueryDef();
            //queryDef.Tables = dataset.Name;
            //queryDef.SubFields = "DISTINCT (" + fieldName.ToUpper() + ")";
            //ICursor cursor = queryDef.Evaluate();
            //var fields = featureClass.Fields;
            //var field = fields.get_Field(fields.FindField(fieldName));
            //var row = cursor.NextRow();
            //while (row != null)
            //{
            //    var val = row.get_Value(0).ToString();
            //    if (field.Type == esriFieldType.esriFieldTypeString)
            //    {
            //        list.Add(string.Format("'{0}'", val));
            //    }
            //    else
            //    {
            //        list.Add(val);
            //    }

            //    row = cursor.NextRow();
            //}
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(cursor);
            int index = featureClass.Fields.FindField(fieldName);
            if (index > -1)
            {
                var featureCursor = featureClass.Search(null, false);
                var feature = featureCursor.NextFeature();
                while (feature != null)
                {
                    var val = feature.get_Value(index).ToString();
                    if (!list.Contains(val))
                    {
                        list.Add(val);
                    }
                    feature = featureCursor.NextFeature();
                }
                System.Runtime.InteropServices.Marshal.ReleaseComObject(featureCursor);
            }
            return list;
        }

        /// <summary>
        /// 作用：向要素类中批量增加字段
        /// 作者：汪建龙
        /// 编写时间：2016年12月27日10:49:45
        /// </summary>
        /// <param name="featureClass"></param>
        /// <param name="list"></param>
        public static void AddFields(this IFeatureClass featureClass,List<TangField> list)
        {
            if (featureClass == null||list==null||list.Count==0)
            {
                return;
            }

            try
            {
                foreach (var item in list)
                {
                    IField field = new FieldClass();
                    IFieldEdit2 fieldEdit = field as IFieldEdit2;
                    fieldEdit.Type_2 = item.Type;
                    fieldEdit.Name_2 = item.Name;
                    fieldEdit.AliasName_2 = item.Alias;
                    AddField(featureClass, field);
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex);
            }
        
        }
    }
}
