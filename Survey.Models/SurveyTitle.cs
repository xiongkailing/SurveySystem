using Survey.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Models
{
    public class SurveyTitle : MongoBaseModel
    {
        /// <summary>
        /// 问卷名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 创建时间   
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 截至时间   
        /// </summary>
        public DateTime DeadLine { get; set; }
        /// <summary>
        /// 适合人群描述
        /// </summary>
        public string Fitter { get; set; }
        /// <summary>
        /// 推送用户Ids
        /// </summary>
        public IEnumerable<int> UserIds { get; set; }
    }
}
