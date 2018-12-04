using Okuma.CLDATAPI.DataAPI;
using Okuma.CLDATAPI.Enumerations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_WPF.OkumaAPI
{

    public class CustomCTools : CTools
    {

        public CustomCTools(SubSystemEnum subSystem) : base(subSystem)
        {
            SubSystem = subSystem;
        }

        public new void SetSubSystem(SubSystemEnum subSystem)
        {
            SubSystem = subSystem;
            base.SetSubSystem(subSystem);
        }

        public new void SetDataUnit(DataUnitEnum unit)
        {
            DataUnit = unit;
            base.SetDataUnit(unit);
        }

        public SubSystemEnum SubSystem { get; internal set; }
        public DataUnitEnum DataUnit { get; internal set; }
    }

    public class CustomCTurret :CTurret
    {
        public CustomCTurret(SubSystemEnum subSystem) : base(subSystem)
        {
            SubSystem = subSystem;
        }
        public new void SetSubSystem(SubSystemEnum subSystem)
        {
            SubSystem = subSystem;
            base.SetSubSystem(subSystem);
        }

        public new void SetDataUnit(DataUnitEnum unit)
        {
            DataUnit = unit;
            base.SetDataUnit(unit);
        }

        public SubSystemEnum SubSystem { get; internal set; }
        public DataUnitEnum DataUnit { get; internal set; }


    }
  
}
