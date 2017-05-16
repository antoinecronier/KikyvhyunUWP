using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kikyvhyun.Entities.Relations
{
    public class PeopleMeeting
    {
        [ForeignKey(typeof(People))]
        public int PeopleId { get; set; }

        [ForeignKey(typeof(Meeting))]
        public int MeetingId { get; set; }
    }
}
