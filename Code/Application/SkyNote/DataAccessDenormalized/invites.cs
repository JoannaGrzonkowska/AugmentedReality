//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessDenormalized
{
    using System;
    using System.Collections.Generic;
    
    public partial class invites
    {
        public int Id { get; set; }
        public string State { get; set; }
        public Nullable<int> GroupId { get; set; }
        public string GroupName { get; set; }
        public Nullable<int> UserId { get; set; }
        public string UserName { get; set; }
        public string UserLogin { get; set; }
        public string UserMail { get; set; }
        public Nullable<int> FriendId { get; set; }
        public string FriendName { get; set; }
        public string FriendLogin { get; set; }
        public string FriendMail { get; set; }
    }
}