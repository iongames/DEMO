//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DEMO.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Activities
    {
        public int ActivityID { get; set; }
        public int EventID { get; set; }
        public System.DateTime StartDate { get; set; }
        public int DaysCount { get; set; }
        public string ActivityName { get; set; }
        public int Day { get; set; }
        public string StartTime { get; set; }
        public int ModeratorID { get; set; }
        public Nullable<int> JuryID1 { get; set; }
        public Nullable<int> JuryID2 { get; set; }
        public Nullable<int> JuryID3 { get; set; }
        public Nullable<int> JuryID4 { get; set; }
        public Nullable<int> JuryID5 { get; set; }
        public Nullable<int> WinnerID { get; set; }
    
        public virtual Events Events { get; set; }
        public virtual Jury Jury { get; set; }
        public virtual Jury Jury1 { get; set; }
        public virtual Jury Jury2 { get; set; }
        public virtual Jury Jury3 { get; set; }
        public virtual Jury Jury4 { get; set; }
        public virtual Moderators Moderators { get; set; }
        public virtual Participants Participants { get; set; }
    }
}