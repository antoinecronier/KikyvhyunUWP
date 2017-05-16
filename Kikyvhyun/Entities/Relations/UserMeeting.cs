using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kikyvhyun.Entities.Relations
{
    public class UserMeeting
    {
        [ForeignKey(typeof(User))]
        public int UserId { get; set; }

        [ForeignKey(typeof(Meeting))]
        public int MeetingId { get; set; }
    }
}
