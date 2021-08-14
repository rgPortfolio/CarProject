using System;

namespace API.Entities
{
    public class Detail
    {
        public Guid Id {get; set;} 
        public Guid? InteriorDetailId {get; set;} 
        public Guid? ExteriorDetailId {get; set;} 
        public Guid? EngineDetailId {get; set;} 
        public Guid? SafetyDetailId {get; set;} 

        public virtual InteriorDetail? InteriorDetail {get; set;}
        public virtual ExteriorDetail? ExteriorDetail {get; set;}
        public virtual EngineDetail? EngineDetail {get; set;}
        public virtual SafetyDetail? SafetyDetail {get; set;}

    }
}