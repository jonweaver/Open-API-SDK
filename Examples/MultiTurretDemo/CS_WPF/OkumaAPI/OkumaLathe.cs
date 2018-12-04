using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataApi = Okuma.CLDATAPI.DataAPI;
using DataEnums = Okuma.CLDATAPI.Enumerations;

namespace CS_WPF.OkumaAPI
{
    public interface IOkumaLathe
    {
        string GetToolComment(int regNum, DataEnums.TurretEnum turret);
        void SetToolComment(int regNum, DataEnums.TurretEnum turret, string toolComment);
    }
    public class OkumaLathe : IDisposable, IOkumaLathe
    {


        private Dictionary<DataEnums.TurretEnum, DataApi.CTools> _toolObjDict;
        private DataApi.CMachine _machine;


        public OkumaLathe()
        {

            _machine = new DataApi.CMachine();
            // 'Init()' must be called exactly once on the main
            //   thread from an instance of CMachine before any
            //   API operations can take place.
            // Note that the instance of CMachine need not remain
            //   after 'Init()' is called as that part of CMachine
            //   is actually static.
            _machine.Init();

            //The _toolObjDict is a dictionary that will hold rerences to the different instances of the CTools class
            //keyed by the turret type

            _toolObjDict = new Dictionary<DataEnums.TurretEnum, DataApi.CTools>();

        }


        public string GetToolComment(int regNum, DataEnums.TurretEnum turret)
        {
            var cTools = GetToolsObj(turret);
            return cTools.GetToolComment(regNum);
        }

        public void SetToolComment(int regNum, DataEnums.TurretEnum turret, string toolComment)
        {
            var cTools = GetToolsObj(turret);
            cTools.SetToolComment(regNum, toolComment);
        }

        private DataApi.CTools GetToolsObj(DataEnums.TurretEnum turret)
        {
            //When an instance of CTools is requested check the dictionary and if has not already been instantiated
            //create it and add it to the dictionary
            if (!_toolObjDict.ContainsKey(turret))
            {
                _toolObjDict.Add(turret, new CustomCTools(turret == DataEnums.TurretEnum.A_Turret
                                                          ? DataEnums.SubSystemEnum.NC_AL
                                                          : DataEnums.SubSystemEnum.NC_BL));
            }

            return _toolObjDict[turret];
        }

        public void Dispose()
        {
            if (_machine != null)
            {
                _machine.Close();
                _toolObjDict.Clear();
            }
        }
    }
}
