﻿using System.Collections.Generic;

namespace ConfigTools
{
    public class TableField
    {
        public static string[] TypeScript_TypeNames = {"number", "number", "string", "boolean", "number[]", "number[]", "string[]"};
        public static string[] CSharp_TypeNames = { "int", "float", "string", "bool", "List<int>", "List<float>", "List<string>" };

        public string mFieldName;
        public string mTypeName;
        public string mComment;
        public string mExportType;

        public string GetFieldTypeName(ExportCodeType pType)
        {
            TableFieldType _type = TableFieldType.TFT_Int;
            if (mTypeName == "int")
                _type = TableFieldType.TFT_Int;
            else if(mTypeName == "float")
                _type = TableFieldType.TFT_Float;
            else if (mTypeName == "string")
                _type = TableFieldType.TFT_String;
            else if (mTypeName == "bool")
                _type = TableFieldType.TFT_Bool;
            else if (mTypeName == "int+")
                _type = TableFieldType.TFT_IntList;
            else if (mTypeName == "float+")
                _type = TableFieldType.TFT_FloatList;
            else if (mTypeName == "string+")
                _type = TableFieldType.TFT_StringList;


            if (pType == ExportCodeType.CSharp)
                return CSharp_TypeNames[(int)_type];
            if (pType == ExportCodeType.TypeScript)
                return TypeScript_TypeNames[(int)_type];

            return null;
        }

        public bool IsExportField(ExportCfgType pExpType)
        {
            if (mExportType == "all")
                return true;

            if (pExpType == ExportCfgType.Client && mExportType == "client")
                return true;

            if (pExpType == ExportCfgType.Server && mExportType == "server")
                return true;

            return false;
        }
    }

    public class TableMeta
    {
        public string TableName;

        public string ClassName => "Cfg" + TableName;

        public List<TableField> Fields = new List<TableField>(8);

        public bool CheckTypeIsMap()
        {
            return Fields[0].mFieldName.ToUpper() == "ID";
        }
    }
}